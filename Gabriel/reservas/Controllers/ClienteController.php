<?php
error_reporting(0);
session_start();

require_once '../Databases/Database.php';
require_once '../Databases/Debug.php';
require_once '../Databases/ClientesDB.php';
require_once '../Models/ClientesModel.php';

$cliente = new ClientesModel();
$action = filter_input(INPUT_GET, 'Action', FILTER_SANITIZE_STRING);

if ($action == 'Add') {
    $cliente->nome = filter_input(INPUT_POST, 'nome', FILTER_SANITIZE_STRING);
    $tipo_documento = filter_input(INPUT_POST, 'tipo_documento', FILTER_SANITIZE_STRING);
    if ($tipo_documento == 'cpf') {
        $cliente->tipo_pessoa = 1;
    } else if ($tipo_documento == 'cnpj') {
        $cliente->tipo_pessoa = 2;
    }
    $cliente->cpf_cnpj = filter_input(INPUT_POST, 'cpf_cnpj', FILTER_SANITIZE_STRING);
    $data = filter_input(INPUT_POST, 'data_nascimento', FILTER_SANITIZE_STRING);
    $data_new = str_replace('/', '-', $data);
    $data_formatada = date("Y-m-d", strtotime($data_new));
    $cliente->data_nascimento = $data_formatada;
    $cliente->telefone = filter_input(INPUT_POST, 'telefone', FILTER_SANITIZE_STRING);
    $cliente->email = filter_input(INPUT_POST, 'email', FILTER_SANITIZE_STRING);

    if ($cliente->salvar()) {
        $_SESSION["tipo_msg"] = "success";
        $_SESSION["msg"] = "Cliente cadastrado com sucesso.";
        header('Location: ../Views/ListarClientesView.php');
    } else {
        $_SESSION["tipo_msg"] = "danger";
        $_SESSION["msg"] = "Houve um erro ao cadastrar o cliente.";
        header('Location: ../Views/CadastrarClienteView.php');
    }
} else if ($action == 'Delete') {
    $id = filter_input(INPUT_GET, 'ID', FILTER_SANITIZE_NUMBER_INT);
    $cliente->idpessoa = $id;
    $cliente->deletar();
    $cliente->idpessoa = "";
    $_SESSION["tipo_msg"] = "success";
    $_SESSION["msg"] = "Cliente ID <strong>" . $id . "</strong> excluido com sucesso.";
    header('Location: ../Views/ListarClientesView.php');
}

