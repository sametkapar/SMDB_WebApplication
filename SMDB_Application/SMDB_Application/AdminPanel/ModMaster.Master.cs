using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMDB_Application.AdminPanel
{
    public partial class ModMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["GirisYapanModerator"] != null)
            {
                Yonetici y = (Yonetici)Session["GirisYapanModerator"];
                lbl_kullanici.Text = y.KullaniciAdi + "(" + y.YoneticiTur + ")";
            }
            else
            {
                Response.Redirect("AdminLogin.aspx");
            }
        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["GirisYapanModerator"] = null;
            Response.Redirect("AdminLogin.aspx");
        }
    }
}