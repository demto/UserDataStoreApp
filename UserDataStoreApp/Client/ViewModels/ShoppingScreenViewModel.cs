using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataStoreApp.BusinessLogic.Domain;
using UserDataStoreApp.BusinessLogic.ServiceLogic.Services;

namespace UserDataStoreApp.Client.ViewModels
{
    public class ShoppingScreenViewModel
    {
        ProductServices productServices = new ProductServices();
        ShoppingServices shoppingServices = new ShoppingServices();

#region Properties

        public IList<Product> AllProdcuts { 
            get {
                return productServices.GetAllProducts();
            } 
        }
#endregion

#region Methods
        public bool PurchaseProduct(User user, Product selectedProduct){
            if(shoppingServices.PurchaseProduct(user, selectedProduct)){
                return true;
            }

            return false;
        }

#endregion
    }
}
