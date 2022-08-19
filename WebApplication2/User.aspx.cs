using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Image = System.Drawing.Image;
using Microsoft.Win32;

namespace WebApplication2
{
    public partial class User : System.Web.UI.Page
    {   
        public string veris;
        public event System.Web.UI.WebControls.GridViewCommandEventHandler RowCommand;
        public int cont = 0;
        public int sayac=0;
       
        
        protected void Page_Load(object sender, EventArgs e)
        {
            IDBox.Visible = false;
            USERNAME.Visible = false;
            Ulastname.Visible = false;
            PASS.Visible = false;
            UserType.Visible = false;
            CANCEL.Visible = false;

            ADD.Enabled= false;
            UPDATE.Enabled= false;
            DELETE.Enabled= false;
            Addn.Enabled= false;

            ADD.Visible= false;
            UPDATE.Visible = false;
            DELETE.Visible = false;
           fuResim.Visible= false;
            FotoText.Visible=false;
            FotoButton.Visible=false;
            

            if (!IsPostBack)
            {
                grid();
                One();
            }
            FunctionAdd();
            FunctionDelete();
            FunctionUpdate();
            Menu();



        }
       

        
        void grid()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=mssql11.turhost.com;Initial Catalog=mosyazil_DB_Staj;User ID=stajuser;Password=ADMm@s1298;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            conn.Open();
            SqlCommand table = new SqlCommand("Select * From TBLUSERS WHERE USERTYPE='USER'", conn);
            SqlDataAdapter da = new SqlDataAdapter(table);
            DataTable dt = new DataTable();
            da.Fill(dt);
            PERSONS.DataSource = dt;
            PERSONS.DataBind();
            conn.Close();
            //conn.Open();
            //SqlCommand tablo2 = new SqlCommand("Select USERNAME,PASSWORD,USERTYPE,İMAGENAME From TBLUSERS WHERE ID='"+Kullanici.KullaniciId+"'", conn);
            //SqlDataAdapter da2 = new SqlDataAdapter(tablo2);
            //DataTable dt2 = new DataTable();
            //da2.Fill(dt2);
            //GridView2.DataSource = dt2;
            //GridView2.DataBind();
            //conn.Close();




        }
        SqlConnection conn = new SqlConnection(@"Data Source=mssql11.turhost.com;Initial Catalog=mosyazil_DB_Staj;User ID=stajuser;Password=ADMm@s1298;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        protected void ADD_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=mssql11.turhost.com;Initial Catalog=mosyazil_DB_Staj;User ID=stajuser;Password=ADMm@s1298;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            try
                 
            {
                 
                                    
                conn.Open();
                string sql2 = "Insert into TBLUSERS (USERNAME,PASSWORD,USERTYPE,RECDATE,LASTNAME) values('" + USERNAME.Text + "', '" + int.Parse(PASS.Text) + "', '" + UserType.SelectedValue + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + Ulastname.Text + "')";
                SqlCommand save = new SqlCommand(sql2, conn);

                save.ExecuteNonQuery();
                conn.Close();
                
                
                   
            }
            catch { }Response.Redirect("User.aspx");
        }

        protected void UPDATE_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=mssql11.turhost.com;Initial Catalog=mosyazil_DB_Staj;User ID=stajuser;Password=ADMm@s1298;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            try
            {   
                
                conn.Open();
                string sql = "UPDATE  TBLUSERS set USERTYPE = '" + UserType.SelectedValue + "',PASSWORD = '" + int.Parse(PASS.Text) + "',USERNAME = '" + USERNAME.Text + "', RECDATE = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',LASTNAME='" + Ulastname.Text + "' where ID= '" + int.Parse(IDBox.Text) + "'";
                SqlCommand save = new SqlCommand(sql, conn);

                save.ExecuteNonQuery();
                conn.Close();
                
            }catch { }
           Response.Redirect("User.aspx");

        }

        protected void DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sql = "DELETE  TBLAUTH where USERID= '" + int.Parse(IDBox.Text) + "'";
                SqlCommand save = new SqlCommand(sql, conn);

                save.ExecuteNonQuery();
                string sql2 = "DELETE  TBLUSERS where ID= '" + int.Parse(IDBox.Text) + "'";
                SqlCommand save2 = new SqlCommand(sql2, conn);

                save2.ExecuteNonQuery();
                conn.Close();
                
            }
            catch { }
            Response.Redirect("User.aspx");
        }
        void FunctionAdd()
        {
            
            string sql = "Select * From TBLAUTH where USERID='"+Kullanici.KullaniciId+"' AND FONKSIYON='ADD' ";
            SqlCommand command = new SqlCommand(sql, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                ADD.Enabled = true;
                Addn.Enabled=  true;
               
            }


        }
        void FunctionUpdate()
        {

            string sql = "Select * FROM TBLAUTH where USERID='"+ Kullanici.KullaniciId + "' AND FONKSIYON='UPDATE'";

            SqlCommand command = new SqlCommand(sql, conn);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                UPDATE.Enabled = true;
            }


        }
        void FunctionDelete() 

        {

            string sql = "Select * FROM TBLAUTH where USERID='"+ Kullanici.KullaniciId + "' AND FONKSIYON='DELETE'";

            SqlCommand command = new SqlCommand(sql, conn);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DELETE.Enabled = true;
            }


        }

        protected void PERSONS_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDBox.Visible = false;
            USERNAME.Visible = true;
            Ulastname.Visible = true;
            PASS.Visible = true;
            UserType.Visible = true;
            CANCEL.Visible = true;
            UPDATE.Visible = true;
            FotoText.Visible = false;
            FotoButton.Visible = true;
            fuResim.Visible = true;
            
            
                       
            GridViewRow row = PERSONS.Rows[SelectId()];

            IDBox.Text = row.Cells[2].Text;
            FotoText.Text = row.Cells[2].Text;
            USERNAME.Text = HttpUtility.HtmlDecode(row.Cells[3].Text);
            PASS.Text = row.Cells[4].Text;
            UserType.Text=row.Cells[5].Text;



        
                
            

        }
        protected void PERSONS_RowCommand(Object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Delete_row")
        {

            cont = 1;
            DELETE.Visible = true;
            CANCEL.Visible = true;
            USERNAME.Visible = true;
                Ulastname.Visible = true;
                int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = PERSONS.Rows[index];
            IDBox.Text = row.Cells[2].Text;


        }
    }

        public int SelectId()
        {
            int secili;
            secili = PERSONS.SelectedIndex;
                       
            return secili;

        }
    
     
       

        protected void CANCEL_Click(object sender, EventArgs e)
        {
            IDBox.Visible = false;
            USERNAME.Visible = false;
            Ulastname.Visible = false;
            PASS.Visible = false;
            UserType.Visible = false;
            CANCEL.Visible=false;
            fuResim.Visible=false;
            FotoText.Visible=false;
            FotoButton.Visible=false;   
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            USERNAME.Visible = true;
            Ulastname.Visible = true;
            PASS.Visible = true;
            UserType.Visible = true;
            CANCEL.Visible = true;
            ADD.Visible = true;
            fuResim.Visible=false;
            FotoText.Visible=false;
            FotoButton.Visible = false;
        }
        protected void Addnn_Click(object sender, EventArgs e)
        {
            USERNAME.Visible = true;
            Ulastname.Visible = true;
            PASS.Visible = true;
            UserType.Visible = true;
            CANCEL.Visible = true;
            ADD.Visible = true;
            fuResim.Visible = false;
            FotoText.Visible = false;
            FotoButton.Visible = false;
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
                cmd.Parameters.AddWithValue("@İMAGENAME","Resimler/"+ resimadi);
                cmd.ExecuteNonQuery();
                baglanti.Close();

                Response.Redirect("User.aspx");
            
                



            
        }
    
        void Menu()
        {
            conn.Open();
            SqlCommand sql = new SqlCommand("SELECT * FROM TBLUSERS where ID='"+Kullanici.KullaniciId+"'",conn);
            SqlDataReader re=sql.ExecuteReader();
            while (re.Read())
            {
                UNAME.Text = re[1].ToString();
                Utype.Text = re[3].ToString();
                Usyd.Text = re[7].ToString();
                UIMAGE.ImageUrl = re[4].ToString();
                
              
            }
            conn.Close();
        }

        
        protected void ushow_Click(object sender, EventArgs e)
        {
            PERSONS.Visible = !PERSONS.Visible;
            Addn.Visible = !Addn.Visible;

        }
        void One()
        {
            if (sayac == 0)
            {
                PERSONS.Visible = false;
                Addn.Visible=false;
                sayac = 15;
            }


        }

        protected void Exit_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}