<?php

class UsuarioDB
{

    private $db;

    public function __construct()
    {
        $this->db = new Database();
        $this->db->debug = false;
    }

    public function consultarUsuario($usuario)
    {
        $sql = "SELECT *
                FROM usuario
                WHERE login = :login AND senha = :senha";
        $data["login"] = $usuario->login;
        $data["senha"] = md5($usuario->senha);
        return $this->db->select($sql, $data);
    }
}
