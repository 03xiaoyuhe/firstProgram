/* global bootstrap: false */
(() => {
  'use strict'
  const tooltipTriggerList = Array.from(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
  tooltipTriggerList.forEach(tooltipTriggerEl => {
    new bootstrap.Tooltip(tooltipTriggerEl)
  })
})()

//1.为 < div > 元素添加一个类:
//document.getElementById("div").classList.add("类名");
//2.为 < div > 元素添加多个类:
//document.getElementById("div").classList.add("类名1", "类名2", "类名3", ...);
//3.为 < div > 元素移除一个类:
//document.getElementById("div").classList.remove("类名");
//4.为 < div > 元素移除多个类:
//document.getElementById("div").classList.remove("类名1", "类名2", "类名3", ...);
