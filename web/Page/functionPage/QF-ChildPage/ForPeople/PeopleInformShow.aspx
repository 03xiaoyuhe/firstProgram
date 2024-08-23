<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PeopleInformShow.aspx.cs" Inherits="WebForm.Page.functionPage.QF_ChildPage.ForPeople.PeopleInformShow" %>

<%@ Register Src="~/ASCX/PeopleInform/PeopleShow.ascx" TagName="PeopleShow" TagPrefix="PeopleInf" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <link href="../../../../assets/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        /* 将字体设为红色 */
        .setCharRed {
            color: red;
        }

        /* 缩小字体 */
        .setCharSizeSmall {
            font-size: 10px;
        }

        .program-errorBox {
            display: inline-block;
        }


        .index_box {
            position: fixed; /*相对于浏览器进行定位*/
            bottom: 50px;
            right: 0;
            /*background:-webkit-linear-gradient(top, rgba(0,0,0,1),rgba(0,0,0,0));*/
            max-height: 40%;
            overflow: auto;
        }

            .index_box::-webkit-scrollbar {
                display: none
            }

        .ppshade {
            background: linear-gradient( rgba(255, 255, 255, 0.001),blue); /* 溢出部分那显示渐变 */
            overflow: hidden;
            margin-right: 10px;
        }
    </style>
</head>


<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div style="width: 100%; margin: 0 auto;">
            

            <div style="width:100%;height:490px;overflow:auto;">
                <PeopleInf:PeopleShow runat="server" ID ="PeopleInf"></PeopleInf:PeopleShow>
            </div>

         </div>

        <div class="z-3 ppshade">
            <div class="index_box">
                <asp:PlaceHolder ID="errroMassage" runat="server"></asp:PlaceHolder>
            </div>
        </div>
    </form>

    
    <script src="../../../../assets/js/color-modes.js"></script>
</body>
</html>
