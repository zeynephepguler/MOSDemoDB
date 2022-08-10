using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Admin : System.Web.UI.Page
    {
        public string veri;
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Visible = false;
            TextBox2.Visible = false;
            TextBox3.Visible = false;
            DropDownList1.Visible = false;
            DropDownList2.Visible = false;
            Button5.Visible = false;
            Button1.Visible = false;
            fuResim.Visible = false;
            FotoText.Visible = false;
            FotoButton.Visible = false;
            if (!IsPostBack)
            {
                
                grid();
            }
           
        }
        void grid()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=MSSQL12.MSSQLSERVER\MSSQL;Initial Catalog=mosyazil_db_staj;Integrated Security=True");
            conn.Open();
            SqlCommand tablo = new SqlCommand("SELECT  TBLUSERS.ID,TBLUSERS.USERNAME,PASSWORD,TBLUSERS.USERTYPE,TBLUSERS.RECDATE,TBLUSERS.İMAGENAME,STUFF((SELECT '-' + FONKSIYON as [text()] FROM TBLAUTH where TBLUSERS.ID = TBLAUTH.USERID FOR XML PATH('')), 1, 1, '') AS Result FROM TBLUSERS LEFT JOIN TBLAUTH ON TBLUSERS.ID = TBLAUTH.USERID ", conn);
            SqlDataAdapter da = new SqlDataAdapter(tablo);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            conn.Close();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=MSSQL12.MSSQLSERVER\MSSQL;Initial Catalog=mosyazil_db_staj;Integrated Security=True");
        protected void ADD_Click(object sender, EventArgs e)
        {
            
            try
            {
                conn.Open();
                string sql = "Insert into TBLUSERS (USERNAME,PASSWORD,USERTYPE,RECDATE) values('" + TextBox2.Text + "', '" + int.Parse(TextBox3.Text) + "', '" + DropDownList1.SelectedValue + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                SqlCommand kayit = new SqlCommand(sql, conn);

                kayit.ExecuteNonQuery();
                
               

              

                Response.Redirect("Admin.aspx");



            }
            catch { }

            
            //string sql1 = "Insert into TBLAUTH (RECDATE) values('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            //SqlCommand kayit1 = new SqlCommand(sql1, conn);

            //kayit1.ExecuteNonQuery();

            //Response.Redirect("Admin.aspx");
            //conn.Close();

        }

        
        protected void UPDATE_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sql = "UPDATE  TBLUSERS set USERNAME = '" + TextBox2.Text + "', PASSWORD = '" + int.Parse(TextBox3.Text) + "', USERTYPE = '" + DropDownList1.SelectedValue + "', RECDATE = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where ID= '" + int.Parse(TextBox1.Text) + "'";
                SqlCommand kayit = new SqlCommand(sql, conn);

                kayit.ExecuteNonQuery();
                conn.Close();
                
            }catch { }
            if (DropDownList2.Text.Equals("YETKİSİZ"))
            {
                try
                {
                    conn.Open();
                string sql = "DELETE  TBLAUTH where USERID= '" +TextBox1.Text + "'";
                SqlCommand kayit = new SqlCommand(sql, conn);

                kayit.ExecuteNonQuery();
                conn.Close();
                   

                }
                catch { }
            }
            else
            {
                 conn.Open();
                    string sql2 = "Insert into TBLAUTH (USERID,FONKSIYON,RECDATE) values('" + TextBox1.Text + "', '" + DropDownList2.SelectedValue + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    SqlCommand kayit2 = new SqlCommand(sql2, conn);

                    kayit2.ExecuteNonQuery();
                    conn.Close();
            }
            Response.Redirect("Admin.aspx");
        }

        protected void DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sql = "DELETE  TBLAUTH where USERID= '" + int.Parse(TextBox1.Text) + "'";
                SqlCommand save = new SqlCommand(sql, conn);

                save.ExecuteNonQuery();
                string sql2 = "DELETE  TBLUSERS where ID= '" + int.Parse(TextBox1.Text) + "'";
                SqlCommand save2 = new SqlCommand(sql2, conn);

                save2.ExecuteNonQuery();
                conn.Close();

            }
            catch { }
            Response.Redirect("Admin.aspx");
        }

        protected void PERSONS_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Visible = false;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            DropDownList1.Visible = true;
            DropDownList2.Visible = true;
            Button5.Visible = true;
            Button1.Visible = false;
            FotoText.Visible = true;
            FotoButton.Visible = true;
            fuResim.Visible = true;

            int secili;
            secili = GridView1.SelectedIndex;
            GridViewRow row = GridView1.Rows[secili];
            TextBox1.Text = row.Cells[2].Text;
            TextBox2.Text = HttpUtility.HtmlDecode(row.Cells[3].Text);
            FotoText.Text = row.Cells[2].Text;
            TextBox3.Text = row.Cells[4].Text;
            DropDownList1.Text = row.Cells[5].Text;
        }
        protected void ADDN_Click(object sender, EventArgs e)
        {
            TextBox1.Visible = false;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            DropDownList1.Visible = true;
            DropDownList2.Visible = true;
            Button5.Visible = true;
            Button1.Visible=true;
            fuResim.Visible = true;
            FotoText.Visible = true;
            FotoButton.Visible = true;
        }

        protected void CANCEL_Click(object sender, EventArgs e)
        {
            TextBox1.Visible = false;
            TextBox2.Visible = false;
            TextBox3.Visible = false;
            DropDownList1.Visible = false;
            DropDownList2.Visible = false;
            Button5.Visible= false;
            Button1.Visible=  false;
            fuResim.Visible = false;
            FotoText.Visible = false;
            FotoButton.Visible = false;
        }
       
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        string uzanti = "";
        string resimadi = "";
        protected void FotoButton_Click(object sender, EventArgs e)
        {
            if (fuResim.HasFile)
            {
                uzanti = Path.GetExtension(fuResim.PostedFile.FileName);
                resimadi = (FotoText.Text) + uzanti;
                fuResim.SaveAs(Server.MapPath("/Resimler/sahte" + uzanti));


                int Donusturme = 640;

                Bitmap bmp = new Bitmap(Server.MapPath("/Resimler/sahte" + uzanti));
                using (Bitmap OrjinalResim = bmp)
                {
                    double ResYukseklik = OrjinalResim.Height;
                    double ResGenislik = OrjinalResim.Width;
                    double oran = 0;

                    if (ResGenislik >= Donusturme)
                    {
                        oran = ResGenislik / ResYukseklik;
                        ResGenislik = Donusturme;
                        ResYukseklik = Donusturme / oran;

                        Size yenidegerler = new Size(Convert.ToInt32(ResGenislik), Convert.ToInt32(ResYukseklik));
                        Bitmap yeniresim = new Bitmap(OrjinalResim, yenidegerler);
                        yeniresim.Save(Server.MapPath("/Resimler/" + resimadi));
                        {
                            yeniresim.Dispose();
                            OrjinalResim.Dispose();
                            bmp.Dispose();


                        }
                    }
                    else
                    {
                        fuResim.SaveAs(Server.MapPath("~/Resimler/" + resimadi));
                    }
                }
                FileInfo figecici = new FileInfo(Server.MapPath("~/Resimler/sahte" + uzanti));
                figecici.Delete();
            }

            SqlConnection baglanti = new SqlConnection(@"Data Source=MSSQL12.MSSQLSERVER\MSSQL;Initial Catalog=mosyazil_db_staj;Integrated Security=True");

            baglanti.Open();

            //SqlCommand cmd = new SqlCommand("UPDATE TBLUSERS (İMAGENAME,İMAGE) set IMAGENAME=@İMAGENAME ,IMAGE=@İMAGE where USERID='" + Kullanici.KullaniciId + "'", baglanti) ;
            string sql = "UPDATE  TBLUSERS set İMAGENAME=@İMAGENAME ,İMAGE=@İMAGE   where  ID='" + FotoText.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, baglanti);


            cmd.Parameters.AddWithValue("@İMAGE", FotoText.Text);
            cmd.Parameters.AddWithValue("@İMAGENAME", "Resimler/" + resimadi);
            cmd.ExecuteNonQuery();
            baglanti.Close();

            Response.Redirect("Admin.aspx");






        }


    }
}

