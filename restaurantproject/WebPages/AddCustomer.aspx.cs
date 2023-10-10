using restaurantproject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace restaurantproject.WebPages
{
    public partial class AddCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private string connectionString =
        WebConfigurationManager.ConnectionStrings["RestaurantDBConnectionString"].ConnectionString;
        protected void btnOK_Click(object sender, EventArgs e)
        {
            //    try { 
            //    Customer customer = new Customer();
            //    customer.customer_name = txtName.Text;
            //    customer.customer_address = txtAddress.Text;
            //    customer.customer_email = txtEmail.Text;
            //    customer.customer_phone = txtPhone.Text;
            //    customer.CreateCustomer(connectionString, customer);
            //    Response.Redirect("Customer.aspx");

            //    }
            //    catch (Exception ex)
            //    {
            //        errorMessage.Text = "An Error Has Occured: " + ex.Message;
            //        errorMessage.Visible = true;
            //        throw ex;
            //    }
            //}
            try
            {
                Customer customer = new Customer();
                customer.customer_name = txtName.Text;
                customer.customer_address = txtAddress.Text;
                customer.customer_email = txtEmail.Text;
                customer.customer_phone = txtPhone.Text;
                customer.CreateCustomer(connectionString, customer);
                Response.Redirect("Customer.aspx");

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    errorMessageLabel.Text = "This customer is already saved in the system. Please select from the customer list.";
                }
                else
                {
                    errorMessageLabel.Text = "An error occurred while inserting data. Please try again later.";
                }
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Customer.aspx");
        }
    }
}