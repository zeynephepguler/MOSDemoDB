using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class User : System.Web.UI.Page
    {
        public string veris;
        public TextBox TextBox4;
        protected void Page_Load(object sender, EventArgs e)
        {
            //ID Id = new ID();
            //textBox4.Text = veris;
            Console.WriteLine(veris);
            Button1.Enabled= false;
            Button2.Enabled= false;
            Button3.Enabled= false;
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
            SqlCommand tablo = new SqlCommand("Select * From TBLUSERS", conn);
            SqlDataAdapter da = new SqlDataAdapter(tablo);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            conn.Close();
            
        }
        SqlConnection conn = new SqlConnection(@"Data Source=ZEYNEP\TEW_SQLEXPRESS;Initial Catalog=MOSDemoDB;Integrated Security=True");
        protected void Button1_Click(object sender, EventArgs e)
        {
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
            try
            {
                conn.Open();
                string sql = "UPDATE  TBLUSERS set USERNAME = '" + TextBox5.Text + "', PASSWORD = '" + int.Parse(TextBox6.Text) + "', USERTYPE = '" + DropDownList2.SelectedValue + "', RECDATE = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where ID= '" + int.Parse(TextBox4.Text) + "'";
                SqlCommand kayit = new SqlCommand(sql, conn);

                kayit.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("User.aspx");
            }
            catch { }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sql = "DELETE  TBLUSERS where ID= '" + int.Parse(TextBox4.Text) + "'";
                SqlCommand kayit = new SqlCommand(sql, conn);

                kayit.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("User.aspx");
            }
            catch { }
        }
        void FunctionAdd()
        {
            //ID Id = new ID();
            User user= new User();
           // user.veris = veri;

            int veri = Convert.ToInt32(veris);
            string sql = "Select * From TBLAUTH where USERID='"+Kullanici.KullaniciId+"' AND FONKSIYON='ADD' ";
            //SqlParameter prm1=new SqlParameter("id",veris);
            SqlCommand komut = new SqlCommand(sql, conn);
            //komut.Parameters.AddWithValue("id", veris);
            //komut.Parameters.Add(prm1);
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
            TextBox4.Text = veris;
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
    }
}