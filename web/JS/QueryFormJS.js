// 显示所有项目信息逻辑
function selectAll() {
    document.getElementById("test").src = "QF-ChildPage/selectAll.aspx";
}

// 快速添加项目
function addProgram() {
    document.getElementById("test").src = "QF-ChildPage/addProgram.aspx";
}


$(function () {
    window.programLoad = function () {
        document.getElementById("test").src = "QF-ChildPage/ProgremLoad.aspx";
    }
})

// 测试
function test() {
    document.getElementById("test").src = "https://www.bilibili.com/";
}
