<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegistroNotas.aspx.cs" Inherits="RegistroNotas" MasterPageFile="Site.master"%>

<asp:Content ID="registroNotasContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:GridView ID="dgvDocentesCursos" runat="server" AutoGenerateColumns="False" 
        SelectedRowStyle-BackColor="Black"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="ID,id_curso"
        DataSourceID="odsDocentesCursos" Width="231px" OnSelectedIndexChanged="dgvDocentesCursos_SelectedIndexChanged">

<SelectedRowStyle BackColor="Black" ForeColor="White"></SelectedRowStyle>
    </asp:GridView>
    <asp:ObjectDataSource ID="odsDocentesCursos" runat="server" SelectMethod="GetCursosPorDocente" TypeName="Data.Database.DocenteCursoAdapter">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="idDocente" SessionField="id_persona" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:LinkButton ID="linkVolver" runat="server">Volver</asp:LinkButton>




</asp:Content>

