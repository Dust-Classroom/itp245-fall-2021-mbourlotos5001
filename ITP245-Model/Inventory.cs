using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ITP245_Model
{
    [MetadataType(typeof(ItemMetaData))]
  public partial class Item
    {
        private sealed class ItemMetaData
        {
         
            [Display(Name = "Item Title")]
            public string Name { get; set; }

       



        }
    }
    [MetadataType(typeof(CategoryMetaData))]
    public partial class Category
    {
        private sealed class CategoryMetaData
        {
            [Display(Name = "Format")]
            public string Name { get; set; }

        



        }
    }
    [MetadataType(typeof(VendorMetaData))]
    public partial class Vendor
    {
        private sealed class VendorMetaData
        {
            [Display(Name = "Vendor")]
            public string Name { get; set; }


        }
    }

}
