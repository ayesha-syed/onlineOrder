using System;
using System.Collections.Generic;
using System.Web.Configuration;
using restaurantproject.Data;



namespace restaurantproject.WebPages
{
    public partial class EditMenu : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["RestaurantDBConnectionString"].ConnectionString;
        int item_id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["item_id"] != "")
                item_id = Convert.ToInt16(Request.QueryString["item_id"]);
            else
                Response.Redirect("Menu.aspx");
            if (!IsPostBack)
            {
                
                FillMenuData();
            }
        }
        private void FillMenuData()
        {
            Menu menu = new Menu();
            menu = menu.GetMenuData(connectionString, item_id);
            txtName.Text = menu.item_name;
            ddlCategory.SelectedValue = menu.category_id; 
            txtPrice.Text = menu.price;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.item_id = item_id;
            menu.item_name = txtName.Text;
            menu.category_id = ddlCategory.SelectedValue;
            menu.price = txtPrice.Text;
            menu.UpdateMenu(connectionString, menu, item_id);
            Response.Redirect("Menu.aspx");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }


    }
}
