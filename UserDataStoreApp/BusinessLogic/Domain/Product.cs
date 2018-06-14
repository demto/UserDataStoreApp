using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDataStoreApp.BusinessLogic.Domain
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public bool IsSalesProduct { get; set; }
        public User Owner { get; set; }
        public int? OwnerId { get; set; }
    }
}
