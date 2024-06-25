function getRectanglesUrl() {
    var path = "rentangles";
    var x1 = $("#PointAX").val();
    var y1 = $("#PointAY").val();
    var x2 = $("#PointBX").val();
    var y2 = $("#PointBY").val();
    var take = $("#Take").val();
    Cookies.set('Take', take, { expires: 1 })
    var rectangleUrl = "Figure/Rectangles?A.X=" + x1 + "&A.Y=" + y1 + "&B.X=" + x2 + "&B.Y=" + y2 + "&take=" + take;
}