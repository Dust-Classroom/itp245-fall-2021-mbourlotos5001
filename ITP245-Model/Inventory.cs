using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ITP245_Model
{
    public interface IEmail
    {
        string VendorEmail { get; }
        string VendorContact { get; }
    }



    [MetadataType(typeof(ItemMetaData))]
    public partial class Item
    {
        public string Price => $"{RetailPrice:C}";
        public string Cost => $"{StandardCost:C}";
        private sealed class ItemMetaData
        {
            [Display(Name = "Item")]
            public string ItemId { get; set; }
            [Display(Name = "Title")]
            public string Name { get; set; }
            [Display(Name = "Category")]
            public string CategoryId { get; set; }

            [Display(Name = "Quantity On Hand")]
            public string QuantityOnHand { get; set; }
            [Display(Name = "Retail Price")]
            public string RetailPrice { get; set; }

            [Display(Name = "Standard Cost")]
            public string StandardCost { get; set; }



        }
    }
    [MetadataType(typeof(CategoryMetaData))]
    public partial class Category
    {
        private sealed class CategoryMetaData
        {
            [Display(Name = "Category")]
            public string Name { get; set; }

            [Display(Name = "Category")]
            public string CategoryId { get; set; }
            




        }
    }
    [MetadataType(typeof(VendorMetaData))]
    public partial class Vendor : IEmail
    {
        public string VendorEmail => Email;
        public string VendorContact => Contact;
        private sealed class VendorMetaData
        {
            [Display(Name = "Vendor")]
            public string Name { get; set; }

            [Display(Name = "Zip Code")]
            public string ZipCode { get; set; }

            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Address 1")]
            public string Address1 { get; set; }

            [Display(Name = "Address 2")]
            public string Address2 { get; set; }

            [Display(Name = "Purchase Orders")]
            public string PurchaseOrders { get; set; }


        }
    }
    [MetadataType(typeof(PurchaseOrderMetaData))]
    public partial class PurchaseOrder
    {

        public string DateDay => PoDate.ToString("d");
        public string Val => $"{Amount:C}";
        private sealed class PurchaseOrderMetaData
        {
            [Display(Name = "Purchase Order Items" )]
            public string PoItems { get; set; }

            [Display(Name = "Vendor")]
            public string VendorId { get; set; }

            [Display(Name = "Purchase Order Date")]
            public string PoDate { get; set; }
            

            [Display(Name = "Purchase Order #")]
            public string PurchaseOrderNumber { get; set; }

            


        }
    }
    [MetadataType(typeof(SpoilageMetaData))]
    public partial class Spoilage
    {
        public string DateDay => SpoilageDate.ToString("d");
        public string Val => $"{Value:C}";
        private sealed class SpoilageMetaData
        {
            [Display(Name = "Title")]
            public string ItemId { get; set; }

            [Display(Name = "Reason Type")]
            public string ReasonType { get; set; }

            [Display(Name = "Spoilage Date")]
            public string SpoilageDate { get; set; }

        }
    }
    [MetadataType(typeof(PoItemMetaData))]
    public partial class PoItem
    {

        public bool InPurchaseOrder { get; set; }
        public static  List<PoItem> Fill(PurchaseOrder purchaseOrder)
        {
            var poItems = purchaseOrder.PoItems.ToList();
            foreach (var item in poItems)
            {
                if (item.Quantity > 0)
                {
                    item.InPurchaseOrder = true;
                }
            }
                
                
            var itemIds = poItems.Select(i => i.ItemId).ToArray();
            using (var db = new InventoryEntities())
            {
                var notIn = db.Items.Where(i => !itemIds.Contains(i.ItemId)).ToList();
                foreach (var item in notIn)
                {
                    purchaseOrder.PoItems.Add(new PoItem()
                    {
                        PurchaseOrderNumber = purchaseOrder.PurchaseOrderNumber,
                        PurchaseOrder = purchaseOrder,
                        ItemId = item.ItemId,
                        Item = item,
                        InPurchaseOrder = false,

                     
                    }); 
   
                }
            }
            return poItems;
        }


        private sealed class PoItemMetaData
        {

        }
    }

}
