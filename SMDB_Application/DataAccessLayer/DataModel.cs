using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConStr);
            cmd = con.CreateCommand();
        }
        #region Yönetici Metotları


        public Yonetici YoneticiGiris(string mail, string sifre)
        {
            cmd.CommandText = "SELECT Y.ID, Y.YoneticiTur_ID, YT.Isim, Y.Isim, Y.Soyisim, Y.Mail, Y.KullaniciAdi, Y.Sifre, Y.AktifMi FROM Yoneticiler AS Y JOIN YoneticiTurleri AS YT ON Y.YoneticiTur_ID = YT.ID WHERE Y.Mail = @mail AND Y.Sifre = @sifre";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@mail", mail);
            cmd.Parameters.AddWithValue("@sifre", sifre);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Yonetici y = null;
            while (reader.Read())
            {
                y = new Yonetici();
                y.ID = reader.GetInt32(0);
                y.YoneticiTur_ID = reader.GetInt32(1);
                y.YoneticiTur = reader.GetString(2);
                y.Isim = reader.GetString(3);
                y.Soyisim = reader.GetString(4);
                y.Mail = reader.GetString(5);
                y.KullaniciAdi = reader.GetString(6);
                y.Sifre = reader.GetString(7);
                y.AktifMi = reader.GetBoolean(8);
            }
            con.Close();
            return y;
        }
        public List<Yonetici> YoneticiGetir()
        {
            List<Yonetici> Yoneticiler = new List<Yonetici>();
            try
            {
                cmd.CommandText = "SELECT Y.ID, Y.YoneticiTur_ID, YT.Isim, Y.Isim, Y.Soyisim, Y.Mail, Y.KullaniciAdi, Y.Sifre, Y.AktifMi FROM Yoneticiler AS Y JOIN YoneticiTurleri AS YT ON Y.YoneticiTur_ID = YT.ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Yonetici y;
                while (reader.Read())
                {
                    y = new Yonetici();
                    y.ID = reader.GetInt32(0);
                    y.YoneticiTur_ID = reader.GetInt32(1);
                    y.YoneticiTur = reader.GetString(2);
                    y.Isim = reader.GetString(3);
                    y.Soyisim = reader.GetString(4);
                    y.Mail = reader.GetString(5);
                    y.KullaniciAdi = reader.GetString(6);
                    y.Sifre = reader.GetString(7);
                    y.AktifMi = reader.GetBoolean(8);
                    Yoneticiler.Add(y);
                }
                return Yoneticiler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        //public void YoneticiTurDegistir(int id)
        //{
        //    try
        //    {
        //        cmd.CommandText = "SELECT Isim FROM YoneticiTurleri WHERE DI=@id";
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("@id", id);
        //        con.Open();
        //        string Isim = Convert.ToString(cmd.ExecuteScalar());
        //        cmd.CommandText = "UPDATE YoneticiTurleri SET Durum =@Isim WHERE ID=@id";
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("@id", id);
        //        cmd.Parameters.AddWithValue("Isim", Isim);
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch
        //    {

        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        #endregion

        #region Kategori Metotları

        public bool KategoriEkle(Kategori kat)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Kategori (Isim, Durum) VALUES(@isim,@durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", kat.Isim);
                cmd.Parameters.AddWithValue("@durum", kat.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Kategori> KategorileriGetir()
        {
            List<Kategori> kategoriler = new List<Kategori>();
            try
            {
                cmd.CommandText = "SELECT ID, Isim, Durum FROM Kategori";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Kategori k;
                while (reader.Read()) 
                {
                    k= new Kategori();
                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                    k.Durum = reader.GetBoolean(2);
                    k.DurumStr = reader.GetBoolean(2) ? "Aktif" : "Pasif";
                    kategoriler.Add(k);
                   
                }
                return kategoriler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close() ;
            }
        }
        public void KategoriDurumDegistir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Durum FROM Kategori WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = Convert.ToBoolean(cmd.ExecuteScalar());
                cmd.CommandText = "UPDATE Kategori SET Durum =@durum WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@durum", !durum);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
        public void KategoriSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Kategori WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
        public bool KategoriGuncelle(Kategori kat)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategori SET Isim=@isim, Durum=@durum WHERE ID=@id"; 
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", kat.ID);
                cmd.Parameters.AddWithValue("@isim", kat.Isim);
                cmd.Parameters.AddWithValue("@durum", kat.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public Kategori KategoriGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID, Isim, Durum FROM Kategori WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Kategori kat = new Kategori();
                while (reader.Read())
                {
                    kat.ID = reader.GetInt32(0);
                    kat.Isim = reader.GetString(1);
                    kat.Durum = reader.GetBoolean(2);
                }
                return kat;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }

        }

        #endregion

        #region Üye Metotları

        public List<Uyeler> UyeleriGetir()
        {
            List<Uyeler> uyeler = new List<Uyeler>();

            try
            {
                cmd.CommandText = "SELECT ID, Isim, Soyisim, Mail, KullaniciAdi, Sifre, AktifMi, Durum FROM Kullanici";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Uyeler u;
                while (reader.Read())
                {
                    u = new Uyeler();
                    u.ID = reader.GetInt32(0);
                    u.Isim= reader.GetString(1);
                    u.Soyisim= reader.GetString(2);
                    u.Mail= reader.GetString(3);
                    u.KullaniciAdi= reader.GetString(4);
                    u.Sifre= reader.GetString(5);
                    u.AktifMi=reader.GetBoolean(6);
                    u.Durum=reader.GetBoolean(7);
                    uyeler.Add(u);
                }
                return uyeler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

    }
}
