<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="equipo.aspx.cs" Inherits="EDUARDO_ESPINOZA_EX2.equipo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <h3>LISTA DE EQUIPOS</h3>
            <div class="container text-center">
        <asp:GridView ID="GridViewEquipo" class= "mydatagrid" runat="server"
            CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
            RowStyle-CssClass="rows" AllowPaging="True" /></asp:GridView>
    </div>
    </div>
        <div class="container text-center">
        Codigo del equipo: <asp:TextBox ID="TxtCE" class="form-control" runat="server"></asp:TextBox>
        Tipo del equipo: <asp:TextBox ID="TxtTE" class="form-control" runat="server"></asp:TextBox>
        Modelo del equipo: <asp:TextBox ID="TxtME" class="form-control" runat="server"></asp:TextBox>
        ID del usuario: <asp:DropDownList ID="DDIDU" class="form-control" runat="server"></asp:DropDownList>
    </div>

    <div class="container text-center">
        <asp:Button ID="BtnAgregarEquipo" class="btn btn-success" runat="server" Text="Agregar" OnClick="BtnAgregarEquipo_Click"/>
        <asp:Button ID="BtnBorrarEquipo" class="btn btn-danger" runat="server" Text="Borrar" OnClick="BtnBorrarEquipo_Click" />
        <asp:Button ID="BtnModificarEquipo" runat="server" class="btn btn-warning" Text="Modificar" OnClick="BtnModificarEquipo_Click" />
        <asp:Button ID="BtnConsultarEquipo" runat="server" class="btn btn-info" Text="Consultar" OnClick="BtnConsultarEquipo_Click" />
        </div>
</asp:Content>
