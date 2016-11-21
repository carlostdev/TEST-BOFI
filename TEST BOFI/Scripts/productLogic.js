var uri = '/api/products';

$(document).ready(function () {
    loadData();
});

function loadData() {
    $.getJSON(uri)
        .done(function (data) {
            $('#productDisplay').empty();
            $.each(data, function (key, item) {
                $('<tr>').append(
                    $('<td>').text(item.Id),
                    $('<td>').text(item.Name),
                    $('<td>').text(item.AgeRestriction),
                    $('<td>').text(item.Price),
                    $('<td>').text(item.Company),
                    $('<td>').html('<a onclick=editItem(' + item.Id + ')><span class="glyphicon glyphicon-edit" aria-hidden="true"></span></a>&nbsp;|&nbsp;<a onclick=deleteItem(' + item.Id + ')><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></a>')
                ).appendTo('#productDisplay')
            });
        });
}

function requestSuccess() {
    $("#CreateModal").modal('hide');
    $("#form0")[0].reset();
    $("#EditModal").modal('hide');
    loadData();
}

function editItem(id) {
    $.getJSON(uri + '/' + id)
        .done(function (data) {
            $("#EditModal #Id").val(data.Id);
            $("#EditModal #Name").val(data.Name);
            $("#EditModal #Description").val(data.Description);
            $("#EditModal #AgeRestriction").val(data.AgeRestriction);
            $("#EditModal #Company").val(data.Company);
            $("#EditModal #Price").val(data.Price);
        });
    $("#EditModal").modal('show');
}

function submitEdit() {
    $.ajax({
        url: uri,
        type: 'PUT',
        data: $("#editForm").serialize(),
        success: requestSuccess
    });
}

function deleteItem(id) {
    $.ajax({
        url: uri + '/' + id,
        type: 'DELETE',
        success: loadData
    });
}