using System;
using System.Collections;
using System.Web.UI.WebControls;
using App_Code;

namespace Controls
{
    public partial class AllViewlData : System.Web.UI.UserControl
    {
        private const int PageSize = 10;

        public int PageNumber { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["page"] != null)
            {
                int page;
                if (int.TryParse(Request["page"], out page))
                {
                    PageNumber = page;
                }
            }

            if (PageNumber < 1) PageNumber = 1;

            if (!Page.IsPostBack)
                LoadData();
        }

        public string GetSelectUrl(string id)
        {
            string url = Request.Path + "?id=" + id;

            if (Request["page"] != null)
                url += "&page=" + PageNumber;

            return url;
        }

        public string GetPageUrl(string pageNumber)
        {
            string url = Request.Path + "?";
            if(Request["id"] != null)
                url += "id=" + Request["id"] + "&";
            url += "page=" + pageNumber;
            return url;
        }

        private void LoadData()
        {
            var allData = TestServer.GetAllData();
            if (allData.Count == 0)
            {
                ViewAllData.Visible = false;
                Empty.Visible = true;
            }
            else
            {
                var pgitems = new PagedDataSource
                                  {
                                      DataSource = allData,
                                      AllowPaging = true,
                                      PageSize = PageSize
                                  };

                if (pgitems.PageCount < PageNumber)
                    PageNumber = pgitems.PageCount;
                   
                pgitems.CurrentPageIndex = PageNumber - 1;

                ViewAllData.DataSource = pgitems;
                ViewAllData.DataBind();
            }
        }

        public void ViewAllData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var pageItems = ViewAllData.DataSource as PagedDataSource;
            if (pageItems != null)
            {
                var viewPage = e.Item.FindControl("ViewPage") as Repeater;
                if (viewPage != null)
                {
                    if (pageItems.PageCount > 1)
                    {
                        var pages = new ArrayList();
                        for (int i = 0; i < pageItems.PageCount; i++)
                            pages.Add((i + 1).ToString());

                        viewPage.DataSource = pages;
                        viewPage.DataBind();
                    }
                    else
                        viewPage.Visible = false;
                }
            }
        }
    }
}