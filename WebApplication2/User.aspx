<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="WebApplication2.User" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml"  style="background:no-repeat linear-gradient(#ff6a00 ,#ffffff);">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="Content/bootstrap-theme.css" rel="stylesheet" />
<link href="Content/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 112px;
            height: 101px;
            margin-left: 34px;
            margin-right: 25px;
            margin-top: 14px;
            margin-bottom: 18px;
        }
        .auto-style2 {
            position: relative;
            min-height: 1px;
            top: 143px;
            left: 469px;
            height: 223px;
            width: 566px;
            float: left;
            margin-right: 7px;
            margin-top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
        .auto-style5 {
            display: block;
            margin-right: auto;
            margin-left: 0px;
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
        .auto-style9 {
            position: relative;
            min-height: 1px;
            top: -1px;
            left: 113px;
            height: 234px;
            width: 69%;
            float: left;
            margin-right: 7px;
            margin-top: 0px;
            padding-left: 15px;
            padding-right: 15px;
            margin-bottom: 20px;
        }
        .auto-style10 {
            font-size: x-small;
        }
        .auto-style11 {
            width: 92px;
        }
    </style>
 
<script>
 
</script>
</head>
   
<body style="height: 1045px; background: linear-gradient(217deg, rgba(255,0,0,.8), rgba(255,0,0,0) 70.71%),
            linear-gradient(127deg, rgba(0,255,0,.8), rgba(0,255,0,0) 70.71%),
            linear-gradient(336deg, rgba(0,0,255,.8), rgba(0,0,255,0) 70.71%); background-color:white;">
    <center>
    <div class="auto-style2">
    <form id="form1" runat="server" class="active" >
      <div class="auto-style9" style="background-color:#ffffff91; color:gray;border-block-color:gray; box-shadow: 5px 5px 6px #00000040; border-radius:30px 30px 30px 30px;">
          <asp:GridView ID="GridView2" runat="server"></asp:GridView>
        <table class="auto-style5"><tr><td id="bilg"></td><td id="bilg">

        <img name="foto" id="foto" alt="yokscnm" class="auto-style1"  src="15.png"
            style="background-color:#ffffff1b; color:gray;border-block-color:gray; box-shadow: 3px 3px 4px #aa5f0300; border-radius:50px 50px 50px 50px; "/>   <?php 
               ş
        $query = " select * from TBLUSERS where ID='"+Kullanici.KullaniciId+"'";
        $result = mysqli_query($db, $query);
 
        while ($data = mysqli_fetch_assoc($result)) {
    ?>
        <img src="<?php echo $data['İMAGENAME']; ?>"/>
 
    <?php
        }
    ?></td><td id="bilg">&nbsp; <?php echo $data['İMAGENAME']; ?></td></tr>
            <tr><td>Adı: </td><td></td><td></td></tr>
            <tr><td>Fonksiyonu :</td><td></td><td></td></tr>
        </table>

      </div>
            <br />
            <table  class="auto-style8" style="background-color:#ffffffff; color:white;border-block-color:white; box-shadow: 5px 5px 6px #00000040; border-radius:25px 25px 25px 25px;"><tr><td><strong><asp:Button  runat="server" ID="Add" Text="ADD new user +" CssClass="auto-style7" style="background-color:#ffffff1b; color:gray;border-block-color:gray;border:3px solid" Height="28px" Width="185px" OnClick="Add_Click"/></strong></td></tr><tr><td>
                <asp:GridView style="border-radius:5px 5px 5px 5px;" ID="GridView1" runat="server" Height="346px" Width="581px"  OnRowCommand="GridView1_RowCommand"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CssClass="auto-style6" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                  
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

         <tr><asp:TextBox ID="TextBox8" runat="server" class="form-control" placeholder="ID" Width="300px" OnTextChanged="TextBox8_TextChanged" ></asp:TextBox> </tr>
        <tr>
            <td> <asp:TextBox ID="FotoText" runat="server" class="form-control" placeholder="Fotoğraf Ekle" Width="129px" Height="21px" ></asp:TextBox></td> </tr>
                <tr>
            <div class="auto-style11" >
            <td> </td>

                <asp:Button ID="FotoButton" runat="server" Text="Ekle" class="btn btn-primary" style="background-color:gray" Height="22px" Width="79px" CssClass="auto-style10" OnClick="FotoButton_Click"/>

            </div>
            <asp:FileUpload ID="fuResim" runat="server" />
            <asp:TextBox ID="TextBox5" runat="server" class="form-control" type="text" placeholder="USERNAME" Width="300px"></asp:TextBox></tr>
                <tr><asp:DropDownList ID="DropDownList2" runat="server" class="form-control" placeholder="USERTYPE" Width="300px">
                <asp:ListItem>ADMIN</asp:ListItem>
                <asp:ListItem>USER</asp:ListItem>
                 </asp:DropDownList></tr>
                <tr><asp:TextBox ID="TextBox6" runat="server" class="form-control" type="text" placeholder="PASSWORD" Width="300px"></asp:TextBox></tr>
                <tr><asp:Button ID="Button5" runat="server" class="btn btn-primary" style="background-color:gray" Height="32px" Width="61px" OnClick="Button5_Click" Text="İptal"/></tr>
              
       
            <asp:Button ID="Button1" runat="server" Text="ADD" class="btn btn-primary" style="background-color:gray" Height="37px" Width="121px" OnClick="Button1_Click"/>
            <asp:Button ID="Button2" runat="server" Text="UPDATE" class="btn btn-primary" style="background-color:gray" Height="37px" Width="121px" OnClick="Button2_Click"/>
            <asp:Button ID="Button3" runat="server" Text="DELETE" class="btn btn-primary" style="background-color:gray" Height="37px" Width="121px" OnClick="Button3_Click"/>
           
                   
        </form>    
            
          </div>
                
              
           
    
        
        </center>
    <p>
        &nbsp;</p>
 </body>
</html>
