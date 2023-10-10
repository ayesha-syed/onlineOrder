using restaurantproject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{


    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }


    protected void btnCustomer_Click(object sender, EventArgs e)
    {
        Response.Redirect("Customer.aspx");
    }

    protected void btnOrder_Click(object sender, EventArgs e)
    {
        Response.Redirect("Order.aspx");
    }

    protected void btnCategory_Click(object sender, EventArgs e)
    {
        Response.Redirect("Category.aspx");
    }

    protected void btnMenu_Click(object sender, EventArgs e)
    {
        Response.Redirect("Menu.aspx");
    }

    protected void btnOrderDetails_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrderDetails.aspx");
    }
}
