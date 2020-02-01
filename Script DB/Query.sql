USE MERCADO_01

SELECT * FROM TBL_PRODUTO
SELECT * FROM TBL_PROD_FORN
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

SELECT DISTINCT PROD_MARCA FROM TBL_PRODUTO WHERE PROD_MARCA IS NOT NULL ORDER BY PROD_MARCA ASC

INSERT INTO TBL_PROD_FORN(PROD_ID, FOR_ID)VALUES('6',NULL)



SELECT P.PROD_ID, PF.PROD_ID FROM TBL_PRODUTO  AS P
INNER JOIN TBL_PROD_FORN AS PF ON P.PROD_ID = PF.PROD_ID WHERE P.PROD_ID = 

DELETE TBL_PROD_FORN WHERE PROD_ID = 1
DELETE TBL_PRODUTO WHERE PROD_ID = 1

SELECT P.PROD_ID, P.PROD_COD,P.PROD_NOME,P.PROD_VALOR, P.PROD_VALOR_VENDA, P.PROD_QTD, P.PROD_QTD_MIN, P.PROD_MARCA,F.FOR_NOME_FANT, S.SUB_CAT_TIPO FROM  TBL_PRODUTO AS P
INNER JOIN TBL_PROD_FORN AS PF ON PF.PROD_ID = P.PROD_ID
INNER JOIN TBL_SUB_CATEGORIA AS S ON S.SUB_CAT_ID = P.SUB_CAT_ID
INNER JOIN TBL_FORNECEDOR AS F ON F.FOR_ID = PF.FOR_ID WHERE P.PROD_ID = 1