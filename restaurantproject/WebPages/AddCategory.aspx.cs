using restaurantproject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace restaurantproject.WebPages
{
    public partial class AddCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private string connectionString =
        WebConfigurationManager.ConnectionStrings["RestaurantDBConnectionString"].ConnectionString;
        protected void btnOK_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.category_name = txtName.Text;
            category.CreateCategory(connectionString, category);
            Response.Redirect("Category.aspx");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Category.aspx");
        }


    }
}