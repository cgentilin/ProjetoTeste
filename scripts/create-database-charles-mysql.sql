create database db_cliente;

use db_cliente;

create table cliente
(
    id bigint not null AUTO_INCREMENT primary key,
    nome varchar(100) not null,
    email varchar(100) not null,
    rg varchar(8) null,
    documento varchar(11) not null,
    fone varchar(11) null,
    data_nascimento datetime null
);
CREATE UNIQUE INDEX indx_cliente_01 ON cliente(email);
CREATE UNIQUE INDEX indx_cliente_02 ON cliente(documento);

create database db_cartao;
use db_cartao;

create table proposta
(
    id bigint not null AUTO_INCREMENT primary key,
    nome_proponente varchar(100) not null,
    documento_proponente varchar(11) not null,
    data_proposta datetime not null,
    valor_proposta decimal(7,2) not null,
    valor_renda_proponente decimal(7,2) not null,
    situacao_proposta int not null COMMENT '1 - Aguardando Analise, 2 - Aprovada, 3 - Reprovada, 4 - Cancelada' 
);
CREATE INDEX indx_proposta_01 ON proposta(documento_proponente, data_proposta, valor_proposta);
CREATE INDEX indx_proposta_02 ON proposta(data_proposta, situacao_proposta);

create table cartao
(
    id bigint not null AUTO_INCREMENT primary key,
    numero varchar(10) not null,
    documento_titular varchar(11) not null,
    data_validade datetime,
    data_emissao datetime not null,
    situacao int not null COMMENT '1 - Ativo, 2 - Boqueado, 3 - Cancelado' 
);
CREATE UNIQUE INDEX indx_cartao_01 ON cartao(numero);
CREATE UNIQUE INDEX indx_cartao_02 ON cartao(documento_titular,numero);

