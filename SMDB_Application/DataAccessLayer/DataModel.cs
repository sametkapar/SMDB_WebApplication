using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
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
                    k = new Kategori();
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
                con.Close();
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
                    u.Isim = reader.GetString(1);
                    u.Soyisim = reader.GetString(2);
                    u.Mail = reader.GetString(3);
                    u.KullaniciAdi = reader.GetString(4);
                    u.Sifre = reader.GetString(5);
                    u.AktifMi = reader.GetBoolean(6);
                    u.Durum = reader.GetBoolean(7);
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

        #region Moderatör Metotları

        public bool PlakSirketiEkle(PlakSirket ps)
        {
            try
            {
                cmd.CommandText = "INSERT into PlakSirket (Isim, Adres, Telefon, Durum) VALUES (@isim, @adres, @telefon, @durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", ps.Isim);
                cmd.Parameters.AddWithValue("@adres", ps.Adres);
                cmd.Parameters.AddWithValue("@telefon", ps.Telefon);
                cmd.Parameters.AddWithValue("@durum", ps.Durum);
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
        public List<PlakSirket> PlakSirketGetir()
        {
            try
            {
                List<PlakSirket> Psirketler = new List<PlakSirket>();
                cmd.CommandText = "SELECT ID, Isim, Adres, Telefon, Durum FROM PlakSirket";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                PlakSirket ps;
                while (reader.Read())
                {
                    ps = new PlakSirket();
                    ps.ID = reader.GetInt32(0);
                    ps.Isim = reader.GetString(1);
                    ps.Adres = reader.GetString(2);
                    ps.Telefon = reader.GetString(3);
                    ps.Durum = reader.GetBoolean(4);
                    Psirketler.Add(ps);

                }
                return Psirketler;

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

        #region Albüm Metotları
        public bool AlbumEkle(Album a)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Album (Sanatci_ID, Sirket_ID, CikisYili, AlbumTopPuan, KapakFoto, MuzikSayisi, Durum, Isim) VALUES (@sanatci_id, @sirket_id, @cikisyili, @albumtoppuan, @kapakfoto, @muziksayisi, @durum, @isim)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@sanatci_id", a.Sanatci_ID);
                cmd.Parameters.AddWithValue("@sirket_id", a.Sirket_ID);
                cmd.Parameters.AddWithValue("@cikisyili", a.CikisYili);
                cmd.Parameters.AddWithValue("albumtoppuan", a.AlbumTopPuan);
                cmd.Parameters.AddWithValue("@kapakfoto", a.KapakFoto);
                cmd.Parameters.AddWithValue("@muziksayisi", a.MuzikSayisi);
                cmd.Parameters.AddWithValue("durum", a.Durum);
                cmd.Parameters.AddWithValue("@isim", a.Isim);
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
        public List<Album> AlbumleriGetir()
        {
            try
            {
                List<Album> albumler = new List<Album>();
                cmd.CommandText = "SELECT ID, Sanatci_ID, Sirket_ID, CikisYili, AlbumTopPuan, KapakFoto, MuzikSayisi, Durum, Isim FROM Album";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Album a;
                while (reader.Read())
                {
                    a = new Album();
                    a.ID = reader.GetInt32(0);
                    a.Sanatci_ID = reader.GetInt32(1);
                    a.Sirket_ID = reader.GetInt32(2);
                    a.CikisYili = reader.GetDateTime(3);
                    a.AlbumTopPuan = reader.GetInt16(4);
                    a.KapakFoto = reader.GetString(5);
                    a.MuzikSayisi = reader.GetByte(6);
                    a.Durum = reader.GetBoolean(7);
                    a.Isim = reader.GetString(8);
                    albumler.Add(a);

                }
                return albumler;
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
        public List<Album> AlbumleriGetir(int id)
        {
            try
            {
                List<Album> albumler = new List<Album>();
                cmd.CommandText = "SELECT ID, Sanatci_ID, Sirket_ID, CikisYili, AlbumTopPuan, KapakFoto, MuzikSayisi, Durum, Isim FROM Album WHERE Sanatci_ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Album a;
                while (reader.Read())
                {
                    a = new Album();
                    a.ID = reader.GetInt32(0);
                    a.Sanatci_ID = reader.GetInt32(1);
                    a.Sirket_ID = reader.GetInt32(2);
                    a.CikisYili = reader.GetDateTime(3);
                    a.AlbumTopPuan = reader.GetInt16(4);
                    a.KapakFoto = reader.GetString(5);
                    a.MuzikSayisi = reader.GetByte(6);
                    a.Durum = reader.GetBoolean(7);
                    a.Isim = reader.GetString(8);
                    albumler.Add(a);

                }
                return albumler;
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
        public Album AlbumGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID, Sanatci_ID, Sirket_ID, CikisYili, AlbumTopPuan, KapakFoto, MuzikSayisi, Durum, Isim FROM Album WHERE Sanatci_ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Album a = new Album();
                while (reader.Read())
                {
                    a.ID = reader.GetInt32(0);
                    a.Sanatci_ID = reader.GetInt32(1);
                    a.Sirket_ID = reader.GetInt32(2);
                    a.CikisYili = reader.GetDateTime(3);
                    a.AlbumTopPuan = reader.GetInt16(4);
                    a.KapakFoto = reader.GetString(5);
                    a.MuzikSayisi = reader.GetByte(6);
                    a.Durum = reader.GetBoolean(7);
                    a.Isim = reader.GetString(8);
                }
                return a;
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

        #region Müzik Metotları

        public bool MuzikEkle(Muzik m)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Muzik (Isim, Durum, Album_ID) VALUES (@isim, @durum,@album_id)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", m.Isim);
                cmd.Parameters.AddWithValue("durum", m.Durum);
                cmd.Parameters.AddWithValue("album_id", m.Album_ID);
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
        public List<MuzikTur> MuzikTurGetir()
        {

            try
            {
                List<MuzikTur> muzikTurleri = new List<MuzikTur>();
                cmd.CommandText = "SELECT ID, Isim FROM MuzikTur";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                MuzikTur mt;
                while (reader.Read())
                {
                    mt = new MuzikTur();
                    mt.ID = reader.GetInt32(0);
                    mt.Isim = reader.GetString(1);
                    muzikTurleri.Add(mt);
                }
                return muzikTurleri;
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
        public List<Muzik> MuzikleriGetir()
        {
            try
            {
                List<Muzik> muzikler = new List<Muzik>();
                cmd.CommandText = "SELECT M.ID, M.Album_ID, A.Isim, A.Sanatci_ID, S.Isim, S.Soyisim, M.Isim FROM Muzik AS M JOIN Album AS A ON M.Album_ID = A.ID  JOIN Sanatci AS S ON S.ID = A.Sanatci_ID ";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Muzik m;
                while (reader.Read())
                {
                    m = new Muzik();
                    m.ID = reader.GetInt32(0);
                    m.Album_ID = reader.GetInt32(1);
                    m.AlbumIsim = reader.GetString(2);
                    m.Sanatci_ID = reader.GetInt32(3);
                    m.SanatciIsim = reader.GetString(4);
                    m.SanatciSoyisim = reader.GetString(5);
                    m.Isim = reader.GetString(6);
                    m.SanatciFullIsim = m.SanatciIsim + " " + m.SanatciSoyisim;
                    muzikler.Add(m);
                }
                return muzikler;
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
        public Muzik MuzikleriGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT M.ID, M.Album_ID, A.Isim, A.Sanatci_ID, S.Isim, S.Soyisim, M.Isim FROM Muzik AS M JOIN Album AS A ON M.Album_ID = A.ID  JOIN Sanatci AS S ON S.ID = A.Sanatci_ID  WHERE A.Sanatci_ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Muzik m = new Muzik();
                while (reader.Read())
                {

                    m.ID = reader.GetInt32(0);
                    m.Album_ID = reader.GetInt32(1);
                    m.AlbumIsim = reader.GetString(2);
                    m.Sanatci_ID = reader.GetInt32(3);
                    m.SanatciIsim = reader.GetString(4);
                    m.SanatciSoyisim = reader.GetString(5);
                    m.Isim = reader.GetString(6);
                    m.SanatciFullIsim = m.SanatciIsim + " " + m.SanatciSoyisim;
                }
                return m;
            }
            catch { return null; }
            finally { con.Close(); }
        }
        #endregion

        #region Sanatçı Metotları
        public bool SanatciEkle(Sanatci sa)
        {
            try
            {
                cmd.CommandText = "INSERT into Sanatci (Isim, Soyisim, GrupMu, Durum) VALUES (@isim, @soyisim, @grupMu, @durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", sa.Isim);
                cmd.Parameters.AddWithValue("@soyisim", sa.Soyisim);
                cmd.Parameters.AddWithValue("@grupMu", sa.GrupMu);
                cmd.Parameters.AddWithValue("@durum", sa.Durum);
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

        public List<Sanatci> SanatcilariGetir()
        {
            try
            {
                List<Sanatci> sanatcilar = new List<Sanatci>();
                cmd.CommandText = "SELECT ID, Isim, Soyisim, GrupMu, Durum FROM Sanatci";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Sanatci s;
                while (reader.Read())
                {
                    s = new Sanatci();
                    s.ID = reader.GetInt32(0);
                    s.Isim = reader.GetString(1);
                    s.Soyisim = reader.GetString(2);
                    s.GrupMu = reader.GetBoolean(3);
                    s.Durum = reader.GetBoolean(4);
                    s.IsimSoyisim = s.Isim + " " + s.Soyisim;
                    sanatcilar.Add(s);

                }
                return sanatcilar;
            }
            catch { return null; }
            finally { con.Close(); }
        }

        public Sanatci SanatciGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID, Isim, Soyisim, GrupMu, Durum FROM Sanatci WHERE ID =@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Sanatci s = new Sanatci();
                while (reader.Read())
                {
                    s.ID = reader.GetInt32(0);
                    s.Isim = reader.GetString(1);
                    s.Soyisim = reader.GetString(2);
                    s.GrupMu = reader.GetBoolean(3);
                    s.Durum = reader.GetBoolean(4);
                    s.IsimSoyisim = s.Isim + " " + s.Soyisim;
                }
                return s;
            }
            catch { return null; }
            finally { con.Close(); }
        }
        #endregion

    }
}
