using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMDB_Application.AdminPanel
{
    public partial class SanatciListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)

        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["SanatciID"]);
                    lv_albümler.DataSource = dm.AlbumleriGetir(id);
                    lv_albümler.DataBind();
                    Album a = dm.AlbumGetir(id);
                    lbl_albumAdıGetir.Text = a.Isim;
                    Sanatci s = dm.SanatciGetir(id);
                    lbl_sanatciAdiGetir.Text = s.IsimSoyisim;
                }
            }
            else
            {
                Response.Redirect("MuzikListele.aspx");
            }


        }

    }
}