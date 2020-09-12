$(document).ready(function () {
    $('#tableMarcacoes').DataTable({
        language: {
            search: "Pesquisar",
            sProcessing: "Processando...",
            sLengthMenu: "Mostrar _MENU_ registros",
            sZeroRecords: "Nenhum resultado encontrado",
            sInfoEmpty: "0 resultados",
            sInfo: "Mostrando de _START_ a _END_ de um total de _TOTAL_ registros",
            sInfoFiltered: "(Filtrado de um total de _MAX_ registros)",
            paginate: {
                "previous": "Página Anterior",
                "next": "Próxima Página"
            },
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