using restaurantproject.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace restaurantproject.WebPages
{
    public partial class AddOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Customer customer = new Customer(); 
                List<Customer> customerList = customer.GetCustomer(connectionString); 
  
                //ddlCustomers.DataSource = customerList;
                //ddlCustomers.DataTextField = "customer_name"; 
                //ddlCustomers.DataValueField = "customer_id";   
                //ddlCustomers.DataBind();
                var dateAndTime = DateTime.Now;
                int year = dateAndTime.Year;
                int month = dateAndTime.Month;
                int day = dateAndTime.Day;
                txtDate.Text = string.Format("{2}/{1}/{0}", day, month, year);
                //ddldelivery.DataSource = orderList;
                //ddldelivery.DataTextField = "delivery_status"; 
                //ddldelivery.DataValueField = "delivery_status"; 
                //ddldelivery.DataBind();
                //ddlpayment.DataSource = orderList;
                //ddlpayment.DataTextField = "payment_method"; 
                //ddlpayment.DataValueField = "payment_method";  
                //ddlpayment.DataBind();


            }
        }

        private string connectionString =
        WebConfigurationManager.ConnectionStrings["RestaurantDBConnectionString"].ConnectionString;
        

        protected void btnOK_Click(object sender, EventArgs e)
        {
            Order order = new Order();

            order.payment_method = ddlpayment.SelectedValue;
            order.order_date = txtDate.Text;
            string customer_id = Request["customer_id"].ToString();
            order.customer_id = customer_id;
            //order.delivery_status = ddldelivery.SelectedValue;

            order.CreateOrder(connectionString, order);
            //Response.Redirect("Customer.aspx");
            //hdnOrderID.Value = order.customer_id.ToString();
            Response.Redirect("AllOrders.aspx?customer_id=" + customer_id);

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Customer.aspx");
            string customer_id = Request["customer_id"].ToString();
            Response.Redirect("AllOrders.aspx?customer_id=" + customer_id);
        }


    }
}