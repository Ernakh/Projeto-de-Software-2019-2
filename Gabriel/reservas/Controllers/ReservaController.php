<?php
error_reporting(0);
session_start();

require_once '../Databases/Database.php';
require_once '../Databases/Debug.php';
require_once '../Databases/ReservaDB.php';
require_once '../Models/ReservaModel.php';

$reserva = new ReservaModel();
$action = filter_input(INPUT_GET, 'Action', FILTER_SANITIZE_STRING);

if ($action == 'Add') {
    $reserva->idpessoa = filter_input(INPUT_POST, 'cliente', FILTER_SANITIZE_NUMBER_INT);

    $data_um = filter_input(INPUT_POST, 'data_um', FILTER_SANITIZE_STRING);
    $data_alterada_um = str_replace('/', '-', $data_um);
    $data_formatada_um = date("Y-m-d", strtotime($data_alterada_um));

    $data_dois = filter_input(INPUT_POST, 'data_dois', FILTER_SANITIZE_STRING);
    $data_alterada_dois = str_replace('/', '-', $data_dois);
    $data_formatada_dois = date("Y-m-d", strtotime($data_alterada_dois));

    if (strtotime($data_dois) > strtotime($data_um)) {
        $reserva->data_inicio = $data_formatada_dois;
        $reserva->data_fim = $data_formatada_um;
    } else {
        $reserva->data_inicio = $data_formatada_um;
        $reserva->data_fim = $data_formatada_dois;
    }

    $reserva->idquarto = filter_input(INPUT_POST, 'quarto', FILTER_SANITIZE_NUMBER_INT);
    $reserva->valor = filter_input(INPUT_POST, 'valor', FILTER_SANITIZE_NUMBER_INT);
    $reserva->idformaPagamento = filter_input(INPUT_POST, 'forma_pagamento', FILTER_SANITIZE_NUMBER_INT);

    if ($reserva->verificar()) {
        $_SESSION["msg"] = "Quarto já ocupado nestas datas.";
        $_SESSION["tipo_msg"] = "danger";
        header('Location: ../Views/CadastrarHorarioView.php');
    } else {
        if ($reserva->salvar()) {
            $_SESSION["msg"] = "Reserva Efetuada com sucesso.";
            $_SESSION["tipo_msg"] = "success";
            $_SESSION['dados_reservas'] = $reserva->consultar();
            header('Location: ../Views/ListarHorariosView.php');
        }
    }
} else if ($action == 'Delete') {
    $id = filter_input(INPUT_GET, 'ID', FILTER_SANITIZE_NUMBER_INT);
    $reserva->idreserva = $id;
    $reserva->excluir();
    $reserva->idreserva = "";
    $_SESSION["msg"] = "Reserva ID <strong>" . $id . "</strong> excluido com sucesso.";
    $_SESSION["tipo_msg"] = "success";
    $_SESSION['dados_reservas'] = $reserva->consultar();
    header('Location: ../Views/ListarHorariosView.php');
}

