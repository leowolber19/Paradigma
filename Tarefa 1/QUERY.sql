
/* CRIANDO O BANCO DE DADOS */
CREATE DATABASE Paradigma;

/* SELECIONAR O BANCO DE DADOS */
USE Paradigma;

/* CRIANDO A TABELA DEPARTAMENTO */
CREATE TABLE Departamento (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(80) NOT NULL
);

/* CRIANDO A TABELA PESSOA */
CREATE TABLE Pessoa (
    Id	INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(80) NOT NULL,
    Salario DECIMAL(10,2) NOT NULL,
    DepartamentoId INT NOT NULL,
    CONSTRAINT FK_Pessoa_Departamento FOREIGN KEY (DepartamentoId) REFERENCES Departamento(Id)
);

/* INSERINDO OS DADOS NA TABELA DEPARTAMENTO */
INSERT INTO Departamento (Nome) VALUES
('TI'),
('Vendas');

/* VERIFICANDO A INCLUSAO DOS DADOS */
SELECT * FROM Departamento;

/* INSERINDO OS DADOS NA TABELA PESSOA */
INSERT INTO Pessoa (Nome, Salario, DepartamentoId) VALUES
('Joe', 70000, 1),
('Henry', 80000, 2),
('Sam', 60000, 2),
('Max', 90000, 1);

/* VERIFICANDO A INCLUSAO DOS DADOS */
SELECT * FROM Pessoa;


/* CRIACAO DA QUERY PARA RETORNAR A PESSOA COM O MAIOR SALARIO DE CADA DEPARTAMENTO */
SELECT 
	DP.Nome						AS Departamento,
	PS_MAIOR_SALARIO.Nome		AS Pessoa,
	PS_MAIOR_SALARIO.Salario	AS Salario
FROM Departamento DP
	OUTER APPLY (
		SELECT TOP 1 
			PS.Nome,
			PS.Salario
		FROM Pessoa PS
			WHERE PS.DepartamentoId = DP.Id
		ORDER BY PS.Salario DESC
	) PS_MAIOR_SALARIO;

/* 
	Utilizei o OUTER APPLY para retornar apenas um registro da tabela Pessoa, filtrando pelo departamento. 
	Alem disso, a busca ordena os salarios em ordem decrescente, trazendo o maior valor.
*/
