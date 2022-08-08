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
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox8.Visible = false;
            TextBox5.Visible = false;
            TextBox6.Visible = false;
            DropDownList2.Visible = false;
            Button5.Visible = false;
            //ID Id = new ID();
            //textBox4.Text = veris;
            Console.WriteLine(veris);
            Button1.Enabled= false;
            Button2.Enabled= false;
            Button3.Enabled= false;
            Button1.Visible= false;
            Button2.Visible = false;
            Button3.Visible = false;
           fuResim.Visible= false;
            FotoText.Visible=false;
            FotoButton.Visible=false;
            loadİmage();

            if (!IsPostBack)
            {
                grid();
            }
            FunctionAdd();
            FunctionDelete();
            FunctionUpdate();
            
        }
       

        
        void grid()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=ZEYNEP\TEW_SQLEXPRESS;Initial Catalog=MOSDemoDB;Integrated Security=True");
            conn.Open();
            SqlCommand tablo = new SqlCommand("Select * From TBLUSERS WHERE USERTYPE='USER'", conn);
            SqlDataAdapter da = new SqlDataAdapter(tablo);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            conn.Close();
            conn.Open();
            SqlCommand tablo2 = new SqlCommand("Select (USERNAME) From TBLUSERS WHERE ID='"+Kullanici.KullaniciId+"'", conn);
            SqlDataAdapter da2 = new SqlDataAdapter(tablo2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            GridView2.DataSource = dt2;
            GridView2.DataBind();
            conn.Close();




        }
        SqlConnection conn = new SqlConnection(@"Data Source=ZEYNEP\TEW_SQLEXPRESS;Initial Catalog=MOSDemoDB;Integrated Security=True");
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=ZEYNEP\TEW_SQLEXPRESS;Initial Catalog=MOSDemoDB;Integrated Security=True");
            try
            {
                 
                                    
                conn.Open();
                string sql2 = "Insert into TBLUSERS (USERNAME,PASSWORD,USERTYPE,RECDATE) values('" + TextBox5.Text + "', '" + int.Parse(TextBox6.Text) + "', '" + DropDownList2.SelectedValue + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                SqlCommand kayit = new SqlCommand(sql2, conn);

                kayit.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("User.aspx");
                
                   
            }
            catch { }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=ZEYNEP\TEW_SQLEXPRESS;Initial Catalog=MOSDemoDB;Integrated Security=True");
            try
            {   
                
                conn.Open();
                string sql = "UPDATE  TBLUSERS set USERTYPE = '" + DropDownList2.SelectedValue + "',PASSWORD = '" + int.Parse(TextBox6.Text) + "',USERNAME = '" + TextBox5.Text + "', RECDATE = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where ID= '" + int.Parse(TextBox8.Text) + "'";
                SqlCommand kayit = new SqlCommand(sql, conn);

                kayit.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("User.aspx");
            }catch { }
           

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sql = "DELETE  TBLAUTH where USERID= '" + int.Parse(TextBox8.Text) + "'";
                SqlCommand kayit = new SqlCommand(sql, conn);

                kayit.ExecuteNonQuery();
                string sql2 = "DELETE  TBLUSERS where ID= '" + int.Parse(TextBox8.Text) + "'";
                SqlCommand kayit2 = new SqlCommand(sql2, conn);

                kayit2.ExecuteNonQuery();
                conn.Close();
                
            }
            catch { }
            Response.Redirect("User.aspx");
        }
        void FunctionAdd()
        {
            User user= new User();
            int veri = Convert.ToInt32(veris);
            string sql = "Select * From TBLAUTH where USERID='"+Kullanici.KullaniciId+"' AND FONKSIYON='ADD' ";
            SqlCommand komut = new SqlCommand(sql, conn);
           
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                Button1.Enabled = true;
               
            }


        }
        void FunctionUpdate()
        {

            //ID Id = new ID();
            
            //int veri = Convert.ToInt32(veris);
            string sql = "Select * FROM TBLAUTH where USERID='"+ Kullanici.KullaniciId + "' AND FONKSIYON='UPDATE'";
            //SqlParameter prm1 = new SqlParameter("id", veris);
            SqlCommand komut = new SqlCommand(sql, conn);
            //komut.Parameters.Add(prm1);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Button2.Enabled = true;
            }


        }
        void FunctionDelete() 

        {
            //ID Id = new ID();
            //int veri = Convert.ToInt32(veris);
            string sql = "Select * FROM TBLAUTH where USERID='"+ Kullanici.KullaniciId + "' AND FONKSIYON='DELETE'";
            //SqlParameter prm1 = new SqlParameter("id", veris);
            SqlCommand komut = new SqlCommand(sql, conn);
            //komut.Parameters.Add( prm1);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Button3.Enabled = true;
            }


        }

        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox8.Visible = false;
            TextBox5.Visible = true;
            TextBox6.Visible = true;
            DropDownList2.Visible = true;
            Button5.Visible = true;
            Button2.Visible = true;
            FotoText.Visible = true;
            FotoButton.Visible = true;
            fuResim.Visible = true;
                 
                       
            GridViewRow row = GridView1.Rows[SelectId()];
            
            TextBox8.Text = row.Cells[2].Text;
            FotoText.Text = row.Cells[2].Text;
            TextBox5.Text = HttpUtility.HtmlDecode(row.Cells[3].Text);
            TextBox6.Text = row.Cells[4].Text;
            DropDownList2.Text=row.Cells[5].Text;
            if (cont == 1)
            {

                

                
            }
                
            

        }
        protected void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "Delete_row")
            {

                cont = 1;
                Button3.Visible = true;
                Button5.Visible = true;
                TextBox5.Visible = true;
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];
                TextBox8.Text = row.Cells[2].Text;


            }
        }
        public int SelectId()
        {
            int secili;
            secili = GridView1.SelectedIndex;
                       
            return secili;

        }
    
     
        //void CustomersGridView1_RowDeleting(Object sender, GridViewCommandEventArgs e)
        //{

        //    if (e.CommandName == "Delete")
        //    {


        //        int secili;
        //        secili = GridView1.SelectedIndex;
        //        GridViewRow row = GridView1.Rows[secili];
        //        TextBox8.Text = row.Cells[2].Text;
        //        TextBox5.Text = HttpUtility.HtmlDecode(row.Cells[3].Text);
        //        TextBox6.Text = row.Cells[4].Text;
        //        DropDownList2.Text = row.Cells[5].Text;
        //        try
        //        {
        //            conn.Open();
        //            string sql = "DELETE  TBLAUTH where USERID= '" + int.Parse(TextBox8.Text) + "'";
        //            SqlCommand kayit = new SqlCommand(sql, conn);

        //            kayit.ExecuteNonQuery();
        //            string sql2 = "DELETE  TBLUSERS where ID= '" + int.Parse(TextBox8.Text) + "'";
        //            SqlCommand kayit2 = new SqlCommand(sql2, conn);

        //            kayit2.ExecuteNonQuery();
        //            conn.Close();

        //        }
        //        catch { }
        //        Response.Redirect("User.aspx");

        //    }

        ////}




        protected void Button5_Click(object sender, EventArgs e)
        {
            TextBox8.Visible = false;
            TextBox5.Visible = false;
            TextBox6.Visible = false;
            DropDownList2.Visible = false;
            Button5.Visible=false;
            fuResim.Visible=false;
            FotoText.Visible=false;
            FotoButton.Visible=false;   
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            TextBox5.Visible = true;
            TextBox6.Visible = true;
            DropDownList2.Visible = true;
            Button5.Visible = true;
            Button1.Visible = true;
            fuResim.Visible=true;
            FotoText.Visible=true;
            FotoButton.Visible = true;
        }

        protected void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }
        //public void InsertFoto(string İMAGENAME, byte[] İMAGE)
        //{
        //    using (SqlConnection conn = new SqlConnection(@"Data Source=ZEYNEP\TEW_SQLEXPRESS;Initial Catalog=MOSDemoDB;Integrated Security=True"))
        //    {
        //        if (conn.State != ConnectionState.Closed)
        //            conn.Open();
                
        //        using (SqlCommand cmd = new SqlCommand("insert into TBLUSERS (İMAGENAME,İMAGE) values(@İMAGENAME ,@İMAGE)"))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Parameters.AddWithValue("@İMAGENAME", FotoText.Text);
        //            cmd.Parameters.AddWithValue("@İMAGE", İMAGE);
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    conn.Close();
        //}
        //public void loadData()
        //{
        //    using(SqlConnection conn =new SqlConnection(@"Data Source=ZEYNEP\TEW_SQLEXPRESS;Initial Catalog=MOSDemoDB;Integrated Security=True"))
        //    {
        //        if(conn.State != ConnectionState.Closed)
        //            conn.Open();
            
            
        //        using(DataTable dt = new DataTable("TBLUSER"))
        //        {
        //            SqlDataAdapter adapter = new SqlDataAdapter("select * from TBLUSERS  ", conn);
        //            adapter.Fill(dt);

        //        }
        //    }
        //}
        
        //byte[] ConvertImageToBytes(Image img)
        //{
        //    using(MemoryStream ms=new MemoryStream())
        //    {
        //        img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        //        return ms.ToArray();
        //    }
        //}

        //public Image ConvertByteArrayToImage(byte[] data)
        //{
        //    using(MemoryStream ms=new MemoryStream(data))
        //    {
        //        return Image.FromStream(ms);
        //    }
        //}
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


                SqlConnection baglanti = new SqlConnection(@"Data Source=ZEYNEP\TEW_SQLEXPRESS;Initial Catalog=MOSDemoDB;Integrated Security=True");
                baglanti.Open();

            //SqlCommand cmd = new SqlCommand("UPDATE TBLUSERS (İMAGENAME,İMAGE) set IMAGENAME=@İMAGENAME ,IMAGE=@İMAGE where USERID='" + Kullanici.KullaniciId + "'", baglanti) ;
            string sql = "UPDATE  TBLUSERS set İMAGENAME=@İMAGENAME ,İMAGE=@İMAGE   where  ID='" + FotoText.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, baglanti);

                
                cmd.Parameters.AddWithValue("@İMAGE", FotoText.Text);
                cmd.Parameters.AddWithValue("@İMAGENAME", resimadi);
                cmd.ExecuteNonQuery();
                baglanti.Close();

                Response.Redirect("User.aspx");
            
                



            
        }
      void loadİmage()
        {

            
            

        }
        //void C()
        //{
        //  conn.Open(); 
        //    SqlCommand sql =new SqlCommand("SELECT *FROM TBLUSERS  where  ID='" + Kullanici.KullaniciId + "'",conn);
        //    sql.ExecuteNonQuery();

        //    SqlDataReader dr;
        //    dr = sql.ExecuteReader();

        //    string adress;
        //    while (dr.Read())
        //    {

        //        adress = dr[4].ToString(); 
        //        foto.ImageUrl=adress;
        //    }
        //    //con.Close();
           
        //}

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}