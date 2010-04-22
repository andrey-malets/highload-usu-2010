using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_RegexValidator : System.Web.UI.UserControl
{
    public string Regex { get; set; }
    public string ControlToValidate { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        DataBind();
    }
}
