using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using restaurantproject.Data;



namespace restaurantproject.WebPages
{
    public partial class EditOrderDetails : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["RestaurantDBConnectionString"].ConnectionString;
        int order_details_id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["order_details_id"] != "")
                order_details_id = Convert.ToInt16(Request.QueryString["order_details_id"]);
            else
                Response.Redirect("Order.aspx");
            if (!IsPostBack)
            {

                FillOrderDetailsData();
            }
        }
        private void FillOrderDetailsData()
        {
            OrderDetails orderDetails = new OrderDetails();
            orderDetails = orderDetails.GetOrderDetailsData(connectionString, order_details_id);
            //orderDetails.item_id = ddlItem.SelectedValue;
            //orderDetails.quantity = txtQuantity.Text;
            hdnOrderID.Value = orderDetails.order_details_id.ToString();
            ddlItem.SelectedValue = orderDetails.item_id;
            txtQuantity.Text = orderDetails.quantity;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            OrderDetails orderDetails = new OrderDetails();
            orderDetails.item_id = ddlItem.SelectedValue; ;
            orderDetails.quantity = txtQuantity.Text;
            orderDetails.UpdateOrderDetails(connectionString, orderDetails, order_details_id);
            Response.Redirect("AllOrders.aspx?customer_id=" + hdnOrderID.Value);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {

            Response.Redirect("AllOrders.aspx?customer_id=" + hdnOrderID.Value);
        }


    }
}
