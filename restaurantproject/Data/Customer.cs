using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Collections.Generic;
using System;
using System.Web.ModelBinding;

namespace restaurantproject.Data
{
    public class Customer
    {
        public int customer_id {get;set;}
        public string customer_name {get;set;}
        public string customer_address {get;set;}
        public string customer_email {get;set;}
        public string customer_phone {get;set;}
        public string order_id { get; set; }
        public string order_date { get; set; }
        public string order_details_id { get; set; }
        public string item_id { get; set; }
        public string item_name { get; set; }
        public string price { get; set; }
        public string quantity { get; set; }
        public string category_name { get; set; }
        public string total_amount { get; set; }

        public List<Customer> GetCustomer(string connectionString)
        {
            List<Customer> customerList = new List<Customer>();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string selectSQL = "select customer_id, customer_name, customer_address, customer_email, customer_phone from vw_Customers";
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    Customer customer = new Customer();
                    customer.customer_id = (int)Convert.ToUInt32(dr["customer_id"]);
                    customer.customer_name = dr["customer_name"].ToString();
                    customer.customer_address = dr["customer_address"].ToString();
                    customer.customer_email = dr["customer_email"].ToString();
                    customer.customer_phone = dr["customer_phone"].ToString();
              
                    customerList.Add(customer);
                }
            }
            return customerList;
        }
        public void CreateCustomer(string connectionString, Customer customer)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("CreateCustomer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@customer_name", customer.customer_name));
                    cmd.Parameters.Add(new SqlParameter("@customer_address", customer.customer_address));
                    cmd.Parameters.Add(new SqlParameter("@customer_email", customer.customer_email));
                    cmd.Parameters.Add(new SqlParameter("@customer_phone", customer.customer_phone));
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
        public Customer GetCustomerData(string connectionString, int customer_id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string selectSQL = "select customer_id, customer_name, customer_address, customer_email, customer_phone from vw_Customers where customer_id = " + customer_id;
            con.Open();
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();
            Customer customer = new Customer();
            if (dr != null)
            {
                while (dr.Read())
                {
                    customer.customer_id = (int)Convert.ToUInt32(dr["customer_id"]);
                    customer.customer_name = dr["customer_name"].ToString();
                    customer.customer_address = dr["customer_address"].ToString();
                    customer.customer_email = dr["customer_email"].ToString();
                    customer.customer_phone = dr["customer_phone"].ToString();

                }
            }
            return customer;
        }

        public void UpdateCustomer(string connectionString, Customer customer, int customer_id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UpdateCustomer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@customer_id", customer.customer_id));
                    cmd.Parameters.Add(new SqlParameter("@customer_name", customer.customer_name));
                    cmd.Parameters.Add(new SqlParameter("@customer_address", customer.customer_address));
                    cmd.Parameters.Add(new SqlParameter("@customer_email", customer.customer_email));
                    cmd.Parameters.Add(new SqlParameter("@customer_phone", customer.customer_phone));
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
         public void DeleteCustomer(string connectionString, int customer_id)
         {
             try
             {
                 using (SqlConnection con = new SqlConnection(connectionString))
                 {
                     SqlCommand cmd = new SqlCommand("DeleteCustomer", con);
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.Add(new SqlParameter("@customer_id", customer_id));
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
        public ViewOrder GetViewOrderData(string connectionString, int customer_id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string selectSQL = "select customer_id, customer_name, category_name, order_id, order_date, order_details_id, item_id,  item_name, price, quantity, category_name, total_amount from vw_CustomerOrder where customer_id = " + customer_id;
            con.Open();
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();
            ViewOrder viewOrder = new ViewOrder();
            if (dr != null)
            {
                while (dr.Read())
                {
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
                   
                }
            }
            return viewOrder;
        }
        public List<ViewOrder> GetViewOrder(string connectionString)
        {
            List<ViewOrder> viewOrderList = new List<ViewOrder>();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string selectSQL = "select customer_id, customer_name, order_id, category_name, order_date, order_details_id,  item_id, item_name, price, quantity, category_name from vw_CustomerOrder";
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    ViewOrder viewOrder = new ViewOrder();
                    viewOrder.customer_id = (int)Convert.ToUInt32(dr["customer_id"]);
                    viewOrder.customer_name = dr["customer_name"].ToString();
                    viewOrder.customer_name = dr["category_name"].ToString();
                    viewOrder.order_id = dr["order_id"].ToString();
                    viewOrder.order_date = dr["order_date"].ToString();
                    viewOrder.order_details_id = dr["order_details_id"].ToString();
                    viewOrder.item_id = dr["item_id"].ToString();
                    viewOrder.item_name = dr["item_name"].ToString();
                    viewOrder.price = dr["price"].ToString();
                    viewOrder.quantity = dr["quantity"].ToString();
             
                    viewOrderList.Add(viewOrder);
                }
            }
            return viewOrderList;
        }
    }
}