using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GezginKusBlogWebApp.YöneticiPaneli
{
    public partial class Giris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Sayfa açılırken yapılması istenen işlemleri buraya yazabiliriz.

        }

        protected void btn_giris_Click(object sender, EventArgs e)
        {
            string mail = tb_mail.Text;
            string sifre = tb_sifre.Text;

            tb_mail.BorderColor = tb_sifre.BorderColor = Color.Empty;
            pnl_mesaj.Visible = false;

            if (!string.IsNullOrEmpty(tb_mail.Text))
            {
                if (!string.IsNullOrEmpty(tb_sifre.Text))
                {
                    if (tb_mail.Text.Contains("@"))
                    {
                        SqlConnection com = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=GezginKus_DB; Integrated Security=True");
                        SqlCommand cmd = com.CreateCommand();
                        cmd.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE Mail=@m AND Sifre=@s";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@m", mail);
                        cmd.Parameters.AddWithValue("@s", sifre);
                        com.Open();
                        int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                        if (sayi != 0)
                        {
                            Response.Redirect("Default.aspx");

                        }
                        else
                        {
                            pnl_mesaj.Visible = true;
                            lbl_mesaj.Text = "Kullanıcı Bulunamadı!";
                        }
                    }
                    else
                    {
                        pnl_mesaj.Visible = true;
                        lbl_mesaj.Text = "Lütfen geçerli bir mail adresi giriniz!";
                        tb_mail.BorderColor = Color.Red;
                    }
                }
                else
                {
                    pnl_mesaj.Visible = true;
                    lbl_mesaj.Text = "Lütfen şifrenizi boş bırakmayın!";
                    tb_sifre.BorderColor = Color.Red;

                }
            }
            else
            {
                pnl_mesaj.Visible = true;
                lbl_mesaj.Text = "Mail adresi boş bırakılamaz!";
                tb_mail.BorderColor = Color.Red;
            }
        }
    }
}