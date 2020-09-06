

$('#all').submit(function (e) {
    e.preventDefault();
    const nome = $('input[name="Nome"]').val();
    const email = $('input[name="Email"]').val();
    const goleiro = $('input[name="Goleiro"]').val();
    const admin = $('textarea[name="Admin"]').val();
    const ativo = $('textarea[name="Ativo"]').val();
    $.ajax({
        type: 'post',
        dataType: 'json',
        cache: false,
        url: 'Jogador/Create',
        data: { Nome: nome, Email: email, Goleiro: goleiro, Admin: admin, Ativo: ativo },
        success: function (data) {
            if (data.Sucesso) {
                alert("Teste");
                //MensagemToastr(Sucesso, "Jogador cadastrado com sucesso.");
            } else {
                MensagemToastr(Erro, "Erro ao cadastrar jogador.");
            }
        },
    })
});