using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataStoreApp.BusinessLogic.Domain;
using UserDataStoreApp.DataAccess;

namespace UserDataStoreApp.BusinessLogic.ServiceLogic.Services
{
    public class ShoppingServices{ 

        public bool PurchaseProduct(User user, Product product){

        ProductServices productServices = new ProductServices();
        using (var context = new UserDataContext())
            {
                if (user == null || product == null)
                {
                    return false;
                }
                try
                {
                    var productFromDb = productServices.GetProduct(product.ProductName);
                    var userId = user.UserId;

                    productServices.PurchaseProduct(userId, product.ProductId);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}
