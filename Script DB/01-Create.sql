--16/01/2020
------------------------------------------------------------------------------------
/*
USE master

IF EXISTS (SELECT name FROM master.sys.databases WHERE name = 'MERCADO_01')
DROP DATABASE MERCADO_01;
GO

CREATE DATABASE MERCADO_01
*/

USE MERCADO_01

------------------------------------------------------------------------------------

CREATE TABLE TBL_CAIXA(
CAX_ID INT NOT NULL IDENTITY(1,1),
CAX_TOTAL DECIMAL (10,2)
)
--PRIMARY KEY
ALTER TABLE TBL_CAIXA ADD CONSTRAINT PK_CAIXA_ID PRIMARY KEY (CAX_ID)


CREATE TABLE TBL_SUB_CATEGORIA(
SUB_CAT_ID INT NOT NULL IDENTITY(1,1),
SUB_CAT_TIPO VARCHAR(20) 
)
--PRIMARY KEY
ALTER TABLE TBL_SUB_CATEGORIA ADD CONSTRAINT PK_SUB_CAT_ID PRIMARY KEY (SUB_CAT_ID)


CREATE TABLE TBL_CATEGORIA(
CAT_ID INT NOT NULL IDENTITY(1,1),
SUB_CAT_ID INT, 
CAT_TIPO VARCHAR(20)
)
--PRIMARY KEY
ALTER TABLE TBL_CATEGORIA ADD CONSTRAINT PK_CATEGORIA_ID PRIMARY KEY (CAT_ID)
--FOREIGN KEY
ALTER TABLE TBL_CATEGORIA ADD CONSTRAINT FK_SUB_CATEGORIA_ID FOREIGN KEY (SUB_CAT_ID) REFERENCES TBL_SUB_CATEGORIA


--CREATE TABLE TBL_FOTO(
--FOT_ID INT NOT NULL IDENTITY(1,1),
--FOT_IMAGEM IMAGE
--)
----PRIMARY KEY
--ALTER TABLE TBL_FOTO ADD CONSTRAINT PK_FOTO_ID PRIMARY KEY (FOT_ID)



CREATE TABLE TBL_PRODUTO(
  PROD_ID INT NOT NULL IDENTITY(1,1),
  PROD_COD VARCHAR(12) UNIQUE,
  SUB_CAT_ID INT,
  --FOT_ID INT,
  PROD_NOME VARCHAR(50) NOT NULL,
  PROD_MARCA VARCHAR(30),
  PROD_QTD INT NOT NULL,
  PROD_QTD_MIN INT,
  --PROD_PESO FLOAT,
  PROD_VALOR DECIMAL(10,2) NOT NULL,
  PROD_VALOR_VENDA DECIMAL(10,2) NOT NULL,
  --PROD_DESC VARCHAR(100) ,
  --PROD_VALIDADE DATE,
  FOTO IMAGE
)
--PRIMARY KEY
ALTER TABLE TBL_PRODUTO ADD CONSTRAINT PK_PRODUTO_ID PRIMARY KEY (PROD_ID)
--FOREIGN KEY
ALTER TABLE TBL_PRODUTO ADD CONSTRAINT FK_SUB_CAT_PROD_ID FOREIGN KEY (SUB_CAT_ID) REFERENCES TBL_SUB_CATEGORIA
----FOREIGN KEY
--ALTER TABLE TBL_PRODUTO ADD CONSTRAINT FK_FOT_PROD_ID FOREIGN KEY (FOT_ID) REFERENCES TBL_FOTO   


CREATE TABLE TBL_TELEFONE (
  TEL_ID INT NOT NULL  IDENTITY(1,1),
  TEL_DDD CHAR(3),
  TEL_CELULAR VARCHAR(14),
  TEL_FIXO VARCHAR(14),
  TEL_OPERADORA VARCHAR(15) NULL
)
--PRIMARY KEY
ALTER TABLE TBL_TELEFONE ADD CONSTRAINT PK_TELEFONE_ID PRIMARY KEY (TEL_ID)


--CREATE TABLE TBL_ESTADO
--(
-- EST_CODUF INT NOT NULL,
-- EST_NOME VARCHAR(30) NOT NULL,
-- EST_UF CHAR(2) NOT NULL,
-- EST_IBGE INT NOT NULL,
--)
-----PRIMARY KEY
--ALTER TABLE TBL_ESTADO
--ADD CONSTRAINT PK_ESTADOUF_ID PRIMARY KEY (EST_CODUF)


--CREATE TABLE TBL_CIDADE
--(
--  CID_ID INT NOT NULL,
--  EST_CODUF INT NOT NULL,
--  CID_NOME VARCHAR(100) NOT NULL, 
--  CID_IBGE INT NOT NULL
--)
-----PRIMARY KEY
--ALTER TABLE TBL_CIDADE
--ADD CONSTRAINT PK_CIDADE_ID PRIMARY KEY (CID_ID)
-----FOREIGN KEY
--ALTER TABLE TBL_CIDADE
--ADD CONSTRAINT FK_ESTADOUF_ID FOREIGN KEY (EST_CODUF) REFERENCES TBL_ESTADO 


CREATE TABLE TBL_ENDERECO (
  END_ID INT NOT NULL IDENTITY(1,1),
  --CID_ID INT,
  END_BAIRRO VARCHAR(50),
  END_RUA VARCHAR(50),
  END_NUMERO DECIMAL,
  END_CEP VARCHAR(8),
  END_COMP VARCHAR(100),
)
---PRIMARY KEY
ALTER TABLE TBL_ENDERECO
ADD CONSTRAINT PK_ENDERECO_ID PRIMARY KEY (END_ID)
-----FOREIGN KEY
--ALTER TABLE TBL_ENDERECO
--ADD CONSTRAINT FK_CIDADE_ID FOREIGN KEY (CID_ID) REFERENCES TBL_CIDADE 


CREATE TABLE TBL_FORNECEDOR (
  FOR_ID INT NOT NULL IDENTITY(1,1),
  TEL_ID INT,
  FOR_NOME VARCHAR(50),
  FOR_NOME_FANT VARCHAR(50),
  FOR_CNPJ VARCHAR(14),
  FOR_EMAIL VARCHAR(100),
  FOR_DESC VARCHAR(100)
)
---PRIMARY KEY
ALTER TABLE TBL_FORNECEDOR
ADD CONSTRAINT PK_FORNECEDOR_ID PRIMARY KEY (FOR_ID)
---FOREIGN KEY
ALTER TABLE TBL_FORNECEDOR
ADD CONSTRAINT FK_TEL_FORN_ID FOREIGN KEY (TEL_ID) REFERENCES TBL_TELEFONE


--REMOVENDO DUPLICIDADE---
CREATE TABLE TBL_PROD_FORN (
  FOR_ID INT,
  PROD_ID INT
)
---FOREIGN KEY
ALTER TABLE TBL_PROD_FORN
ADD CONSTRAINT FK_FOR_PROD_ID FOREIGN KEY (FOR_ID) REFERENCES TBL_FORNECEDOR
---FOREIGN KEY
ALTER TABLE TBL_PROD_FORN
ADD CONSTRAINT FK_PROD_FOR_ID FOREIGN KEY (PROD_ID) REFERENCES TBL_PRODUTO



--REMOVENDO DUPLICIDADE---
CREATE TABLE TBL_FOR_END (
  FOR_ID INT NOT NULL,
  END_ID INT NOT NULL
)
---FOREIGN KEY
ALTER TABLE TBL_FOR_END
ADD CONSTRAINT FK_FOR_END_ID FOREIGN KEY (FOR_ID) REFERENCES TBL_FORNECEDOR
---FOREIGN KEY
ALTER TABLE TBL_FOR_END
ADD CONSTRAINT FK_END_FOR_ID FOREIGN KEY (END_ID) REFERENCES TBL_ENDERECO


CREATE TABLE TBL_EMPRESA (
  EMP_ID INT NOT NULL IDENTITY(1,1),
  TEL_ID INT,
  EMP_NOME_FANT VARCHAR(60) NOT NULL,
  EMP_CNPJ VARCHAR(14),
  EMP_EMAIL VARCHAR(100),
  EMP_DESC VARCHAR(100),
)
---PRIMARY KEY
ALTER TABLE TBL_EMPRESA
ADD CONSTRAINT PK_EMPRESA_ID PRIMARY KEY (EMP_ID)
---FOREIGN KEY
ALTER TABLE TBL_EMPRESA
ADD CONSTRAINT FK_TEL_EMP_ID FOREIGN KEY (TEL_ID) REFERENCES TBL_TELEFONE


--REMOVENDO DUPLICIDADE---
CREATE TABLE TBL_EMP_END (
  EMP_ID INT NOT NULL,
  END_ID INT NOT NULL
)
---FOREIGN KEY
ALTER TABLE TBL_EMP_END
ADD CONSTRAINT FK_EMP_END_ID FOREIGN KEY (EMP_ID) REFERENCES TBL_EMPRESA
---FOREIGN KEY
ALTER TABLE TBL_EMP_END
ADD CONSTRAINT FK_END_EMP_ID FOREIGN KEY (END_ID) REFERENCES TBL_ENDERECO


CREATE TABLE TBL_NOTA_FISC (
  NOT_ID INT NOT NULL IDENTITY(1,1),
  EMP_ID INT,
  NOT_TOTAL DECIMAL(10,2),
  NOT_CPF_CLI VARCHAR(11)UNIQUE 
)

---PRIMARY KEY
ALTER TABLE TBL_NOTA_FISC
ADD CONSTRAINT PK_NOTAFISCAL_ID PRIMARY KEY (NOT_ID)
---FOREIGN KEY
ALTER TABLE TBL_NOTA_FISC
ADD CONSTRAINT FK_EMP_FISC_ID FOREIGN KEY (EMP_ID) REFERENCES TBL_EMPRESA


CREATE TABLE TBL_LOGIN (
  LOG_ID INT NOT NULL IDENTITY(1,1),
  LOG_LOGIN VARCHAR(15) NOT NULL,
  LOG_SENHA VARCHAR(15) NOT NULL,
  LOG_PAL_CHAVE VARCHAR(20)
)
---PRIMARY KEY
ALTER TABLE TBL_LOGIN
ADD CONSTRAINT PK_LOGIN_ID PRIMARY KEY (LOG_ID)


CREATE TABLE TBL_FUNCIONARIO (
  FUN_ID INT NOT NULL IDENTITY(1,1),
  TEL_ID INT,
  LOG_ID INT,
  END_ID INT,
  FUN_NOME VARCHAR(60) NOT NULL,
  FUN_NASC DATE,
  FUN_CPF VARCHAR(11) UNIQUE,
  FUN_RG VARCHAR(9) NOT NULL UNIQUE,
  FUN_SEXO CHAR(1) NOT NULL,
  FUN_CARGO INT NOT NULL
)
---PRIMARY KEY
ALTER TABLE TBL_FUNCIONARIO
ADD CONSTRAINT PK_FUNCIONARIO_ID PRIMARY KEY (FUN_ID)
---FOREIGN KEY
ALTER TABLE TBL_FUNCIONARIO
ADD CONSTRAINT FK_FUN_TEL_ID FOREIGN KEY (TEL_ID) REFERENCES TBL_TELEFONE
---FOREIGN KEY
ALTER TABLE TBL_FUNCIONARIO
ADD CONSTRAINT FK_FUN_LOG_ID FOREIGN KEY (LOG_ID) REFERENCES TBL_LOGIN
---FOREIGN KEY
ALTER TABLE TBL_FUNCIONARIO
ADD CONSTRAINT FK_FUN_END_ID FOREIGN KEY (END_ID) REFERENCES TBL_ENDERECO


CREATE TABLE TBL_CLIENTE(
CLI_ID INT NOT NULL IDENTITY(1,1),
TEL_ID INT,
CLI_NOME VARCHAR(50),
CLI_DIVIDA DECIMAL(10,2),


)
---PRIMARY KEY
ALTER TABLE TBL_CLIENTE
ADD CONSTRAINT PK_CLIENTE_ID PRIMARY KEY (CLI_ID)

---FOREIGN KEY
ALTER TABLE TBL_CLIENTE
ADD CONSTRAINT FK_TEL_CLI_ID FOREIGN KEY (TEL_ID) REFERENCES TBL_TELEFONE


CREATE TABLE TBL_VENDA (
  VEN_ID INT NOT NULL IDENTITY(1,1),
  CLI_ID INT,
 -- NOT_ID INT,
 --CAX_ID INT,
 --FUN_ID INT,
 -- PROD_ID INT,
  VEN_PAGAMENTO VARCHAR(15),
  VEN_PARCELA INT,
  VEN_BANDEIRA VARCHAR(30),
  VEN_QTD INT,
  VEN_TOTAL DECIMAL(10,2),
  VEN_DATE DATE
)
---PRIMARY KEY
ALTER TABLE TBL_VENDA
ADD CONSTRAINT PK_VENDA_ID PRIMARY KEY (VEN_ID)
---FOREIGN KEY
ALTER TABLE TBL_VENDA
ADD CONSTRAINT FK_VEN_CLI_ID FOREIGN KEY (CLI_ID) REFERENCES TBL_CLIENTE
---FOREIGN KEY
--ALTER TABLE TBL_VENDA
--ADD CONSTRAINT FK_VEN_NOT_ID FOREIGN KEY (NOT_ID) REFERENCES TBL_NOTA_FISC
-----FOREIGN KEY
--ALTER TABLE TBL_VENDA
--ADD CONSTRAINT FK_VEN_CAX_ID FOREIGN KEY (CAX_ID) REFERENCES TBL_CAIXA
-----FOREIGN KEY
--ALTER TABLE TBL_VENDA
--ADD CONSTRAINT FK_VEN_FUN_ID FOREIGN KEY (FUN_ID) REFERENCES TBL_FUNCIONARIO
-----FOREIGN KEY
--ALTER TABLE TBL_VENDA
--ADD CONSTRAINT FK_VEN_PROD_ID FOREIGN KEY (PROD_ID) REFERENCES TBL_PRODUTO



--REMOVENDO DUPLICIDADE---
CREATE TABLE TBL_CLI_END (
  CLI_ID INT NOT NULL,
  END_ID INT NOT NULL
)
---FOREIGN KEY
ALTER TABLE TBL_CLI_END
ADD CONSTRAINT FK_CLI_END_ID FOREIGN KEY (CLI_ID) REFERENCES TBL_CLIENTE
---FOREIGN KEY
ALTER TABLE TBL_CLI_END
ADD CONSTRAINT FK_END_CLI_ID FOREIGN KEY (END_ID) REFERENCES TBL_ENDERECO


CREATE TABLE TBL_ITEM_VENDA(
PROD_ID INT,
VEN_ID INT,
ITEM_VALOR DECIMAL(10,2),
ITEM_QTD INT
)
---FOREIGN KEY
ALTER TABLE TBL_ITEM_VENDA
ADD CONSTRAINT FK_PROD_ITEM_ID FOREIGN KEY (PROD_ID) REFERENCES TBL_PRODUTO
---FOREIGN KEY
ALTER TABLE TBL_ITEM_VENDA
ADD CONSTRAINT FK_VEN_ITEM_ID FOREIGN KEY (VEN_ID) REFERENCES TBL_VENDA


CREATE TABLE TBL_FECHAMENTO(
FECH_ID INT IDENTITY(1,1) NOT NULL,
FECH_DEBITO DECIMAL(10,2),
FECH_CREDITO DECIMAL(10,2),
FECH_DINHEIRO DECIMAL(10,2),
FECH_CREDIARIO DECIMAL(10,2),
FECH_TOTAL DECIMAL(10,2),
FECH_HORA TIME,
FECH_DATA DATE
)

---FOREIGN KEY
ALTER TABLE TBL_FECHAMENTO
ADD CONSTRAINT FK_FECHAMENTO_ID PRIMARY KEY (FECH_ID)

