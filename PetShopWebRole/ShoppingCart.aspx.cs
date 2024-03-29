using System;
using System.Web;
using PetShop.AppCode;

public partial class ShoppingCart : System.Web.UI.Page {

    private CustomProfile Profile = new CustomProfile(); 

    protected void Page_PreInit(object sender, EventArgs e) {
        if (!IsPostBack) {
            string itemId = Request.QueryString["addItem"];
            if (!string.IsNullOrEmpty(itemId)) {
                Profile.ShoppingCart.Add(itemId);
                Profile.Save();
                // Redirect to prevent duplictations in the cart if user hits "Refresh"
                Response.Redirect("~/ShoppingCart.aspx", true);
            }
        }
    }
}