<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VerInscripciones.aspx.cs" Inherits="VerInscripciones" MasterPageFile="Site.master" %>

<asp:Content ID="estadoAcademicoContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat ="server">
    <header>
        <h2>Inscripciones</h2>
    </header>
<asp:GridView ID="dgvInscripcones" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="desc_curso" HeaderText="Materia" />
        <asp:BoundField DataField="condicion" HeaderText="Condicion" />
        <asp:BoundField DataField="id_inscripcion" HeaderText="id_inscripcion" Visible="False" />
    </Columns>
</asp:GridView>
<asp:Panel ID="pageOptions" runat="server">
    <asp:LinkButton ID="otraInscripcion" text="Insecibirse a otra materia" runat="server" OnClick="otraInscripcion_Click"></asp:LinkButton>
    <asp:LinkButton ID="lbVolver" text="Volver" runat="server" OnClick="lbVolver_Click"></asp:LinkButton>
</asp:Panel>
 <asp:Label ID="lblError" runat="server"></asp:Label>





</asp:Content>