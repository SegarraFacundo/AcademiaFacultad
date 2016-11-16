<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reportes.aspx.cs" Inherits="Reportes" MasterPageFile="Site.master"%>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="reportesContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <asp:LinkButton ID="linkReporteCursos" runat="server" OnClick="linkReporteCursos_Click">Reporte de Cursos</asp:LinkButton>
    <br />
    <asp:LinkButton ID="linkReportePlanes" runat="server" OnClick="linkReportePlanes_Click">Reporte de Planes</asp:LinkButton>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="CrystalReport.rpt">
        </Report>
    </CR:CrystalReportSource>
</asp:Content>

