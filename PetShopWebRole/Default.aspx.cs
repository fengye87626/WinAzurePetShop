using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetShop.Profile;
using PetShop.AppCode;

namespace PetShopWebRole
{
    public partial class Default : System.Web.UI.Page
    {
        /// <summary>
        /// Redirect to Search page
        /// </summary>
		protected void btnSearch_Click(object sender, EventArgs e)
        {
            WebUtility.SearchRedirect(txtSearch.Text);
		}


    }
}