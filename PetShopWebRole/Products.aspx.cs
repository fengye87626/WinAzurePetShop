using System;
using PetShop.AppCode;


namespace PetShopWebRole {
    
    public partial class Products : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            //get page header and title
            Page.Title = WebUtility.GetCategoryName(Request.QueryString["categoryId"]);
        }
    }
}