using System;
using System.Collections.Generic;

namespace OnlineClients.Models
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Garagem = new HashSet<Garagem>();
            Pedido = new HashSet<Pedido>();
            Reserva = new HashSet<Reserva>();
            RestauranteIdChefCozinhaNavigation = new HashSet<Restaurante>();
            RestauranteIdGarcomNavigation = new HashSet<Restaurante>();
        }

        public int Idpessoa { get; set; }
        public int Idusuario { get; set; }
        public string Nome { get; set; }
        public int? TipoPessoa { get; set; }
        public string CpfCnpj { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public byte? Funcionario { get; set; }
        public byte? Cliente { get; set; }
        public byte? Gerente { get; set; }
        public byte? Recepcionista { get; set; }
        public byte? ChefeCozinha { get; set; }
        public byte? Fornecedor { get; set; }

        public Usuario IdusuarioNavigation { get; set; }
        public ICollection<Garagem> Garagem { get; set; }
        public ICollection<Pedido> Pedido { get; set; }
        public ICollection<Reserva> Reserva { get; set; }
        public ICollection<Restaurante> RestauranteIdChefCozinhaNavigation { get; set; }
        public ICollection<Restaurante> RestauranteIdGarcomNavigation { get; set; }
    }
}
