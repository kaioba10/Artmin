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

    $('#tableMarcacoes').DataTable({
        "order": [[7, "desc"]],
        language: {
            url: '//cdn.datatables.net/plug-ins/1.10.21/i18n/Portuguese-Brasil.json'
        },
        "ajax": {
            "url": caminhoWebSite + "Marcacao/ObterMarcacoes",
            "type": "POST",
            "dataSrc": ""
        },
        "columns": [
            { "data": 'Jogador.Nome' },
            { "data": 'Gol' },
            { "data": 'Assistencia' },
            { "data": 'Vitoria' },
            { "data": 'PenaltiDefendido' },
            { "data": 'PenaltiPerdido' },
            { "data": 'GolContra' },
            { "data": 'Pontos' },
            {
                "mData": null,
                "bSortable": false,
                "mRender": function (o) {
                    return '<a href="Marcacao/Edit"' + o.MarcacaoId + '>' + 'Editar' + '</a>' + ' | ' +
                           '<a href="Marcacao/Delete"' + o.MarcacaoId + '>' + 'Excluir' + '</a>';
                }
            }
        ]
    });
});


function AbrirEdicao(idMarcacao) {
    $.ajax({
        url: caminhoWebSite + "Marcacao/Edit",
        type: 'GET',
        data: { id: idMarcacao },
        success: function () {
            location.href = caminhoWebSite + 'Marcacao/Edit' + "/" + idMarcacao
        }
    })
};