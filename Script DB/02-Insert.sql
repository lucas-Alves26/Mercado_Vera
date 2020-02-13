
USE MERCADO_01
--TELEFONE
INSERT INTO TBL_TELEFONE(TEL_DDD,TEL_FIXO,TEL_CELULAR,TEL_OPERADORA)VALUES(011,84597284,974556230,'CLARO') 
INSERT INTO TBL_TELEFONE(TEL_DDD,TEL_FIXO,TEL_CELULAR,TEL_OPERADORA)VALUES(011,33397284,964556232,'TIM')
INSERT INTO TBL_TELEFONE(TEL_DDD,TEL_FIXO,TEL_CELULAR,TEL_OPERADORA)VALUES(011,83397287,944556231,'CLARO')
INSERT INTO TBL_TELEFONE(TEL_DDD,TEL_FIXO,TEL_CELULAR,TEL_OPERADORA)VALUES(011,83397288,944556232,'NEXTEL')
--SUB_CATEGORIA
INSERT INTO TBL_SUB_CATEGORIA(SUB_CAT_TIPO) VALUES('INFORM�TICA')
INSERT INTO TBL_SUB_CATEGORIA(SUB_CAT_TIPO) VALUES('MATERIAL ESCOLAR')
INSERT INTO TBL_SUB_CATEGORIA(SUB_CAT_TIPO) VALUES('REM�DIO')
INSERT INTO TBL_SUB_CATEGORIA(SUB_CAT_TIPO) VALUES('BJUTERIA')
INSERT INTO TBL_SUB_CATEGORIA(SUB_CAT_TIPO) VALUES('C�SMETICO')
INSERT INTO TBL_SUB_CATEGORIA(SUB_CAT_TIPO) VALUES('BRINQUEDOS')
INSERT INTO TBL_SUB_CATEGORIA(SUB_CAT_TIPO) VALUES('PAPEL�RIA')
INSERT INTO TBL_SUB_CATEGORIA(SUB_CAT_TIPO) VALUES('HIGIENE')
SELECT * FROM TBL_SUB_CATEGORIA

--PRODUTO
INSERT INTO TBL_PRODUTO(PROD_COD,PROD_NOME,PROD_MARCA,PROD_QTD,PROD_QTD_MIN,PROD_VALOR,PROD_VALOR_VENDA,SUB_CAT_ID)
VALUES ('000123214033','ESTOJO BATMAN','FABER CASTEL',5,2,8.60,15.00,2)

INSERT INTO TBL_PRODUTO(PROD_COD,PROD_NOME,PROD_MARCA,PROD_QTD,PROD_QTD_MIN,PROD_VALOR,PROD_VALOR_VENDA,SUB_CAT_ID)
VALUES ('800123214030','TECLADO','BRIGHT',2,1,15.00,20.00,1)

INSERT INTO TBL_PRODUTO(PROD_COD,PROD_NOME,PROD_MARCA,PROD_QTD,PROD_QTD_MIN,PROD_VALOR,PROD_VALOR_VENDA,SUB_CAT_ID)
VALUES ('100123214999','PERFUME ESSENCIAL','NATURA',2,1,50.60,80.00,5)

SELECT * FROM TBL_PRODUTO
--FORNECEDOR


INSERT INTO TBL_FORNECEDOR(FOR_NOME,FOR_CNPJ,FOR_NOME_FANT,FOR_EMAIL,FOR_DESC)
VALUES(NULL,NULL,NULL,NULL,NULL)

INSERT INTO TBL_FORNECEDOR(TEL_ID,FOR_NOME,FOR_CNPJ,FOR_NOME_FANT,FOR_EMAIL,FOR_DESC)
VALUES(1,'MATIAS CAMPOS','22365984523622','EXTRA','EXTRA@hotmail.com','Mercado')

INSERT INTO TBL_FORNECEDOR(TEL_ID,FOR_NOME,FOR_CNPJ,FOR_NOME_FANT,FOR_EMAIL,FOR_DESC)
VALUES(2,'MARIO SUZANO','32365984523333','IMPORTADOS LTDA','importltda@hotmail.com','Loja de importados')

INSERT INTO TBL_FORNECEDOR(TEL_ID,FOR_NOME,FOR_CNPJ,FOR_NOME_FANT,FOR_EMAIL,FOR_DESC)
VALUES(3,'LUIZA MARTINS SILVA','12365984523657','NATURA','natura@hotmail.com','Loja de c�smeticos')

SELECT * FROM TBL_FORNECEDOR

INSERT INTO TBL_PROD_FORN(PROD_ID, FOR_ID)VALUES(1,1)
INSERT INTO TBL_PROD_FORN(PROD_ID, FOR_ID)VALUES(2,2)
INSERT INTO TBL_PROD_FORN(PROD_ID, FOR_ID)VALUES(3,3)
SELECT * FROM TBL_PROD_FORN

INSERT INTO TBL_ENDERECO(END_BAIRRO,END_RUA,END_NUMERO,END_CEP) VALUES (NULL,NULL,NULL,NULL)
INSERT INTO TBL_ENDERECO(END_BAIRRO,END_RUA,END_NUMERO,END_CEP) VALUES ('Santana','Marechal Os�rio',14,05037030)
INSERT INTO TBL_ENDERECO(END_BAIRRO,END_RUA,END_NUMERO,END_CEP) VALUES ('Lapa','Cl�ria',1001,35037050)
INSERT INTO TBL_ENDERECO(END_BAIRRO,END_RUA,END_NUMERO,END_CEP) VALUES (' JD CLARA','Maria',200,35037060)
SELECT * FROM TBL_ENDERECO

INSERT INTO TBL_FOR_END (FOR_ID,END_ID) VALUES (2,1)
INSERT INTO TBL_FOR_END (FOR_ID,END_ID) VALUES (3,2)
INSERT INTO TBL_FOR_END (FOR_ID,END_ID) VALUES (4,1)
SELECT * FROM TBL_FOR_END


INSERT INTO TBL_CLIENTE(CLI_NOME,TEL_ID,END_ID) VALUES ('JEAN',4,4)
SELECT * FROM TBL_CLIENTE