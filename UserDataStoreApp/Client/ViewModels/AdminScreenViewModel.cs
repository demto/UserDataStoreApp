using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataStoreApp.BusinessLogic.Domain;
using UserDataStoreApp.BusinessLogic.Dtos;
using UserDataStoreApp.BusinessLogic.ServiceLogic.Services;
using UserDataStoreApp.DataAccess;

namespace UserDataStoreApp.Client.ViewModels
{
    public class AdminScreenViewModel
    {
        UserServices userServices = new UserServices();
        ProductServices productServices = new ProductServices();

#region Properties
        public User MyProperty { get; set; }

        public IList<User> AllUsers{
            get{
                return userServices.GetAllUsersFromDb();
            }
        }

        public IList<Product> AllProducts{
            get{
                return productServices.GetAllProducts();
            }
        }
#endregion

#region User Methods
        public User GetUser(string name){
            if(string.IsNullOrWhiteSpace(name)){
                throw new NullReferenceException("Must provide a name to get a user!");
            }

            return userServices.GetUser(name);
        }

        public bool UpdateUserName(int uId, string newName){
            if(string.IsNullOrWhiteSpace(newName)){
                return false;
            }
            userServices.UpdateUserName(uId, newName);
            return true;
        }

        public bool SaveUser(User newUser){
            if(newUser == null){
                return false;
            }

            if (userServices.SaveUser(newUser))
            {
                return true;
            };

            return false;
        }

        public bool DeleteUser(int id){
            if(userServices.DeleteUser(id)){
                return true;
            }
            return false;
        }
#endregion

#region Product Methods
        public Product GetProduct(string name){
            return productServices.GetProduct(name);
        }

        public bool TryUpdateProduct(string productName, string newProductName, double newPrice, bool isSaleProduct){
            var updates = new ProductUpdateDto
            {
                ProductName = newProductName,
                ProductPrice = newPrice,
                IsSalesProduct = isSaleProduct
            };

            if (productServices.UpdateProduct(productName, updates))
            {
                return true;
            }

            return false;
        }

        private bool UpdateProduct(string productName, ProductUpdateDto updates){
            if(productServices.UpdateProduct(productName, updates)){
                return true;
            }

            return false;
        }

        public bool AddNewProduct(Product newProduct){
            if(productServices.AddNewProduct(newProduct)){
                return true;
            }

            return false;
        }

        public bool DeleteProduct(int productId){
            if (productServices.DeleteProduct(productId)){
                return true;
            }

            return false;
        }
#endregion
    }
}
