﻿var tipoToastr = {
    sucesso: "success",
    informacao: "info",
    alerta: "warning",
    erro: "error",
    fecharEmAbertas: false,
    exibirMensagem: function (tipo, mensagem) {
        MensagemToastr(tipo, mensagem);
    }
};

function MensagemToastr(tipo, mensagem, onHidden) {
    /*  
        Tipos de mensagem:
        - success
        - info
        - warning
        - error
    
        Outra forma de mandar exibir a mensagem, colocando título
        - toastr.error("teste erro", "Título erro");
    */

    MensagemToastrFechar();
    toastr.clear();

    //Fecha depois de um tempo
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-bottom-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "3000",
        "hideDuration": "1000",
        "timeOut": "3000",
        "extendedTimeOut": "4000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut",
        "onHidden": onHidden
    };

    toastr[tipo](mensagem);
}

$(document).keyup(function (e) {
    if ($('#toast-container').length > 0)
        if (e.keyCode === 27) toastr.clear(); // esc
});

function MensagemToastrFechar() {
    if (tipoToastr.fecharEmAbertas)
        toastr.clear();
}