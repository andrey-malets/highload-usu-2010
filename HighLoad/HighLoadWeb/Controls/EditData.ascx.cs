using System;
using System.Web.UI;
using App_Code;
using Common.DataContracts;

namespace Controls
{
    public partial class EditData : UserControl
    {
        protected DataRow Entity { get; private set; }

        public string GetUrl()
        {
            string url = Request.Path + "?";

            if (Request["id"] != null)
                url += "&&id=" + Request["id"] + "&&act=read";

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
                {
                    Number.Text = Entity.Number.ToString();
                    Name.Text = Entity.Name;
                    return;
                }
            }
            Response.Redirect(Request.Path);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CancelLink.NavigateUrl = GetUrl();
        }


        protected void Update(object sender, EventArgs e)
        {
            var id = new Guid(Request["id"]);
            int number = int.Parse(Number.Text);
            string name = Name.Text;
            TestServer.UpdateData(id, number, name);
            Response.Redirect(GetUrl());
        }
    }
}
