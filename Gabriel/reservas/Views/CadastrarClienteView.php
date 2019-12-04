<?php
error_reporting(0);
session_start();

?>
<head>
    <?php include '../Views/BasicView.php'; ?>
</head>

<h2 class="text-center">
    Registro de Novos Clientes
</h2>
<hr>

<?php if (isset($_SESSION['msg']) && $_SESSION['msg'] != "" && isset($_SESSION['tipo_msg']) && $_SESSION['tipo_msg'] != "") { ?>
    <div align="center">
        <div style="font-size: 1.2em; margin-top: 25px; width:400px;" class="alert alert-<?= $_SESSION['tipo_msg']; ?>"
             align="center">
            <strong><?= $_SESSION['msg']; ?></strong>
        </div>
    </div>
    <?php
    $_SESSION['msg'] = "";
    $_SESSION['tipo_msg'] = "";
}

?>

<form method="post" action="../Controllers/ClienteController.php?Action=Add" id="cadastro_cliente">
    <div class="container" align="center">
        <div class="col-md-4">
            Nome: <i class="fa fa-user"></i>
            <input style="text-align: center" type="text" class="form-control" name="nome" id="nome" maxlength="100"
                   required autofocus>
            <br>
        </div>
        <div class="col-md-4">
            Documento: <i class="fa fa-file"></i>
            <div>
                <input type="radio" name="tipo_documento" value="cpf" id="tipo_documento"> CPF
                <input type="radio" name="tipo_documento" value="cnpj" id="tipo_documento"> CNPJ
            </div>
            <input type="text" class="form-control" name="cpf_cnpj" id="cpf_cnpj" required disabled="disabled"
                   style="text-align: center">
            <br>
        </div>
        <div class="col-md-4">
            Email: <i class="fa fa-at"></i>
            <input style="text-align: center" type="email" class="form-control" name="email" id="email" maxlength="100"
                   required autofocus>
            <br>
        </div>
        <div class="col-md-4">
            Telefone: <i class="fa fa-phone"></i>
            <div>
                <input type="radio" name="tipo_telefone" value="residencial" id="tipo_telefone"> Residencial
                <input type="radio" name="tipo_telefone" value="celular" id="tipo_telefone"> Celular
            </div>
            <input type="text" class="form-control" name="telefone" id="telefone" required disabled="disabled"
                   style="text-align: center">
            <br>
        </div>
        <div class="col-md-6">
            Data de Nascimento: <i class="fa fa-calendar"></i>
            <input type="text" class="form-control" id="data_nascimento" name="data_nascimento" required
                   style="text-align: center; width:40%">
            <br>
        </div>
    </div>

    <div class="col-md-12" align="center">
        <button class="btn btn-primary btn-lg" id="cadastrar">Cadastrar</button>
        <br><br>
        <a href="../Views/ListarHorariosView.php">Voltar</a>
    </div>
</form>
<script type="text/javascript">
    $(document).ready(function () {
        $('#data_nascimento').mask("00/00/0000");

        $('input:radio[name="tipo_telefone"]').change(function () {
            $('input:text[name="telefone"]').removeAttr("disabled");
            $('input[name="telefone"]').val('');
            if (this.value === 'residencial') {
                $("#telefone").mask("(00)0000-0000");
            } else if (this.value === 'celular') {
                $("#telefone").mask("(00)00000-0000");
            }
        });

        $('input:radio[name="tipo_documento"]').change(function () {
            $('input:text[name="cpf_cnpj"]').removeAttr("disabled");
            $('input[name="cpf_cnpj"]').val('');
            if (this.value === 'cpf') {
                $("#cpf_cnpj").mask("000.000.000-00");
            } else if (this.value === 'cnpj') {
                $("#cpf_cnpj").mask("00.000.000/0000-00");
            }
        });

        $("#cadastrar").click(function () {
            var tipo_telefone = $('input:radio[name="tipo_telefone"]:checked').val();
            var telefone = $('input[name="telefone"]').val().length;
            var tipo_documento = $('input:radio[name="tipo_documento"]:checked').val();
            var cpf_cnpj = $('input[name="cpf_cnpj"]').val().length;

            if (tipo_telefone === 'residencial' && telefone < 13) {
                alert("Preencha um número de telefone.");
                return false;
            } else if (tipo_telefone === 'celular' && telefone < 14) {
                alert("Preencha um número de celular.");
                return false;
            }

            if (tipo_documento === 'cpf' && cpf_cnpj < 13) {
                alert("Preencha um CPF válido.");
                return false;
            } else if (tipo_documento === 'cnpj' && cpf_cnpj < 18) {
                alert("Preencha um CNPJ válido.");
                return false;
            }
        });
    });
</script>
