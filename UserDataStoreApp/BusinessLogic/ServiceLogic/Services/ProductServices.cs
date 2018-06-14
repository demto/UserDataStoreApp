using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataStoreApp.BusinessLogic.Domain;
using UserDataStoreApp.DataAccess;

namespace UserDataStoreApp.BusinessLogic.ServiceLogic.Services
{
    public class ProductServices
    {

        public bool DoesProductExist(string productName){
            using(var context = new UserDataContext()){
                var product = context.Products.SingleOrDefault(p => p.ProductName == productName);
                if(product == null){
                    return false;
                }
                return true;
            }
        }

        public bool AddNewProduct(Product product){
            using(var context = new UserDataContext()){

                if(context.Products.Contains(product) || product == null){
                    return false;
                }
                context.Products.Add(product);
                context.SaveChanges();
                return true;
            }
        }

        public bool UpdateProduct(Product product){
            using (var context = new UserDataContext())
            {

                if (!context.Products.Contains(product) || product == null)
                {
                    return false;
                }
                var existingProduct = context.Products
                    .SingleOrDefault(p => p.ProductName == product.ProductName);

                existingProduct.ProductName = product.ProductName;
                existingProduct.ProductPrice = product.ProductPrice;
                existingProduct.IsSalesProduct = product.IsSalesProduct;

                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteProduct(int productId){
            using (var context = new UserDataContext())
            {
                var product = context.Products.Find(productId);

                if (product == null)
                {
                    return false;
                }

                context.Products.Remove(product);
                context.SaveChanges();
                return true;
            }
        }

        public List<Product> GetAllProducts(){
            using(var context = new UserDataContext()){
                return context.Products.ToList();
            }
        }
    }
}
