<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="WebApplication2.User" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml"  style="background:no-repeat linear-gradient(#ff6a00 ,#ffffff);">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="Content/bootstrap-theme.css" rel="stylesheet" />
<link href="Content/bootstrap.css" rel="stylesheet" />
    <style type="text/css">


        .auto-style2 {
            position: relative;
            min-height: 1px;
            top: 143px;
            left: 650px;
            height: 223px;
            width: 566px;
            float: left;
            margin-right: 7px;
            margin-top: 0px;
            padding-left: 15px;
            padding-right: 15px;
            text-align: -webkit-center;

        }
        .auto-style6 {
            margin-top: 0px;
            margin-left: 23px;
            margin-right: 22px;
            margin-bottom: 11px;
            font-size: x-small;
                        

        }
        .auto-style7 {
            font-size: small;
            margin-right: 9px;
            margin-top: 7px;
            margin-bottom: 5px;
            margin-left: 19px;
               
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
        .auto-style11 {
            width: 92px;
        }
        .auto-style12 {
            font-size: xx-small;
            margin-right: 2px;
            margin-top: 5px;
        }
        .auto-style13 {
            margin-right: 301px;
        }
        .auto-style14 {
            font-size: large;
        }
    </style>
 

    <link href="Menu.css" rel="stylesheet" />

</head>
   
<body style="height: 1045px; background: linear-gradient(217deg, rgba(255,0,0,.8), rgba(255,0,0,0) 70.71%),
            linear-gradient(127deg, rgba(0,255,0,.8), rgba(0,255,0,0) 70.71%),
            linear-gradient(336deg, rgba(0,0,255,.8), rgba(0,0,255,0) 70.71%); background-color:white;">
 
    <form id="form1" runat="server"  >
    <ul class="auto-style13">
        <li style="margin-top:50px"></li>
        <li>
     
            <asp:Image ID="UIMAGE" runat="server" class="i"/>
               <br />
               <br />
            <asp:Label ID="UNAME" runat="server"  class="t"  ></asp:Label>
           
           
             
        </li>
  <li><a class="active" href="#">Kullanıcı Ekle</a></li>

  <li><a href="#news">Kullanıcı Listele</a></li>

  
</ul>


    
   

     
             <div class="auto-style2">
             

                        
                     
             
      

  
            <br />
            <table  class="auto-style8" style="background-color:#ffffffff; color:white;border-block-color:white; box-shadow: 5px 5px 6px #00000040; border-radius:25px 25px 25px 25px;"><tr><td><strong><asp:Button runat="server" ID="Addn" Text="ADD new user +" CssClass="auto-style7" style="background-color:#ffffff1b; color:gray;border-block-color:gray;border:3px solid" Height="28px" Width="185px" OnClick="Add_Click"/></strong></td></tr><tr><td>
                <asp:GridView style="border-radius:5px 5px 5px 5px;" ID="PERSONS" runat="server" Height="346px" Width="581px"  OnRowCommand="PERSONS_RowCommand"  OnSelectedIndexChanged="PERSONS_SelectedIndexChanged" CssClass="auto-style6" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                  
                <Columns>
                <asp:ButtonField CommandName="Select" Text="Düzenle" />
                    
                    <asp:ButtonField CommandName="Delete_row" Text="Sil"  />
                    
            </Columns>
                    <FooterStyle BackColor="#ffffff91" ForeColor="Black" />
                    <HeaderStyle BackColor="WhiteSmoke" Font-Bold="True" ForeColor="Gray" />
                    <PagerStyle BackColor="#ffffff91" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />

                </asp:GridView></td></tr></table>
            <br />

         <tr><asp:TextBox ID="IDBox" runat="server" class="form-control" placeholder="ID" Width="300px"  ></asp:TextBox> </tr>
        <tr>
            <td> <asp:TextBox ID="FotoText" runat="server" class="form-control" placeholder="Fotoğraf Ekle" Width="129px" Height="21px" ></asp:TextBox></td> </tr>
                <tr>
            <div class="auto-style11" >
            <td> </td>

                <asp:Button ID="FotoButton" runat="server" Text="Ekle" class="btn btn-primary" style="background-color:gray" Height="22px" Width="79px" CssClass="auto-style10" OnClick="FotoButton_Click"/>

            </div>
            <asp:FileUpload ID="fuResim" runat="server" />
            <asp:TextBox ID="USERNAME" runat="server" class="form-control" type="text" placeholder="USERNAME" Width="300px"></asp:TextBox></tr>
                <tr><asp:DropDownList ID="UserType" runat="server" class="form-control" placeholder="USERTYPE" Width="300px">
                <asp:ListItem>ADMIN</asp:ListItem>
                <asp:ListItem>USER</asp:ListItem>
                 </asp:DropDownList></tr>
                <tr><asp:TextBox ID="PASS" runat="server" class="form-control" type="text" placeholder="PASSWORD" Width="300px"></asp:TextBox></tr>
                <tr><asp:Button ID="CANCEL" runat="server" class="btn btn-primary" style="background-color:gray" Height="32px" Width="61px" OnClick="CANCEL_Click" Text="İptal"/></tr>
              
       
            <asp:Button ID="ADD" runat="server" Text="ADD" class="btn btn-primary" style="background-color:gray" Height="37px" Width="121px" OnClick="ADD_Click"/>
            <asp:Button ID="UPDATE" runat="server" Text="UPDATE" class="btn btn-primary" style="background-color:gray" Height="37px" Width="121px" OnClick="UPDATE_Click"/>
            <asp:Button ID="DELETE" runat="server" Text="DELETE" class="btn btn-primary" style="background-color:gray" Height="37px" Width="121px" OnClick="DELETE_Click"/>
           
             </div>      
        </form>    
            
          
                
              
           
    
        
  
   
 </body>


</html>
