<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="cargaNota.aspx.cs" Inherits="UI.Web.cargaNota" %>

<asp:Content ID="Content1" ContentPlaceHolderID="opciones" runat="server">
    <asp:Panel ID="PanelPrincipal" runat="server">
        <asp:HyperLink ID="hlAlumnosInscripciones" runat="server" NavigateUrl="~/AlumnosInscripciones.aspx">Inscribirse a materia</asp:HyperLink>
        <br />
        <asp:HyperLink ID="hlCursos" runat="server" NavigateUrl="~/Cursos.aspx">Cursos</asp:HyperLink>
        <br />
        <asp:HyperLink ID="hlComisiones" runat="server" NavigateUrl="~/Comisiones.aspx">Comisiones</asp:HyperLink>
        <br />
        <asp:HyperLink ID="hlMaterias" runat="server" NavigateUrl="~/Materias.aspx">Materias</asp:HyperLink>
        <br />
        <asp:HyperLink ID="hlEspecialidades" runat="server" NavigateUrl="~/Especialidades.aspx">Especialidades</asp:HyperLink>
        <br />
        <asp:HyperLink ID="hlPlanes" runat="server" NavigateUrl="~/Planes.aspx">Planes</asp:HyperLink>
        <br />
        <asp:HyperLink ID="hlCargaNota" runat="server" NavigateUrl="~/CargaNota.aspx">Cargar nota</asp:HyperLink>
        <br />
        <asp:HyperLink ID="hlAlumnos" runat="server" NavigateUrl="~/Alumnos.aspx">Alumnos</asp:HyperLink>
        <br />
        <asp:HyperLink ID="hlProfesores" runat="server" NavigateUrl="~/Profesores.aspx">Profesores</asp:HyperLink>
        <br />
        <asp:HyperLink ID="hlUsuarios" runat="server" NavigateUrl="~/Usuarios.aspx">Usuarios</asp:HyperLink>
        <br />
        <asp:HyperLink ID="hlDocentesCursos" runat="server" NavigateUrl="~/DocentesCursos.aspx">Asignar docente</asp:HyperLink>
        <br />
        <asp:HyperLink ID="hlReportes" runat="server" NavigateUrl="~/Reportes.aspx">Reportes</asp:HyperLink>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:DropDownList ID="CursosDocenteDDL" runat="server">
    </asp:DropDownList>
    <br />
    <asp:LinkButton ID="cargarNotasLinkButton" runat="server" OnClick="cargarNotasLinkButton_Click">Cargar notas</asp:LinkButton>
    <br />
    <asp:Label ID="ErrorLabel" runat="server" Text="Label" Visible="False" Width="446px"></asp:Label>
</asp:Content>
