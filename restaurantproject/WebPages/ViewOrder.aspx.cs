using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using restaurantproject.Data;
using ViewOrder = restaurantproject.Data.ViewOrder;



namespace restaurantproject.WebPages
{
    public partial class ViewCustomerOrder : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["RestaurantDBConnectionString"].ConnectionString;
        int order_id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["order_id"] != "")
                order_id = Convert.ToInt16(Request.QueryString["order_id"]);
            else
                Response.Redirect("Customer.aspx");
            if (!IsPostBack)
            {
                FillViewOrderData();
            }
        }
        private void FillViewOrderData()
        {

            List<ViewOrder> viewOrderList = new List<ViewOrder>();
            ViewOrder viewOrder = new ViewOrder();
            viewOrderList = viewOrder.GetViewOrderData(connectionString, order_id);
            gridViewOrderList.DataSource = viewOrderList;
            gridViewOrderList.DataBind();

        }
        protected void btnNewOrder_Click(object sender, EventArgs e)
        {
            string order_id = Request["order_id"].ToString();
            Response.Redirect("AddOrderDetails.aspx?order_id=" + order_id);
        }

        //protected void btnBack_Click(object sender, EventArgs e)
        //{
        //    string order_id = Request["order_id"].ToString();
        //    Response.Redirect("AllOrders.aspx?customer_id=" + customer_id);
        //}

        //protected void gridViewOrderList_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "DeleteOrderDetails")
        //    {
        //        int order_details_id = Convert.ToInt32(e.CommandArgument);
        //        OrderDetails orderDetails = new OrderDetails();
        //        orderDetails.DeleteOrderDetails(connectionString, order_details_id);
        //        FillViewOrderData();
        //    }
        //    if (e.CommandName == "EditOrderDetails")
        //    {
        //        string id = e.CommandArgument.ToString();
        //        Response.Redirect("EditOrderDetails.aspx?order_details_id=" + id);
        //    }
        //}

    }

    }

