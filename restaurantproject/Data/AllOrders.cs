using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Collections.Generic;
using System;
using System.Configuration;

namespace restaurantproject.Data
{
    public class AllOrders
    {
        public int order_id { get; set; }
        public string customer_id { get; set; }

        public string payment_method { get; set; }
        public string order_date { get; set; }
        public string total_amount { get; set; }


        public List<AllOrders> GetAllOrders(string connectionString, int customer_id)
        {
            List<AllOrders> allOrderList = new List<AllOrders>();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string selectSQL = "select order_id, payment_method, customer_id, order_date, total_amount from vw_Orders where customer_id =" + customer_id;
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
    

                    AllOrders allOrders = new AllOrders();
                    allOrders.order_id = (int)Convert.ToUInt32(dr["order_id"]);
                    allOrders.customer_id = dr["customer_id"].ToString();
                    //allOrders.delivery_status = dr["delivery_status"].ToString();
                    //allOrders.order_date = dr["order_date"].ToString();
                    allOrders.payment_method = dr["payment_method"].ToString();
                    allOrders.total_amount = dr["total_amount"].ToString();
                    var dateAndTime = DateTime.Now;
                    int year = dateAndTime.Year;
                    int month = dateAndTime.Month;
                    int day = dateAndTime.Day;
                    allOrders.order_date = string.Format("{2}/{1}/{0}", day, month, year);
                    allOrderList.Add(allOrders);
                }
            }
            return allOrderList;
        }
       // public void CreateOrder(string connectionString, Order order)
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(connectionString))
        //        {
        //            SqlCommand cmd = new SqlCommand("CreateOrder", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add(new SqlParameter("@customer_id", order.customer_id));
        //            cmd.Parameters.Add(new SqlParameter("@order_date", order.order_date));
        //            cmd.Parameters.Add(new SqlParameter("@delivery_status", order.delivery_status));
        //            cmd.Parameters.Add(new SqlParameter("@payment_method", order.payment_method));
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public AllOrders GetAllOrdersData(string connectionString, int customer_id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string selectSQL = "select order_id,  payment_method, total_amount, customer_id, order_date from vw_Orders where customer_id =" + customer_id;
            con.Open();
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();
            AllOrders allOrders = new AllOrders();
            if (dr != null)
            {
                while (dr.Read())
                {
                    allOrders.order_id = (int)Convert.ToUInt32(dr["order_id"]);
                    allOrders.customer_id = dr["customer_id"].ToString();
                    //allOrders.delivery_status = dr["delivery_status"].ToString();
                    allOrders.payment_method = dr["payment_method"].ToString();
                    allOrders.customer_id = dr["order_date"].ToString();
                    allOrders.total_amount = dr["total_amount"].ToString();

                }
            }
            return allOrders;
        }

        //public void UpdateOrder(string connectionString, Order order, int order_id)
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(connectionString))
        //        {
        //            SqlCommand cmd = new SqlCommand("UpdateOrder", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add(new SqlParameter("@order_id", order.order_id));
        //            cmd.Parameters.Add(new SqlParameter("@customer_id", order.customer_id));
        //            cmd.Parameters.Add(new SqlParameter("@order_date", order.order_date));
        //            cmd.Parameters.Add(new SqlParameter("@delivery_status", order.delivery_status));
        //            cmd.Parameters.Add(new SqlParameter("@payment_method", order.payment_method));
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public void DeleteOrder(string connectionString, int order_id)
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(connectionString))
        //        {
        //            SqlCommand cmd = new SqlCommand("DeleteOrder", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add(new SqlParameter("@order_id", order_id));
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


    }
}