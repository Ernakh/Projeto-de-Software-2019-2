<?php
session_start();
error_reporting(0);
require_once '../Databases/Debug.php';
require_once '../Databases/Database.php';
require_once '../Databases/ClientesDB.php';
require_once '../Models/ClientesModel.php';

$cliente = new ClientesModel();

?>
<head>
    <?php include '../Views/BasicView.php'; ?>
</head>
<div class="container">
    <h2 class="text-center">Clientes cadastrados</h2>
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
    <div class="table-responsive">
        <table id="lista_clientes" class="cell-border">
            <thead>
            <tr>
                <th>ID</th>
                <th>Nome</th>
                <th>Documento</th>
                <th>Data de Nascimento</th>
                <th>Telefone</th>
                <th>Email</th>
                <th>Excluir</th>
            </tr>
            </thead>
            <tbody>
            <?php foreach ($cliente->consultar() as $clientes) { ?>
                <tr class="table-light">
                    <td><?= $clientes['idpessoa']; ?></td>
                    <td width="25%"><?= $clientes['nome']; ?></td>
                    <td><?= $clientes['cpf_cnpj']; ?></td>
                    <td><?= $clientes['dt_nascimento']; ?></td>
                    <td><?= $clientes['telefone']; ?></td>
                    <td><?= $clientes['email']; ?></td>
                    <td align="center" style="width: 90px;">
                        <a href="../Controllers/ClienteController.php?Action=Delete&ID=<?= $clientes['idpessoa']; ?> "
                           title="Excluir Cliente"
                           onClick="return confirm('Deseja prosseguir com a exclusão do usuário?');"
                           class="btn btn-danger">
                            <i class="fas fa-trash-alt" title="Excluir Usuário"></i>
                        </a>
                    </td>
                </tr>
            <?php } ?>
            </tbody>
        </table>
    </div>
    <br><br>
    <div align="center">
        <a href="../Controllers/HorariosController.php">Voltar</a>
    </div>
</div>
<script type="text/javascript">
    $(document).ready(function () {
        $('#lista_clientes').DataTable({
            "lengthMenu": [
                [10, 50, 100],
                ['10 ', '25 ', '50 ']],
            "order": [[0, "desc"]],
            "language": {
                url: '//cdn.datatables.net/plug-ins/1.10.19/i18n/Portuguese-Brasil.json'
            }
        });
    });
</script>