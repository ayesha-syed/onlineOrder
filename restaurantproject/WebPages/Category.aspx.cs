using restaurantproject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CategoryList : System.Web.UI.Page
{

    private string connectionString = WebConfigurationManager.ConnectionStrings["RestaurantDBConnectionString"].ConnectionString;


    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillCategoryGrid();
        }
    }

    private void FillCategoryGrid()
    {
        List<Category> categoryList = new List<Category>();
        Category category = new Category();
        categoryList = category.GetCategory(connectionString);
        gridCategoryList.DataSource = categoryList;
        gridCategoryList.DataBind();
    }
    protected void btnNewCategory_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddCustomer.aspx");
    }

    protected void btnEditCategory_Click(object sender, EventArgs e)
    {
        string category_id = hdnCategoryID.Value;
        if (gridCategoryList.SelectedIndex != -1)
            category_id = gridCategoryList.SelectedRow.Cells[0].Text;
        Response.Redirect("EditCategory.aspx?categoryid=" + category_id);
    }
    protected override void Render(HtmlTextWriter writer)
    {
        foreach (GridViewRow row in gridCategoryList.Rows)
        {
            row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference
            (gridCategoryList, "Select$" + row.RowIndex.ToString(), true));
        }
        base.Render(writer);
    }
    protected void gridCategoryList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("OnMouseOver", "this.style.cursor='pointer';");
            e.Row.ToolTip = "Click on select row";
        }
    }
    protected void gridCategoryList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteCategory")
        {
            int category_id = Convert.ToInt32(e.CommandArgument);
            Category category = new Category();
            category.DeleteCategory(connectionString, category_id);
            FillCategoryGrid();
        }
        if (e.CommandName == "EditCategory")
        {
            string id = e.CommandArgument.ToString();
            Response.Redirect("EditCategory.aspx?category_id=" + id);
        }


    }

    protected void btnDeleteCategory_Click(object sender, EventArgs e)
    {
        int category_id = 0;
        if (gridCategoryList.SelectedIndex != -1)
        {
            category_id = Convert.ToInt32(gridCategoryList.SelectedRow.Cells[0].Text);
            Category category = new Category();
            category.DeleteCategory(connectionString, category_id);
            FillCategoryGrid();
        }
    }

}
