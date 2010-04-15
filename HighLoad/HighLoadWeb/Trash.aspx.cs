using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

public partial class Trash : System.Web.UI.Page
{
    protected DataContract Entity { get; private set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        GetEntity();
    }

    private void GetEntity()
    {
        if (Request["id"] == null)
            Entity = new DataContract();
        else
        {
            //load DataContract by id from storage
        }
    }

    protected void Save(object sender, EventArgs e)
    {
        Validate();
        if (!this.IsValid)
            return;

        GetFormValues();

        //save using storage client

        //redirect
    }

    private void GetFormValues()
    {
        Entity.Name = Name.Text;
    }
}