using System;
using System.Web.UI;

namespace Controls
{
    public partial class DetailsViewData : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ViewElement(Guid id)
        {
            Example.Text = id.ToString();
        }
    }
}