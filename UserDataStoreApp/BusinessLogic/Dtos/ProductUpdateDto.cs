using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDataStoreApp.BusinessLogic.Dtos
{
    public class ProductUpdateDto
    {
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public bool IsSalesProduct { get; set; }
    }
}
