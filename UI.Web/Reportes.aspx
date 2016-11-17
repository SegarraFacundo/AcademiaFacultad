<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reportes.aspx.cs" Inherits="Reportes" MasterPageFile="Site.master"%>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="reportesContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:LinkButton ID="lblCursos" Text="Imprimir reporte Cursos" runat="server" OnClick="lblCursos_Click"></asp:LinkButton>
    <br />
    <asp:LinkButton ID="lblPlanes" Text ="Imprimir reporte Planes" runat="server" OnClick="lblPlanes_Click"></asp:LinkButton>
    <br />


    <CR:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="True"  Height="1202px" ReportSourceID="CrystalReportSource1"  ToolPanelWidth="200px" Width="1104px" Visible="False" />


    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="CrystalReport.rpt">
        </Report>
    </CR:CrystalReportSource>
    <p>
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </p>

</asp:Content>