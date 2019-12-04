<?php
error_reporting(0);
session_start();

?>
<head>
    <?php include '../Views/BasicView.php'; ?>
</head>
<div class="container">
    <h2 class="text-center">Reservas do Hotel</h2>
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
    <h5 class="text-left">
        <a href="../Views/CadastrarHorarioView.php" class="btn btn-success">
            <i class="fas fa-calendar-plus" style="padding: 3px 3px 3px 3px" title="Agendar horário"></i>
        </a>
        <a href="../Views/CadastrarClienteView.php" class="btn btn-primary">
            <i class="fa fa-user-plus" style="padding: 3px 3px 3px 3px" title="Registrar cliente"></i>
        </a>
        <a href="../Views/ListarClientesView.php" class="btn btn-dark">
            <i class="fas fa-users" style="padding: 3px 3px 3px 3px" title="Clientes cadastrados"></i>
        </a>
        <a class="btn navbar-btn btn-danger navbar-right" role="button"
           href="../Controllers/LoginController.php?Logout=1" style="float: right;">Logout</a>
        <p>
    </h5>
    <div class="table-responsive">
        <table id="lista_agendamento" class="cell-border">
            <thead>
            <tr>
                <th>ID</th>
                <th>Cliente</th>
                <th>Telefone</th>
                <th>Email</th>
                <th>Pagamento</th>
                <th>Valor</th>
                <th>Quarto</th>
                <th>Datas</th>
                <th>Excluir</th>
            </tr>
            </thead>
            <tbody>
            <?php
            if (isset($_SESSION['dados_reservas']) && $_SESSION['dados_reservas'] != "") {
                $dados = $_SESSION['dados_reservas'];
                foreach ($dados as $key => $value) {
                    $data_inicio = strtotime($dados[$key]['data_inicio']);
                    $dt_inicio = date('d/m/Y', $data_inicio);
                    $data_fim = strtotime($dados[$key]['data_fim']);
                    $dt_fim = date('d/m/Y', $data_fim);
                    ?>
                    <tr class="table-warning">
                        <td><?= $dados[$key]['idreserva']; ?></td>
                        <td><?= $dados[$key]['nome_pessoa']; ?></td>
                        <td><?= $dados[$key]['telefone']; ?></td>
                        <td><?= $dados[$key]['email']; ?></td>
                        <td><?= $dados[$key]['forma_pagamento']; ?></td>
                        <td><?= $dados[$key]['valor']; ?></td>
                        <td>A<?= $dados[$key]['andar']; ?>N<?= $dados[$key]['numero']; ?></td>
                        <td>De <?= $dt_inicio; ?> até <?= $dt_fim; ?></td>
                        <td style="text-align: center">
                            <a href="../Controllers/ReservaController.php?Action=Delete&ID=<?= $dados[$key]['idreserva']; ?> "
                               title="Excluir Reserva"
                               onClick="return confirm('Deseja prosseguir com a exclusão da reserva?');"
                               class="btn btn-danger">
                                <i class="fas fa-trash-alt" title="Excluir Reserva"></i>
                            </a>
                        </td>
                    </tr>
                    <?php
                }
            }

            ?>
            </tbody>
        </table>
    </div>
</div>
<script type="text/javascript">
    $(document).ready(function () {
        $(window).bind("beforeunload", function () {
            $.ajax({
                url: '../Controllers/HorariosController.php'
            });
        });

        $('#lista_agendamento').DataTable({
            "lengthMenu": [
                [10, 50, 100],
                ['10 ', '25 ', '50 ']],
            "order": [[1, "desc"]],
            "language": {
                url: '//cdn.datatables.net/plug-ins/1.10.19/i18n/Portuguese-Brasil.json'
            }
        });
    });
</script>
