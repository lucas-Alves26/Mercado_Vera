USE MERCADO_01

SELECT * FROM TBL_PRODUTO
SELECT * FROM TBL_PROD_FORN
SELECT * FROM TBL_SUB_CATEGORIA
SELECT * FROM TBL_FOTO
SELECT * FROM TBL_FORNECEDOR
SELECT * FROM TBL_ENDERECO
SELECT * FROM TBL_TELEFONE
SELECT * FROM TBL_FOR_END

UPDATE TBL_FORNECEDOR SET TEL_ID = '' WHERE FOR_ID =



SELECT F.FOR_NOME_FANT,F.FOR_CNPJ, T.TEL_CELULAR, T.TEL_FIXO, E.END_RUA,E.END_NUMERO FROM TBL_FORNECEDOR AS F
INNER JOIN TBL_TELEFONE  AS  T ON T.TEL_ID = F.TEL_ID
INNER JOIN TBL_FOR_END AS FE ON FE.FOR_ID = F.FOR_ID
INNER JOIN TBL_ENDERECO AS E ON E.END_ID= FE.END_ID order by F.FOR_NOME_FANT desc





SELECT COUNT(*) AS NUMERO FROM TBL_FORNECEDOR WHERE FOR_NOME_FANT = '' OR FOR_CNPJ = '22365984523622'

INSERT INTO TBL_FORNECEDOR(FOR_CNPJ,FOR_NOME_FANT) VALUES(NULL,NULL)

INSERT INTO TBL_TELEFONE(TEL_DDD,TEL_FIXO,TEL_CELULAR,TEL_OPERADORA)VALUES(011,83397287,944556231,'CLARO')






SELECT MAX(TEL_ID) AS ID FROM TBL_TELEFONE






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

SELECT P.PROD_ID, S.SUB_CAT_ID, F.FOR_ID FROM  TBL_PRODUTO AS P  
INNER JOIN TBL_PROD_FORN AS PF ON PF.PROD_ID = P.PROD_ID 
INNER JOIN TBL_SUB_CATEGORIA AS S ON S.SUB_CAT_ID = P.SUB_CAT_ID 
INNER JOIN TBL_FORNECEDOR AS F ON F.FOR_ID = PF.FOR_ID 
WHERE P.PROD_ID =4
INNER JOIN TBL_FOTO AS FT ON FT.FOT_ID = P.FOT_ID


UPDATE TBL_PRODUTO SET PROD_COD='', PROD_NOME = '',PROD_VALOR = '', PROD_VALOR_VENDA = '',PROD_QTD = '',PROD_QTD_MIN='',PROD_MARCA ='' WHERE PROD_ID =;

UPDATE TBL_PROD_FORN SET FOR_ID = 2 WHERE  PROD_ID= 1


