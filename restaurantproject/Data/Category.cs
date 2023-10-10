using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Collections.Generic;
using System;

namespace restaurantproject.Data
{
    public class Category
    {
        public int category_id { get; set; }
        public string category_name { get; set; }

        public List<Category> GetCategory(string connectionString)
        {
            List<Category> categoryList = new List<Category>();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string selectSQL = "select category_id, category_name from vw_Category";
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    Category category = new Category();
                    category.category_id = (int)Convert.ToUInt32(dr["category_id"]);
                    category.category_name = dr["category_name"].ToString();

                    categoryList.Add(category);
                }
            }
            return categoryList;
        }
        public void CreateCategory(string connectionString, Category category)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("CreateCategory", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@category_name", category.category_name));
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
        public Category GetCategoryData(string connectionString, int _id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string selectSQL = "select category_id, category_name from vw_Category where Category_id = " + category_id;
            con.Open();
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();
            Category category = new Category();
            if (dr != null)
            {
                while (dr.Read())
                {
                    category.category_id = (int)Convert.ToUInt32(dr["category_id"]);
                    category.category_name = dr["category_name"].ToString();

                }
            }
            return category;
        }

        public void EditCategory(string connectionString, Category category)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("EditCategory", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@category_id", category.category_id));
                    cmd.Parameters.Add(new SqlParameter("@category_name", category.category_name));
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

        public void UpdateCategory(string connectionString, Category category, int category_id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UpdateCategory", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@category_id", category.category_id));
                    cmd.Parameters.Add(new SqlParameter("@category_name", category.category_name));
            
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
        public void DeleteCategory(string connectionString, int category_id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DeleteCategory", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@category_id", category_id));
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