USE MERCADO_01

SELECT * FROM TBL_PRODUTO
SELECT * FROM TBL_VENDA
SELECT * FROM TBL_PROD_FORN
SELECT * FROM TBL_SUB_CATEGORIA
<<<<<<< HEAD
SELECT * FROM TBL_LOGIN
=======
SELECT * FROM TBL_FOTO
SELECT * FROM TBL_FORNECEDOR
SELECT * FROM TBL_ENDERECO
SELECT * FROM TBL_TELEFONE
SELECT * FROM TBL_FOR_END
SELECT * FROM TBL_CLIENTE ORDER BY CLI_NOME ASC

UPDATE TBL_PRODUTO SET PROD_QTD = 5 WHERE PROD_ID = 1



SELECT P.PROD_ID, P.PROD_COD,P.PROD_NOME,P.PROD_VALOR, P.PROD_VALOR_VENDA, P.PROD_QTD, P.PROD_QTD_MIN, P.PROD_MARCA,F.FOR_NOME_FANT, S.SUB_CAT_TIPO, S.SUB_CAT_ID, F.FOR_ID, P.FOTO FROM  TBL_PRODUTO AS P  INNER JOIN TBL_PROD_FORN AS PF ON PF.PROD_ID = P.PROD_ID INNER JOIN TBL_SUB_CATEGORIA AS S ON S.SUB_CAT_ID = P.SUB_CAT_ID INNER JOIN TBL_FORNECEDOR AS F ON F.FOR_ID = PF.FOR_ID WHERE P.PROD_ID =4
INSERT INTO TBL_VENDA (CLI_ID, PROD_ID,VEN_QTD,VEN_TOTAL,VEN_DATE) VALUES (@CLI_ID,@PROD_ID,@QTD,@TOTAL,@DATA)