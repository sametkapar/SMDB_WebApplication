<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminPanelMaster.Master" AutoEventWireup="true" CodeBehind="KategoriListele.aspx.cs" Inherits="SMDB_Application.AdminPanel.KategoriListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Gövde.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="gövde">
        <div class="gövdeBaslik">
            <h3>Kategori Listesi</h3>
        </div>
        <div class="gövdePanel">
            <asp:ListView ID="lv_kategoriler" runat="server">
                <LayoutTemplate>
                    <table>
                        <tr>
                            <th>no</th>
                            <th>kategori adı</th>
                        </tr>
                    </table>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>aaaa</td>
                        <td>bbbb</td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
