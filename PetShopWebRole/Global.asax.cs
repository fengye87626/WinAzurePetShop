using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Diagnostics;
using System.Configuration;
using PetShop.Model;
using System.Web.Profile;

namespace PetShopWebRole
{
    public class Global : HttpApplication
    {
        CustomProfile Profile = new CustomProfile();

        private static string LOG_SOURCE = ConfigurationManager.AppSettings["Event Log Source"];

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
            
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
            Exception x = Server.GetLastError().GetBaseException();
            EventLog.WriteEntry(LOG_SOURCE, x.ToString(), EventLogEntryType.Error);
        }


        // Carry over profile property values from an anonymous to an authenticated state 
        void Profile_MigrateAnonymous(Object sender, ProfileMigrateEventArgs e)
        {

            var anonProfile = ProfileBase.Create(e.AnonymousID);
           //CustomProfile anonProfile = Profile.GetProfile(e.AnonymousID);

            // Merge anonymous shopping cart items to the authenticated shopping cart items
            foreach (CartItemInfo cartItem in  ((PetShop.BLL.Cart)anonProfile.GetPropertyValue("ShoppingCart")).CartItems)
                Profile.ShoppingCart.Add(cartItem);

            // Merge anonymous wishlist items to the authenticated wishlist items
            foreach (CartItemInfo cartItem in((PetShop.BLL.Cart)(anonProfile.GetPropertyValue("WishList"))).CartItems)
                Profile.WishList.Add(cartItem);

            // Clean up anonymous profile
            ProfileManager.DeleteProfile(e.AnonymousID);
            AnonymousIdentificationModule.ClearAnonymousIdentifier();

            // Save profile
            Profile.Save();
        }

    }
}
