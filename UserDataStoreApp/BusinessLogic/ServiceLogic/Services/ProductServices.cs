using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataStoreApp.BusinessLogic.Domain;
using UserDataStoreApp.BusinessLogic.Dtos;
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

        public bool AddNewProduct(Product product)
{
            using(var context = new UserDataContext()){

                if(DoesProductExist(product.ProductName) || product == null){
                    return false;
                }

                context.Products.Add(product);
                context.SaveChanges();
                return true;
            }
        }

        public bool UpdateProduct(string existingProductName, ProductUpdateDto productUpdate){
            using (var context = new UserDataContext())
            {
                var existingProduct = context.Products.SingleOrDefault(p => p.ProductName == existingProductName);
                if (productUpdate == null || existingProduct == null)
                {
                    return false;
                }

                existingProduct.ProductName = productUpdate.ProductName;
                existingProduct.ProductPrice = productUpdate.ProductPrice;
                existingProduct.IsSalesProduct = productUpdate.IsSalesProduct;

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
                return context.Products.Include(p => p.Owner).ToList();
            }
        }

        public Product GetProduct(string name){
            using (var context = new UserDataContext()){
                var product = context.Products.SingleOrDefault(p => p.ProductName == name);
                if(product != null){
                    return product;
                }
                return null;
            }
        }

        public void PurchaseProduct(int userId, int productId){
            using(var context = new UserDataContext()){
                var product = context.Products.Find(productId);
                product.OwnerId = userId;
                product.IsPurchased = true;
                context.SaveChanges();
            }
        }

    }
}
