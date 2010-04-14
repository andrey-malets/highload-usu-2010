using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using Common;

public partial class Default : Page
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
            if(commandRowIndex == -1) return;
            var commandRow = DetailsViewData.Rows[commandRowIndex];

            var cell = (DataControlFieldCell)commandRow.Controls[0];
            foreach (Control ctl in cell.Controls)
            {
                var link = ctl as LinkButton;
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

    protected void HighLoadGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetIndex();
    }

    private void SetIndex()
    {
        if (GridViewData.PageIndex != -1 && GridViewData.Rows.Count != 0)
        {
            DetailsViewData.ChangeMode(DetailsViewMode.ReadOnly);
            SetDetailsViewDataPageIndex();
        }
    }

    private void SetDetailsViewDataPageIndex()
    {
        DetailsViewData.DataSource = TestServer.GetAllData();
        DetailsViewData.PageIndex = GridViewData.SelectedIndex + GridViewData.PageSize * GridViewData.PageIndex;
        DetailsViewData.DataBind();
    }

    protected void HighLoadDetailsView_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        if (e.NewMode != DetailsViewMode.ReadOnly && DetailsViewData.CurrentMode != DetailsViewMode.ReadOnly)
        {
            SetIndex();
            return;
        }
        DetailsViewData.ChangeMode(e.NewMode);

        if (e.NewMode == DetailsViewMode.Edit)
        {
            SetDetailsViewDataPageIndex();
        }
    }

    protected void HighLoadDetailsView_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
    {
        if (GridViewData.SelectedDataKey != null)
            TestServer.DeleteData(new Guid(GridViewData.SelectedDataKey.Value.ToString()));
        DetailsViewData.ChangeMode(DetailsViewMode.Insert);
        GridViewData.DataSource = TestServer.GetAllData();
        GridViewData.SelectedIndex = -1;
        GridViewData.DataBind();
    }

    protected void HighLoadDetailsView_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        if (GridViewData.SelectedDataKey != null)
        {
            var id = new Guid(GridViewData.SelectedDataKey.Value.ToString());
            DataContract dataContract = GetHighLoadDataString();
            if (dataContract != null)
                TestServer.UpdateData(id, dataContract.Number, dataContract.Name);
            else return;
        }
        DetailsViewData.ChangeMode(DetailsViewMode.ReadOnly);
        UpdateAllDataSource();
    }

    protected void HighLoadDetailsView_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        DataContract dataContract = GetHighLoadDataString();
        if(dataContract != null)
            TestServer.AddData(dataContract);
        UpdateAllDataSource();
    }

    private void UpdateAllDataSource()
    {
        List<DataContract> allData = TestServer.GetAllData();
        DetailsViewData.DataSource = allData;
        DetailsViewData.DataBind();
        GridViewData.DataSource = allData;
        GridViewData.DataBind();
    }

    private DataContract GetHighLoadDataString()
    {
        int number;
        string err = string.Empty;
        if(!int.TryParse(((TextBox)DetailsViewData.Rows[1].Controls[1].Controls[0]).Text, out number))
        {
            err = "Number field must be an integer.";
        }
        string name = ((TextBox)DetailsViewData.Rows[2].Controls[1].Controls[0]).Text;
        if (name.Equals(string.Empty))
        {
            err += "<br />Name field can not be empty.";
        }
        if (!err.Equals(string.Empty))
        {
            InsertValidator.ErrorMessage = err;
            InsertValidator.IsValid = false;
            return null;
        }
        return new DataContract(number, name);
    }
}

