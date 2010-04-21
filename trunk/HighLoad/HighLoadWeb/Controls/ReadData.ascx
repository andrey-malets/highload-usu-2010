<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReadData.ascx.cs" Inherits="Controls.ReadData" %>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr class="title">
        <th colspan="2" class="view">Detailed Information</th>
    </tr>
    <tr>
        <td class="titleview">ID</td>
        <td class="view"><asp:Label ID="Id" runat="server"><%= Entity.Id %></asp:Label></td>
    </tr>
    <tr>
        <td class="titleview">Number</td>
        <td class="view"><asp:Label ID="Number" runat="server"><%= Entity.Number %></asp:Label></td>
    </tr>
    <tr>
         <td class="titleview">Name</td>
         <td class="view"><asp:Label ID="Name" runat="server"><%= Entity.Name %></asp:Label></td>
    </tr>
    <tr>
        <td class="titleview">Revision Time</td>
        <td class="view"><asp:Label ID="RevisionTime" runat="server"><%= Entity.RevisionTime %></asp:Label></td>
    </tr>
    <tr class="title">
        <td colspan="2" class="view">
            <asp:HyperLink ID="Edit" runat="server" 
                ToolTip="Click here to edit the current record" 
                ForeColor="White">Edit</asp:HyperLink>
            <asp:LinkButton ID="Delete" runat="server" 
                ToolTip="Click here to delete" 
                OnClientClick="return confirm('Do you really want to delete this record?');" 
                ForeColor="White" OnClick="DeleteItem">Delete</asp:LinkButton>
            <asp:HyperLink ID="New" runat="server" 
                ToolTip="Click here to add a new record" ForeColor="White">New</asp:HyperLink>
        </td>
    </tr>
</table>