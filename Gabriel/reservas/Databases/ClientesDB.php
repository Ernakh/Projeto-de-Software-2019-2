<?php

class ClientesDB
{

    private $db;

    public function __construct()
    {
        $this->db = new Database();
        $this->db->debug = false;
    }

    public function cadastrarCliente($cliente)
    {
        $data["idusuario"] = null;
        $data["nome"] = $cliente->nome;
        $data["tipo_pessoa"] = $cliente->tipo_pessoa;
        $data["cpf_cnpj"] = $cliente->cpf_cnpj;
        $data["data_nascimento"] = $cliente->data_nascimento;
        $data["telefone"] = $cliente->telefone;
        $data["email"] = $cliente->email;
        $data["funcionario"] = 0;
        $data["cliente"] = 1;
        $data["gerente"] = 0;
        $data["recepcionista"] = 0;
        $data["chefe_cozinha"] = 0;
        $data["fornecedor"] = 0;

        $cliente->idpessoa = $this->db->insert("pessoa", $data);

        if ($cliente->idpessoa) {
            return $cliente->idpessoa;
        } else {
            return false;
        }
    }

    public function consultarClientes()
    {
        $sql = "SELECT idpessoa, nome, cpf_cnpj, DATE_FORMAT(data_nascimento,'%d/%m/%Y') as dt_nascimento, telefone, email
                  FROM ufnprojeto2019.pessoa
              ORDER BY idpessoa DESC";
        return $this->db->select($sql);
    }

    public function deletarCliente($cliente)
    {
        $sql = "DELETE 
                FROM ufnprojeto2019.pessoa
                WHERE idpessoa = :idpessoa";
        $data["idpessoa"] = $cliente->idpessoa;
        return $this->db->update($sql, $data);
    }
}
