<%@ Page Title="Materia" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>
    <asp:Content ID="opciones" ContentPlaceHolderID="opciones" runat="server">
    <asp:Panel ID="PanelPrincipal" runat="server">
        <asp:HyperLink ID="hlUsuarios" runat="server" NavigateUrl="~/Usuarios.aspx">Usuarios</asp:HyperLink>
        <br />
        <asp:HyperLink ID="hlEspecialidades" runat="server" NavigateUrl="~/Especialidades.aspx">Especialidades</asp:HyperLink>
        <br />
        <asp:HyperLink ID="hlDocentesCursos" runat="server" NavigateUrl="~/DocentesCursos.aspx">Docentes Cursos</asp:HyperLink>
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
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White" DataKeyNames="idMateria" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="idMateria" DataField="idMateria" />
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText="Plan" DataField="DescPlan" />
                <asp:BoundField HeaderText="HSemanales" DataField="HSemanales" />
                <asp:BoundField HeaderText="HTotales" DataField="HTotales" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="idPlan" runat="server" Text="idPlan: "></asp:Label>
        <asp:DropDownList ID="idPlanDDL" runat="server" DataSourceID="SqlDataSource1" 
            DataTextField="desc_plan" DataValueField="id_plan">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnStringLocal %>" 
            SelectCommand="SELECT [id_plan], [desc_plan] FROM [planes]">
        </asp:SqlDataSource>
        <br />
        <asp:Label ID="descMateria" runat="server" Text="descMateria: "></asp:Label>
        <asp:TextBox ID="descMateriaTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="descMateriaTextBox"
            ErrorMessage='Ingrese la descripción' EnableClientScript="true" SetFocusOnError="true"
            Text="*"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="hsSemanalesLabel" runat="server" Text="hsSemanales: "></asp:Label>
        <asp:TextBox ID="hsSemanalesTextBox" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="hsSemanalesTextBox"
            ErrorMessage='Ingrese las horas semanales' EnableClientScript="true" SetFocusOnError="true"
            Text="*"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="hsTotalesLabel" runat="server" Text="hsTotales: "></asp:Label>
        <asp:TextBox ID="hsTotalesTextBox" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="hsTotalesTextBox"
            ErrorMessage='Ingrese las horas totales' EnableClientScript="true" SetFocusOnError="true"
            Text="*"></asp:RequiredFieldValidator>
        <br />
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" 
                onclick="cancelarLinkButton_Click1">Cancelar</asp:LinkButton>
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
