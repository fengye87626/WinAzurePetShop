using System.Web.Profile;
using System.Web;

namespace PetShop.Profile
{
    public  class ProfileCommon : System.Web.Profile.ProfileBase
    {

        public virtual PetShop.BLL.Cart WishList
        {
            get
            {
                return ((PetShop.BLL.Cart)(HttpContext.Current.Profile.GetPropertyValue("WishList")));
            }
            set
            {
                HttpContext.Current.Profile.SetPropertyValue("WishList", value);
            }
        }

        public virtual PetShop.BLL.Cart ShoppingCart
        {
            get
            {
                return ((PetShop.BLL.Cart)(HttpContext.Current.Profile.GetPropertyValue("ShoppingCart")));
            }
            set
            {
                HttpContext.Current.Profile.SetPropertyValue("ShoppingCart", value);
            }
        }

        public virtual PetShop.Model.AddressInfo AccountInfo
        {
            get
            {
                return ((PetShop.Model.AddressInfo)(HttpContext.Current.Profile.GetPropertyValue("AccountInfo")));
            }
            set
            {
                HttpContext.Current.Profile.SetPropertyValue("AccountInfo", value);
            }
        }

        public virtual ProfileCommon GetProfile(string username)
        {
            return ((ProfileCommon)(ProfileBase.Create(username)));
        }

    }
}
