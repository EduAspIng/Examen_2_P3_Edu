<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="tecnico.aspx.cs" Inherits="EDUARDO_ESPINOZA_EX2.tecnico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container text-center">
        <h3>LISTA DE TECNICOS</h3>
    </div>
    <div class="container text-center">
        <asp:GridView ID="GridViewTecnico" class= "mydatagrid" runat="server"
            CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
            RowStyle-CssClass="rows" AllowPaging="True" /></asp:GridView>

    </div>       
        <div class="container text-center">
        Codigo del tecnico: <asp:TextBox ID="TxtCT" class="form-control" runat="server"></asp:TextBox>
        Nombre del tecnico: <asp:TextBox ID="TxtNT" class="form-control" runat="server"></asp:TextBox>
        Especialidad del tecnico: <asp:TextBox ID="TxtET" class="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="container text-center">
        <asp:Button ID="BtnAgregarTecnico" class="btn btn-success" runat="server" Text="Agregar" OnClick="BtnAgregarTecnico_Click"/>
        <asp:Button ID="BtnBorrarTecnico" class="btn btn-danger" runat="server" Text="Borrar" OnClick="BtnBorrarTecnico_Click" />
        <asp:Button ID="BtnModificarTecnico" runat="server" class="btn btn-warning" Text="Modificar" OnClick="BtnModificarTecnico_Click" />
        <asp:Button ID="BtnConsultarTecnico" runat="server" class="btn btn-info" Text="Consultar" OnClick="BtnConsultarTecnico_Click" />
        </div>
</asp:Content>
