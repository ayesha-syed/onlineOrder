using System;
using System.Web.Configuration;
using restaurantproject.Data;
using System.Data.SqlClient;


namespace restaurantproject.WebPages
{
    public partial class EditCustomer : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["RestaurantDBConnectionString"].ConnectionString;
        int customer_id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["customer_id"] != "")
                customer_id = Convert.ToInt16(Request.QueryString["customer_id"]);
            else
                Response.Redirect("Customer.aspx");
            if (!IsPostBack)
            {
                FillCustomerData();
            }
        }
        private void FillCustomerData()
        {
            Customer customer = new Customer();
            customer = customer.GetCustomerData(connectionString, customer_id);
            txtName.Text = customer.customer_name;
            txtAddress.Text = customer.customer_address;
            txtEmail.Text = customer.customer_email;
            txtPhone.Text = customer.customer_phone;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Customer customer = new Customer();
                customer.customer_id = customer_id;
                customer.customer_name = txtName.Text;
                customer.customer_address = txtAddress.Text;
                customer.customer_email = txtEmail.Text;
                customer.customer_phone = txtPhone.Text;
                customer.UpdateCustomer(connectionString, customer, customer_id);
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

