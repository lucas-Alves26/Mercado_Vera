
USE MERCADO_01
--TELEFONE
INSERT INTO TBL_TELEFONE(TEL_DDD,TEL_FIXO,TEL_CELULAR,TEL_OPERADORA)VALUES(011,84597284,984556232,'CLARO') 
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
INSERT INTO TBL_FORNECEDOR(FOR_NOME,FOR_CNPJ,FOR_NOME_FANT,FOR_EMAIL,FOR_DESC,TEL_ID)
VALUES('LUIZA MARTINS SILVA','12365984523657','NATURA','natura@hotmail.com','Loja de c�smeticos',1)
SELECT * FROM TBL_FORNECEDOR
