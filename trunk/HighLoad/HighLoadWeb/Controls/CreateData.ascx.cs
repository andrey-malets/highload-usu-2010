using System;
using System.Web.UI;
using App_Code;
using Common.DataContracts;

namespace Controls
{
    public partial class CreateData : UserControl
    {
        public string GetUrl()
        {
            string url = Request.Path + "?";

            if (Request["id"] != null)
                url += "&&id=" + Request["id"] + "&&act=read";

            if (Request["page"] != null)
                url += "&&page=" + Request["page"];

            return url;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CancelLink.NavigateUrl = GetUrl();
        }

        protected void Insert(object sender, EventArgs e)
        {
            int number = int.Parse(Number.Text);
            string name = Name.Text;
            TestServer.AddData(new DataRow(number, name));
            Response.Redirect(GetUrl());
        }
    }
}
