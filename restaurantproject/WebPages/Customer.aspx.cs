using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI;
using restaurantproject.Data;
using System.Data.SqlClient;
using System.Data;



    public partial class CustomerList : System.Web.UI.Page
    {

        private string connectionString = WebConfigurationManager.ConnectionStrings["RestaurantDBConnectionString"].ConnectionString;
    private SqlConnection connection;

        void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            LoadCustomersByPhone("");
                FillCustomerGrid();
            }
        }

        private void FillCustomerGrid()
        {
            
        
        List<Customer> customerList = new List<Customer>();
            Customer customer = new Customer();
            customerList = customer.GetCustomer(connectionString);
            gridCustomerList.DataSource = customerList;
            gridCustomerList.DataBind();
        }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string searchName = txtSearch.Text.Trim();
        LoadCustomersByPhone(searchName);
    }

    protected void btnSearchEmail_Click(object sender, EventArgs e)
    {
        string searchEmail = txtSearchEmail.Text.Trim();
        LoadCustomersByEmail(searchEmail);
    }
    private void LoadCustomersByPhone(string searchName)
    {
        using (connection = new SqlConnection(connectionString)) 
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TBL_Customer WHERE customer_phone LIKE @SearchName", connection);
            cmd.Parameters.AddWithValue("@SearchName", "%" + searchName + "%");

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            gridCustomerList.DataSource = dt;
            gridCustomerList.DataBind();
        }
    }

    private void LoadCustomersByEmail(string searchEmail)
    {
        using (connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TBL_Customer WHERE customer_email LIKE @SearchEmail", connection);
            cmd.Parameters.AddWithValue("@SearchEmail", "%" + searchEmail + "%");

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            gridCustomerList.DataSource = dt;
            gridCustomerList.DataBind();
        }
    }
    protected void btnNewCustomer_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddCustomer.aspx");
    }

    protected void btnEditCustomer_Click(object sender, EventArgs e)
    {
        string customer_id = hdnCustomerID.Value;
        if (gridCustomerList.SelectedIndex != -1)
            customer_id = gridCustomerList.SelectedRow.Cells[0].Text;
        Response.Redirect("EditCustomer.aspx?customerid=" + customer_id);
    }
    protected override void Render(HtmlTextWriter writer)
    {
        foreach (GridViewRow row in gridCustomerList.Rows)
        {
            row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference
            (gridCustomerList, "Select$" + row.RowIndex.ToString(), true));
        }
        base.Render(writer);
    }
    protected void gridCustomerList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("OnMouseOver", "this.style.cursor='pointer';");
            e.Row.ToolTip = "Click on select row";
        }
    }
    protected void gridCustomerList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    if (e.CommandName == "DeleteCustomer")
    {
        int customer_id = Convert.ToInt32(e.CommandArgument);
        Customer customer = new Customer();
        customer.DeleteCustomer(connectionString, customer_id);
        FillCustomerGrid();
    }
        if (e.CommandName == "UpdateCustomer")
        {
            string id = e.CommandArgument.ToString();
            Response.Redirect("EditCustomer.aspx?customer_id=" + id);
        }

        if (e.CommandName == "ViewCustomerOrder")
        {
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("ViewOrder.aspx?customer_id=" + id);
            }
        }

        if (e.CommandName == "ViewOrd")
        {
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("AllOrders.aspx?customer_id=" + id);
            }
        }
    }

    protected void btnDeleteCustomer_Click(object sender, EventArgs e)
    {
        int customer_id = 0;
        if (gridCustomerList.SelectedIndex != -1)
        {
            customer_id = Convert.ToInt32(gridCustomerList.SelectedRow.Cells[0].Text);
            Customer customer = new Customer();
            customer.DeleteCustomer(connectionString, customer_id);
            FillCustomerGrid();
        }
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewOrder.aspx");
    }

}
