CREATE SCHEMA `ufnprojeto2019`;
USE `ufnprojeto2019`;

-- -----------------------------------------------------
-- Table `ufnprojeto2019`.`itemCardapio`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ufnprojeto2019`.`itemCardapio`
(
    `iditemCardapio` INT         NOT NULL,
    `nome`           VARCHAR(50) NULL,
    `valor`          FLOAT       NULL,
    PRIMARY KEY (`iditemCardapio`)
)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ufnprojeto2019`.`cardapio`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ufnprojeto2019`.`cardapio`
(
    `idcardapio`     INT NOT NULL,
    `iditemCardapio` INT NOT NULL,
    PRIMARY KEY (`idcardapio`),
    CONSTRAINT `fk_cardapio_itemCardapio`
        FOREIGN KEY (`iditemCardapio`)
            REFERENCES `ufnprojeto2019`.`itemCardapio` (`iditemCardapio`)
            ON DELETE NO ACTION
            ON UPDATE NO ACTION
)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ufnprojeto2019`.`mesa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ufnprojeto2019`.`mesa`
(
    `idmesa`     INT NOT NULL,
    `numero`     INT NULL,
    `capacidade` INT NULL,
    PRIMARY KEY (`idmesa`)
)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ufnprojeto2019`.`usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ufnprojeto2019`.`usuario`
(
    `idusuario`    INT         NOT NULL AUTO_INCREMENT,
    `login`        VARCHAR(50) NULL,
    `senha`        VARCHAR(50) NULL,
    `tipo_usuario` TINYINT     NULL,
    PRIMARY KEY (`idusuario`)
)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ufnprojeto2019`.`pessoa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ufnprojeto2019`.`pessoa`
(
    `idpessoa`        INT         NOT NULL AUTO_INCREMENT,
    `idusuario`       INT         NULL,
    `nome`            VARCHAR(50) NULL,
    `tipo_pessoa`     INT         NULL,
    `cpf_cnpj`        VARCHAR(50) NULL,
    `data_nascimento` DATE        NULL,
    `telefone`        VARCHAR(20) NULL,
    `email`           VARCHAR(20) NULL,
    `funcionario`     TINYINT     NULL,
    `cliente`         TINYINT     NULL,
    `gerente`         TINYINT     NULL,
    `recepcionista`   TINYINT     NULL,
    `chefe_cozinha`   TINYINT     NULL,
    `fornecedor`      TINYINT     NULL,
    PRIMARY KEY (`idpessoa`),
    CONSTRAINT `fk_pessoa_usuario1`
        FOREIGN KEY (`idusuario`)
            REFERENCES `ufnprojeto2019`.`usuario` (`idusuario`)
            ON DELETE NO ACTION
            ON UPDATE NO ACTION
)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ufnprojeto2019`.`restaurante`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ufnprojeto2019`.`restaurante`
(
    `idrestaurante`   INT NOT NULL,
    `idmesa`          INT NOT NULL,
    `idcardapio`      INT NOT NULL,
    `id_chef_cozinha` INT NOT NULL,
    `id_garcom`       INT NOT NULL,
    PRIMARY KEY (`idrestaurante`),
    CONSTRAINT `fk_restaurante_mesa1`
        FOREIGN KEY (`idmesa`)
            REFERENCES `ufnprojeto2019`.`mesa` (`idmesa`)
            ON DELETE NO ACTION
            ON UPDATE NO ACTION,
    CONSTRAINT `fk_restaurante_cardapio1`
        FOREIGN KEY (`idcardapio`)
            REFERENCES `ufnprojeto2019`.`cardapio` (`idcardapio`)
            ON DELETE NO ACTION
            ON UPDATE NO ACTION,
    CONSTRAINT `fk_restaurante_pessoa1`
        FOREIGN KEY (`id_chef_cozinha`)
            REFERENCES `ufnprojeto2019`.`pessoa` (`idpessoa`)
            ON DELETE NO ACTION
            ON UPDATE NO ACTION,
    CONSTRAINT `fk_restaurante_pessoa2`
        FOREIGN KEY (`id_garcom`)
            REFERENCES `ufnprojeto2019`.`pessoa` (`idpessoa`)
            ON DELETE NO ACTION
            ON UPDATE NO ACTION
)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ufnprojeto2019`.`pedido`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ufnprojeto2019`.`pedido`
(
    `idpedido` INT   NOT NULL,
    `idmesa`   INT   NOT NULL,
    `valor`    FLOAT NULL,
    `idpessoa` INT   NOT NULL,
    PRIMARY KEY (`idpedido`),
    CONSTRAINT `fk_pedido_mesa1`
        FOREIGN KEY (`idmesa`)
            REFERENCES `ufnprojeto2019`.`mesa` (`idmesa`)
            ON DELETE NO ACTION
            ON UPDATE NO ACTION,
    CONSTRAINT `fk_pedido_pessoa1`
        FOREIGN KEY (`idpessoa`)
            REFERENCES `ufnprojeto2019`.`pessoa` (`idpessoa`)
            ON DELETE NO ACTION
            ON UPDATE NO ACTION
)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ufnprojeto2019`.`vagaGaragem`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ufnprojeto2019`.`vagaGaragem`
(
    `idvagaGaragem` INT     NOT NULL,
    `andar`         INT     NULL,
    `numero`        INT     NULL,
    `valor`         FLOAT   NULL,
    `disponivel`    TINYINT NULL,
    PRIMARY KEY (`idvagaGaragem`)
)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ufnprojeto2019`.`garagem`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ufnprojeto2019`.`garagem`
(
    `idgaragem`     INT NOT NULL,
    `idvagaGaragem` INT NOT NULL,
    `idgaragista`   INT NOT NULL,
    PRIMARY KEY (`idgaragem`),
    CONSTRAINT `fk_garagem_vagaGaragem1`
        FOREIGN KEY (`idvagaGaragem`)
            REFERENCES `ufnprojeto2019`.`vagaGaragem` (`idvagaGaragem`)
            ON DELETE NO ACTION
            ON UPDATE NO ACTION,
    CONSTRAINT `fk_garagem_pessoa1`
        FOREIGN KEY (`idgaragista`)
            REFERENCES `ufnprojeto2019`.`pessoa` (`idpessoa`)
            ON DELETE NO ACTION
            ON UPDATE NO ACTION
)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ufnprojeto2019`.`formaPagamento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ufnprojeto2019`.`formaPagamento`
(
    `idformaPagamento` INT         NOT NULL AUTO_INCREMENT,
    `titulo`           VARCHAR(50) NULL,
    PRIMARY KEY (`idformaPagamento`)
)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ufnprojeto2019`.`item`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ufnprojeto2019`.`item`
(
    `iditem`     INT         NOT NULL,
    `nome`       VARCHAR(50) NULL,
    `preco`      FLOAT       NULL,
    `quantidade` INT         NULL,
    PRIMARY KEY (`iditem`)
)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ufnprojeto2019`.`frigobar`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ufnprojeto2019`.`frigobar`
(
    `idfrigobar` INT NOT NULL,
    `iditem`     INT NOT NULL,
    PRIMARY KEY (`idfrigobar`),
    CONSTRAINT `fk_frigobar_item1`
        FOREIGN KEY (`iditem`)
            REFERENCES `ufnprojeto2019`.`item` (`iditem`)
            ON DELETE NO ACTION
            ON UPDATE NO ACTION
)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ufnprojeto2019`.`quarto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ufnprojeto2019`.`quarto`
(
    `idquarto`         INT     NOT NULL AUTO_INCREMENT,
    `idfrigobar`       INT     NULL,
    `numero`           INT     NULL,
    `andar`            INT     NULL,
    `quantidade_camas` INT     NULL,
    `tipo_cama`        CHAR(1) NULL,
    `categoria`        CHAR(1) NULL,
    `luxo`             TINYINT NULL,
    PRIMARY KEY (`idquarto`),
    CONSTRAINT `fk_quarto_frigobar1`
        FOREIGN KEY (`idfrigobar`)
            REFERENCES `ufnprojeto2019`.`frigobar` (`idfrigobar`)
            ON DELETE NO ACTION
            ON UPDATE NO ACTION
)
    ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `ufnprojeto2019`.`salao`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ufnprojeto2019`.`salao`
(
    `idsalao`    INT         NOT NULL,
    `nome`       VARCHAR(50) NULL,
    `capacidade` INT         NULL,
    PRIMARY KEY (`idsalao`)
)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ufnprojeto2019`.`evento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ufnprojeto2019`.`evento`
(
    `idevento`           INT         NOT NULL,
    `idsalao`            INT         NOT NULL,
    `nome`               VARCHAR(50) NULL,
    `tipo_evento`        CHAR(1)     NULL,
    `quantidade_pessoas` INT         NULL,
    PRIMARY KEY (`idevento`),
    CONSTRAINT `fk_evento_salao1`
        FOREIGN KEY (`idsalao`)
            REFERENCES `ufnprojeto2019`.`salao` (`idsalao`)
            ON DELETE NO ACTION
            ON UPDATE NO ACTION
)
    ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ufnprojeto2019`.`reserva`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ufnprojeto2019`.`reserva`
(
    `idreserva`        INT      NOT NULL AUTO_INCREMENT,
    `data_inicio`      DATETIME NULL,
    `data_fim`         DATETIME NULL,
    `valor`            FLOAT    NULL,
    `idformaPagamento` INT      NULL,
    `idquarto`         INT      NULL,
    `idevento`         INT      NULL,
    `idpessoa`         INT      NULL,
    `idvagaGaragem`    INT      NULL,
    PRIMARY KEY (`idreserva`),
    CONSTRAINT `fk_reserva_formaPagamento1`
        FOREIGN KEY (`idformaPagamento`)
            REFERENCES `ufnprojeto2019`.`formaPagamento` (`idformaPagamento`)
            ON DELETE NO ACTION
            ON UPDATE NO ACTION,
    CONSTRAINT `fk_reserva_quarto1`
        FOREIGN KEY (`idquarto`)
            REFERENCES `ufnprojeto2019`.`quarto` (`idquarto`)
            ON DELETE NO ACTION
            ON UPDATE NO ACTION,
    CONSTRAINT `fk_reserva_evento1`
        FOREIGN KEY (`idevento`)
            REFERENCES `ufnprojeto2019`.`evento` (`idevento`)
            ON DELETE NO ACTION
            ON UPDATE NO ACTION,
    CONSTRAINT `fk_reserva_pessoa1`
        FOREIGN KEY (`idpessoa`)
            REFERENCES `ufnprojeto2019`.`pessoa` (`idpessoa`)
            ON DELETE NO ACTION
            ON UPDATE NO ACTION,
    CONSTRAINT `fk_reserva_vagaGaragem1`
        FOREIGN KEY (`idvagaGaragem`)
            REFERENCES `ufnprojeto2019`.`vagaGaragem` (`idvagaGaragem`)
            ON DELETE NO ACTION
            ON UPDATE NO ACTION
)
    ENGINE = InnoDB;

INSERT INTO USUARIO(login, senha, tipo_usuario)
values ('admin', md5('admin'), 1);

INSERT INTO QUARTO(idfrigobar, numero, andar, quantidade_camas, tipo_cama, categoria, luxo)
VALUES (null, 1, 1, 2, 'A', 'A', 0),
(null, 2, 1, 1, 'B', 'A', 1),
(null, 3, 1, 1, 'A', 'B', 0),
(null, 4, 1, 1, 'A', 'A', 1),
(null, 5, 1, 1, 'A', 'A', 1),
(null, 6, 1, 1, 'C', 'A', 1),
(null, 1, 2, 1, 'C', 'A', 0),
(null, 2, 2, 1, 'A', 'D', 0),
(null, 3, 2, 1, 'B', 'D', 0),
(null, 4, 2, 1, 'B', 'B', 1),
(null, 5, 2, 1, 'A', 'B', 1),
(null, 6, 2, 1, 'A', 'C', 1);

INSERT INTO FORMAPAGAMENTO(titulo)
VALUES ('Cartão de Crédito'),
('Cartão de Débito'),
('Dinheiro');