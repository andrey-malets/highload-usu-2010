<%@ Control Language="C#" AutoEventWireup="true" CodeFile="~/Controls/AllViewlData.ascx.cs" Inherits="Controls.AllViewlData" %>

<asp:Label ID="Empty" runat="server" Visible="false" Text="There's no data to show in this view." />
<asp:Repeater ID="ViewAllData" runat="server" OnItemDataBound="ViewAllData_ItemDataBound">
    <HeaderTemplate>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr class="title">
        <th class="view"></th>
        <th class="view">Number</th>
        <th class="view">Name</th>
        <th class="view">Revision Time</th>
    </tr>
    </HeaderTemplate>
    <ItemTemplate>
    <tr>
        <td class="view"><asp:LinkButton ID="SelectLink" runat="server" 
            Text="select" OnClick="SelectLink_Click" CommandArgument=<%# Eval("Id")%> />
        </td>
        <td class="view"><%# Eval("Number")%></td>
        <td class="view"><%# Eval("Name")%></td>
        <td class="view"><%# Eval("RevisionTime")%></td>
    </tr>
    </ItemTemplate>
    <FooterTemplate>
        <asp:Repeater ID="ViewPage" runat="server" OnItemCommand="ViewPage_ItemCommand">
            <HeaderTemplate>
    <tr class="title">
        <td colspan="4" class="view" align="center">            
            </HeaderTemplate>
            <ItemTemplate>
                <asp:LinkButton ID="PageLink" runat="server" ForeColor="White" 
                    Font-Underline = "<%# Container.DataItem.ToString() != ((PageNumber + 1).ToString()) %>"
                    CommandArgument="<%# Container.DataItem %>">
                    <%# Container.DataItem %>
                </asp:LinkButton> 
            </ItemTemplate>
            <FooterTemplate>
        </td>
    </tr>          
            </FooterTemplate>
        </asp:Repeater>
</table>
    </FooterTemplate>
</asp:Repeater> 