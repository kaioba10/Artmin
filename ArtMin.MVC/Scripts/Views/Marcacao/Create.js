$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: window.caminhoWebSite + "Jogador/GetAll",
        dataType: "json",
        contentType: "application/json",
        success: function (res) {
            $.each(res, function (data, value) {

                $("#JogadorId").append($("<option></option>").val(value.JogadorId).html(value.Nome));
            })
        }
    });
})