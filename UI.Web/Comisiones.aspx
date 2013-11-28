<%@ Page Title="Comision" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" %>

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
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White" DataKeyNames="idComision" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="ID Comisión" DataField="idComision" />
                <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                <asp:BoundField HeaderText="Año Especialidad" DataField="anioEspecialidad" />
                <asp:BoundField HeaderText="Plan" DataField="descPlan" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="idPlanLabel" runat="server" Text="idPlan: "></asp:Label>
        <asp:DropDownList ID="idPlanDDL" runat="server" DataSourceID="SqlDataSource1" DataTextField="desc_plan"
            DataValueField="id_plan">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStringLocal %>"
            SelectCommand="SELECT [id_plan], [desc_plan] FROM [planes]"></asp:SqlDataSource>
        <br />
        <asp:Label ID="DescripcionLabel" runat="server" Text="Descripcion: "></asp:Label>
        <asp:TextBox ID="DescripcionTextBox" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DescripcionTextBox"
            ErrorMessage='Ingrese la descripción' EnableClientScript="true" SetFocusOnError="true"
            Text="*"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="anioEspecialidad" runat="server" Text="Año especialidad: "></asp:Label>
        <asp:TextBox ID="anioEspecialidadTextBox" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="anioEspecialidadTextBox"
            ErrorMessage='Ingrese el id de plan' EnableClientScript="true" SetFocusOnError="true"
            Text="*"></asp:RequiredFieldValidator>
        <br />
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click1" CausesValidation="False">Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
    </asp:Panel>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Errores:"
        ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" />
</asp:Content>
