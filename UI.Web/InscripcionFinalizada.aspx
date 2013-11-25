<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="InscripcionFinalizada.aspx.cs" Inherits="UI.Web.InscripcionFinalizada" %>

<asp:Content ID="opciones" ContentPlaceHolderID="opciones" runat="server">
    <asp:Panel ID="PanelPrincipal" runat="server">
        <asp:HyperLink ID="hlUsuarios" runat="server" NavigateUrl="~/Usuarios.aspx">Usuarios</asp:HyperLink>
        <br />
        <asp:HyperLink ID="hlEspecialidades" runat="server" NavigateUrl="~/Especialidades.aspx">Especialidades</asp:HyperLink>
        <br />
        <asp:HyperLink ID="hlPlanes" runat="server" NavigateUrl="~/Planes.aspx">Planes</asp:HyperLink>
        <br />
        <asp:HyperLink ID="hlMaterias" runat="server" NavigateUrl="~/Materias.aspx">Materias</asp:HyperLink>
        <br />
        <asp:HyperLink ID="hlCursos" runat="server" NavigateUrl="~/Cursos.aspx">Cursos</asp:HyperLink>
        <br />
        <asp:HyperLink ID="hlComisiones" runat="server" NavigateUrl="~/Comisiones.aspx">Comisiones</asp:HyperLink>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <h2>
        Inscripción realizada con éxito:
    </h2>
    <table style="width: 100%; border: 0;">
        <tr>
            <td style="height: 23px; width: 123px;">
                <b>Materia</b>
            </td>
            <td style="height: 23px">
                <asp:Label ID="lblMateria" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 123px">
                <b>Comisión</b>
            </td>
            <td>
                <asp:Label ID="lblComision" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
