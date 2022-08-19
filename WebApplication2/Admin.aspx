
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication2.Admin"  Debug="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="background:linear-gradient(336deg, rgba(0,0,255,.8), rgba(0,0,255,0) 70.71%), 
    linear-gradient(217deg, rgba(255,0,0,.8), rgba(255,0,0,0) 70.71%),
    linear-gradient(127deg, rgba(0,255,0,.8), rgba(0,255,0,0) 70.71%); background-color:white;">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <configuration>
   <system.web>
       <compilation debug="true"/>
   </system.web>
</configuration>
  <style type="text/css">


        .auto-style2 {
            position: relative;
            min-height: 1px;
            top: -19px;
            left: 500px;
            height: 63px;
            width: 566px;
            float: left;
            margin-right: 7px;
            margin-top: 0px;
            padding-left: 15px;
            padding-right: 15px;
            text-align: -webkit-center;
            

        }
        .auto-style8 {
            width: 489px;
            margin-right: 0px;
            height: 240px;
            margin-top: 50px;
             
        }
        .auto-style10 {
            font-size: x-small;
            
        }
        .auto-style14 {
          width: 489px;
          margin-right: 0px;
          height: 50px;
          margin-top: 10px;
          
      }
        .auto-style15 {
          position:absolute;
          right:25px;
          margin-top:25px;
          border-radius:30px 30px 30px 30px;
          color:white;
          background-color:#ffffff52;
          border-style: solid; 
          border-color: inherit; 
          border-width: 2px; 
          background-color:#ffffff1a; 
          color:white; 
          border-block-color:white;
          box-shadow: 3px 3px 4px #aa5f0300;
          font-size:medium;
          background-image:url();
      }
        .auto-style16 {
          width: 489px;
          margin-right: 0px;
          height: 240px;
          margin-top: 7px;
      }
        .auto-style17 {
             width: 190px;
            margin-left: 37px;
            margin-right: 9px;
          
      }
        .auto-style18 {
          width: 232px;
          margin-left:22px;
      }
        </style>
  

    <link href="Menu.css" rel="stylesheet" />

</head>
   
<body style="height: 1045px; background: linear-gradient(217deg, rgba(255,0,0,.8), rgba(255,0,0,0) 70.71%),
            linear-gradient(127deg, rgba(0,255,0,.8), rgba(0,255,0,0) 70.71%),
            linear-gradient(336deg, rgba(0,0,255,.8), rgba(0,0,255,0) 70.71%); background-color:white;">
 
    <form id="form1" runat="server" class="page" >
    <ul style="width:auto; position: absolute; perspective:100px;"class="menu";
    height: 1045px;
    overflow: auto;
    left: 0px;">
        <li style="margin-top:50px"></li>
        <li>
     
            <asp:Image ID="UIMAGE" runat="server" class="i"/>
               <br />
               <br />
           <table class="auto-style17">
            <tr><td><h5> Adı :</h5></td><td ><asp:Label ID="UNAME" runat="server"  class="t"   ></asp:Label></td></tr>
               <tr><td><h5 > Soyadı :</h5></td><td ><asp:Label ID="Usyd" runat="server"  class="t"  ></asp:Label></td></tr>
            <tr><td><h5> Tipi :</h5></td><td ><asp:Label ID="Utype" runat="server"  class="t"   ></asp:Label></td></tr>
            
            </table>
            
           </li>
          
             
        
          <li><a href="#">
      <asp:Button runat="server" Text="Kullanıcı Listele" style="margin: 0px;
    padding: 0;
    left:0px;
    width: 100%;
    height:35px;
    background-color: #4caf50ce;
    font-size: small;
    color: #ffffff;
    padding: 8px 16px;    
    border-color:azure;
    " id="ushow" OnClick="ushow_Click" />
      </a></li>  
        <li>
            <a>
             <asp:Button runat="server" Text="Kullanıcı Ekleme" style="margin: 0px;
    padding: 0;
    left:0px;
    width: 100%;
    height:35px;
    background-color: #4caf50ce;
    font-size: small;
    color: #ffffff;
    padding: 8px 16px;    
    border-color:azure;
    " id="uAdd" OnClick="uAdd_Click" />
      </a></li> 
        <li>
             <table class="auto-style18">
               <tr>
                      <td> <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="ID" Width="200px" Height="30px"></asp:TextBox><br />
                          </td>
                      </tr>
                      
                      <tr>
                          <td>             <asp:TextBox ID="FotoText" runat="server" class="form-control" placeholder="Fotoğraf Ekle" Width="200px" Height="30px" ></asp:TextBox>
                        </td>
                      </tr>
                  
                      <tr>
                          <td>               <asp:FileUpload ID="fuResim" runat="server" Width="209px" Height="30px" />
                      </tr>
                      <tr>
                          <td>                <asp:Button ID="FotoButton" runat="server" Text="Ekle" class="btn btn-primary" style="background-color:gray" Height="30px" Width="80px" CssClass="auto-style10" OnClick="FotoButton_Click"/> </td>
                      </tr>
                      <tr>
                          <td>
                                <asp:TextBox ID="TextBox2" runat="server" class="form-control" type="text" placeholder="USERNAME" Width="200px" Height="30px" ></asp:TextBox>

                          </td>
                      </tr>
                 <tr>
                    <td>
                             <asp:TextBox ID="Ulastname" runat="server" class="form-control" type="text" placeholder="LASTNAME" Width="200px" Height="30px"></asp:TextBox>

                    </td>
                </tr>
                      <tr>
                          <td>
                                 <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" placeholder="USERTYPE" Width="209px" Height="30px">
                                                <asp:ListItem>ADMIN</asp:ListItem>
                                                <asp:ListItem>USER</asp:ListItem>
                                                 </asp:DropDownList>
                          </td>
                      </tr>
                <tr>
                    <td>
                             <asp:TextBox ID="TextBox3" runat="server" class="form-control" type="text" placeholder="PASSWORD" Width="200px" Height="30px"></asp:TextBox>

                    </td>
                </tr>
                      <tr>
                          <td>
                 <asp:DropDownList ID="DropDownList2" runat="server" class="form-control" placeholder="FONKSIYON" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Width="209px" Height="30px">
                                <asp:ListItem>YETKİSİZ</asp:ListItem>
                                <asp:ListItem>ADD</asp:ListItem>
                                <asp:ListItem>DELETE</asp:ListItem>
                                <asp:ListItem>UPDATE</asp:ListItem>
                                 </asp:DropDownList>
                          </td>
                      </tr>
                  <tr>
                          <td>
                                          <asp:Button ID="Button5" runat="server" class="btn btn-primary" style="background-color:chocolate" Height="31px" Width="52px" OnClick="CANCEL_Click" Text="X"/>

                                          <asp:Button ID="Button1" runat="server" Text="ADD" class="btn btn-primary"   style="background-color:#ffffff1b; color:gray;border-block-color:gray;border:3px solid" Height="30px" Width="121px" OnClick="ADD_Click"/>

                          </td>
                      </tr>
           </table>
        </li>
</ul>
        <div class="auto-style2">
            <div class="auto-style8">
          <div style="box-shadow: 3px 3px 4px #aa5f0300; margin-left: 0px; margin-right: 0px; border-radius:150px 150px 150px 150px; margin-top: 4px; margin-bottom: 3px;" class="auto-style14">
            
              <table >
                  <tr><td>
   
              <asp:Button  ID="Button4" runat="server" class="btn btn-primary" style="background-color:#ffffff1b; color:white;border-block-color:white;border:3px solid" Height="37px" Width="121px" OnClick="ADDN_Click" Text="ADD"/>
            <asp:Button ID="Button2" runat="server" Text="UPDATE" class="btn btn-primary"  style="background-color:#ffffff1b; color:white;border-block-color:white;border:3px solid" Height="37px" Width="121px" OnClick="UPDATE_Click"/>
            <asp:Button ID="Button3" runat="server" Text="DELETE" class="btn btn-primary"  style="background-color:#ffffff1b; color:white;border-block-color:white;border:3px solid" Height="37px" Width="121px" OnClick="DELETE_Click"/>
            
                      </td></tr>
               
                  <tr><td> <asp:GridView ID="PERSONS" runat="server"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnSelectedIndexChanged="PERSONS_SelectedIndexChanged" CssClass="auto-style16" Height="320px" Width="750px">
               <FooterStyle BackColor="#ffffff91" ForeColor="Black" />
                    <HeaderStyle BackColor="WhiteSmoke" Font-Bold="True" ForeColor="Gray" />
                    <PagerStyle BackColor="#ffffff91" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                       
                <Columns>
                <asp:ButtonField CommandName="Select" Text="Düzenle" />
                      <asp:TemplateField>
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                        
                          <asp:Image runat="server"  ImageUrl='<%#Eval("İMAGENAME") %>' Width="50px" Height="50px"/>
                            

                        
                      </ItemTemplate>
                  </asp:TemplateField>
            </Columns>
                 </asp:GridView>

                      </td>
                      
               
                  </tr>
                  
                     
                      <tr>
                          <td>
                                          &nbsp;</td>
                      </tr>
            <div class="auto-style11" >
            <td> </td>

            </div>
             <br />
           
             <br />
                 <br />
           
                 <br />
                 <br /></td>
                     
                  </tr>
              </table>
             
                   <br />
                    <br
                        />
              </div>
             </div>
            
            
          </div>                  
            
        </div>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:ImageButton ID="Exit" runat="server" CssClass="auto-style15" Height="27px" Width="33px" src="home.svg" OnClick="Exit_Click"/>
    </form>
    </body>
                                 

</html>





