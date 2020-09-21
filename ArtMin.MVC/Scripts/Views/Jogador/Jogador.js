$(document).ready(function () {

    $("input[id*='cpf']").inputmask({
        mask: ['999.999.999-99']
    });

    ValidarFormularioCreate();

});

function ConfirmarCadastro() {
    $('#ConfimacaoCadastro').modal('show');
}

function SalvarCadastro() {

    var form = $('#formCadastroJogador');

    if (!form.valid()) {
        MensagemToastr(tipoToastr.alerta, "Preencha corretamente os campos obrigatórios");
        $('#ConfimacaoCadastro').modal('toggle')
        return false;
    }

    $.ajax({
        url: caminhoWebSite + "Jogador/CadastrarJogador",
        type: "POST",
        data: form.serializeArray(),
        dataType: "json",
        success: function (data) {

            if (data) {
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
                }
            },
            // Mensagens referentes às especificações de regras acima
            messages: {
                Nome: {
                    required: "O campo Nome é obrigatório.",
                    maxlength: "Permitido no máximo 50 caracteres",
                    minlength: "Permitido no mínimo 2 caracteres"
                },
                Email: "Formato de e-mail inválido.",
            },

            //errorElement: 'span',
            errorPlacement: function (error, element) {
                error.addClass('invalid-feedback text-danger');
                element.closest('.form-group>div').append(error);
            },
            highlight: function (element, errorClass, validClass) {
                $(element).addClass('alert alert-danger');
                $(element).removeClass('alert alert-success');
            },
            unhighlight: function (element, errorClass, validClass) {
                $(element).addClass('alert alert-success');
                $(element).removeClass('alert alert-danger');
            },

            submitHandler: function (form) {
                form.submit();
            }
        });
    });
}

$.validator.addMethod("regx", function (value, element, regexpr) {
    return regexpr.test(value);
}, "Número de CPF inválido");
$("#formCadastroJogador").validate({

    rules: {
        Cpf: {
            required: true,
            //regx: "/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])\w{6,}$/",
            minlength: 2,
            maxlength: 11
        }
    },
    errorPlacement: function (error, element) {
        error.addClass('invalid-feedback text-danger');
        element.closest('.form-group>div').append(error);
    },
    highlight: function (element, errorClass, validClass) {
        $(element).addClass('alert alert-danger');
        $(element).removeClass('alert alert-success');
    },
    unhighlight: function (element, errorClass, validClass) {
        $(element).addClass('alert alert-success');
        $(element).removeClass('alert alert-danger');
    },

    submitHandler: function (form) {
        form.submit();
    }
});