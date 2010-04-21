using System;
using System.Web.UI;

namespace Controls
{
    public partial class DetailsViewData : UserControl
    {
        void Page_Init(object sender, EventArgs e)
        {
            if(Request["act"] != null)
            {
                switch(Request["act"])
                {
                    case "read":
                        PlaceHolderOperation.Controls.Add(LoadControl("~/Controls/ReadData.ascx"));
                        return;
                    case "edit":
                        PlaceHolderOperation.Controls.Add(LoadControl("~/Controls/EditData.ascx"));
                        return;
                    case "create":
                        PlaceHolderOperation.Controls.Add(LoadControl("~/Controls/CreateData.ascx"));
                        return;
                    default:
                        Response.Redirect(Request.Path);
                        return;
                }
            }

            PlaceHolderOperation.Controls.Add(LoadControl("~/Controls/CreateData.ascx"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}