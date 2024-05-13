using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmanii
{
    public class VeriModeli
    {
        SqlConnection baglanti;
        SqlCommand komut;
        public VeriModeli()
        {
            baglanti = new SqlConnection(BaglantiYollari.BaglantiYolu);
            komut = baglanti.CreateCommand();
        }

        #region Yonetici Metotlari
        // Bu metot mail ve şifreyi veri tabanında kontrol edip eğer varsa giriş yapmak isteyen yönetici bilgilerini nesne haline getirip döndürecek.
        public Yonetici YöneticiGiris(string mail, string sifre)
        {
            try
            {
                komut.CommandText = "SELECT Y.ID, Y.YöneticiTur_ID, YT.Isim, Y.Isim, Y.SoyIsim, Y.Mail, Y.KullaniciAdı, Y.Sifre, Y.ProfilFotografi, Y.Durum, Y.Silinmis FROM Yoneticiler AS Y  JOIN YöneticiTurleri AS YT ON Y.YöneticiTur_ID = YT.ID  WHERE Y.Mail = @mail AND Y.Sifre = @sifre";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@mail", mail);
                komut.Parameters.AddWithValue("@sifre", sifre);
                baglanti.Open();
                SqlDataReader Okuyucu = komut.ExecuteReader();
                Yonetici y = new Yonetici();
                while (Okuyucu.Read())
                {
                    y.ID = Okuyucu.GetInt32(0);
                    y.YöneticiTur_ID = Okuyucu.GetInt32(1);
                    y.YoneticiTur = Okuyucu.GetString(2);
                    y.Isim = Okuyucu.GetString(3);
                    y.SoyIsim = Okuyucu.GetString(4);
                    y.Mail = Okuyucu.GetString(5);
                    y.KullaniciAdi = Okuyucu.GetString(6);
                    y.Sifre = Okuyucu.GetString(7);
                    y.ProfilFotografi = Okuyucu.GetString(8);
                    y.Durum = Okuyucu.GetBoolean(9);
                    y.Silinmis = Okuyucu.GetBoolean(10);

                }
                return y;
            }
            catch
            {

                throw;
            }
            finally
            {
                baglanti.Close();
            }
        }

        #endregion
        #region Katogeri Metotları
        public bool KategoriEkle(Kategori kat)
        {
            try
            {
                komut.CommandText = "INSERT INTO Kategoriler(Isim, Acikalama, Durum) VALUES (@isim, @aciklama, @durum)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@isim", kat.Isim);
                komut.Parameters.AddWithValue("@aciklama", kat.Aciklama);
                komut.Parameters.AddWithValue("@durum", kat.Durum);
                baglanti.Open();
                komut.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;

            }
            finally
            {
                baglanti.Close();
            }

        }
        public List<Kategori> TumKategorileriGetir()
        {
            try
            {
                List<Kategori> kategoriler = new List<Kategori>();
                komut.CommandText = "SELECT ID, Isim, Aciklama, Durum FROM Kategoriler";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Kategori kat = new Kategori();
                    kat.ID = okuyucu.GetInt32(0);
                    kat.Isim = okuyucu.GetString(1);
                    kat.Aciklama = okuyucu.GetString(2);
                    kat.Durum = okuyucu.GetBoolean(3);
                    kategoriler.Add(kat);
                }
                return kategoriler;
            }
            catch
            {
                return null;

            }
            finally
            {
                baglanti.Close();
            }

        }




        #endregion
    }
}
