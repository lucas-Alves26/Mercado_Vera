USE MERCADO_01

SELECT * FROM TBL_PRODUTO
SELECT * FROM TBL_CATEGORIA
SELECT * FROM TBL_SUB_CATEGORIA
SELECT * FROM TBL_PROD

INSERT INTO TBL_SUB_CATEGORIA(SUB_CAT_TIPO)VALUES ('MATERIAL ESCOLAR')

INSERT INTO TBL_PRODUTO(PROD_COD,PROD_NOME,PROD_MARCA,PROD_QTD,PROD_QTD_MIN,PROD_VALOR,PROD_VALOR_VENDA,SUB_CAT_ID)
VALUES ('000123214060','ESTOJO BATMAN',null,5,NULL,8.60,15.00,1)

SELECT SUB_CAT_ID, SUB_CAT_TIPO FROM TBL_SUB_CATEGORIA 

DELETE TBL_PRODUTO WHERE PROD_ID = 4
SELECT * FROM TBL_PRODUTO

SELECT COUNT(*) as numero FROM TBL_PRODUTO WHERE PROD_COD = '00012321403' OR PROD_NOME = 'ESTOJO BATMAN'


SELECT PROD_MARCA FROM TBL_PRODUTO