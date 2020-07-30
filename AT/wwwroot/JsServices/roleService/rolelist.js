
function loadtable() {
    var table = jQuery("#rolelist");
    table.dataTable({
        "bProcessing": true,
        "processing": true,
        "serverSide": true,
        "dom": 'RBr<"clear">t<"row"<"col-sm-3"l><"col-sm-3"i><"col-sm-6"p>><"clear">',
        'searching': true,//recordsFiltered
        "ajax": {
            "url": "rolelist.html", "type": "POST", "data": function (d) {
                d.status = "bmscompleted";
                d.filter = $("#Action").val();
                d.search = $("#usersearch").val();
            }
        },
        "language": {
            "infoFiltered": ""
        },
        'stateSave': true,
        'select': {
            info: false
        },
        'select': {
            'style': 'multi'
        },
        'createdRow': function (row, data, dataIndex) {
            $(row).attr('id', data.id);
        },
        "columns": [
            { "data": "name", "orderable": true },
            { "data": "normalizedName", "orderable": true },
            { "data": "concurrencyStamp", "orderable": true },
            { "data": "id", "orderable": false },
        ],
        "rowCallback": rowCallback,
        order: [

            [2, "desc"]
        ],
        "paging": true,
        "pageLength": 10,
        lengthMenu: [
            [5, 10, 20, 50, 100, 500], [5, 10, 20, 50, 100, 500]
        ],
        "fnInitComplete": function (oSettings, json) {
            //jQuery("#estimate").css({ "display": "table" }).animate({ "opacity": 1 }, 500);
        },

    });
    jQuery('#usersearch').on("keyup", function () {
        table.fnFilter(this.value);
    }).on("keypress", function (e) {
        if (e.which == 13) {
            return false;
        }
    });
    function rowCallback(row, data, index) {
        var url = '/@ViewContext.RouteData.Values["orgid"]/bms/' + data.id + '/ViewBmsJob.html';
        var link = "<a class='process' href='" + url + "'>" + data.jobnumber + "</a>";
        jQuery('td:first-child', row).find("input").attr({ "id": data.id, "name": "Ids", "value": data.id });
        jQuery('td:nth-child(1)', row).html(link);
        jQuery('td:last-child', row).html("<a href=" + url + " title='Edit BMS' class='process' data-toggle='tooltip'><i class='fa fa-edit'></i></a>");
    }

}







