﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public Category(int catID, string catname)
        {
            this.CategoryId = catID;
            this.CategoryName = catname;
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
