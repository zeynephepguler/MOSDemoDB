<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/StyleSheet1.css" rel="stylesheet" />
    

<div style="height:200px"></div>
    <div style="margin-left: 450px; margin-right: 450px; background-color:chocolate;border-radius:10px 10px 50px 10px; height: 274px;">
    
    <form>
        <br />
        <div class="form-group"  style="margin-left: 45px; margin-right: 45px;">
            <label for="Kullanıcı Adı">Kullanıcı Adı</label>
            <input type="text" class="form-control" id="kAdi" >
    
        </div>
        <div class="form-group" style="margin-left: 45px; margin-right: 45px;">
            <label for="sifre">Şifre</label>
            <input type="password" class="form-control" id="sifre">
        </div>
  
        
         
    </form>
    
        
        
            <Button  style="margin-left: 45px; margin-right: 45px;" ID="Button2" OnClick="Button2_Click"runat="server" >Gönder</button>
        
       
        

  </div>

</asp:Content>