using System;
using System.Web.UI;
using App_Code;
using Common.DataContracts;

namespace Controls
{
    public partial class EditData : UserControl
    {
//        protected DataRow Entity { get; private set; }


        private DataRow entity;

        protected Guid? EntityId
        {
            get
            {
                if (Request["id"] == null)
                    return null;

                return new Guid(Request["id"]);
            }
        }


        protected DataRow Entity
        {
            get 
            { 
                return entity 
                            ?? 
                         (entity = (!EntityId.HasValue ? new DataRow() : TestServer.GetData(EntityId.Value))); 
            }
        }


        public string GetUrl()
        {
            string url = Request.Path + "?";

            if (Request["id"] != null)
                url += "&&id=" + Request["id"] + "&&act=read";

            if (Request["page"] != null)
                url += "&&page=" + Request["page"];

            return url;
        }

//        void Page_Init(object sender, EventArgs e)
//        {
//            if (Request["id"] != null)
//            {
//                var id = new Guid(Request["id"]);
////                Entity = TestServer.GetData(id);
//                if (Entity != null)
//                {
//                    Number.Text = Entity.Number.ToString();
//                    Name.Text = Entity.Name;
//                    return;
//                }
//            }
//            Response.Redirect(Request.Path);
//        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CancelLink.NavigateUrl = GetUrl();
            DataBind();
        }


        protected void Update(object sender, EventArgs e)
        {
            var id = new Guid(Request["id"]);
            int number = int.Parse(Number.Text);
            string name = Name.Text;
//            TestServer.UpdateData(id, number, name);
            Entity.Name = name;
            Entity.Number = number;
            TestServer.AddData(Entity);
            Response.Redirect(GetUrl());
        }
    }
}