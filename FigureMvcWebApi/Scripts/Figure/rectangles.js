// yourModel now contains your MVC (server side) model as json serialized model.
function buildChart(dataSource, id, number) {
    
    //var dataSource = [
    //    { 'X': '2', 'Y': 3 },
    //    { 'X': '3', 'Y': 1 },
    //    { 'X': '3', 'Y': 1 },
    //    { 'X': '3', 'Y': 4 },
    //    { 'X': '4', 'Y': 3 },
    //    { 'X': '5', 'Y': 4 },
    //    { 'X': '5', 'Y': 1 },
    //    { 'X': '5', 'Y': 1 }

        //    //{ argument: '3', value1: 15, value2: 10, value3: 60, value4: 40 }

    //]
    //console.log(dataSource);
    //console.log(dataSource1);

    $("#chartContainer" + number).dxChart({
        dataSource: dataSource,
       
        //tooltip: { enabled: true },
        commonSeriesSettings: {
            argumentField: 'X',
            type: 'line',
            //label: {
            //    visible: true,
            //    connector: {
            //        visible: true,
            //        width: 1
            //    }
            //}
        },
        //argumentAxis: {
        //    name: "X"
        //},
        series: [
            { valueField: 'Y2', name: 'Segment' },
            { valueField: 'Y1', name: 'Rectangle Id: ' + id, point: { symbol: "rectangle" }, color: 'blue' },
            { valueField: 'Y3', point: { symbol: "rectangle" }, color: 'blue' }
            ],

    });
};

function getRectanglesUrl() {
    var path = "/mvc/rectangles";
    var x1 = $("#PointAX").val();
    if (x1 == '' || x1 == undefined) {
        alert('Please fill field coordinate X point\'s A');
        return;
    }
    var y1 = $("#PointAY").val();
    if (y1 == '' || y1 == undefined) {
        alert('Please fill field coordinate Y point\'s A');
        return;
    }
    var x2 = $("#PointBX").val();
    if (x2 == '' || x2 == undefined) {
        alert('Please fill field coordinate X point\'s B');
        return;
    }
    var y2 = $("#PointBY").val();
    if (y2 == '' || y2 == undefined) {
        alert('Please fill field coordinate Y point\'s B');
        return;
    }
    var take = $("#Take").val();
    return path + "?A.X=" + x1 + "&A.Y=" + y1 + "&B.X=" + x2 + "&B.Y=" + y2 + "&take=" + take;
}

function getRectangles(rectangleUrl) {
    var curl = getRectanglesUrl();

    if (rectangleUrl != '' && rectangleUrl != undefined) {
        curl = rectangleUrl;
    }
    Cookies.set('rectangleUrl', curl);
    $.get(curl, function (data, status) {
        if (status == 'success') {
            var x1 = $("#PointAX").val();
            var y1 = $("#PointAY").val();
            var x2 = $("#PointBX").val();
            var y2 = $("#PointBY").val();

            $('#myPartialViewDiv').html('');
            for (let i = 0; i < data.RectangleList.length; ++i) {

                jQuery('<div>', {
                    id: 'chartContainer'+i,
                }).appendTo('#myPartialViewDiv');

                var dataSource = buildDataSourceForChart(data.RectangleList[i], x1, y1, x2, y2);
                buildChart(dataSource, data.RectangleList[i].Id, i);
            }

            pagination(data.TotalCount, data.RectangleList.length);
        }
        else {
            alert(status + ' Ooooops. Something went wrong');
        }
    });
}

function buildDataSourceForChart(rectangle, x1, y1, x2, y2) {
    var dataSource = [
        { X: rectangle.PointA.X, Y1: rectangle.PointA.Y },
        { X: rectangle.PointB.X, Y1: rectangle.PointB.Y },
        { X: rectangle.PointD.X, Y1: rectangle.PointD.Y },
        { X: rectangle.PointC.X, Y1: rectangle.PointC.Y },
        
    ];
    var index = dataSource.findIndex(x => x1 <= x.X);
    dataSource.splice(index, 0, { X: x1, Y2: y1 });

    index = dataSource.findIndex(x => x2 <= x.X);
    dataSource.splice(index, 0, { X: x2, Y2: y2 })

    //for (let i = 0; i < dataSource.length; i++) {
    //    if (i != dataSource.length - 1) {
    //        if (dataSource[i].X <= x1 && x1 <= dataSource[i + 1]) {
    //            dataSource.splice(i, 0, { X: x1, Y2: y1 })
    //        }
    //        if (dataSource[i].X <= x2 && x2 <= dataSource[i + 1]) {
    //            dataSource.splice(i, 0, { X: x2, Y2: y2 })
    //        }
    //    }
    //    else if (i == dataSource.length - 1 && dataSource[i].X <= x1) {
    //        dataSource.splice(i, 0, { X: x1, Y2: y1 })
    //    }
    //    else if (i == dataSource.length - 1 && dataSource[i].X <= x2) {
    //        dataSource.splice(i, 0, { X: x2, Y2: y2 })
    //    }
    //    else if (i == dataSource.length - 1 && dataSource[i].X <= x1) {
    //        dataSource.splice(i, 0, { X: x1, Y2: y1 })
    //    }
    //    else if (i == dataSource.length - 1 && dataSource[i].X <= x2) {
    //        dataSource.splice(i, 0, { X: x2, Y2: y2 })
    //    }
    //}

    //dataSource = dataSource.sort(function (a, b) {
    //    if (a.X > b.X) {
    //        return 1;
    //    }
    //    if (a.X < b.X) {
    //        return -1;
    //    }
    //    // a должно быть равным b
    //    return 0;
    //});

    dataSource.push({ X: rectangle.PointC.X, Y3: rectangle.PointC.Y });
    dataSource.push({ X: rectangle.PointA.X, Y3: rectangle.PointA.Y });
    return dataSource;
}