using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMDB_Application.AdminPanel
{
    public partial class SanatciEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cb_durum.Checked = true;
                cb_grupMu.Checked = false;
            }
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                Sanatci s = new Sanatci();
                s.Isim = tb_isim.Text;
                s.Soyisim = tb_soyisim.Text;
                s.GrupMu = cb_grupMu.Checked;
                s.Durum = cb_durum.Checked;
                if (dm.SanatciEkle(s))
                {
                    pnl_basarisiz.Visible = false;
                    pnl_basarili.Visible = true;
                }
                else
                {
                    lbl_mesaj.Text = "Sanatçı eklenirken bir hata oluştu";
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                }

            }
            else
            {
                lbl_mesaj.Text = "İsim alanı boş bırakılamaz";
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
            }
        }
    }
}