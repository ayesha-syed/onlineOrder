using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Collections.Generic;
using System;

namespace restaurantproject.Data
{
    public class ViewOrder
    {
        public int customer_id { get; set; }
        public string customer_name { get; set; }
        public string order_id { get; set; }
        public string order_date { get; set; }
        public string order_details_id { get; set; }
        public string item_id { get; set; }
        public string item_name { get; set; }
        public string price { get; set; }
        public string quantity { get; set; }
        public string category_name { get; set; }
        public string delivery_status { get; set; }
        public string amount { get; set; }



        public List<ViewOrder> GetViewOrder(string connectionString)
        {
            List<ViewOrder> viewOrderList = new List<ViewOrder>();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string selectSQL = "select customer_id, customer_name,amount, order_id, delivery_status, category_name, order_date, order_details_id, item_id, item_name, price, quantity, category_name from vw_CustomerOrder";
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    ViewOrder viewOrder = new ViewOrder();
                    viewOrder.customer_id = (int)Convert.ToUInt32(dr["customer_id"]);
                    viewOrder.customer_name = dr["customer_name"].ToString();
                    viewOrder.category_name = dr["category_name"].ToString();
                    viewOrder.order_id = dr["order_id"].ToString();
                    viewOrder.order_date = dr["order_date"].ToString();
                    viewOrder.order_details_id = dr["order_details_id"].ToString();
                    viewOrder.item_id = dr["item_id"].ToString();
                    viewOrder.item_name = dr["item_name"].ToString();
                    viewOrder.price = dr["price"].ToString();
                    viewOrder.quantity = dr["quantity"].ToString();
                    viewOrder.delivery_status = dr["delivery_status"].ToString();
                    viewOrder.amount = dr["amount"].ToString();
                    viewOrderList.Add(viewOrder);
                }
            }
            return viewOrderList;
        }
      
        public List<ViewOrder> GetViewOrderData(string connectionString, int order_id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string selectSQL = "select customer_id, customer_name, order_id, category_name, delivery_status, order_date, order_details_id, item_id, item_name, price, quantity, category_name from vw_CustomerOrder where order_id = " + order_id;
            con.Open();
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();
            ViewOrder viewOrder = new ViewOrder();
            List<ViewOrder> orderslist = new List<ViewOrder>();

            if (dr != null)
            {
                while (dr.Read())
                {
                    ViewOrder viewOrderTemp = new ViewOrder();

                    viewOrderTemp.customer_id = (int)Convert.ToUInt32(dr["customer_id"]);
                    viewOrderTemp.customer_name = dr["customer_name"].ToString();
                    viewOrderTemp.category_name = dr["category_name"].ToString();
                    viewOrderTemp.order_id = dr["order_id"].ToString();
                    viewOrderTemp.order_date = dr["order_date"].ToString();
                    viewOrderTemp.order_details_id = dr["order_details_id"].ToString();
                    viewOrderTemp.item_id = dr["item_id"].ToString();
                    viewOrderTemp.item_name = dr["item_name"].ToString();
                    viewOrderTemp.price = dr["price"].ToString();
                    viewOrderTemp.quantity = dr["quantity"].ToString();
                    viewOrderTemp.delivery_status = dr["delivery_status"].ToString();
                  
                    orderslist.Add(viewOrderTemp);
                }
            }
            return orderslist;
        }
       

    }
}