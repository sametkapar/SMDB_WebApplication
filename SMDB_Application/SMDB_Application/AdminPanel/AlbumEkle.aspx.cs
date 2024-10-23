using DataAccessLayer;
using System;
using System.Collections.Generic;
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
            ddl_sanatciSec.DataSource = dm.SanatciGetir();
            ddl_sanatciSec.DataBind();
            ddl_plakSirketSec.DataSource = dm.PlakSirketGetir();
            ddl_plakSirketSec.DataBind();
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {

        }
    }
}