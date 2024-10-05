/*
    Comando docker para subir o container do SQL Server
*/
docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=MyPassword123#" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sql mcr.microsoft.com/azure-sql-edge

/*
    Comandos para criar o banco de dados e as tabelas
*/
/

create database LeanWork;

/

use LeanWork;

/

CREATE TABLE Carrinhos (
    CarrinhoId INT PRIMARY KEY IDENTITY(1,1),
	TotalItens INT NOT NULL,
	ValorTotal DECIMAL(10, 2) NOT NULL
);

/

CREATE TABLE Carrinho_Itens (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CarrinhoId INT NOT NULL,
    Produto VARCHAR(200) NOT NULL,
    Quantidade INT NOT NULL,
    PrecoUnitario DECIMAL(10, 2) NOT NULL,
    PrecoTotal DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (CarrinhoId) REFERENCES Carrinhos(CarrinhoId),
);

/

INSERT INTO LeanWork.dbo.Carrinhos 
(TotalItens, ValorTotal)
VAlLUES(0,0)