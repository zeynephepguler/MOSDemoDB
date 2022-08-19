<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-top: 0px;
        }
        .auto-style2 {
            position: center;
            margin:0;
           
           
            height: 442px;
            width: 384px;
          
           
           
        }
    </style><link href="Content/bootstrap-theme.css" rel="stylesheet" />
<link href="Content/bootstrap.css" rel="stylesheet" />
</head>

    <body style="background: linear-gradient(217deg, rgba(255,0,0,.8), rgba(255,0,0,0) 70.71%),
            linear-gradient(127deg, rgba(0,255,0,.8), rgba(0,255,0,0) 70.71%),
            linear-gradient(336deg, rgba(0,0,255,.8), rgba(0,0,255,0) 70.71%);margin:0px;" >
     
    
             <form id="form1" runat="server" class="auto-style1" style="margin:0px;" ><center>
                         <div style="border-style: solid; border-color: inherit; border-width: 2px; background-color:#ffffff1a; color:white; border-block-color:white; box-shadow: 3px 3px 4px #aa5f0300;margin-top:200px; margin-left: 0px; margin-right: 0px; border-radius:50px 50px 50px 50px; margin-bottom: 3px;" class="auto-style2">
                            <p>Admin : Ece 123</p>
                             <p>User : Zeynep 123</p>
                            <br />
                            
                                
                                     
                                                                      
                                        
                                            <asp:Image ID="Image1" runat="server" Width="323px"  src="cizim1.svg" Height="163px"/>
                                            <br />
                                            <br />

                                            <asp:TextBox ID="TextBox1" runat="server" type="text" class="form-control" placeholder="Kullanıcı Adı" style="background-color:#ffffff4c; color:white;border-block-color:white;border:2px solid" Height="40px" Width="282px"></asp:TextBox>
                                            <br />
                                            <asp:TextBox ID="TextBox2" runat="server" type="password" class="form-control" placeholder="Şifre" style="background-color:#ffffff3d; color:white;border-block-color:white;border:2px solid" Height="40px" Width="282px"></asp:TextBox><br />
                                            <asp:Button ID="Button2" runat="server" Text="Login" class="btn btn-primary" style="background-color:#ffffffa3; color:white;border-block-color:white;border:2px solid" OnClick="Button2_Click" Height="42px" Width="121px"/>
                                    
                                                
                                        
                                            
                                 </div>
                             
</center>
                         

             </form>
           </body>
   
                       
   
                         
   
                       
   
              

</html>
