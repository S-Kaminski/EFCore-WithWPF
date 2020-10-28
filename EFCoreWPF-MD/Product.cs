using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreWPF_MD
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
