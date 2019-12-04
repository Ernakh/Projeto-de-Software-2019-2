<?php

class ClientesModel
{

    public $idpessoa;
    public $idusuario;
    public $nome;
    public $tipo_pessoa;
    public $cpf_cnpj;
    public $data_nascimento;
    public $telefone;
    public $email;
    public $funcionario;
    public $cliente;
    public $gerente;
    public $recepcionista;
    public $chefe_cozinha;
    public $fornecedor;

    public function __construct()
    {
        $this->DB = new ClientesDB();
    }

    public function __construct_1($vet)
    {
        $this->idpessoa = $vet["idpessoa"];
        $this->nome = $vet["nome"];
        $this->tipo_pessoa = $vet["tipo_pessoa"];
        $this->cpf_cnpj = $vet["cpf_cnpj"];
        $this->email = $vet["email"];
        $this->telefone = $vet["telefone"];
        $this->data_nascimento = $vet["data_nascimento"];
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
        $clientesDB = new ClientesDB();
        return $clientesDB->cadastrarCliente($this);
    }

    public function consultar()
    {
        $clientesDB = new ClientesDB();
        return $clientesDB->consultarClientes();
    }

    public function deletar()
    {
        $clienteDB = new ClientesDB();
        return $clienteDB->deletarCliente($this);
    }
}
