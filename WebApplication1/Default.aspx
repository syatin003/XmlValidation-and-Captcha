<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="jquery-1.11.1.js"></script>
     <script type="text/javascript">

         $("#refreshbtn").click(function () {
             $("#img").attr("src", Test.aspx);

         })

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
             <ContentTemplate>
               <br />
                 <img id="img0" height="30" alt="Captcha" src="Test.aspx" style="width: 99px"/>
              </ContentTemplate>
             <Triggers>
              <asp:AsyncPostBackTrigger ControlID="audiobtn" EventName="Click" />
             </Triggers>
         </asp:UpdatePanel>
        <br />
        <asp:ImageButton ID="refreshbtn" runat="server" ImageUrl="~/refresh.png"  Width="36px" ToolTip="Refresh" />
                
         <br />
         <br />
         <asp:ImageButton ID="audiobtn" runat="server" ImageUrl="~/audio.png"  Width="36px" ToolTip="Audio" OnClick="audiobtn_Click" />
        <br />
         <br />
        
<asp:TextBox ID="txtTest" runat="server"></asp:TextBox>
      
        <input type="text" id="text1"/>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" ></asp:Label>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
       
    </div>
    </form>
</body>
</html>
