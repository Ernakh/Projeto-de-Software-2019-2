<?php

class InformacoesDB
{

    private $db;

    public function __construct()
    {
        $this->db = new Database();
        $this->db->debug = false;
    }

    public function consultarClientes()
    {
        $sql = "SELECT idpessoa, nome
                FROM  pessoa
                ORDER BY idpessoa DESC";
        return $this->db->select($sql);
    }

    public function consultarQuartos()
    {
        $sql = "SELECT idquarto, numero, andar, quantidade_camas
                FROM quarto";
        return $this->db->select($sql);
    }

    public function consultarFormaPagamento()
    {
        $sql = "SELECT idformaPagamento, titulo
                FROM formapagamento";
        return $this->db->select($sql);
    }
}
