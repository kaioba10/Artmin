$(document).ready(function () {

    $("input[id*='cpf']").inputmask({
        mask: ['999.999.999-99'],
        keepStatic: true
    });

    ValidarFormularioCreate();

});

function ConfirmarCadastro() {
    $('#ConfimacaoCadastro').modal('show');
}

function SalvarCadastro() {

    var form = $('#formCadastroJogador').serializeArray();

    $.ajax({
        url: caminhoWebSite + "Jogador/CadastrarJogador",
        type: "POST",
        data: form,
        dataType: "json",
        success: function (result) {

            if (result) {
                MensagemToastr(tipoToastr.sucesso, "Jogador cadastrado com sucesso");
            }
            else {
                MensagemToastr(tipoToastr.erro, "Erro ao cadastrar o jogador");
                return;
            }

            $('#formCadastroJogador')[0].reset();
            $('#ConfimacaoCadastro').modal('toggle')
        }
    });
}

function ValidarFormularioCreate(){
    $(function () {
        $("#formCadastroJogador").validate({
            rules: {
                Nome: {
                    required: true,
                    maxlength: 50,
                    minlength: 2
                },
                Email: {
                    required: true,
                    email: true,
                    maxlength: 120,
                    minlength: 2
                },
                Cpf: "required"
            },
            // Mensagens referentes às especificações de regras acima
            messages: {
                Nome: {
                    required: "O campo Nome é obrigatório.",
                    maxlength: "Permitido no máximo 50 caracteres",
                    minlength: "Permitido no mínimo 2 caracteres"
                },
                Email: "Formato de e-mail inválido.",
                Cpf: "O campo CPF é obrigatório"
            },

            submitHandler: function (form) {
                form.submit();
            }
        });
    });
}