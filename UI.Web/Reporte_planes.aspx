<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Reporte_planes.aspx.cs" Inherits="UI.Web.Reporte_planes" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="opciones" ContentPlaceHolderID="opciones" runat="server">
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
    <%@ register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
        namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
        InteractiveDeviceInfos="(Colección)" WaitMessageFont-Names="Verdana" 
        WaitMessageFont-Size="14pt" Width="100%">
        <LocalReport ReportPath="Report3.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="PlanesDataSet" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData"
        TypeName="UI.Web.tp2_netDataSetTableAdapters.planesTableAdapter"></asp:ObjectDataSource>
</asp:Content>
