<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EstadoAcademico.aspx.cs" Inherits="VerInscripciones" MasterPageFile="~/Site.master"%>


<asp:Content ID="verInscripcionesContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">





    <asp:GridView ID="dgvInscripciones" runat="server" AutoGenerateColumns="False">
        <Columns>
        <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
         <asp:BoundField HeaderText="Curso" DataField="desc_curso" />
         <asp:BoundField HeaderText="Condicion" DataField="condicion" />
         <asp:BoundField HeaderText="Nota" DataField="nota" />
    </Columns>
    </asp:GridView>





</asp:Content>

