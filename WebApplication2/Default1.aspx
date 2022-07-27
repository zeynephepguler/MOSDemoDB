<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="background-image:url(mars.jpg)">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<link href="Content/bootstrap-theme.css" rel="stylesheet" />
<link href="Content/bootstrap.css" rel="stylesheet" />
    <body style="background-image:url(mars.jpg)">
     
    
             <form id="form1" runat="server" >
                         <div style="box-shadow: 3px 3px 4px #aa5f0300; margin-left: 661px; margin-right: 0px; ;border-radius:150px 150px 150px 150px; height: 442px; width: 388px; top: 34px; left: 101px; margin-top: 250px; margin-bottom: 3px;" class="col-md-3">
    
                            <br />
                                <div class="row"
                                    <div class="col-md"
                                      
                                        <div style="margin-left: 55px; margin-right: 55px; margin:55px;"> 
                                            <asp:Image ID="Image1" runat="server" Width="224px"  src="mos.png" Height="112px"/>
                                            <br />
                                            <br />
                                            <asp:TextBox ID="TextBox1" runat="server" type="text" class="form-control" placeholder="Kullanıcı Adı" style="background-color:#ffffff3d; color:white" Height="40px" Width="282px"></asp:TextBox>
                                            <br />
                                            <asp:TextBox ID="TextBox2" runat="server" type="text" class="form-control" placeholder="Şifre" style="background-color:#ffffff3d; color:white" Height="40px" Width="282px"></asp:TextBox><br />
                                            <asp:Button ID="Button2" runat="server" Text="Button" class="btn btn-primary" style="background-color:chocolate" OnClick="Button2_Click" Height="42px" Width="121px"/>
                                     </div>
                                                
                                        </div>
                                            
                                 </div>
                             </div> 

                         

             </form>
           </body>
   
                       
   
                         
   
                       
   
              

</html>
