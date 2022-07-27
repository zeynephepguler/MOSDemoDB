using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public string veri;
        public int sayac;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        SqlConnection conn = new SqlConnection(@"Data Source=ZEYNEP\TEW_SQLEXPRESS;Initial Catalog=MOSDemoDB;Integrated Security=True");
        protected void Button2_Click(object sender, EventArgs e)

        {
            //SqlConnection conn = new SqlConnection(@"Data Source=ZEYNEP\TEW_SQLEXPRESS;Initial Catalog=MOSDemoDB;Integrated Security=True");
            //string sql = "Insert into TBLUSERS (USERNAME,PASSWORD) values('" + TextBox1.Text + "', '" + int.Parse(TextBox2.Text) + "')";
            //SqlCommand kayit = new SqlCommand(sql, conn);
            //conn.Open();
            //kayit.ExecuteNonQuery();
            //conn.Close();
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('kayıt başarıyla yapıldı.);", true);

            try
            {
                conn.Open();
                string sql = "Select * From TBLUSERS where USERNAME=@adi AND PASSWORD=@sifresi ";
                SqlParameter prm1 = new SqlParameter("adi", TextBox1.Text.Trim());
                SqlParameter prm2 = new SqlParameter("sifresi", TextBox2.Text.Trim());
                SqlCommand komut = new SqlCommand(sql, conn);
                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);

                if (dt.Rows.Count > 0)

                {
                    SqlCommand sql2 = new SqlCommand("Select * From TBLUSERS where USERNAME=@ad AND PASSWORD=@sif AND USERTYPE='ADMIN' ", conn);
                    SqlParameter prm3 = new SqlParameter("ad", TextBox1.Text.Trim());
                    SqlParameter prm4 = new SqlParameter("sif", TextBox2.Text.Trim());
                    sql2.Parameters.Add(prm3);
                    sql2.Parameters.Add(prm4);
                    DataTable dt2 = new DataTable();
                    SqlDataAdapter da2 = new SqlDataAdapter(sql2);
                    da2.Fill(dt2);

                    if (dt2.Rows.Count > 0)
                    {

                        
                        SqlCommand sql3 = new SqlCommand("Select ID From TBLUSERS where USERNAME=@ad AND PASSWORD=@sif  ", conn);
                        SqlParameter prm5 = new SqlParameter("ad", TextBox1.Text.Trim());
                        SqlParameter prm6 = new SqlParameter("sif", TextBox2.Text.Trim());
                        sql3.Parameters.Add(prm5);
                        sql3.Parameters.Add(prm6);
                        DataTable dt3 = new DataTable();
                        SqlDataAdapter da3=new SqlDataAdapter(sql3);
                        da3.Fill(dt3);
                        if (dt3.Rows.Count > 0) { 
                        SqlDataReader dr= sql3.ExecuteReader();
                        while(dr.Read())
                        {
                            Admin admin = new Admin();
                            admin.veri=dr[0].ToString();
                            Response.Redirect("Admin.aspx");
                        }

                    }


                    }
                    else
                    {
                        SqlConnection conn = new SqlConnection(@"Data Source=ZEYNEP\TEW_SQLEXPRESS;Initial Catalog=MOSDemoDB;Integrated Security=True");
                        conn.Open();
                        SqlCommand sql3 = new SqlCommand("Select ID From TBLUSERS where USERNAME=@ad AND PASSWORD=@sif", conn);
                        SqlParameter prm5 = new SqlParameter("ad", TextBox1.Text.Trim());
                        SqlParameter prm6 = new SqlParameter("sif", TextBox2.Text.Trim());
                        sql3.Parameters.Add(prm5);
                        sql3.Parameters.Add(prm6);

                        SqlDataReader dr = sql3.ExecuteReader();
                        User user = new User();
                      
                        while (dr.Read())
                        {

                            veri = dr["ID"].ToString();
                            TextBox1.Text = veri;
                            Kullanici.KullaniciId = dr["ID"].ToString();
                            
                            sayac++;
                            TextBox2.Text = Kullanici.KullaniciId;
                            Response.Redirect("User.aspx");

                        }
                        dr.Close();
                        conn.Close();
                        
                        
                        //TextBox1.Text = dr[0].ToString();
                        



                        //sql3.ExecuteNonQuery();
                        //SqlDataReader oku;
                        //oku = sql3.ExecuteReader();

                        //while (oku.Read())
                        //{

                        //    veris = oku["Ad"].ToString();


                        //}
                        //oku.Close();
                        //sqlBaglantisi.Close();

                        //User user = new User();
                        //user.veris = sql4.ToString();
                        //Response.Redirect("User.aspx");

                    }
                }

            }
            catch
            {

            }








        }
        void Gonder()
        {

            
        }

    }
}