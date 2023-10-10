using restaurantproject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OrderDetailsList : System.Web.UI.Page
{

    private string connectionString = WebConfigurationManager.ConnectionStrings["RestaurantDBConnectionString"].ConnectionString;


    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillOrderDetailsGrid();
        }
    }

    private void FillOrderDetailsGrid()
    {
        List<OrderDetails> orderDetailsList = new List<OrderDetails>();
        OrderDetails orderDetails = new OrderDetails();
        orderDetailsList = orderDetails.GetOrderDetails(connectionString);
        gridOrderDetailsList.DataSource = orderDetailsList;
        gridOrderDetailsList.DataBind();
    }
    protected void btnNewOrderDetails_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddOrderDetails.aspx");
    }


    protected void btnEditOrderDetails_Click(object sender, EventArgs e)
    {
        string order_details_id = null;
        if (gridOrderDetailsList.SelectedIndex != -1)
            order_details_id = gridOrderDetailsList.SelectedRow.Cells[0].Text;
        Response.Redirect("EditOrderDetails.aspx?orderdetailsid=" + order_details_id);
    }
    protected override void Render(HtmlTextWriter writer)
    {
        foreach (GridViewRow row in gridOrderDetailsList.Rows)
        {
            row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference
            (gridOrderDetailsList, "Select$" + row.RowIndex.ToString(), true));
        }
        base.Render(writer);
    }
    protected void gridOrderDetailsList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("OnMouseOver", "this.style.cursor='pointer';");
            e.Row.ToolTip = "Click on select row";
        }
    }
    protected void btnDeleteOrderDetails_Click(object sender, EventArgs e)
    {
        int order_details_id = 0;
        if (gridOrderDetailsList.SelectedIndex != -1)
        {
            order_details_id = Convert.ToInt32(gridOrderDetailsList.SelectedRow.Cells[0].Text);
            OrderDetails orderDetails = new OrderDetails();
            orderDetails.DeleteOrderDetails(connectionString, order_details_id);
            FillOrderDetailsGrid();
        }
    }

}