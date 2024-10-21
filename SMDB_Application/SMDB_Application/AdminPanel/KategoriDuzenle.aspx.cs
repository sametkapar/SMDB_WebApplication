using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMDB_Application.AdminPanel
{
    public partial class KategoriDuzenle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["KatID"]);
                    Kategori k = dm.KategoriGetir(id);
                    tb_isim.Text = k.Isim;
                    cb_durum.Checked = k.Durum;
                }
            }
            else
            {
                Response.Redirect("KategoriListele.aspx");
            }
        }
        protected void lbtn_düzenle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                if (tb_isim.Text.Length < 50)
                {
                    int id = Convert.ToInt32(Request.QueryString["KatID"]);
                    Kategori k = dm.KategoriGetir(id);
                    k.Isim = tb_isim.Text;
                    k.Durum = cb_durum.Checked;
                    if (dm.KategoriGuncelle(k))
                    {
                        pnl_basarisiz.Visible = false;
                        pnl_basarili.Visible = true;
                    }
                    else
                    {
                        pnl_basarili.Visible = false;
                        pnl_basarisiz.Visible = true;
                        lbl_mesaj.Text = "Kategori düzenlenirken bir hata oluştu.";
                    }
                }
                else
                {
                    lbl_mesaj.Text = "Katergori adı 50 karakterden büyük olamaz";
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                }
            }
            else
            {
                lbl_mesaj.Text = "Kategori adı boş bırakılamaz";
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
            }
        }
    }
}