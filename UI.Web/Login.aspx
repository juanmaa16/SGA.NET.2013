<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <br />
    <br />
    <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
    <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <recaptcha:RecaptchaControl ID="recaptcha" runat="server" Theme="red" PublicKey="6Lev-OESAAAAACY8qYIcrsv8yLAlCHA6RoJ-vcxZ"
        PrivateKey="6Lev-OESAAAAAG-CBvcnGwdzSWowmKZ4-Z4LUYhp" />
    <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" />
</asp:Content>
