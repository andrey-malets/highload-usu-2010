using System;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public void ViewAllData_Select(Guid id)
    {
        ViewDetailsData.ViewElement(id);
    }
}
