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
    public partial class AddOrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Menu menu = new Menu(); 
                List<Menu> menuList = menu.GetMenu(connectionString);

                //ddlOrder.DataSource = orderList;
                //ddlOrder.DataTextField = "customer_name"; 
                //ddlOrder.DataValueField = "order_id";   
                //ddlOrder.DataBind();
                ddlMenu.DataSource = menuList;
                ddlMenu.DataTextField = "item_name";
                ddlMenu.DataValueField = "item_id";  
                ddlMenu.DataBind();
            }
        }
        private string connectionString =
        WebConfigurationManager.ConnectionStrings["RestaurantDBConnectionString"].ConnectionString;
        protected void btnOK_Click(object sender, EventArgs e)
        {
            OrderDetails orderDetails = new OrderDetails();
            orderDetails.quantity = txtQuantity.Text;
            //DropDownList orderDropDown = (DropDownList)FindControl("ddlOrder");
            //DropDownList menuDropDown = (DropDownList)FindControl("ddlMenu");
            //orderDetails.order_id = orderDropDown.SelectedValue;
            //orderDetails.item_id = menuDropDown.SelectedValue;
            string order_id = Request["order_id"].ToString();
            orderDetails.order_id = order_id;
            //orderDetails.order_id = ddlOrder.SelectedValue;
            orderDetails.item_id = ddlMenu.SelectedValue;
           //lblName = orderDetails.order_id;
   
            orderDetails.CreateOrderDetails(connectionString, orderDetails);
            Response.Redirect("OrderDetails.aspx");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderDetails.aspx");
        }


    }
}