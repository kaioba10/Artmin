$(document).ready(function () {

    $("input[id*='cpf']").inputmask({
        mask: ['999.999.999-99'],
        keepStatic: true
    });
});
