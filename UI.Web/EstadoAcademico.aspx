<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EstadoAcademico.aspx.cs" Inherits="VerInscripciones" MasterPageFile="~/Site.master"%>


<asp:Content ID="verInscripcionesContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

<<<<<<< HEAD
    <header>
        <h2>Estado académico</h2>
    </header>
=======

>>>>>>> b856c64105955d493269ea90d33c199b47bf234e
    <asp:GridView ID="dgvInscripciones" runat="server" AutoGenerateColumns="False">
        <Columns>
        <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
         <asp:BoundField HeaderText="Curso" DataField="desc_curso" />
         <asp:BoundField HeaderText="Condicion" DataField="condicion" />
         <asp:BoundField HeaderText="Nota" DataField="nota" />
    </Columns>
    </asp:GridView>





</asp:Content>

