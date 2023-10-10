using restaurantproject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Menu = restaurantproject.Data.Menu;

namespace restaurantproject.WebPages
{
    public partial class AddMenu : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                Category category = new Category(); 
                List<Category> categoryList = category.GetCategory(connectionString); 
                ddlCategory.DataSource = categoryList;
                ddlCategory.DataTextField = "category_name"; 
                ddlCategory.DataValueField = "category_id";   
                ddlCategory.DataBind();
            }
        }

        private string connectionString =
        WebConfigurationManager.ConnectionStrings["RestaurantDBConnectionString"].ConnectionString;
        protected void btnOK_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.item_name = txtName.Text;
            menu.price = txtPrice.Text;
            menu.category_id = ddlCategory.SelectedValue;
            menu.category_name = ddlCategory.SelectedValue;
            menu.CreateMenu(connectionString, menu);
            Response.Redirect("Menu.aspx");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }


    }
}