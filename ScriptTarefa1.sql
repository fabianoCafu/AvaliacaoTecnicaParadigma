
-- Criar tabela Departamento
CREATE TABLE Departamento (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(150) NOT NULL
);

-- Criar tabela Pessoa
CREATE TABLE Pessoa (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Nome VARCHAR(256) NOT NULL,
	Salario DECIMAL(18,2) NOT NULL,
	DeptId INT NOT NULL,
	
	CONSTRAINT FK_Pessoa_Departamento FOREIGN KEY (DeptId) REFERENCES Departamento(Id)
);

  SELECT 
       dep.NOME AS Departamento,
       pes.NOME AS Pessoa,
       pes.SALARIO AS Salario 
  FROM Pessoa pes
      JOIN Departamento dep ON dep.Id = pes.DeptId
  WHERE pes.Salario = (SELECT 
                            MAX(sap.Salario)
                       FROM Pessoa sap
					       WHERE sap.DeptId = pes.DeptId);