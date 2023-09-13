<%@ Page Language="C#" AutoEventWireup="true" CodeFile="homeTest.aspx.cs" Inherits="home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        /* 通用功能设置 */
        .positionRelative{
            position:relative;
        }

        /* 右浮动 */
        .float-right{
            float:right;
        }

        /* 右浮动 */
        .float-left{
            float:left;
        }

        /* 取消孩子浮动 */
        .makeUnfloat{
            overflow:hidden;
        }
        
        /* 竖直居中 使用相对定位*/
        .relVerticalCenter{/* 竖直margin必须为零否则会出bug */
            position:relative;
            top:50%;
            transform:translate(0,-50%);
        }
        
        /* 竖直居中 使用绝对定位*/
        .absVerticalCenter{/* 竖直margin必须为零否则会出bug */
            position:absolute;
            top:50%;
            transform:translate(0,-50%);
        }
        
        /* 中心居中 使用绝对定位*/
        .absCenter{/* 竖直margin必须为零否则会出bug */
            position:absolute;
            left:50%;
            top:50%;
            transform:translate(-50%,-50%);
        }


        /* 特定功能属性 */

        /* 主页基本设定 */
        .body{
            min-width:1200px;
            max-width:1550px;
            margin:auto;
            /* 设置背景图 并使其自适应大小 */
            background-image:url("img/homeHeadImg.jpg");
            background-repeat: no-repeat;
            background-size: contain;
        }
        /* 首页大图部分 */

        /* 首页大图辅助定位 */
        .HeadHelpBox{
            position:relative;
            height:100%;
            padding-bottom:55.8%;
            margin:0 auto;
        }

        /* 大图放置容器 */
        .imgBox{
            position:absolute;
            width:80%;
            height:80%;
            
            border:solid 1px;
            border-color:white;
            border-radius:20px;
            overflow:hidden;
            box-shadow: 0 0 20px 5px rgba(126, 126, 126);/* 阴影设置 */
            margin-top:-10px;

        }
        /* 图片样式 */
        .Img{
            margin:0 auto;
            width:100%;
            height:100%;
            object-fit:cover;
        }

        /* 功能展示部分 */

        /* 便签格式 */
        .note{
            height:200px;
            width:700px;
            margin:20px 150px;
            border-radius:10px;
            box-shadow: 0 0 10px 2px rgba(126, 126, 126);/* 便签阴影设置 */
        }
        /* 文本框格式 */
        .textBox{
            margin:10px;
            width:380px;
            word-wrap:break-word;
        }
        
        /* 照片盒子 */
        /* 盒子1  左浮动 */
        .imgBox1{
            margin:0 10px;
            background-color:aqua;
            height:160px;
            width:160px;
        }
        
        /* 盒子2  右浮动 */
        .imgBox2{
            margin:0 10px;
            background-color:brown;
            height:160px;
            width:160px;
        }
        
        /* 盒子3  左浮动 */
        .imgBox3{
            margin:0 10px;
            background-color:coral;
            height:160px;
            width:160px;

        }
    </style>
</head>
<body>

    <form id="form1" runat="server" class="body">
        <!-- 首页大图部分 -->
        <div class="HeadHelpBox"><!-- 辅助定位盒子 -->
        </div>

        <!-- 功能展示部分 -->
        <div> <!-- 功能展示主盒子 -->
             <div class="makeUnfloat"><!-- 便签1辅助定位盒子 -->
                <div class="note makeUnfloat"><!-- 便签本体 -->
                     <div class="imgBox1 float-right relVerticalCenter"></div><!-- 配图放置处 -->
                     <div class="textBox float-left"><!-- 文字盒子 -->
                         11111111111111111111111111111111111111
                     </div>
                 </div>
             </div>
        
            <div class="makeUnfloat"><!-- 便签2辅助定位盒子 -->
                <div class="note float-right makeUnfloat"><!-- 便签本体 -->
                    <div class="textBox float-right"><!-- 文字盒子 -->
                        11111111111111111111111111111111111111111111111111
                    </div>
                    <div class="imgBox2 float-left relVerticalCenter"></div><!-- 配图放置处 -->
                </div>
            </div>

            <div class="makeUnfloat"><!-- 便签3辅助定位盒子 -->
                <div class="note makeUnfloat"><!-- 便签本体 -->
                    <div class="imgBox3 float-right relVerticalCenter"></div><!-- 配图放置处 -->
                    <div class="textBox float-left"><!-- 文字盒子 -->
                        11111111111111111111111111111111111111

                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
