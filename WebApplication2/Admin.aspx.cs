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
        public int sayac = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            Menu();
            
            if (!IsPostBack)
            {
               One(); 
                grid();
            }
           
        }

        void grid()
        {
        SqlConnection conn = new SqlConnection(@"Data Source=mssql11.turhost.com;Initial Catalog=mosyazil_DB_Staj;User ID=stajuser;Password=ADMm@s1298;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            conn.Open();
            SqlCommand tablo = new SqlCommand("SELECT T" +
                "BLUSERS.ID,TBLUSERS.USERNAME,LASTNAME,PASSWORD,TBLUSERS.USERTYPE,TBLUSERS.RECDATE,TBLUSERS.İMAGENAME,STUFF((SELECT '-' + FONKSIYON as [text()] FROM TBLAUTH where TBLUSERS.ID = TBLAUTH.USERID FOR XML PATH('')), 1, 1, '') AS Result FROM TBLUSERS LEFT JOIN TBLAUTH ON TBLUSERS.ID = TBLAUTH.USERID ", conn);
            SqlDataAdapter da = new SqlDataAdapter(tablo);
            DataTable dt = new DataTable();
            da.Fill(dt);
            PERSONS.DataSource = dt;
            PERSONS.DataBind();
            conn.Close();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=mssql11.turhost.com;Initial Catalog=mosyazil_DB_Staj;User ID=stajuser;Password=ADMm@s1298;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        protected void ADD_Click(object sender, EventArgs e)
        {
            
            try
            {
                conn.Open();
                string sql = "Insert into TBLUSERS (USERNAME,PASSWORD,USERTYPE,RECDATE,LASTNAME) values('" + TextBox2.Text + "', '" + int.Parse(TextBox3.Text) + "', '" + DropDownList1.SelectedValue + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + Ulastname.Text + "')";
                SqlCommand kayit = new SqlCommand(sql, conn);

                kayit.ExecuteNonQuery();

                conn.Close();

              

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
                string sql = "UPDATE  TBLUSERS set USERNAME = '" + TextBox2.Text + "', PASSWORD = '" + int.Parse(TextBox3.Text) + "', USERTYPE = '" + DropDownList1.SelectedValue + "', RECDATE = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',LASTNAME='" + Ulastname.Text + "' where ID= '" + int.Parse(TextBox1.Text) + "'";
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
            Ulastname.Visible = true;  
            TextBox3.Visible = true;
            DropDownList1.Visible = true;
            DropDownList2.Visible = true;
            Button5.Visible = true;
            Button1.Visible = false;
            FotoText.Visible = false;
            FotoButton.Visible = true;
            fuResim.Visible = true;

            int secili;
            secili = PERSONS.SelectedIndex;
            GridViewRow row = PERSONS.Rows[secili];
            TextBox1.Text = row.Cells[2].Text;
            TextBox2.Text = HttpUtility.HtmlDecode(row.Cells[3].Text);
            FotoText.Text = row.Cells[2].Text;
            TextBox3.Text = row.Cells[5].Text;
            DropDownList1.Text = row.Cells[6].Text;
        }
        protected void ADDN_Click(object sender, EventArgs e)
        {
            TextBox1.Visible = false;
            FotoText.Visible = false;
            TextBox2.Visible = true;
            Ulastname.Visible = true;
            TextBox3.Visible = true;
            DropDownList1.Visible = true;
            DropDownList2.Visible = true;
            Button5.Visible = true;
            Button1.Visible=true;
            fuResim.Visible = false;
            
            FotoButton.Visible = false;
        }

        protected void CANCEL_Click(object sender, EventArgs e)
        {
            TextBox1.Visible = false;
            TextBox2.Visible = false;
            Ulastname.Visible = false;
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
          

            SqlConnection baglanti = new SqlConnection(@"Data Source=mssql11.turhost.com;Initial Catalog=mosyazil_DB_Staj;User ID=stajuser;Password=ADMm@s1298;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

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
        void Menu()
        {
            conn.Open();
            SqlCommand sql = new SqlCommand("SELECT * FROM TBLUSERS where ID='" + Kullanici.KullaniciId + "'", conn);
            SqlDataReader re = sql.ExecuteReader();
            while (re.Read())
            {
                UNAME.Text = re[1].ToString();
                Utype.Text = re[3].ToString();
                Usyd.Text = re[7].ToString();
                UIMAGE.ImageUrl = re[4].ToString();
                Console.WriteLine(UIMAGE.ImageUrl);

            }
            conn.Close();
        }

        protected void ushow_Click(object sender, EventArgs e)
        {
            PERSONS.Visible = !PERSONS.Visible;
            Button2.Visible = !Button2.Visible;
            Button3.Visible = !Button3.Visible;
            Button4.Visible = !Button4.Visible;

        }
      
        void One()
        {
            if (sayac == 0)
            {
            PERSONS.Visible = false ;
            Button4.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
                TextBox1.Visible = false;
                TextBox2.Visible = false;
                Ulastname.Visible = false;
                TextBox3.Visible = false;
                DropDownList1.Visible = false;
                DropDownList2.Visible = false;
                Button5.Visible = false;
                Button1.Visible = false;
                fuResim.Visible = false;
                FotoText.Visible = false;
                FotoButton.Visible = false;
                sayac = 15;
            }
            

        }

        protected void uAdd_Click(object sender, EventArgs e)
        {
           
            TextBox1.Visible = false;
            FotoText.Visible = false;
            TextBox2.Visible = !TextBox2.Visible;
            Ulastname.Visible = !Ulastname.Visible;
            TextBox3.Visible = !TextBox3.Visible;
            DropDownList1.Visible = !DropDownList1.Visible;
            DropDownList2.Visible = !DropDownList2.Visible;
            Button5.Visible = !Button5.Visible;
            Button1.Visible =! Button1.Visible;
            fuResim.Visible = false;
            FotoButton.Visible = false;
            

        }

        protected void Exit_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}

