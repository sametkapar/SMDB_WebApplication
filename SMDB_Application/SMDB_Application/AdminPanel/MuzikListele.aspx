<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/ModMaster.Master" AutoEventWireup="true" CodeBehind="MuzikListele.aspx.cs" Inherits="SMDB_Application.AdminPanel.MuzikListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/KatEkleStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="anaPanel">
        <div class="panelBaslik">
            <h3>Müzik Listesi</h3>
        </div>
        <div class="panelIci">
            <asp:ListView ID="lv_muzikler" runat="server" >
                <LayoutTemplate>
                    <table class="pavlov" cellpadding="0" cellspacing="0">
                        <tr>
                            <th>Müzik ID</th>
                            <th>İsim</th>
                            <th>Sanatçı</th>
                            <th>Albüm</th>
                            <th>Ortalama Puan</th>
                            <th>Seçenekler</th>
                        </tr>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("ID") %></td>
                        <td><%# Eval("Isim") %></td>
                        <td><a href='SanatciListele.aspx?SanatciID=<%# Eval("Sanatci_ID") %>' class="tablobuton sil">
                            <%# Eval("SanatciFullIsim") %>
                            </a></td>
                        <td><a href='AlbumListele.aspx?AlbumID=<%# Eval("Album_ID") %>' class="tablobuton düzenle"</a>
                            <%# Eval("AlbumIsim") %>
                        </td>
                        <td>Puanlama</td>
                        <td>Seçenekler</td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
