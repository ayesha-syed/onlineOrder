using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Collections.Generic;
using System;
using System.Configuration;

namespace restaurantproject.Data
{
    public class Order
    {
        public int order_id { get; set; }
        public string customer_id { get; set; }
        public string customer_name { get; set; }
        public string order_date { get; set; }
        public string delivery_status { get; set; }
        public string payment_method { get; set; }


        public List<Order> GetOrder(string connectionString)
        {
            List<Order> orderList = new List<Order>();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string selectSQL = "select order_id, customer_name, customer_id, order_date, payment_method from vw_Orders";
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    Order order = new Order();
                    order.order_id = (int)Convert.ToUInt32(dr["order_id"]);
                    order.customer_id = dr["customer_id"].ToString();
                    order.customer_name = dr["customer_name"].ToString();
                    var dateAndTime = DateTime.Now;
                    int year = dateAndTime.Year;
                    int month = dateAndTime.Month;
                    int day = dateAndTime.Day;
                    order.order_date = string.Format("{2}/{1}/{0}", day, month, year);
                    cmd.Parameters.Add(new SqlParameter("@@order_date", order.order_date));
    
                    order.payment_method = dr["payment_method"].ToString();

                    orderList.Add(order);
                }
            }
            return orderList;
        }
        public void CreateOrder(string connectionString, Order order)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("CreateOrder", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@customer_id", order.customer_id));
                    var dateAndTime = DateTime.Now;
                    int year = dateAndTime.Year;
                    int month = dateAndTime.Month;
                    int day = dateAndTime.Day;
                    order.order_date = string.Format("{2}/{1}/{0}", day, month, year);
                    cmd.Parameters.Add(new SqlParameter("@order_date", order.order_date));
         
                    cmd.Parameters.Add(new SqlParameter("@payment_method", order.payment_method));
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
        public Order GetOrderData(string connectionString, int order_id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string selectSQL = "select order_id, customer_id, customer_name, order_date, payment_method from vw_Orders  WHERE order_id = " + order_id;
            con.Open();
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();
            Order order = new Order();
            if (dr != null)
            {
                while (dr.Read())
                {
                    order.order_id = (int)Convert.ToUInt32(dr["order_id"]);
                    order.customer_id = dr["customer_id"].ToString();
                    order.customer_name = dr["customer_name"].ToString();
                    var dateAndTime = DateTime.Now;
                    int year = dateAndTime.Year;
                    int month = dateAndTime.Month;
                    int day = dateAndTime.Day;
                    order.order_date = string.Format("{2}/{1}/{0}", day, month, year);
                    cmd.Parameters.Add(new SqlParameter("@@order_date", order.order_date));

                    order.payment_method = dr["payment_method"].ToString();

                }
            }
            return order;
        }

        public void UpdateOrder(string connectionString, Order order, int order_id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UpdateOrder", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@order_id", order.order_id));
                    cmd.Parameters.Add(new SqlParameter("@order_date", order.order_date));
             
                    cmd.Parameters.Add(new SqlParameter("@payment_method", order.payment_method));
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
        public void DeleteOrder(string connectionString, int order_id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DeleteOrder", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@order_id", order_id));
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