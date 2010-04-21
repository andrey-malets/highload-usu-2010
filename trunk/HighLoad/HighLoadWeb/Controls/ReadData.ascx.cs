using System;
using System.Web.UI;
using App_Code;
using Common.DataContracts;

namespace Controls
{
    public partial class ReadData : UserControl
    {
        protected DataRow Entity { get; private set; }

        public string GetCreateUrl()
        {
            string url = Request.Path + "?act=create";

            if (Request["id"] != null)
                url += "&&id=" + Request["id"];

            if (Request["page"] != null)
                url += "&&page=" + Request["page"];

            return url;
        }

        public string GetEditUrl()
        {
            string url = Request.Path + "?act=edit";

            if (Request["id"] != null)
                url += "&&id=" + Request["id"];

            if (Request["page"] != null)
                url += "&&page=" + Request["page"];

            return url;
        }

        void Page_Init(object sender, EventArgs e)
        {
            if (Request["id"] != null)
            {
                var id = new Guid(Request["id"]);
                Entity = TestServer.GetData(id);
                if (Entity != null)
                    return;
            }
            Response.Redirect(Request.Path);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            New.NavigateUrl = GetCreateUrl();
            Edit.NavigateUrl = GetEditUrl();
        }

        protected void DeleteItem(object sender, EventArgs e)
        {
            TestServer.DeleteData(new Guid(Request["id"]));
            Response.Redirect(Request.Path);
        }
    }
}