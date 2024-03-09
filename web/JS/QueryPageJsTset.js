
/////////////////////////
//   导航栏操作定义    //
/////////////////////////

// 定义按钮与对应Div的映射
var buttonToDiv = {
    filtrateBtm: "filtrateSidebar",
};

// 存储显示状态
var divMode = {
    filtrateSidebar: "unShow",
};

// 存储按钮点击状态
var buttonMode = {
    filtrateBtm: "PopOff",
};

// 初始化页面显示数据
function initStartData() {
    for (var data in buttonToDiv) {
        var divId = buttonToDiv[data];

        divMode[divId] = "UnShow";
    }
    for (var data in divMode) {
        window.alert(data);
    }
}

// 检测侧边栏显示状态
var checkDivIsShow = function (Id) {
    //函数声明使用匿名函数声明然后赋值给变量的方法
    if (divMode[Id] == "Show") {
        return true;
    }
    else {
        return false;
    }
};

// 将Div设为可见
function setSidebarShow(Id) {
    document.getElementById(Id).style.display = "";
    window.alert(divId);
    divMode[Id] = "Show";
}


// 导航栏按钮点击事件
function sidebarButtom_OnClick() {
    // 获取被点击的按钮的id
    var buttonId = event.target.getAttribute("id");

    // 获取被点击的按钮对应的Div Id
    var divId = buttonToDiv[buttonId];
    var IsShow = checkDivIsShow(divId);

    if (!IsShow) {
        setSidebarShow(divId);
        window.alert(divId);
    }

}
