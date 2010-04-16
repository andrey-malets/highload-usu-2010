using System;
using System.Collections;
using System.Web.UI.WebControls;
using App_Code;

namespace Controls
{
    public partial class AllViewlData : System.Web.UI.UserControl
    {
        public delegate void SelectHandler(Guid id);       
        public event SelectHandler Select;

        private const int PageSize = 10;

        public int PageNumber
        {
            get
            {
                if (ViewState["PageNumber"] != null)
                    return Convert.ToInt32(ViewState["PageNumber"]);
                return 0;
            }
            set
            {
                ViewState["PageNumber"] = value;
            }
        }

        protected void ViewPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
            LoadData();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                LoadData();
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
                                      PageSize = PageSize,
                                      CurrentPageIndex = PageNumber
                                  };

                ViewAllData.DataSource = pgitems;
                ViewAllData.DataBind();
            }
        }

        protected void SelectLink_Click(object sender, EventArgs e)
        {
            if (Select != null)
            {
                var selectIdButton = sender as LinkButton;
                if (selectIdButton != null)
                {
                    string id = selectIdButton.CommandArgument;
                    Select(new Guid(id));
                }
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