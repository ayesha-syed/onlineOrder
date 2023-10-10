using System;
using System.Web.Configuration;
using restaurantproject.Data;



namespace restaurantproject.WebPages
{
    public partial class EditCategory : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["RestaurantDBConnectionString"].ConnectionString;
        int category_id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["category_id"] != "")
                category_id = Convert.ToInt16(Request.QueryString["category_id"]);
            else
                Response.Redirect("Category.aspx");
            if (!IsPostBack)
            {
                FillCategoryData();
            }
        }
        private void FillCategoryData()
        {
            Category category = new Category();
            category = category.GetCategoryData(connectionString, category_id);
            txtName.Text = category.category_name;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.category_id = category_id;
            category.category_name = txtName.Text;
            category.UpdateCategory(connectionString, category, category_id);
            Response.Redirect("Category.aspx");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Category.aspx");
        }


    }
}
