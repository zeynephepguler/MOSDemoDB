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
            Button4.Enabled= false; 
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
                Button4.Enabled = true;
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
            TextBox8.Visible = true;
            TextBox5.Visible = true;
            TextBox6.Visible = true;
            DropDownList2.Visible = true;
            Button5.Visible = true;

            int secili;
            secili = GridView1.SelectedIndex;
            GridViewRow row = GridView1.Rows[secili];
            TextBox8.Text = row.Cells[1].Text;
            TextBox5.Text = HttpUtility.HtmlDecode(row.Cells[2].Text);
            TextBox6.Text = row.Cells[3].Text;
            DropDownList2.Text=row.Cells[4].Text;
            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            TextBox5.Visible = true;
            TextBox6.Visible = true;
            DropDownList2.Visible = true;
            Button5.Visible = true;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            TextBox8.Visible = false;
            TextBox5.Visible = false;
            TextBox6.Visible = false;
            DropDownList2.Visible = false;
            Button5.Visible=false;
        }
    }
}