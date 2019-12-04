<?php

class ReservaDB
{

    private $db;

    public function __construct()
    {
        $this->db = new Database();
        $this->db->debug = false;
    }

    public function cadastrarReserva($reserva)
    {
        $data["data_inicio"] = $reserva->data_inicio;
        $data["data_fim"] = $reserva->data_fim;
        $data["valor"] = $reserva->valor;
        $data["idformaPagamento"] = $reserva->idformaPagamento;
        $data["idquarto"] = $reserva->idquarto;
        $data["idevento"] = null;
        $data["idpessoa"] = $reserva->idpessoa;
        $data["idvagaGaragem"] = null;
        $reserva->idreserva = $this->db->insert("reserva", $data);

        if ($reserva->idreserva) {
            return $reserva->idreserva;
        } else {
            return false;
        }
    }

    public function consultarReserva()
    {
        $sql = "SELECT r.idreserva, r.valor, r.data_inicio, r.data_fim, 
                p.nome as nome_pessoa, q.andar as andar, q.numero as numero, 
                p.email as email, p.telefone as telefone, f.titulo as forma_pagamento
                FROM ufnprojeto2019.reserva r
                INNER JOIN ufnprojeto2019.pessoa p ON r.idpessoa = p.idpessoa
                INNER JOIN ufnprojeto2019.quarto q ON r.idquarto = q.idquarto
                INNER JOIN ufnprojeto2019.formapagamento f ON r.idformapagamento = f.idformaPagamento
                ORDER BY r.idreserva DESC";
        return $this->db->select($sql);
    }

    public function verificarReserva($reserva)
    {
        $sql = "SELECT * 
                FROM reserva 
                WHERE data_inicio = :data_inicio AND data_fim = :data_fim AND idquarto = :idquarto";
        $data["data_inicio"] = $reserva->data_inicio;
        $data["data_fim"] = $reserva->data_fim;
        $data["idquarto"] = $reserva->idquarto;
        return $this->db->select($sql, $data);
    }

    public function excluirReserva($reserva)
    {
        $sql = "DELETE
                FROM ufnprojeto2019.reserva
                WHERE idreserva = :idreserva";
        $data["idreserva"] = $reserva->idreserva;
        return $this->db->update($sql, $data);
    }
}
