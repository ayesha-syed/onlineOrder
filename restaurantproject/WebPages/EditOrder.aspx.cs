using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using restaurantproject.Data;



namespace restaurantproject.WebPages
{
    public partial class EditOrder : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["RestaurantDBConnectionString"].ConnectionString;
        int order_id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["order_id"] != "")
                order_id = Convert.ToInt16(Request.QueryString["order_id"]);
            else
                Response.Redirect("Order.aspx");
            if (!IsPostBack)
            {
                var dateAndTime = DateTime.Now;
                int year = dateAndTime.Year;
                int month = dateAndTime.Month;
                int day = dateAndTime.Day;
                txtDate.Text = string.Format("{2}/{1}/{0}", day, month, year);
                // Bind the customer data to the dropdown list
                FillOrderData();
            }
        }
        private void FillOrderData()
        {
            Order order = new Order();
            order = order.GetOrderData(connectionString, order_id);
            txtCustomer.Text = order.customer_name;

            hdnOrderID.Value = order.customer_id.ToString();
            //ddldelivery.SelectedValue = order.delivery_status;
            ddlpayment.SelectedValue = order.payment_method;
            var dateAndTime = DateTime.Now;
            int year = dateAndTime.Year;
            int month = dateAndTime.Month;
            int day = dateAndTime.Day;
            txtDate.Text = string.Format("{2}/{1}/{0}", day, month, year);

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.order_id = order_id;
            //DropDownList customerDropDown = (DropDownList)FindControl("ddlCustomer");
            //order.customer_id = customerDropDown.SelectedValue;
            order.order_date = txtDate.Text;
            //order.delivery_status = ddldelivery.SelectedValue;
            order.payment_method = ddlpayment.SelectedValue;
            order.UpdateOrder(connectionString, order, order_id);
            Response.Redirect("AllOrders.aspx?customer_id=" + hdnOrderID.Value);
        }
        protected void btnCancel_Click(object sender, EventArgs e) {

            Response.Redirect("AllOrders.aspx?customer_id=" + hdnOrderID.Value);
        }


    }
}
