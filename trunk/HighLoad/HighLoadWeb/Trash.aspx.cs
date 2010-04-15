using System;
using Common.DataContracts;

public partial class Trash : System.Web.UI.Page
{
    protected DataRow Entity { get; private set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        GetEntity();
    }

    private void GetEntity()
    {
        if (Request["id"] == null)
            Entity = new DataRow();
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