using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace restaurantproject.Data
{
    public class Menu
    {
        public int item_id { get; set; }
        public string item_name { get; set; }
        public string category_id { get; set; }
        public string category_name { get; set; }
        public string price { get; set; }
        public List<Menu> GetMenu(string connectionString)
        {
            List<Menu> menuList = new List<Menu>();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string selectSQL = "select item_id, item_name, category_id, price, category_name from vw_Menu";
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    Menu menu = new Menu();
                    menu.item_id = (int)Convert.ToUInt32(dr["item_id"]);
                    menu.item_name = dr["item_name"].ToString();
                    menu.category_id = dr["category_id"].ToString();
                    menu.price = dr["price"].ToString();
                    menu.category_name = dr["category_name"].ToString();
                    menuList.Add(menu);
                }
            }
            return menuList;
        }
        public void CreateMenu(string connectionString, Menu menu)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("CreateMenu", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@item_name", menu.item_name));
                    cmd.Parameters.Add(new SqlParameter("@category_id", menu.category_id));
                    cmd.Parameters.Add(new SqlParameter("@price", menu.price));
                    //cmd.Parameters.Add(new SqlParameter("@category_name", menu.category_name));
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
        public Menu GetMenuData(string connectionString, int item_id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string selectSQL = "select item_id, item_name, price, category_id, category_name from vw_Menu where item_id = " + item_id;
            con.Open();
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();
            Menu menu = new Menu();
            if (dr != null)
            {
                while (dr.Read())
                {
                    menu.item_id = (int)Convert.ToUInt32(dr["item_id"]);
                    menu.item_name = dr["item_name"].ToString();
                    menu.category_id = dr["category_id"].ToString();
                    menu.price = dr["price"].ToString();
                    menu.category_name = dr["category_name"].ToString();
                }
            }
            return menu;
        }

        public void UpdateMenu(string connectionString, Menu menu, int item_id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UpdateMenu", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@item_id", menu.item_id));
                    cmd.Parameters.Add(new SqlParameter("@item_name", menu.item_name));
                    cmd.Parameters.Add(new SqlParameter("@category_id", menu.category_id));
                    cmd.Parameters.Add(new SqlParameter("@price", menu.price));
                    cmd.Parameters.Add(new SqlParameter("@category_name", menu.category_name));
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
        public void DeleteMenu(string connectionString, int item_id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DeleteMenu", con);
                    cmd.CommandType = CommandType.StoredProcedure;
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
    }
}