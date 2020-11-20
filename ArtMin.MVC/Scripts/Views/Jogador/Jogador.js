$(document).ready(function () {

    $("input[id*='cpf']").inputmask({
        mask: ['999.999.999-99']
    });

    ValidarFormularioCreate();
    ValidarFormularioEdit()

});

function ConfirmarCadastro() {
    $('#ConfimacaoCadastro').modal('show');
};

function ConfirmarEdicao() {
    $('#ConfimacaoEdicao').modal('show');
};

function ConfirmacaoRemocao(id) {
    $('#JogadorId').val(id);
    $('#ConfirmacaoRemocao').modal('show');
};

function SalvarCadastro() {

    var form = $('#formCadastroJogador');

    if (!form.valid()) {
        MensagemToastr(tipoToastr.alerta, "Preencha corretamente os campos obrigatórios");
        $('#ConfimacaoCadastro').modal('toggle');
        return false;
    }

    $.ajax({
        url: caminhoWebSite + "Jogador/CadastrarJogador",
        type: "POST",
        data: form.serializeArray(),
        dataType: "json",
        success: function (data) {

            if (data.success) {
                MensagemToastr(tipoToastr.sucesso, "Jogador cadastrado com sucesso");
            } else {
                MensagemToastr(tipoToastr.alerta, "CPF já cadastrado na base de dados");

                $('#ConfimacaoCadastro').modal('toggle');
                return false;
            }

            $('#formCadastroJogador')[0].reset();
            $('#ConfimacaoCadastro').modal('toggle');
        },
        error: function (error) {
            MensagemToastr(tipoToastr.erro, "Erro ao cadastrar o jogador");
            $('#ConfimacaoCadastro').modal('toggle');
            return;
        }
    });
}

function SalvarEdicao() {

    var form = $('#formEditarJogador');

    if (!form.valid()) {
        MensagemToastr(tipoToastr.alerta, "Preencha corretamente os campos obrigatórios");
        $('#ConfimacaoEdicao').modal('toggle')
        return false;
    }

    $.ajax({
        url: caminhoWebSite + "Jogador/EditarJogador",
        type: "POST",
        data: form.serializeArray(),
        dataType: "json",
        success: function (data) {

            if (data) {
                MensagemToastr(tipoToastr.sucesso, "Cadastro alterado com sucesso", function () { location.href = caminhoWebSite + 'Jogador/Index' });
            }
            else {
                MensagemToastr(tipoToastr.erro, "Erro ao alterar o cadastro");
                return;
            }

            $('#ConfimacaoEdicao').modal('toggle');
        }
    });
}

function RemoverCadastro() {

    var jogadorId = $('#JogadorId').val();

    $.ajax({
        type: "POST",
        url: caminhoWebSite + "Jogador/RemoverJogador",
        data: JSON.stringify({ id: jogadorId }),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data.success)
                MensagemToastr(tipoToastr.sucesso, "Jogador removido com sucesso", function () { location.reload(); });
            else {
                MensagemToastr(tipoToastr.informacao, "O jogador possui marcação.", function () { location.reload(); });
                return false;
            }
        },
        error: function () {
            MensagemToastr(tipoToastr.erro, "Erro ao remover o jogador");
            return false;
        }
    });

    $('#ConfirmacaoRemocao').modal('toggle');
}

function AbrirEdicao(idJogador) {
    $.ajax({
        url: caminhoWebSite + "Jogador/Edit",
        type: 'GET',
        data: { id: idJogador },
        success: function () {
            location.href = caminhoWebSite + 'Jogador/Edit' + "/" + idJogador
        }
    });
}

function ValidarFormularioCreate() {
    $(function () {

        jQuery.validator.addMethod("Cpf", function (value, element) {
            value = jQuery.trim(value);

            value = value.replace('.', '');
            value = value.replace('.', '');
            cpf = value.replace('-', '');
            while (cpf.length < 11) cpf = "0" + cpf;
            var expReg = /^0+$|^1+$|^2+$|^3+$|^4+$|^5+$|^6+$|^7+$|^8+$|^9+$/;
            var a = [];
            var b = new Number;
            var c = 11;
            for (i = 0; i < 11; i++) {
                a[i] = cpf.charAt(i);
                if (i < 9) b += (a[i] * --c);
            }
            if ((x = b % 11) < 2) { a[9] = 0 } else { a[9] = 11 - x }
            b = 0;
            c = 11;
            for (y = 0; y < 10; y++) b += (a[y] * c--);
            if ((x = b % 11) < 2) { a[10] = 0; } else { a[10] = 11 - x; }

            var retorno = true;
            if ((cpf.charAt(9) != a[9]) || (cpf.charAt(10) != a[10]) || cpf.match(expReg)) retorno = false;

            return this.optional(element) || retorno;

        }, "Informe um CPF válido"),

            $.validator.addMethod(
                "regex",
                function (value, element, regexp) {
                    if (regexp && regexp.constructor != RegExp) {
                        regexp = new RegExp(regexp);
                    }
                    else if (regexp.global) regexp.lastIndex = 0;

                    return this.optional(element) || regexp.test(value);
                }
            ),
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
                        regex: /^\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i
                    },
                    Cpf: {
                        required: true,
                        Cpf: true
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
                    Cpf: {
                        required: "O campo CPF é obrigatório",
                        Cpf: 'CPF inválido'
                    }
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
            })
    });
}

function ValidarFormularioEdit() {
    $(function () {

        jQuery.validator.addMethod("Cpf", function (value, element) {
            value = jQuery.trim(value);

            value = value.replace('.', '');
            value = value.replace('.', '');
            cpf = value.replace('-', '');
            while (cpf.length < 11) cpf = "0" + cpf;
            var expReg = /^0+$|^1+$|^2+$|^3+$|^4+$|^5+$|^6+$|^7+$|^8+$|^9+$/;
            var a = [];
            var b = new Number;
            var c = 11;
            for (i = 0; i < 11; i++) {
                a[i] = cpf.charAt(i);
                if (i < 9) b += (a[i] * --c);
            }
            if ((x = b % 11) < 2) { a[9] = 0 } else { a[9] = 11 - x }
            b = 0;
            c = 11;
            for (y = 0; y < 10; y++) b += (a[y] * c--);
            if ((x = b % 11) < 2) { a[10] = 0; } else { a[10] = 11 - x; }

            var retorno = true;
            if ((cpf.charAt(9) != a[9]) || (cpf.charAt(10) != a[10]) || cpf.match(expReg)) retorno = false;

            return this.optional(element) || retorno;

        }, "Informe um CPF válido"),

            $.validator.addMethod(
                "regex",
                function (value, element, regexp) {
                    if (regexp && regexp.constructor != RegExp) {
                        regexp = new RegExp(regexp);
                    }
                    else if (regexp.global) regexp.lastIndex = 0;

                    return this.optional(element) || regexp.test(value);
                }
            ),
            $("#formEditarJogador").validate({
                rules: {
                    Nome: {
                        required: true,
                        maxlength: 50,
                        minlength: 2
                    },
                    Email: {
                        required: true,
                        email: true,
                        regex: /^\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i
                    },
                    Cpf: {
                        required: true,
                        Cpf: true
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
                    Cpf: {
                        required: "O campo CPF é obrigatório",
                        Cpf: 'CPF inválido'
                    }
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
            })
    });
}
