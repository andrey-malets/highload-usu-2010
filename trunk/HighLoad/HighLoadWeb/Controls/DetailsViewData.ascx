<%@ Control Language="C#" AutoEventWireup="true" CodeFile="~/Controls/DetailsViewData.ascx.cs" Inherits="Controls.DetailsViewData" %>

<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr class="title">
        <th colspan="2" class="view">Detailed Information</th>
    </tr>
    <asp:Panel runat="server" Visible="<%# EntityId.HasValue %>">
    <tr>
        <td class="titleview">ID</td>
        <td class="view">
            <asp:Label ID="Id" runat="server"><%= Entity.Id %></asp:Label>
        </td>
    </tr>
    </asp:Panel>
    <tr>
        <td class="titleview">Number</td>
        <td class="view">
            <asp:TextBox ID="Number" runat="server"
                Text="<%# EntityId.HasValue ? Entity.Number.ToString() : string.Empty %>" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Number" Text="*"
                ErrorMessage="Number field can not be empty." />
            <asp:RegularExpressionValidator runat="server" Text="*"
                ControlToValidate="Number" ValidationExpression="\d+" 
                ErrorMessage = "Number field must be an integer." />
        </td>
    </tr>
    <tr>
         <td class="titleview">Name</td>
         <td class="view">
            <asp:TextBox ID="Name" Text="<%#Entity.Name%>" runat="server" />
            <asp:RequiredFieldValidator runat="server" Text="*" ControlToValidate="Name" 
                ErrorMessage="Name field can not be empty." />
        </td>
    </tr>
    <asp:Panel runat="server" Visible="<%# EntityId.HasValue %>">
    <tr>
        <td class="titleview">Revision Time</td>
        <td class="view">
            <asp:Label ID="RevisionTime" runat="server"><%= Entity.RevisionTime %></asp:Label>
        </td>
    </tr>
    </asp:Panel>
    <tr class="title">
        <td colspan="2" class="view">
            <asp:LinkButton runat="server" Visible="<%# EntityId.HasValue %>"
                ToolTip="Click here to update the current record" OnClick="UpdateItem" 
                ForeColor="White">Update</asp:LinkButton>
            <asp:LinkButton runat="server" Visible="<%# EntityId.HasValue %>" 
                ToolTip="Click here to delete the current record" OnClick="DeleteItem" 
                OnClientClick="return confirm('Do you really want to delete this record?');" 
                ForeColor="White">Delete</asp:LinkButton>
            <asp:HyperLink runat="server" Visible="<%# EntityId.HasValue %>" 
                ToolTip="Click here to add a new record" NavigateUrl="<%#GetUrl()%>" 
                ForeColor="White">New</asp:HyperLink>
            <asp:LinkButton runat="server" Visible="<%# !EntityId.HasValue %>"
                ToolTip="Click here to insert the current record" OnClick="InsertItem" 
                ForeColor="White">Insert</asp:LinkButton>
            <asp:HyperLink runat="server" NavigateUrl="<%#Request.Url.AbsoluteUri%>" 
                ToolTip="Click here to cancel" 
                ForeColor="White">Cansel</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:ValidationSummary runat="server" ShowSummary="true"
                HeaderText="The following errors occurred:"  />
        </td>
    </tr>
</table>
