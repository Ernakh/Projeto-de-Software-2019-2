using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineClients.Models
{
    public partial class ufnprojeto2019Context : DbContext
    {
        public ufnprojeto2019Context()
        {
        }

        public ufnprojeto2019Context(DbContextOptions<ufnprojeto2019Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Cardapio> Cardapio { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<Evento2> Evento2 { get; set; }
        public virtual DbSet<FormaPagamento> FormaPagamento { get; set; }
        public virtual DbSet<Frigobar> Frigobar { get; set; }
        public virtual DbSet<Garagem> Garagem { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<ItemCardapio> ItemCardapio { get; set; }
        public virtual DbSet<Mesa> Mesa { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Quarto> Quarto { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Restaurante> Restaurante { get; set; }
        public virtual DbSet<Salao> Salao { get; set; }
        public virtual DbSet<Salao2> Salao2 { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Usuarios2> Usuarios2 { get; set; }
        public virtual DbSet<VagaGaragem> VagaGaragem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=ufnprojeto2019.mysql.dbaas.com.br;uid=ufnprojeto2019;pwd=projeto2019;database=ufnprojeto2019");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cardapio>(entity =>
            {
                entity.HasKey(e => e.Idcardapio);

                entity.ToTable("cardapio", "ufnprojeto2019");

                entity.HasIndex(e => e.IditemCardapio)
                    .HasName("fk_cardapio_itemCardapio");

                entity.Property(e => e.Idcardapio)
                    .HasColumnName("idcardapio")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.IditemCardapio)
                    .HasColumnName("iditemCardapio")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IditemCardapioNavigation)
                    .WithMany(p => p.Cardapio)
                    .HasForeignKey(d => d.IditemCardapio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cardapio_itemCardapio");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.Idevento);

                entity.ToTable("evento", "ufnprojeto2019");

                entity.HasIndex(e => e.Idsalao)
                    .HasName("fk_evento_salao1");

                entity.Property(e => e.Idevento)
                    .HasColumnName("idevento")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idsalao)
                    .HasColumnName("idsalao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QuantidadePessoas)
                    .HasColumnName("quantidade_pessoas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TipoEvento)
                    .HasColumnName("tipo_evento")
                    .HasColumnType("char(1)");

                entity.HasOne(d => d.IdsalaoNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.Idsalao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_evento_salao1");
            });

            modelBuilder.Entity<Evento2>(entity =>
            {
                entity.HasKey(e => e.Idevento);

                entity.ToTable("evento2", "ufnprojeto2019");

                entity.HasIndex(e => e.Idsalao)
                    .HasName("fk_idsalao");

                entity.Property(e => e.Idevento)
                    .HasColumnName("idevento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idsalao)
                    .HasColumnName("idsalao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QuantidadePessoas)
                    .HasColumnName("quantidade_pessoas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TipoEvento)
                    .HasColumnName("tipo_evento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdsalaoNavigation)
                    .WithMany(p => p.Evento2)
                    .HasForeignKey(d => d.Idsalao)
                    .HasConstraintName("fk_idsalao");
            });

            modelBuilder.Entity<FormaPagamento>(entity =>
            {
                entity.HasKey(e => e.IdformaPagamento);

                entity.ToTable("formaPagamento", "ufnprojeto2019");

                entity.Property(e => e.IdformaPagamento)
                    .HasColumnName("idformaPagamento")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Titulo)
                    .HasColumnName("titulo")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Frigobar>(entity =>
            {
                entity.HasKey(e => e.Idfrigobar);

                entity.ToTable("frigobar", "ufnprojeto2019");

                entity.HasIndex(e => e.Iditem)
                    .HasName("fk_frigobar_item1");

                entity.Property(e => e.Idfrigobar)
                    .HasColumnName("idfrigobar")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Iditem)
                    .HasColumnName("iditem")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IditemNavigation)
                    .WithMany(p => p.Frigobar)
                    .HasForeignKey(d => d.Iditem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_frigobar_item1");
            });

            modelBuilder.Entity<Garagem>(entity =>
            {
                entity.HasKey(e => e.Idgaragem);

                entity.ToTable("garagem", "ufnprojeto2019");

                entity.HasIndex(e => e.Idgaragista)
                    .HasName("fk_garagem_pessoa1");

                entity.HasIndex(e => e.IdvagaGaragem)
                    .HasName("fk_garagem_vagaGaragem1");

                entity.Property(e => e.Idgaragem)
                    .HasColumnName("idgaragem")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idgaragista)
                    .HasColumnName("idgaragista")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdvagaGaragem)
                    .HasColumnName("idvagaGaragem")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdgaragistaNavigation)
                    .WithMany(p => p.Garagem)
                    .HasForeignKey(d => d.Idgaragista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_garagem_pessoa1");

                entity.HasOne(d => d.IdvagaGaragemNavigation)
                    .WithMany(p => p.Garagem)
                    .HasForeignKey(d => d.IdvagaGaragem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_garagem_vagaGaragem1");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.Iditem);

                entity.ToTable("item", "ufnprojeto2019");

                entity.Property(e => e.Iditem)
                    .HasColumnName("iditem")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Preco).HasColumnName("preco");

                entity.Property(e => e.Quantidade)
                    .HasColumnName("quantidade")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<ItemCardapio>(entity =>
            {
                entity.HasKey(e => e.IditemCardapio);

                entity.ToTable("itemCardapio", "ufnprojeto2019");

                entity.Property(e => e.IditemCardapio)
                    .HasColumnName("iditemCardapio")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comida)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TempoEspera).HasColumnName("Tempo_espera");
            });

            modelBuilder.Entity<Mesa>(entity =>
            {
                entity.HasKey(e => e.Idmesa);

                entity.ToTable("mesa", "ufnprojeto2019");

                entity.Property(e => e.Idmesa).HasColumnType("int(11)");

                entity.Property(e => e.Capacidade).HasColumnType("int(11)");

                entity.Property(e => e.Numeromesa).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.Idpedido);

                entity.ToTable("pedido", "ufnprojeto2019");

                entity.HasIndex(e => e.Idmesa)
                    .HasName("fk_pedido_mesa1");

                entity.HasIndex(e => e.Idpessoa)
                    .HasName("fk_pedido_pessoa1");

                entity.Property(e => e.Idpedido)
                    .HasColumnName("idpedido")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idmesa)
                    .HasColumnName("idmesa")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idpessoa)
                    .HasColumnName("idpessoa")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.HasOne(d => d.IdmesaNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.Idmesa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pedido_mesa1");

                entity.HasOne(d => d.IdpessoaNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.Idpessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pedido_pessoa1");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.Idpessoa);

                entity.ToTable("pessoa", "ufnprojeto2019");

                entity.HasIndex(e => e.Idusuario)
                    .HasName("fk_pessoa_usuario1");

                entity.Property(e => e.Idpessoa)
                    .HasColumnName("idpessoa")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ChefeCozinha)
                    .HasColumnName("chefe_cozinha")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Cliente)
                    .HasColumnName("cliente")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.CpfCnpj)
                    .HasColumnName("cpf_cnpj")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("data_nascimento")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fornecedor)
                    .HasColumnName("fornecedor")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Funcionario)
                    .HasColumnName("funcionario")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Gerente)
                    .HasColumnName("gerente")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Idusuario)
                    .HasColumnName("idusuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Recepcionista)
                    .HasColumnName("recepcionista")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Telefone)
                    .HasColumnName("telefone")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoPessoa)
                    .HasColumnName("tipo_pessoa")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Pessoa)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pessoa_usuario1");
            });

            modelBuilder.Entity<Quarto>(entity =>
            {
                entity.HasKey(e => e.Idquarto);

                entity.ToTable("quarto", "ufnprojeto2019");

                entity.HasIndex(e => e.Idfrigobar)
                    .HasName("fk_quarto_frigobar1");

                entity.Property(e => e.Idquarto)
                    .HasColumnName("idquarto")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Andar)
                    .HasColumnName("andar")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Categoria)
                    .HasColumnName("categoria")
                    .HasColumnType("char(1)");

                entity.Property(e => e.Idfrigobar)
                    .HasColumnName("idfrigobar")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Luxo)
                    .HasColumnName("luxo")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasColumnType("int(11)");

                entity.Property(e => e.QuantidadeCamas)
                    .HasColumnName("quantidade_camas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TipoCama)
                    .HasColumnName("tipo_cama")
                    .HasColumnType("char(1)");

                entity.HasOne(d => d.IdfrigobarNavigation)
                    .WithMany(p => p.Quarto)
                    .HasForeignKey(d => d.Idfrigobar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_quarto_frigobar1");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.Idreserva);

                entity.ToTable("reserva", "ufnprojeto2019");

                entity.HasIndex(e => e.Idevento)
                    .HasName("fk_reserva_evento1");

                entity.HasIndex(e => e.IdformaPagamento)
                    .HasName("fk_reserva_formaPagamento1");

                entity.HasIndex(e => e.Idpessoa)
                    .HasName("fk_reserva_pessoa1");

                entity.HasIndex(e => e.Idquarto)
                    .HasName("fk_reserva_quarto1");

                entity.HasIndex(e => e.IdvagaGaragem)
                    .HasName("fk_reserva_vagaGaragem1");

                entity.Property(e => e.Idreserva)
                    .HasColumnName("idreserva")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataFim).HasColumnName("data_fim");

                entity.Property(e => e.DataInicio).HasColumnName("data_inicio");

                entity.Property(e => e.Idevento)
                    .HasColumnName("idevento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdformaPagamento)
                    .HasColumnName("idformaPagamento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idpessoa)
                    .HasColumnName("idpessoa")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idquarto)
                    .HasColumnName("idquarto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdvagaGaragem)
                    .HasColumnName("idvagaGaragem")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.HasOne(d => d.IdeventoNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.Idevento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reserva_evento1");

                entity.HasOne(d => d.IdformaPagamentoNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.IdformaPagamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reserva_formaPagamento1");

                entity.HasOne(d => d.IdpessoaNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.Idpessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reserva_pessoa1");

                entity.HasOne(d => d.IdquartoNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.Idquarto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reserva_quarto1");

                entity.HasOne(d => d.IdvagaGaragemNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.IdvagaGaragem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reserva_vagaGaragem1");
            });

            modelBuilder.Entity<Restaurante>(entity =>
            {
                entity.HasKey(e => e.Idrestaurante);

                entity.ToTable("restaurante", "ufnprojeto2019");

                entity.HasIndex(e => e.IdChefCozinha)
                    .HasName("fk_restaurante_pessoa1");

                entity.HasIndex(e => e.IdGarcom)
                    .HasName("fk_restaurante_pessoa2");

                entity.HasIndex(e => e.Idcardapio)
                    .HasName("fk_restaurante_cardapio1");

                entity.HasIndex(e => e.Idmesa)
                    .HasName("fk_restaurante_mesa1");

                entity.Property(e => e.Idrestaurante)
                    .HasColumnName("idrestaurante")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdChefCozinha)
                    .HasColumnName("id_chef_cozinha")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdGarcom)
                    .HasColumnName("id_garcom")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idcardapio)
                    .HasColumnName("idcardapio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idmesa)
                    .HasColumnName("idmesa")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdChefCozinhaNavigation)
                    .WithMany(p => p.RestauranteIdChefCozinhaNavigation)
                    .HasForeignKey(d => d.IdChefCozinha)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_restaurante_pessoa1");

                entity.HasOne(d => d.IdGarcomNavigation)
                    .WithMany(p => p.RestauranteIdGarcomNavigation)
                    .HasForeignKey(d => d.IdGarcom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_restaurante_pessoa2");

                entity.HasOne(d => d.IdcardapioNavigation)
                    .WithMany(p => p.Restaurante)
                    .HasForeignKey(d => d.Idcardapio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_restaurante_cardapio1");

                entity.HasOne(d => d.IdmesaNavigation)
                    .WithMany(p => p.Restaurante)
                    .HasForeignKey(d => d.Idmesa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_restaurante_mesa1");
            });

            modelBuilder.Entity<Salao>(entity =>
            {
                entity.HasKey(e => e.Idsalao);

                entity.ToTable("salao", "ufnprojeto2019");

                entity.Property(e => e.Idsalao)
                    .HasColumnName("idsalao")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Capacidade)
                    .HasColumnName("capacidade")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Salao2>(entity =>
            {
                entity.HasKey(e => e.Idsalao);

                entity.ToTable("salao2", "ufnprojeto2019");

                entity.Property(e => e.Idsalao)
                    .HasColumnName("idsalao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Capacidade)
                    .HasColumnName("capacidade")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario);

                entity.ToTable("usuario", "ufnprojeto2019");

                entity.Property(e => e.Idusuario)
                    .HasColumnName("idusuario")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Login)
                    .HasColumnName("login")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasColumnName("senha")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoUsuario)
                    .HasColumnName("tipo_usuario")
                    .HasColumnType("tinyint(4)");
            });

            modelBuilder.Entity<Usuarios2>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("usuarios2", "ufnprojeto2019");

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_user")
                    .HasColumnType("int(6) unsigned");

                entity.Property(e => e.Adm)
                    .HasColumnName("adm")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("cep")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasColumnName("endereco")
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Sobrenome)
                    .IsRequired()
                    .HasColumnName("sobrenome")
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VagaGaragem>(entity =>
            {
                entity.HasKey(e => e.IdvagaGaragem);

                entity.ToTable("vagaGaragem", "ufnprojeto2019");

                entity.Property(e => e.IdvagaGaragem)
                    .HasColumnName("idvagaGaragem")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Andar)
                    .HasColumnName("andar")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Disponivel)
                    .HasColumnName("disponivel")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Valor).HasColumnName("valor");
            });
        }
    }
}
