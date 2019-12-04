<?php
error_reporting(0);
session_start();
require_once '../Databases/Database.php';
require_once '../Databases/Debug.php';
require_once '../Databases/ReservaDB.php';
require_once '../Models/ReservaModel.php';

$reserva = new ReservaModel();

$_SESSION['dados_reservas'] = $reserva->consultar();
header('Location: ../Views/ListarHorariosView.php');