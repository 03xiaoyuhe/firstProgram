<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<%@ Register Src="~/ASCX/popMassage.ascx" TagName="popMassage" TagPrefix="TpopMassage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <script type="text/javascript">
        const toastTrigger = document.getElementById('liveToastBtn')
        const toastLiveExample = document.getElementById('liveToast')
        if (toastTrigger) {
            toastTrigger.addEventListener('click', () => {
                const toast = new bootstrap.Toast(toastLiveExample)

                toast.show()
            })
        }
    </script>
    <form id="form1" runat="server">
        <div>
            <TpopMassage:popMassage ID="footer1" runat="server" HeadColor="Red" HeadLine="ERRO" Massage="未知错误" />
            
            <link href="bootstrap-5.3.0-alpha1-dist/css/bootstrap.min.css" rel="stylesheet" />
            <script src="bootstrap-5.3.0-alpha1-dist/js/bootstrap.bundle.min.js"></script>
        </div>
    </form>
</body>
</html>
