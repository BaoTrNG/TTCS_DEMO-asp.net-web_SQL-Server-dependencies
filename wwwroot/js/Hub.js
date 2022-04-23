alert("hub")
var connection = new signalR.HubConnectionBuilder().withUrl("/dashboardHub").build();
$(function () {

    connection.start().then(function () {
        InvokeProducts();
    }).catch(function (err) {
        return console.error(err.toString());
    });
});

function InvokeProducts() {

    connection.invoke("SendOrder").catch(function (err) {

        return console.error(err.toString());
    });
}
connection.on("ReceiveOrder", function (Orders) {

    BindProductsToGrid(Orders);

});

function BindProductsToGrid(Orders) {

    $('#tblOrder tbody').empty();
    var tr;
    // var test = Orders
    $.each(Orders, function (index, Order) {

        tr = $('<tr/>');
        tr.append(`<td>${(index + 1)}</td>`);
        tr.append(`<td>${Order.mack}</td>`); //1 //done
        tr.append(`<td>${Order.giamuathree}</td>`); //2 //done
        tr.append(`<td>${Order.khoiluongmuathree}</td>`);//3 //done
        tr.append(`<td>${Order.giamuatwo}</td>`); //4 //DONE
        tr.append(`<td>${Order.khoiluongmuatwo}</td>`); //5 //done
        tr.append(`<td>${Order.giamuaone}</td>`); //6 //DONE
        tr.append(`<td>${Order.khoiluongmuaone}</td>`); //7 /done
        tr.append(`<td>${Order.giamua}</td>`); //8 //done
        tr.append(`<td>${Order.khoiluongmua}</td>`); //9
        tr.append(`<td>${Order.giabanone}</td>`); //10
        tr.append(`<td>${Order.khoiluongbanone}</td>`); //11
        tr.append(`<td>${Order.giabantwo}</td>`); //12
        tr.append(`<td>${Order.khoiluongbantwo}</td>`); //13
        tr.append(`<td>${Order.giabanthree}</td>`); //14
        tr.append(`<td>${Order.khoiluongbanthree}</td>`); //15
        tr.append(`<td>${Order.tongkhoiluong}</td>`); //16 //done


        $('#tblOrder').append(tr);

    });
}