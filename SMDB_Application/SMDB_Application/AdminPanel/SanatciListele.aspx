<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/ModMaster.Master" AutoEventWireup="true" CodeBehind="SanatciListele.aspx.cs" Inherits="SMDB_Application.AdminPanel.SanatciListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/KatEkleStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="anaPanel">
        <div class="panelBaslik">
          <h3> SANATÇI ADI GELECEK </h3>
        </div>
    <div class="panelIci">
        <asp:ListView ID="lv_sanatcilar" runat="server">
            <LayoutTemplate>
                <table class="pavlov" cellpadding="0" cellspacing="0">
                    <tr>
                        <th>Albümler</th>
                    </tr>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><a href='AlbumleriListele.aspx?AlbumID=<%# Eval("ID") %>' class="tablobuton düzenle">
                        <%# Eval("IsimSoyisim") %></a>

                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
    </div>
</asp:Content>
