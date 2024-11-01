<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/ModMaster.Master" AutoEventWireup="true" CodeBehind="AlbumListele.aspx.cs" Inherits="SMDB_Application.AdminPanel.AlbumListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="anaPanel">
        <div class="panelBaslik">
            <div class="panelBaslik">
                <h3>
                    <asp:Label ID="lbl_sanatciAdiGetir" runat="server" Text=""></asp:Label>
                </h3>
            </div>
        </div>
        <div class="panelIci">
            <div class="panelBaslik">
                <asp:Label ID="lbl_albumAdıGetir" runat="server" Text=""></asp:Label>
            </div>
            <div>
                <asp:ListView ID="lv_ablumBilgiGetir" runat="server">
                    <LayoutTemplate>
                        <table class="pavlov" cellpadding="0" cellspacing="0">
                            <tr>
                                <th>Müzikler</th>
                                <th>Müzik Ortalama Puanı</th> <%--ortalama puan eklendikçe updatelenecek--%>
                            </tr>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>    
                            <td>Müzik isimleri gelecek</td>
                            <td>Ortalama puanlar gelecek</td>
                        </tr>
                    </ItemTemplate>

                </asp:ListView>
            </div>
        </div>
    </div>
</asp:Content>
