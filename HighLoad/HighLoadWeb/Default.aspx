<%@ Page Title="HighLoad" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Default" %>
<%@ Register TagPrefix="view" TagName="AllViewData" Src="~/Controls/AllViewlData.ascx" %>
<%@ Register TagPrefix="view" TagName="DetailsViewData" Src="~/Controls/DetailsViewData.ascx" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table>
        <tr>
            <td valign="top" style="border:solid 1px black;">
                <view:AllViewData ID="ViewAllData" runat="server" OnSelect="ViewAllData_Select" />
            </td>
            <td valign="top" style="border:solid 1px black;">
                <view:DetailsViewData ID="ViewDetailsData" runat="server" />
            </td>
        </tr>
    </table>  
</asp:Content>
