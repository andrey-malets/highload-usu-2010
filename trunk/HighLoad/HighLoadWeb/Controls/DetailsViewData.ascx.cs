using System;
using System.Web.UI;
using App_Code;
using Common.DataContracts;

namespace Controls
{
    public partial class DetailsViewData : UserControl
    {
        protected Guid? EntityId { get; private set; }
        protected DataRow Entity { get; private set; }

        public string GetUrl()
        {
            return Request.Path + "?page=" + (Request["page"] ?? "1");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["id"] != null)
                {
                    try
                    {
                        var entityId = new Guid(Request["id"]);
                        Entity = TestServer.GetData(entityId);
                        if (Entity != null) EntityId = entityId;
                    }
                    catch { }
                }

                if (Entity == null) Entity = new DataRow();

                DataBind();
            }
        }

        protected void DeleteItem(object sender, EventArgs e)
        {
            try
            {
                TestServer.DeleteData(new Guid(Request["id"]));
            }
            catch { }
            finally
            {
                Response.Redirect(GetUrl());
            }
        }

        protected void InsertItem(object sender, EventArgs e)
        {
            try
            {
                TestServer.AddData(new DataRow(int.Parse(Number.Text), Name.Text));
            }
            catch { }
            finally
            {
                Response.Redirect(GetUrl());
            }
        }

        protected void UpdateItem(object sender, EventArgs e)
        {
            try
            {
                TestServer.UpdateData(new Guid(Request["id"]), 
                    int.Parse(Number.Text), Name.Text);
            }
            catch { }
            finally
            {
                Response.Redirect(GetUrl());
            }
        }
    }
}