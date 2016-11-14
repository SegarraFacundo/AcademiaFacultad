<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VerInscripciones.aspx.cs" Inherits="VerInscripciones" MasterPageFile="Site.master" %>

<asp:Content ID="estadoAcademicoContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat ="server">





<asp:GridView ID="dgvInscripcones" runat="server">
</asp:GridView>
<asp:Panel ID="pageOptions" runat="server">
    <asp:LinkButton ID="imprimirReporte" text="Imprimir Reporte" runat="server"></asp:LinkButton>
    <asp:LinkButton ID="lbVolver" text="Volver" runat="server"></asp:LinkButton>
</asp:Panel>
 <asp:Label ID="lblError" runat="server"></asp:Label>





</asp:Content>