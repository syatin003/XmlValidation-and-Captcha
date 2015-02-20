<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iframe.aspx.cs" Inherits="WebApplication1.iframe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script type="text/javascript">
         function SetFrameBGToRed() {
             var italicTag = document.createElement("i");
             italicTag.innerHTML = "Italic text";

             var frame = document.getElementById("myFrame");
             var frameDoc = frame.contentWindow.document;
             frameDoc.body.style.backgroundColor = "red";
         }
    </script>
</head>

<body style="background-color:#fbd8a4;">
    <h1>Contents of the frame</h1>
    <form id="form1" runat="server">
    <div>
    <button onclick="SetFrameBGToRed ()">Set frame background to red</button>
    <iframe id="myFrame" src="frame.htm" width="500px" height="250px" draggable="true"></iframe>
    </div>
    </form>
</body>
</html>
