# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.db import models

# Create your models here.

class Cardapio(models.Model):
    idcardapio = models.IntegerField(primary_key=True)
    iditemcardapio = models.ForeignKey('Itemcardapio', models.DO_NOTHING, db_column='iditemCardapio')  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'cardapio'


class Evento(models.Model):
    idevento = models.IntegerField(primary_key=True)
    idsalao = models.ForeignKey('Salao', models.DO_NOTHING, db_column='idsalao')
    nome = models.CharField(max_length=50, blank=True, null=True)
    tipo_evento = models.CharField(max_length=1, blank=True, null=True)
    quantidade_pessoas = models.IntegerField(blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'evento'


class Formapagamento(models.Model):
    idformapagamento = models.IntegerField(db_column='idformaPagamento', primary_key=True)  # Field name made lowercase.
    titulo = models.CharField(max_length=50, blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'formaPagamento'


class Frigobar(models.Model):
    idfrigobar = models.IntegerField(primary_key=True)
    iditem = models.ForeignKey('Item', models.DO_NOTHING, db_column='iditem')

    class Meta:
        managed = False
        db_table = 'frigobar'


class Garagem(models.Model):
    idgaragem = models.IntegerField(primary_key=True)
    idvagagaragem = models.ForeignKey('Vagagaragem', models.DO_NOTHING, db_column='idvagaGaragem')  # Field name made lowercase.
    idgaragista = models.ForeignKey('Pessoa', models.DO_NOTHING, db_column='idgaragista')

    class Meta:
        managed = False
        db_table = 'garagem'


class Item(models.Model):
    iditem = models.IntegerField(primary_key=True)
    nome = models.CharField(max_length=50, blank=True, null=True)
    preco = models.FloatField(blank=True, null=True)
    quantidade = models.IntegerField(blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'item'


class Itemcardapio(models.Model):
    iditemcardapio = models.IntegerField(db_column='iditemCardapio', primary_key=True)  # Field name made lowercase.
    nome = models.CharField(max_length=50, blank=True, null=True)
    valor = models.FloatField(blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'itemCardapio'


class Mesa(models.Model):
    idmesa = models.IntegerField(primary_key=True)
    numero = models.IntegerField(blank=True, null=True)
    capacidade = models.IntegerField(blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'mesa'


class Pedido(models.Model):
    idpedido = models.IntegerField(primary_key=True)
    idmesa = models.ForeignKey(Mesa, models.DO_NOTHING, db_column='idmesa')
    valor = models.FloatField(blank=True, null=True)
    idpessoa = models.ForeignKey('Pessoa', models.DO_NOTHING, db_column='idpessoa')

    class Meta:
        managed = False
        db_table = 'pedido'


class Pessoa(models.Model):
    idpessoa = models.IntegerField(primary_key=True)
    idusuario = models.ForeignKey('Usuario', models.DO_NOTHING, db_column='idusuario')
    nome = models.CharField(max_length=50, blank=True, null=True)
    tipo_pessoa = models.IntegerField(blank=True, null=True)
    cpf_cnpj = models.CharField(max_length=50, blank=True, null=True)
    data_nascimento = models.DateField(blank=True, null=True)
    telefone = models.CharField(max_length=20, blank=True, null=True)
    email = models.CharField(max_length=20, blank=True, null=True)
    funcionario = models.IntegerField(blank=True, null=True)
    cliente = models.IntegerField(blank=True, null=True)
    gerente = models.IntegerField(blank=True, null=True)
    recepcionista = models.IntegerField(blank=True, null=True)
    chefe_cozinha = models.IntegerField(blank=True, null=True)
    fornecedor = models.IntegerField(blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'pessoa'


class Quarto(models.Model):
    idquarto = models.IntegerField(primary_key=True)
    idfrigobar = models.ForeignKey(Frigobar, models.DO_NOTHING, db_column='idfrigobar')
    numero = models.IntegerField(blank=True, null=True)
    andar = models.IntegerField(blank=True, null=True)
    quantidade_camas = models.IntegerField(blank=True, null=True)
    tipo_cama = models.CharField(max_length=1, blank=True, null=True)
    categoria = models.CharField(max_length=1, blank=True, null=True)
    luxo = models.IntegerField(blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'quarto'


class Reserva(models.Model):
    idreserva = models.IntegerField(primary_key=True)
    data_inicio = models.DateTimeField(blank=True, null=True)
    data_fim = models.DateTimeField(blank=True, null=True)
    valor = models.FloatField(blank=True, null=True)
    idformapagamento = models.ForeignKey(Formapagamento, models.DO_NOTHING, db_column='idformaPagamento')  # Field name made lowercase.
    idquarto = models.ForeignKey(Quarto, models.DO_NOTHING, db_column='idquarto')
    idevento = models.ForeignKey(Evento, models.DO_NOTHING, db_column='idevento')
    idpessoa = models.ForeignKey(Pessoa, models.DO_NOTHING, db_column='idpessoa')
    idvagagaragem = models.ForeignKey('Vagagaragem', models.DO_NOTHING, db_column='idvagaGaragem')  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'reserva'


class Restaurante(models.Model):
    idrestaurante = models.IntegerField(primary_key=True)
    idmesa = models.ForeignKey(Mesa, models.DO_NOTHING, db_column='idmesa')
    idcardapio = models.ForeignKey(Cardapio, models.DO_NOTHING, db_column='idcardapio')
    id_chef_cozinha = models.ForeignKey(Pessoa, models.DO_NOTHING, db_column='id_chef_cozinha', related_name='id_chef_cozinha_pessoa')
    id_garcom = models.ForeignKey(Pessoa, models.DO_NOTHING, db_column='id_garcom', related_name='id_garcom_pessoa')

    class Meta:
        managed = False
        db_table = 'restaurante'


class Salao(models.Model):
    idsalao = models.IntegerField(primary_key=True)
    nome = models.CharField(max_length=50, blank=True, null=True)
    capacidade = models.IntegerField(blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'salao'


class Usuario(models.Model):
    idusuario = models.IntegerField(primary_key=True)
    login = models.CharField(max_length=50, blank=True, null=True)
    senha = models.CharField(max_length=50, blank=True, null=True)
    tipo_usuario = models.IntegerField(blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'usuario'


class Vagagaragem(models.Model):
    idvagagaragem = models.IntegerField(db_column='idvagaGaragem', primary_key=True)  # Field name made lowercase.
    andar = models.IntegerField(blank=True, null=True)
    numero = models.IntegerField(blank=True, null=True)
    valor = models.FloatField(blank=True, null=True)
    disponivel = models.IntegerField(blank=True, null=True)

    class Meta:
        managed = False
        db_table = 'vagaGaragem'