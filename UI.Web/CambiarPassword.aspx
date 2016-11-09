<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CambiarPassword.aspx.cs" Inherits="CambiarPassword" MasterPageFile="Site.Master"%>

<asp:Content ID="cambiarPassContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">


    <table style="width: 22%;">
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label1" runat="server" Text="Password Anterior:"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="txtPassAnterior" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label2" runat="server" Text="Nuevo Password:"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="txtNuevoPass" TextMode="Password" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label3" runat="server" Text="Repetir Password:"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="txtNuevoPass2" TextMode="Password" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
   <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
       <br />
            <asp:Label ID="labelError" runat="server"></asp:Label>
    </asp:Panel>




</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 122px;
        }
        .auto-style2 {
            width: 108px;
        }
    </style>
</asp:Content>
