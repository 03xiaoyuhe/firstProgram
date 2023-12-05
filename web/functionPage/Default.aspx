<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="functionPage_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <button id="btn" onclick="threeFn(this)" next="tttt" sss="QueryForm.aspx">点我</button>
    <div id="aaa"></div>
    <iframe id="tttt"></iframe>
    <script type="text/javascript">

        // 第三种 通过方法响应点击事件
        function threeFn(this){
            //var tttt = document.getElementById(event.target.getAttribute("id"));
            var next = this.getAttribute("next");
            document.getElementById(next).src = this.getAttribute("sss");
        }

    </script>
    </form>
</body>
</html>
