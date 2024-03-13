
function TurnPage(type) {
    var currentPage = getQueryString("currentPage") == null ? 1 : parseInt(getQueryString("currentPage"));
    var maxPage = <%=maxPage%>;

    switch (type) {
        case 'f':
            currentPage = 1;
            break;
        case 'p':
            if (currentPage <= 1) {
                return;
            }
            else {
                currentPage = currentPage - 1;
            }
            break;
        case 'n':
            if (currentPage >= maxPage) {
                return;
            }
            else {
                currentPage = currentPage + 1;
            }
            break;
        case 'e':
            if (currentPage == maxPage) return;
            currentPage = maxPage;
            break;
        case 'a':
            if (isNaN(parseInt(document.getElementById("txtInputNumber").value))) {
                return;
            } else if (parseInt(document.getElementById("txtInputNumber").value) > maxPage) {
                alert("没有那么多页");
                return;
            } else {
                currentPage = parseInt(document.getElementById("txtInputNumber").value);
            }
            break;
        default:
            break;
    }

    if (!isNaN(currentPage) && currentPage > 0) {
        location.href = "?currentPage=" + currentPage;
    }
}
