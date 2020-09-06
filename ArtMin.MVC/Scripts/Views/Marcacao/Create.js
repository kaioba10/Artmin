$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "https://localhost:44363/Jogador/GetAll", dataType: "json", contentType: "application/json",
        success: function (res) {
            $.each(res, function (data, value) {

                $("#JogadorId").append($("<option></option>").val(value.JogadorId).html(value.Nome));
            })
        }

    });
})