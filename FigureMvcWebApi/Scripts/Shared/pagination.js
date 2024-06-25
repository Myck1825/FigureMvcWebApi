$.urlParam = function (name, currentUrl) {
    var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(currentUrl);
    if (results == null) {
        return null;
    }
    return decodeURI(results[1]) || 0;
}

function pagination (totalCount, take) {
    window.pagObj = $('#pagination').twbsPagination({
        totalPages: totalCount / take,
        visiblePages: 10,
        onPageClick: function (event, page) {
        }
    }).on('page', function (event, page) {
        var currentUrl = Cookies.get('rectangleUrl');
        var pageNumber = $.urlParam('PageNumber', currentUrl)
        if (pageNumber == null) {
            currentUrl = currentUrl + '&PageNumber=' + page
        }
        else {
            currentUrl = currentUrl.replace("PageNumber=" + pageNumber, "PageNumber=" + page);
        }
        getRectangles(currentUrl);
    });
};