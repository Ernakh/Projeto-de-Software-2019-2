<?php

class InformacoesModel
{

    private $nome;

    public function __construct()
    {
        $this->DB = new InformacoesDB();
    }

    public function __construct_1($vet)
    {
        $this->nome = $vet["nome"];
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

    public function consultaCliente()
    {
        $InformacoesDB = new InformacoesDB();
        return $InformacoesDB->consultarClientes();
    }

    public function consultaQuartos()
    {
        $InformacoesDB = new InformacoesDB();
        return $InformacoesDB->consultarQuartos();
    }

    public function consultaFormaPagamento()
    {
        $InformacoesDB = new InformacoesDB();
        return $InformacoesDB->consultarFormaPagamento();
    }
}
