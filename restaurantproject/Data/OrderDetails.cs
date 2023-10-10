using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Collections.Generic;
using System;

namespace restaurantproject.Data
{
    public class OrderDetails
    {
        public int order_details_id { get; set; }
        public string quantity { get; set; }
        public string order_id { get; set; }
        public string item_id { get; set; }


        public List<OrderDetails> GetOrderDetails(string connectionString)
        {
            List<OrderDetails> orderDetailsList = new List<OrderDetails>();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string selectSQL = "select order_details_id, quantity, order_id, item_id from vw_Order_details";
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    OrderDetails orderDetails = new OrderDetails();
                    orderDetails.order_details_id = (int)Convert.ToUInt32(dr["order_details_id"]);
                    orderDetails.quantity = dr["quantity"].ToString();
                    orderDetails.order_id = dr["order_id"].ToString();
                    orderDetails.item_id = dr["item_id"].ToString();

                    orderDetailsList.Add(orderDetails);
                }
            }
            return orderDetailsList;
        }
        public void CreateOrderDetails(string connectionString, OrderDetails orderDetails)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("CreateOrderDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@quantity", orderDetails.quantity));
                    cmd.Parameters.Add(new SqlParameter("@order_id", orderDetails.order_id));
                    cmd.Parameters.Add(new SqlParameter("@item_id", orderDetails.item_id));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public OrderDetails GetOrderDetailsData(string connectionString, int order_details_id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string selectSQL = "select quantity, order_id, item_id from vw_order_details  WHERE order_details_id  " + order_details_id;
            con.Open();
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();
            OrderDetails orderDetails = new OrderDetails();
            if (dr != null)
            {
                while (dr.Read())
                {
                    orderDetails.order_details_id = (int)Convert.ToUInt32(dr["order_details_id"]);
                    orderDetails.quantity = dr["quantity"].ToString();
                    orderDetails.order_id = dr["order_id"].ToString();
                    orderDetails.item_id = dr["item_id"].ToString();

                }
            }
            return orderDetails;
        }

        public void UpdateOrderDetails(string connectionString, OrderDetails orderDetails, int order_details_id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UpdateOrderDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@order_details_id", order_details_id));
                    cmd.Parameters.Add(new SqlParameter("@quantity", quantity));
                    cmd.Parameters.Add(new SqlParameter("@order_id", order_id));
                    cmd.Parameters.Add(new SqlParameter("@item_id", item_id));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteOrderDetails(string connectionString, int order_details_id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DeleteOrderDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@order_details_id", order_details_id));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}