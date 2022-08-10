
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication2.Admin"  Debug="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="background:no-repeat fixed linear-gradient(#808080, #ffffff) ; ">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <configuration>
   <system.web>
       <compilation debug="true"/>
   </system.web>
</configuration>
  <style type="text/css">
       
        .auto-style1 {
            position: relative;
            min-height: 1px;
            top: 313px;
            left: 24px;
            height: 81px;
            width: 32%;
            float: left;
            margin-right: 7px;
            margin-top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
        .auto-style2 {
            position: relative;
            min-height: 1px;
            top: 263px;
            left: 666px;
            height: 81px;
            width: 31%;
            float: left;
            margin-right: 7px;
            margin-top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
        .auto-style5 {
            position: relative;
            min-height: 1px;
            top: 129px;
            left: -458px;
            height: 39px;
            width: 4%;
            float: left;
            font-size: xx-large;
            margin-right: 7px;
            margin-top: 0px;
            padding-left: 15px;
            padding-right: 15px;
          color: #FFFFFF;
      }
       
      .auto-style6 {
          height: 366px;
      }
       
      .auto-style7 {
          margin-right: 0px;
      }
      .auto-style8 {
          font-size: small;
          margin-right: 0px;
      }
       
    </style>
     <link href="Content/bootstrap-theme.css" rel="stylesheet" />
<link href="Content/bootstrap.css" rel="stylesheet" />
</head>
   
<body style="height: 1045px; background: linear-gradient(217deg, rgba(255,0,0,.8), rgba(255,0,0,0) 70.71%),
            linear-gradient(127deg, rgba(0,255,0,.8), rgba(0,255,0,0) 70.71%),
            linear-gradient(336deg, rgba(0,0,255,.8), rgba(0,0,255,0) 70.71%); background-color:white;" >
    <form id="form1" runat="server" class="auto-style6">
        <div class="auto-style7">
          <div style="box-shadow: 3px 3px 4px #aa5f0300; margin-left: 0px; margin-right: 0px; border-radius:150px 150px 150px 150px; margin-top: 4px; margin-bottom: 3px;" class="auto-style2">
            <asp:Button  ID="Button4" runat="server" class="btn btn-primary" style="background-color:#ffffff1b; color:gray;border-block-color:gray;border:3px solid" Height="37px" Width="121px" OnClick="ADDN_Click" Text="ADD"/>
              &nbsp;<asp:Button ID="Button2" runat="server" Text="UPDATE" class="btn btn-primary"  style="background-color:#ffffff1b; color:gray;border-block-color:gray;border:3px solid" Height="37px" Width="121px" OnClick="UPDATE_Click"/>
            <asp:Button ID="Button3" runat="server" Text="DELETE" class="btn btn-primary"  style="background-color:#ffffff1b; color:gray;border-block-color:gray;border:3px solid" Height="37px" Width="121px" OnClick="DELETE_Click"/>
          </div>
             <div class="auto-style1">
                <asp:GridView ID="GridView1" runat="server"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnSelectedIndexChanged="PERSONS_SelectedIndexChanged" CssClass="auto-style8" Height="320px" Width="750px">
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
                   <br />
                    <br
                        
             </div><asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="ID"></asp:TextBox> &nbsp;<br />
            <td> <asp:TextBox ID="FotoText" runat="server" class="form-control" placeholder="Fotoğraf Ekle" Width="129px" Height="21px" ></asp:TextBox></td> </tr>
                <tr>
            <div class="auto-style11" >
            <td> </td>
               <asp:FileUpload ID="fuResim" runat="server" />
                <asp:Button ID="FotoButton" runat="server" Text="Ekle" class="btn btn-primary" style="background-color:gray" Height="22px" Width="79px" CssClass="auto-style10" OnClick="FotoButton_Click"/>

            </div>
            
            <asp:TextBox ID="TextBox2" runat="server" class="form-control" type="text" placeholder="USERNAME" ></asp:TextBox>
             <br />
            <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" placeholder="USERTYPE">
                <asp:ListItem>ADMIN</asp:ListItem>
                <asp:ListItem>USER</asp:ListItem>
                 </asp:DropDownList>
             <br />
                 <asp:TextBox ID="TextBox3" runat="server" class="form-control" type="text" placeholder="PASSWORD"></asp:TextBox>
                 <br />
            <asp:DropDownList ID="DropDownList2" runat="server" class="form-control" placeholder="FONKSIYON" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                <asp:ListItem>YETKİSİZ</asp:ListItem>
                <asp:ListItem>ADD</asp:ListItem>
                <asp:ListItem>DELETE</asp:ListItem>
                <asp:ListItem>UPDATE</asp:ListItem>
                 </asp:DropDownList>
                 <br />
            <asp:Button ID="Button5" runat="server" class="btn btn-primary" style="background-color:chocolate" Height="31px" Width="52px" OnClick="CANCEL_Click" Text="X"/>
            <asp:Button ID="Button1" runat="server" Text="ADD" class="btn btn-primary"   style="background-color:#ffffff1b; color:gray;border-block-color:gray;border:3px solid" Height="37px" Width="121px" OnClick="ADD_Click"/>
                 <br />
&nbsp;
                 &nbsp;&nbsp;&nbsp;
            <br />
            <br />
          </div>                  
            
            <div class="auto-style5">
                <strong>ADMİN</strong></div>
        </div>
        <p>
            &nbsp;</p>
    </form>
    <p>
&nbsp;</p>
 </body>
                                 

</html>





