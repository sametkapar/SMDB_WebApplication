<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminPanelMaster.Master" AutoEventWireup="true" CodeBehind="KategoriListele.aspx.cs" Inherits="SMDB_Application.AdminPanel.KategoriListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/KatEkleStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="anaPanel">
        <div class="panelBaslik">
            <h3>Kategori Listesi</h3>
        </div>
        <div class="panelIci">
            <asp:ListView ID="lv_kategoriler" runat="server" OnItemCommand="lv_kategoriler_ItemCommand">
                <LayoutTemplate>
                    <table class="pavlov" cellpadding="0" cellspacing="0">
                        <tr>
                            <th>No</th>
                            <th width="50%">Kategori Adı</th>
                            <th>Durum</th>
                            <th>Seçenekler</th>
                        </tr>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("ID") %></td>
                        <td><%# Eval("Isim") %></td>
                        <td><%# Eval("DurumStr") %></td>
                        <td>
                            <asp:LinkButton ID="lbtn_durumdegistir" runat="server" CssClass="tablobuton durum" CommandArgument='<%# Eval("ID") %>' CommandName="durum">Durum Değiştir</asp:LinkButton>
                            <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="tablobuton sil" CommandArgument='<%# Eval("ID") %>' CommandName="sil">Sil</asp:LinkButton>
                            <a href='KategoriDuzenle.aspx?KatID=<%# Eval("ID") %>' class="tablobuton düzenle">Düzenle</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
