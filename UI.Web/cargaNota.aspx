<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cargaNota.aspx.cs" Inherits="UI.Web.cargaNota" %>
<asp:Content ID="Content1" ContentPlaceHolderID="opciones" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:DropDownList ID="CursosDocenteDDL" runat="server">
    </asp:DropDownList>
    <br />
    <asp:LinkButton ID="cargarNotasLinkButton" runat="server" 
        onclick="cargarNotasLinkButton_Click">Cargar notas</asp:LinkButton>
    <br />
    <asp:Label ID="ErrorLabel" runat="server" Text="Label" Visible="False" 
        Width="446px"></asp:Label>
</asp:Content>
