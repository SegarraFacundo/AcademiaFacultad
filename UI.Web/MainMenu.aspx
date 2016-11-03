<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainMenu.aspx.cs" Inherits="MainMenu" MasterPageFile="Site.master"%>

<asp:Content ID="MainManuContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div>
            <asp:LinkButton ID="linkMenuUsuarios" runat="server">Menu Usuarios</asp:LinkButton>
    </div>
    <div>
            <asp:LinkButton ID="linkMenuPeronas" runat="server" OnClick="linkMenuPeronas_Click">Menu Alumnos</asp:LinkButton>
    </div>

</asp:Content>
