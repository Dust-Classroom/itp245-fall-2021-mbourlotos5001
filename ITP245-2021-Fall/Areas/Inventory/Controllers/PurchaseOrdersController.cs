using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITP245_Model;

namespace ITP245_2021_Fall.Areas.Inventory.Controllers
{
    public class PurchaseOrdersController : Controller
    {
        private InventoryEntities db = new InventoryEntities();

        // GET: Inventory/PurchaseOrders
        public ActionResult Index()
        {
            var purchaseOrders = db.PurchaseOrders.Include(p => p.Vendor);
            return View(purchaseOrders.ToList());
        }

        // GET: Inventory/PurchaseOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrder);
        }

        // GET: Inventory/PurchaseOrders/Create
        public ActionResult Create()
        {
            ViewBag.VendorId = new SelectList(db.Vendors, "VendorId", "Name");
            
            return View();
        }

        // POST: Inventory/PurchaseOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VendorId,PoDate,Amount")] PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseOrders.Add(purchaseOrder);
                db.SaveChanges();
                return RedirectToAction("PoItem/" + purchaseOrder.PurchaseOrderNumber);
                //return View(purchaseOrder);
            }

            ViewBag.VendorId = new SelectList(db.Vendors, "VendorId", "Name", purchaseOrder.VendorId);
            

            return View(purchaseOrder);
        }

        // GET: Inventory/PurchaseOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.VendorId = new SelectList(db.Vendors, "VendorId", "Name", purchaseOrder.VendorId);
            return View(purchaseOrder);
        }

        // POST: Inventory/PurchaseOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseOrderNumber,VendorId,PoDate,Amount")] PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VendorId = new SelectList(db.Vendors, "VendorId", "Name", purchaseOrder.VendorId);
            return View(purchaseOrder);
        }

        // GET: Inventory/PurchaseOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }

            return View(purchaseOrder);
        }

        // POST: Inventory/PurchaseOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            db.PurchaseOrders.Remove(purchaseOrder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
      public ActionResult ChangePrice(string parm)
        {
            decimal newPrice = 0;
            var parms = parm.Split('|');
            if (parms.Length > 2)
            {
                int purchaseOrderNumber = Convert.ToInt32(parms[0]);
                int itemId = Convert.ToInt32(parms[1]);
                newPrice = Convert.ToDecimal(parms[2]);
                
                var item = db.PoItems
                    .FirstOrDefault(i =>
                        i.PurchaseOrderNumber.Equals(purchaseOrderNumber)
                        && i.ItemId.Equals(itemId));
                if (item == null)
                {
                    db.PoItems.Add(new PoItem()
                    {
                        PurchaseOrder = db.PurchaseOrders.Find(purchaseOrderNumber),
                        Item = db.Items.Find(itemId),
                        Price = newPrice,
                        Quantity = 1
                    });
                }else
                {
                    item.Price = newPrice;
                }
                
                
                db.SaveChanges();
            }

                return View();
        }

        public ActionResult ChangeQuantity(string parm)
        {
            
            decimal total = 0;
            var parms = parm.Split('|');
            int purchaseOrderNumber = Convert.ToInt32(parms[0]);
            if (parms.Length > 2)
            {
                int itemId = Convert.ToInt32(parms[1]);
                int quantity = Convert.ToInt32(parms[2]);
                var item = db.PoItems
                    .FirstOrDefault(i =>
                        i.PurchaseOrderNumber.Equals(purchaseOrderNumber)
                        && i.ItemId.Equals(itemId));
                if (item != null)
                {
                    if (quantity <= 0)
                    {
                        db.PoItems.Remove(item);
                    } else
                    {
                        item.Quantity = quantity;
                    }
                }
                else
                {
                    if (quantity > 0)
                    {
                        db.PoItems.Add(new PoItem()
                        {
                            PurchaseOrder = db.PurchaseOrders.Find(purchaseOrderNumber),
                            Item = db.Items.Find(itemId),
                            Quantity = quantity
                            
                        });
                    }
                }
                db.SaveChanges();
               
            }
            foreach (var x in db.PoItems.Where(r => r.PurchaseOrderNumber.Equals(purchaseOrderNumber)))
            {
                total = (x.Price * x.Quantity) + total;
            }

            return View(total);
        }

        public ActionResult LoadTotal(int purchaseOrderNumber)
        {
            decimal total = 0;
            foreach (var x in db.PoItems.Where(r => r.PurchaseOrderNumber.Equals(purchaseOrderNumber)))
            {
                total = (x.Price * x.Quantity) + total;
            }
            return View(total);
        }

        public ActionResult PoItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            ITP245_Model.PoItem.Fill(purchaseOrder);
            return View(purchaseOrder);
        }

      













        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
