using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMDB_Application.AdminPanel
{
    public partial class AlbumEkle : System.Web.UI.Page
    {
        DataModel dm =new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
            ddl_sanatciSec.DataSource = dm.SanatciGetir();
            ddl_sanatciSec.DataBind();
            ddl_plakSirketSec.DataSource = dm.PlakSirketGetir();
            ddl_plakSirketSec.DataBind();
            }
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            Album a = new Album();
        
            a.Sanatci_ID = Convert.ToInt32(ddl_sanatciSec.SelectedItem.Value);
            a.Sirket_ID = Convert.ToInt32(ddl_plakSirketSec.SelectedItem.Value);
            a.CikisYili = Convert.ToDateTime(tb_cikisYili.Text);
            a.Isim = tb_isim.Text;
            a.Durum = cb_durum.Checked;
            a.MuzikSayisi = 0;
            a.AlbumTopPuan = 0;
            bool isValidExtension = true;
            if (fu_resim.HasFile)//Resim seçilmiş ise
            {
                string isim = Guid.NewGuid().ToString();
                FileInfo fi = new FileInfo(fu_resim.FileName);
                string uzanti = fi.Extension;//.jpg
                if (uzanti == ".jpg" || uzanti == ".png")
                {
                    string tamisim = isim + uzanti;
                    a.KapakFoto = tamisim;
                    fu_resim.SaveAs(Server.MapPath("../AlbumResimleri/" + tamisim));
                }
                else
                {
                    isValidExtension = false;
                }
            }
            else
            {
                a.KapakFoto = "none.png";
            }
            if (isValidExtension)
            {
                if (dm.AlbumEkle(a))
                {
                    pnl_basarisiz.Visible = false;
                    pnl_basarili.Visible = true;

                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                    lbl_mesaj.Text = "Album eklenirken bir hata oluştu";
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
                lbl_mesaj.Text = "Resim uzantısı JPG veya PNG olmalıdır";
            }
        }
    }
}