<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="usuario.aspx.cs" Inherits="EDUARDO_ESPINOZA_EX2.usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container text-center">
        <h3>LISTA DE USUARIOS</h3>
    </div>
        <div class="container text-center">
        <asp:GridView ID="GridViewUsuario" class= "mydatagrid" runat="server"
            CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
            RowStyle-CssClass="rows" AllowPaging="True" /></asp:GridView>
    </div>
        <div class="container text-center">
        Codigo del usuario: <asp:TextBox ID="TxtCodU" class="form-control" runat="server"></asp:TextBox>
        Nombre del usuario: <asp:TextBox ID="TxtIDU" class="form-control" runat="server"></asp:TextBox>
        Correo del usuario: <asp:TextBox ID="TxtCU" class="form-control" runat="server"></asp:TextBox>
        Numero del usuario: <asp:TextBox ID="TxtNU" class="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="container text-center">
        <asp:Button ID="BtnAgregarUsuario" class="btn btn-success" runat="server" Text="Agregar" OnClick="BtnAgregarUsuario_Click"/>
        <asp:Button ID="BtnBorrarUsuario" class="btn btn-danger" runat="server" Text="Borrar" OnClick="BtnBorrarUsuario_Click" />
        <asp:Button ID="BtnModificarUsuario" runat="server" class="btn btn-warning" Text="Modificar" OnClick="BtnModificarUsuario_Click" />
        <asp:Button ID="BtnConsultarUsuario" runat="server" class="btn btn-info" Text="Consultar" OnClick="BtnConsultarUsuario_Click" />
        </div>
</asp:Content>
