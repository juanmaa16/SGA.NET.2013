<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Reporte_comisiones.aspx.cs" Inherits="UI.Web.Reporte_comisiones" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="opciones" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <%@ register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
        namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="reports">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
            InteractiveDeviceInfos="(Colección)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
            Width="100%">
            <LocalReport ReportPath="Report2.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="Comisiones" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData"
        TypeName="UI.Web.tp2_netDataSetTableAdapters.comisionesTableAdapter"></asp:ObjectDataSource>
</asp:Content>
