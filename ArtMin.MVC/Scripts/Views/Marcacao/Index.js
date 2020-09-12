$(document).ready(function () {
    $('#tableMarcacoes').DataTable({
        language: {
            url: '//cdn.datatables.net/plug-ins/1.10.21/i18n/Portuguese-Brasil.json'
        },
        "ajax": {
            "url": "Marcacao/ObterMarcacoes",
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
            { "data": 'GolContra' }
        ]
    });
});