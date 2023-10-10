using restaurantproject.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OrderList : System.Web.UI.Page
{

    private string connectionString = WebConfigurationManager.ConnectionStrings["RestaurantDBConnectionString"].ConnectionString;


    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            FillOrderGrid();
           
        }
    }
    

    private void FillOrderGrid()
    {
        List<Order> orderList = new List<Order>();
        Order order = new Order();
        orderList = order.GetOrder(connectionString);
        gridOrderList.DataSource = orderList;
        gridOrderList.DataBind();
    }


    protected void btnNewOrder_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddOrder.aspx");
    }

    protected void btnAddDetails_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddOrderDetails.aspx");
    }

    protected void btnEditOrder_Click(object sender, EventArgs e)
    {
        string order_id = hdnOrderID.Value;
        if (gridOrderList.SelectedIndex != -1)
            order_id = gridOrderList.SelectedRow.Cells[0].Text;
        Response.Redirect("EditOrder.aspx?orderid=" + order_id);
    }
    protected override void Render(HtmlTextWriter writer)
    {
        foreach (GridViewRow row in gridOrderList.Rows)
        {
            row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference
            (gridOrderList, "Select$" + row.RowIndex.ToString(), true));
        }
        base.Render(writer);
    }
    protected void gridOrderList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("OnMouseOver", "this.style.cursor='pointer';");
            e.Row.ToolTip = "Click on select row";
        }
    }
    protected void gridOrderList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteOrder")
        {
            int order_id = Convert.ToInt32(e.CommandArgument);
            Order order = new Order();
            order.DeleteOrder(connectionString, order_id);
            FillOrderGrid();
        }
        if (e.CommandName == "EditOrder")
        {
            string id = e.CommandArgument.ToString();
            Response.Redirect("EditOrder.aspx?order_id=" + id);
        }
    }
    protected void btnDeleteOrder_Click(object sender, EventArgs e)
    {
        int order_id = 0;
        if (gridOrderList.SelectedIndex != -1)
        {
            order_id = Convert.ToInt32(gridOrderList.SelectedRow.Cells[0].Text);
            Order order = new Order();
            order.DeleteOrder(connectionString, order_id);
            FillOrderGrid();
        }
    }

}
