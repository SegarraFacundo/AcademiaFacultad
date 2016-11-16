<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reportes.aspx.cs" Inherits="Reportes" MasterPageFile="Site.master"%>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="reportesContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <asp:ImageButton ID="Img1" Height="50px" ImageUrl="http://www.dmca.com/img/pdf-icon.png" runat="server" onclick="Img1_Click" />


    <CR:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="True"  Height="1202px" ReportSourceID="CrystalReportSource1"  ToolPanelWidth="200px" Width="1104px" />
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="CrystalReport.rpt">
        </Report>
    </CR:CrystalReportSource>
    <p>
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </p>

</asp:Content>