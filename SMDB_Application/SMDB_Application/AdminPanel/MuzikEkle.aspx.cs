using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMDB_Application.AdminPanel
{
    public partial class MuzikEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

            ddl_albumSec.DataSource = dm.AlbumGetir();
            ddl_albumSec.DataBind();
            ddl_turSec.DataSource = dm.MuzikTurGetir();
            ddl_turSec.DataBind();
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                Muzik m = new Muzik();
                m.Isim = tb_isim.Text;
                m.Album_ID = Convert.ToInt32(ddl_albumSec.SelectedItem.Value);
                if (dm.MuzikEkle(m))
                {
                    pnl_basarisiz.Visible = false;
                    pnl_basarili.Visible = true;
                }
                else
                {
                    lbl_mesaj.Text = "Müzik eklenirken bir hata ile karşlışalıldı";
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                }
            }
            else
            {
                lbl_mesaj.Text = "Müzik ismi boş bırakılamaz";
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
            }
        }
    }
}