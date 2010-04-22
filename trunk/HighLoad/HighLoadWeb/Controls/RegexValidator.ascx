<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RegexValidator.ascx.cs" Inherits="Controls_RegexValidator" %>
            <asp:RequiredFieldValidator runat="server" Text="*" 
                ControlToValidate="<%#ControlToValidate%>" ErrorMessage="Number field can not be empty." />
            <asp:RegularExpressionValidator runat="server"  Text="*" 
                    ControlToValidate="<%#ControlToValidate%>" ValidationExpression="<%#Regex%>" 
                    ErrorMessage = "Number field must be an integer." />
