using restaurantproject.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Menu = restaurantproject.Data.Menu;

public partial class MenuList : System.Web.UI.Page
{

    private string connectionString = WebConfigurationManager.ConnectionStrings["RestaurantDBConnectionString"].ConnectionString;


    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            FillMenuGrid();
        }
    }

    private void FillMenuGrid()
    {
        List<Menu> menuList = new List<Menu>();
        Menu menu = new Menu();
        menuList = menu.GetMenu(connectionString);
        gridMenuList.DataSource = menuList;
        gridMenuList.DataBind();
    }
    protected void btnNewItem_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddMenu.aspx");
    }


    protected void btnEditItem_Click(object sender, EventArgs e)
    {
        string item_id = hdnMenuID.Value;
        if (gridMenuList.SelectedIndex != -1)
            item_id = gridMenuList.SelectedRow.Cells[0].Text;
        Response.Redirect("EditMenu.aspx?itemid=" + item_id);
    }
    protected override void Render(HtmlTextWriter writer)
    {
        foreach (GridViewRow row in gridMenuList.Rows)
        {
            row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference
            (gridMenuList, "Select$" + row.RowIndex.ToString(), true));
        }
        base.Render(writer);
    }
    protected void gridMenuList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("OnMouseOver", "this.style.cursor='pointer';");
            e.Row.ToolTip = "Click on select row";
        }
    }

    protected void gridMenuList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteItem")
        {
            int item_id = Convert.ToInt32(e.CommandArgument);
            Menu menu = new Menu();
            menu.DeleteMenu(connectionString, item_id);
            FillMenuGrid();
        }
        if (e.CommandName == "UpdateMenu")
        {
            string id = e.CommandArgument.ToString();
            Response.Redirect("EditMenu.aspx?item_id=" + id);
        }

    }

    protected void btnDeleteItem_Click(object sender, EventArgs e)
    {
        int item_id = 0;
        if (gridMenuList.SelectedIndex != -1)
        {
            item_id = Convert.ToInt32(gridMenuList.SelectedRow.Cells[0].Text);
            Menu menu = new Menu();
            menu.DeleteMenu(connectionString, item_id);
            FillMenuGrid();
        }
    }




}



