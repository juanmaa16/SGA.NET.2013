<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="panelNotas.aspx.cs" Inherits="UI.Web.panelNotas" %>

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
        <asp:HyperLink ID="hlAlumnos" runat="server" NavigateUrl="~/Alumnos.aspx">Alumnos</asp:HyperLink>
        <br />
        <asp:HyperLink ID="hlProfesores" runat="server" NavigateUrl="~/Profesores.aspx">Profesores</asp:HyperLink>
        <br />
        <asp:HyperLink ID="hlUsuarios" runat="server" NavigateUrl="~/Usuarios.aspx">Usuarios</asp:HyperLink>
        <br />
        <asp:HyperLink ID="hlDocentesCursos" runat="server" NavigateUrl="~/DocentesCursos.aspx">Asignar docente</asp:HyperLink>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White" DataKeyNames="IdAlumno,IdCurso" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Id Alumno" DataField="IdAlumno" />
                <asp:BoundField HeaderText="Id Curso" DataField="IdCurso" />
                <asp:BoundField HeaderText="Nombre Alumno" DataField="NombreAlumno" />
                <asp:BoundField HeaderText="Apellido Alumno" DataField="ApellidoAlumno" />
                <asp:BoundField HeaderText="Condición" DataField="Condicion" />
                <asp:BoundField HeaderText="Nota" DataField="Nota" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
        <asp:TextBox ID="NombreTextBox" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NombreTextBox"
            ErrorMessage='Ingrese nombre' EnableClientScript="true" SetFocusOnError="true"
            Text="*"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="apellidoLabel" runat="server" Text="Apellido:"></asp:Label>
        <asp:TextBox ID="ApellidoTextBox" runat="server" Enabled="False" 
            ReadOnly="True"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="ApellidoTextBox" EnableClientScript="true" 
            ErrorMessage="Ingrese apellido" SetFocusOnError="true" Text="*"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="descripcionLabel1" runat="server" Text="Condición"></asp:Label>
        <asp:DropDownList ID="CondicionDDL" runat="server">
            <asp:ListItem>Libre</asp:ListItem>
            <asp:ListItem>Regular</asp:ListItem>
            <asp:ListItem>Aprobada</asp:ListItem>
            <asp:ListItem>Recursa</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="descripcionLabel2" runat="server" Text="Nota:"></asp:Label>
        <asp:DropDownList ID="NotaDDL" runat="server">
            <asp:ListItem Selected="True">0</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:TextBox ID="IdAlumnoTextBox" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="IdCursoTextBox" runat="server" Visible="False"></asp:TextBox>
        <br />
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click1"
                CausesValidation="False">Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
    </asp:Panel>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Errores:"
        ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" />
</asp:Content>
