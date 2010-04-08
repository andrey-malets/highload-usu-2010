using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridViewData.DataSource = TestServer.GetAllData();
            GridViewData.DataBind();
        }
    }

    protected void DetailsViewData_ItemCreated(object sender, EventArgs e)
    {
        if (DetailsViewData.FooterRow != null)
        {
            int commandRowIndex = DetailsViewData.Rows.Count - 1;
            DetailsViewRow commandRow = DetailsViewData.Rows[commandRowIndex];

            DataControlFieldCell cell = (DataControlFieldCell)commandRow.Controls[0];
            foreach (Control ctl in cell.Controls)
            {
                LinkButton link = ctl as LinkButton;
                if (link != null)
                {
                    if (link.CommandName == "Delete")
                    {
                        link.ToolTip = "Click here to delete";
                        link.OnClientClick = "return confirm('Do you really want to delete this record?');";
                    }
                    else if (link.CommandName == "New")
                    {
                        link.ToolTip = "Click here to add a new record";
                    }
                    else if (link.CommandName == "Edit")
                    {
                        link.ToolTip = "Click here to edit the current record";
                    }
                }
            }
        }
    }

    protected void HighLoadGridView_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {
        GridViewData.DataSource = TestServer.GetAllData();
        GridViewData.PageIndex = e.NewPageIndex;
        GridViewData.DataBind();
    }

    protected void HighLoadDetailsView_PageIndexChanging(Object sender, DetailsViewPageEventArgs e)
    {
        DetailsViewData.DataSource = TestServer.GetAllData();
        DetailsViewData.PageIndex = e.NewPageIndex + GridViewData.PageSize * GridViewData.PageIndex;
        DetailsViewData.DataBind();
    }

    protected void HighLoadGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        DetailsViewData.ChangeMode(DetailsViewMode.ReadOnly);
        DetailsViewData.DataSource = TestServer.GetAllData();
        DetailsViewData.PageIndex = GridViewData.SelectedIndex + GridViewData.PageSize * GridViewData.PageIndex;
        DetailsViewData.DataBind();
    }

    protected void HighLoadDetailsView_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        DetailsViewData.ChangeMode(DetailsViewMode.Edit);
        DetailsViewData.DataSource = TestServer.GetAllData();
        DetailsViewData.PageIndex = GridViewData.SelectedIndex;
        DetailsViewData.DataBind();
    }

    protected void HighLoadDetailsView_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
    {
        TestServer.DeleteData(new Guid(GridViewData.SelectedDataKey.Value.ToString()));
        DetailsViewData.ChangeMode(DetailsViewMode.Insert);
        GridViewData.DataSource = TestServer.GetAllData();
        GridViewData.SelectedIndex = -1;
        GridViewData.DataBind();
    }

    protected void HighLoadDetailsView_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        Guid id = new Guid(GridViewData.SelectedDataKey.Value.ToString());
        int number = int.Parse(((TextBox)DetailsViewData.Rows[1].Controls[1].Controls[0]).Text);
        string name = ((TextBox)DetailsViewData.Rows[2].Controls[1].Controls[0]).Text;
        TestServer.UpdateData(id, number, name);
        DetailsViewData.ChangeMode(DetailsViewMode.ReadOnly);
        List<DataContract> allData = TestServer.GetAllData();
        DetailsViewData.DataSource = allData;
        DetailsViewData.DataBind();
        GridViewData.DataSource = allData;
        GridViewData.DataBind();
    }

    protected void HighLoadDetailsView_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        TestServer.AddData(getHighLoadDataString());
        List<DataContract> allData = TestServer.GetAllData();
        DetailsViewData.DataSource = allData;
        DetailsViewData.DataBind();
        GridViewData.DataSource = allData;
        GridViewData.DataBind();
    }

    private DataContract getHighLoadDataString()
    {
        //string id = ((TextBox)DetailsViewData.Rows[0].Controls[1].Controls[0]).Text;
        int number = int.Parse(((TextBox)DetailsViewData.Rows[1].Controls[1].Controls[0]).Text);
        string name = ((TextBox)DetailsViewData.Rows[2].Controls[1].Controls[0]).Text;
        return new DataContract(number, name);
    }
}

