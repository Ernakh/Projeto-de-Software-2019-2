<?php

class ReservaModel
{

    public $idreserva;
    public $data_inicio;
    public $data_fim;
    public $valor;
    public $idformaPagamento;
    public $idquarto;
    public $idpessoa;

    public function __construct()
    {
        $this->DB = new ReservaDB();
    }

    public function __construct_1($vet)
    {
        $this->idreserva = $vet["idreserva"];
        $this->data_inicio = $vet["data_inicio"];
        $this->data_fim = $vet["data_fim"];
        $this->valor = $vet["valor"];
        $this->idformaPagamento = $vet["idformaPagamento"];
        $this->idquarto = $vet["idquarto"];
        $this->idpessoa = $vet["idpessoa"];
    }

    public function __get($property)
    {
        if (property_exists($this, $property)) {
            return $this->$property;
        }
    }

    public function __set($property, $value)
    {
        if (property_exists($this, $property)) {
            $this->$property = $value;
        }
    }

    public function salvar()
    {
        $reservaDB = new ReservaDB();
        return $reservaDB->cadastrarReserva($this);
    }

    public function consultar()
    {
        $reservaDB = new ReservaDB();
        return $reservaDB->consultarReserva();
    }

    public function verificar()
    {
        $reservaBD = new ReservaDB();
        return $reservaBD->verificarReserva($this);
    }

    public function excluir()
    {
        $reservaDB = new ReservaDB;
        return $reservaDB->excluirReserva($this);
    }
}
