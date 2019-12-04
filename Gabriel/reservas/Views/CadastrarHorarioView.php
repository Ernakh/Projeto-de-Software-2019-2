<?php
session_start();
error_reporting(0);
require_once '../Databases/Debug.php';
require_once '../Databases/Database.php';
require_once '../Databases/InformacoesDB.php';
require_once '../Models/InformacoesModel.php';

$informacoes = new InformacoesModel();

?>
<head>
    <?php include '../Views/BasicView.php'; ?>
</head>

<h2 class="text-center">Agendar horário</h2>
<hr>

<?php if (isset($_SESSION['msg']) && $_SESSION['msg'] != "" && isset($_SESSION['tipo_msg']) && $_SESSION['tipo_msg'] != "") { ?>
    <div align="center">
        <div style="font-size: 1.2em; margin-top: 25px; width:400px;"
             class="alert alert-<?= $_SESSION['tipo_msg']; ?>" align="center">
            <strong><?= $_SESSION['msg']; ?></strong>
        </div>
    </div>
    <?php
    $_SESSION['msg'] = "";
    $_SESSION['tipo_msg'] = "";
}

?>

<form method="post" action="../Controllers/ReservaController.php?Action=Add">
    <div class="container" style="text-align: center">
        <div class="col-sm">
            <label>Clientes</label>
            <div style="text-align: center">
                <select class="js-example-basic-single" name="cliente" style="width:25%" required>
                    <option value="" selected="true" disabled="disabled">--- Selecione ---</option>
                    <?php foreach ($informacoes->consultaCliente() as $cliente) { ?>
                        <option value="<?= $cliente['idpessoa'] ?>"><?= $cliente['nome'] ?></option>
                    <?php } ?>
                </select>
            </div>
        </div>
        <div class="col-sm">
            <label>Datas: </label>
            <div style="text-align: center">
                <input class="datepick" type="text" id="data_um" name="data_um"
                       style="text-align: center;width:10%" required>
                <input class="datepick" type="text" id="data_dois" name="data_dois"
                       style="text-align: center;width:10%" required>
            </div>
        </div>
        <div class="col-sm">
            <label>Quartos</label>
            <div style="text-align: center">
                <select class="js-example-basic-single" name="quarto" style="width:25%" required>
                    <option value="" selected="true" disabled="disabled">--- Selecione ---</option>
                    <?php foreach ($informacoes->consultaQuartos() as $quarto) { ?>
                        <option value="<?= $quarto['idquarto'] ?>">N° <?= $quarto['numero'] ?> -
                            Andar <?= $quarto['andar'] ?> (<?= $quarto['quantidade_camas'] ?> Camas)
                        </option>
                    <?php } ?>
                </select>
            </div>
        </div>
        <div class="col-sm">
            <label>Valor</label>
            <div style="text-align: center">
                <input type="text" name="valor" id="valor" style="text-align: center; width: 50px;" required>
            </div>
        </div>
        <div class="col-sm">
            <label>Forma Pagamento</label>
            <div style="text-align: center">
                <select class="js-example-basic-single" name="forma_pagamento" style="width:25%" required>
                    <option value="" selected="true" disabled="disabled">--- Selecione ---</option>
                    <?php foreach ($informacoes->consultaFormaPagamento() as $forma) { ?>
                        <option value="<?= $forma['idformaPagamento'] ?>"><?= $forma['titulo'] ?></option>
                    <?php } ?>
                </select>
            </div>
        </div>
        <p>
        <div>
            <button class="btn btn-primary btn-lg">Registrar</button>
        </div>
    </div>
</form>
<div align="center">
    <a href="../Views/ListarHorariosView.php">Voltar</a>
</div>
<script type="text/javascript">
    $(document).ready(function () {
        $(function () {
            $(".datepick").datepicker({dateFormat: 'dd/mm/yy', changeMonth: true, changeYear: true});
            $.datepicker.regional['pt-BR'] = {
                minDate: new Date(),
                closeText: 'Fechar',
                prevText: '&#x3c;Anterior',
                nextText: 'Pr&oacute;ximo&#x3e;',
                currentText: 'Hoje',
                monthNames: ['Janeiro', 'Fevereiro', 'Mar&ccedil;o', 'Abril', 'Maio', 'Junho',
                    'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
                monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun',
                    'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
                dayNames: ['Domingo', 'Segunda-feira', 'Ter&ccedil;a-feira', 'Quarta-feira', 'Quinta-feira', 'Sexta-feira', 'Sabado'],
                dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'],
                dayNamesMin: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'],
                weekHeader: 'Sm',
                dateFormat: 'dd/mm/yy',
                firstDay: 0,
                isRTL: false,
                showMonthAfterYear: false,
                yearSuffix: ''
            };
            $.datepicker.setDefaults($.datepicker.regional['pt-BR']);
        });

        $("#valor").mask("0000");

        $('.js-example-basic-single').select2();
    });
</script>
