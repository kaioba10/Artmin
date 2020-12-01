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
        "order": [[8, "desc"]],
        language: {
            url: '//cdn.datatables.net/plug-ins/1.10.21/i18n/Portuguese-Brasil.json'
        },
        "ajax": {
            "url": caminhoWebSite + "Marcacao/ObterMarcacoes",
            "type": "POST",
            "dataSrc": ""
        },
        "columns": [
            { "data": 'MarcacaoId', visible: false, id: 'marcacaoId' },
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
                    return '<a type="button" class=" btn btn-link btn-sm"  onclick="AbrirEdicao(' + o.MarcacaoId + ')"> Editar </a>' + ' | ' +
                           '<a type="button" class=" btn btn-link btn-sm"  data-toggle="modal" data-target="#RemoverMarcacao"  onclick="ConfirmarRemocao(' + o.MarcacaoId + ')"> Remover </a>'
                }
            }
        ]
    });
});

//Variaveis de escopo global
var marcacaoId = 0;

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

function ConfirmarCadastro() {
    $('#ConfimacaoCadastro').modal('show');
};

function ConfirmarEdicao() {
    $('#ConfimacaoEdicao').modal('show');
}

function ConfirmarRemocao(id) {
    marcacaoId = id;
    $('#ConfimacaoRemocao').modal('show');
}

function SalvarCadastro() {

    var form = $('#formCadastroMarcacao');
    var jogadorId = $("#JogadorId").val();

    if (!form.valid()) {
        MensagemToastr(tipoToastr.alerta, "Preencha corretamente os campos obrigatórios");
        $('#ConfimacaoCadastro').modal('toggle');
        return false;
    }

    if (jogadorId == -1) {
        MensagemToastr(tipoToastr.alerta, "Selecione o Jogador");
        $('#ConfimacaoCadastro').modal('toggle');
        return false;
    }

    $.ajax({
        url: caminhoWebSite + "Marcacao/CadastrarMarcacao",
        type: "POST",
        data: form.serializeArray(),
        dataType: "json",
        success: function (data) {

            if (data.success) {
                MensagemToastr(tipoToastr.sucesso, "Marcação cadastrada com sucesso");
            } else {
                MensagemToastr(tipoToastr.alerta, "Dados incorretos");

                $('#ConfimacaoCadastro').modal('toggle');
                return false;
            }

            $('#formCadastroMarcacao')[0].reset();
            $('#ConfimacaoCadastro').modal('toggle');
        },
        error: function (error) {
            MensagemToastr(tipoToastr.erro, "Erro ao cadastrar marcação");
            $('#ConfimacaoCadastro').modal('toggle');
            return false;
        }
    });
}

function EditarMarcacao() {
    var form = $('#formCadastroMarcacao');
    var jogadorId = $("#JogadorId").val();

    if (!form.valid()) {
        MensagemToastr(tipoToastr.alerta, "");
        $('#ConfimacaoEdicao').modal('toggle');
        return false;
    }
}

function RemoverMarcacao() {

    $.ajax({
        type: "POST",
        url: caminhoWebSite + "Marcacao/RemoverMarcacao",
        data: JSON.stringify({ id: marcacaoId }),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function () {
            MensagemToastr(tipoToastr.sucesso, "Marcação removida com sucesso", function () { location.reload(); });
            $('#ConfimacaoRemocao').modal('toggle');
        },
        error: function () {
            MensagemToastr(tipoToastr.erro, "Erro ao remover Marcação");
            $('#ConfimacaoRemocao').modal('toggle');
            return false;
        }
    });

    $('#ConfirmacaoRemocao').modal('toggle');
}