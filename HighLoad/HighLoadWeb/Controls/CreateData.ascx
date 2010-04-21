<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CreateData.ascx.cs" Inherits="Controls.CreateData" %>

<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr class="title">
        <th colspan="2" class="view">Detailed Information</th>
    </tr>
    <tr>
        <td class="titleview">Number</td>
        <td class="view">
            <asp:TextBox ID="Number" runat="server" />
            <asp:RequiredFieldValidator runat="server" ID="NotEmptyNumberValidator" Text="*" 
                ControlToValidate="Number" ErrorMessage="Number field can not be empty." />
            <asp:RegularExpressionValidator runat="server" ID="NumberValidator" Text="*" 
                    ControlToValidate="Number" ValidationExpression="\d+" 
                    ErrorMessage = "Number field must be an integer." />
        </td>
    </tr>
    <tr>
         <td class="titleview">Name</td>
         <td class="view">
            <asp:TextBox ID="Name" runat="server" />
            <asp:RequiredFieldValidator runat="server" ID="NameValidator" Text="*" 
                ControlToValidate="Name" ErrorMessage="Name field can not be empty." />
        </td>
    </tr>
    <tr class="title">
        <td colspan="2" class="view">
            <asp:LinkButton ID="Edit" runat="server" 
                ForeColor="White" OnClick="Insert">Insert</asp:LinkButton>
           
            <asp:HyperLink ID="CancelLink" runat="server" ForeColor="White">Cancel</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:ValidationSummary runat="server" 
                HeaderText="The following errors occurred:" ShowSummary="true" />
        </td>
    </tr>
</table>