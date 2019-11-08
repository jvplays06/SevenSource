CREATE DATABASE LOCADORASEVENCAR;


USE LOCADORASEVENCAR;

CREATE TABLE TELEFONE(
IDTELEFONE INT IDENTITY PRIMARY KEY NOT NULL,
TELFIXO VARCHAR(15),
TELMOVEL VARCHAR(15),
CPFCLIENTE bigint null,
IDFUN int null,
foreign key (CPFCLIENTE) references CLIENTE(CPFCLIENTE),
foreign key (IDFUN) references FUNCIONARIO(IDFUN)
);
alter table	TELEFONE alter COLUMN TELFIXO varchar(15);
alter table	TELEFONE alter COLUMN TELMOVEL varchar(15);

CREATE TABLE ENDERECO(
IDENDERECO INT PRIMARY KEY IDENTITY,
RUA VARCHAR(20),
NUMERO NUMERIC(5),
CIDADE VARCHAR(20),
BAIRRO VARCHAR(20),
ESTADO VARCHAR(2),
CEP NUMERIC(8),
);

CREATE TABLE CARGO(
IDCARGO INT IDENTITY PRIMARY KEY,
NIVEL NUMERIC(1)
);

CREATE TABLE FUNCIONARIO(
IDFUN INT IDENTITY PRIMARY KEY,
LOGINFUN VARCHAR(20) NOT NULL,
SENHAFUN VARCHAR(100) NOT NULL,
NOMEFUN VARCHAR(100) NOT NULL,
CPFFUN VARCHAR(11) NOT NULL,
IDCARGO INT,
FOREIGN KEY (IDCARGO) REFERENCES CARGO(IDCARGO),
);
alter table FUNCIONARIO alter COLUMN CPFFUN varchar(11);

CREATE TABLE CLIENTE(
CPFCLIENTE bigint primary key,
NOMECLIENTE VARCHAR(100),
EMAILCLIENTE VARCHAR(100),
CNHCLIENTE VARCHAR(11),
IDENDERECO INT,
foreign key (IDENDERECO) references ENDERECO(IDENDERECO)
);
alter table CLIENTE alter COLUMN CNHCLIENTE varchar(11);
alter table CLIENTE alter COLUMN CPFCLIENTE BIGINT;


CREATE TABLE MODELO(
IDMODELO INT IDENTITY PRIMARY KEY,
NOMEMODELO VARCHAR(15),
ANOMODELO NUMERIC(4),
IDMARCA INT,
IDCATEGORIA INT,
FOREIGN KEY (IDMARCA) REFERENCES MARCA(IDMARCA),
FOREIGN KEY (IDCATEGORIA) REFERENCES CATEGORIA(IDCATEGORIA)
);

CREATE TABLE MARCA(
IDMARCA INT IDENTITY PRIMARY KEY,
NOMEMARCA VARCHAR(20)
);

CREATE TABLE MANUTENCAO(
IDMANUTENCAO INT IDENTITY PRIMARY KEY,
DSMANUTENCAO TEXT,
);

CREATE TABLE CATEGORIA(
IDCATEGORIA INT PRIMARY KEY IDENTITY,
TIPOCATEGORIA VARCHAR(15),
VALOR_P_DIA DECIMAL(4,2),
DSCATEGORIA TEXT
);

CREATE TABLE VEICULO(
IDVEICULO INT IDENTITY PRIMARY KEY,
PLACA VARCHAR(8) UNIQUE,
CAMBIO CHAR(1),
IDMODELO INT ,
IDMARCA INT,
IDMANUTENCAO INT 
FOREIGN KEY (IDMODELO) REFERENCES MODELO(IDMODELO),
FOREIGN KEY (IDMANUTENCAO) REFERENCES MANUTENCAO(IDMANUTENCAO)
);

CREATE TABLE PAGAMENTO(
IDPAGAMENTO INT IDENTITY PRIMARY KEY,
TIPOPAGAMENTO VARCHAR(50)
);

CREATE TABLE LOCACAO(
IDLOCACAO INT PRIMARY KEY IDENTITY,
IDVEICULO INT,
CPFCLIENTE BIGINT,
IDFUN INT,
RETIRADA DATE NOT NULL,
PRAZOENTREGA DATE NOT NULL,
IDPAGAMENTO INT,
FOREIGN KEY (IDPAGAMENTO) REFERENCES PAGAMENTO(IDPAGAMENTO),
FOREIGN KEY (IDVEICULO) REFERENCES VEICULO(IDVEICULO),
FOREIGN KEY (CPFCLIENTE) REFERENCES CLIENTE(CPFCLIENTE),
FOREIGN KEY (IDFUN) REFERENCES FUNCIONARIO(IDFUN),
);

CREATE TABLE DEVOLUCAO(
IDDEVOLUCAO INT PRIMARY KEY IDENTITY,
DATADEVOLUCAO DATE ,
IDLOCACAO INT,
FOREIGN KEY (IDLOCACAO) REFERENCES LOCACAO(IDLOCACAO)
);

drop table TELEFONE;
drop table ENDERECO;
drop table cliente;
drop table FUNCIONARIO;
drop table LOCACAO;
drop table DEVOLUCAO;
drop table VEICULO;
drop table marca ;
drop table modelo ;
drop table MANUTENCAO;
drop table CARGO;
drop table CATEGORIA;
drop table PAGAMENTO;
drop database LOCADORASEVENCAR;

select * from telefone;
select * from cliente;

SELECT * FROM TELEFONE as T
INNER JOIN CLIENTE as C
   on T.CPFCLIENTE = C.CPFCLIENTE where T.CPFCLIENTE=1234567896

SELECT * FROM TELEFONE as T
INNER JOIN CLIENTE AS C ON T.CPFCLIENTE = C.CPFCLIENTE
INNER JOIN ENDERECO ON  = CLIENTE.CPFCLIENTE;

INSERT INTO ENDERECO (RUA,NUMERO,CIDADE,BAIRRO,ESTADO,CEP) VALUES ('PEDRO AMERICO','96','CIDADE','BAIRRO','SP','3696525');
INSERT INTO CLIENTE VALUES(36936936966,'JOAO','JVOLIVEIRA@GMAIL.COM','36936936966',1);
SELECT * FROM ENDERECO;