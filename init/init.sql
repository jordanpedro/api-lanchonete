USE [master];
GO

IF NOT EXISTS (SELECT * FROM sys.sql_logins WHERE name = 'rmjordan')
BEGIN
    CREATE LOGIN rmjordan WITH PASSWORD = 'fiap@2025', CHECK_POLICY = OFF;
    ALTER SERVER ROLE [sysadmin] ADD MEMBER rmjordan;
    CREATE USER [rmjordan] FOR LOGIN [rmjordan];
END
GO
IF DB_ID('Lanchonete') IS NULL
BEGIN
CREATE DATABASE Lanchonete;
END
--ELSE
--BEGIN 
--drop database Lanchonete
--CREATE DATABASE Lanchonete;
--END

GO
USE Lanchonete

GO
IF NOT EXISTS (SELECT * FROM sys.sql_logins WHERE name = 'rmjordan')
BEGIN
    CREATE LOGIN rmjordan WITH PASSWORD = 'fiap@2025', CHECK_POLICY = OFF;
    ALTER SERVER ROLE [sysadmin] ADD MEMBER rmjordan;
    CREATE USER [rmjordan] FOR LOGIN [rmjordan];
END

GO

IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cliente]') AND type in (N'U'))
BEGIN
create table Cliente(
Id  BIGINT IDENTITY(1,1) Primary key,
Nome varchar(100)  NULL,
Cpf varchar(100) NOT NULL,
Email varchar(100) NULL,
DataCriacao DATETIME2(3) NOT NULL DEFAULT GETDATE())

END
 
GO

IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categoria]') AND type in (N'U'))
BEGIN
create table Categoria(
Id  BIGINT IDENTITY(1,1) Primary key,
Nome varchar(100)  NULL,
DataCriacao DATETIME2(3) NOT NULL  DEFAULT GETDATE())

END
GO

IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Produto]') AND type in (N'U'))
BEGIN
create table Produto(
Id  BIGINT IDENTITY(1,1) Primary key,
Nome varchar(100)  NULL,
IdCategoria   BIGINT NOT NULL,
DataCriacao DATETIME2(3) NOT NULL  DEFAULT GETDATE(),
Preco Decimal(12,2) NOT NULL,
ImagemUrl varchar(1000),
FOREIGN KEY (IdCategoria) REFERENCES Categoria(Id)
)

END
GO
IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pedido]') AND type in (N'U'))
BEGIN
create table Pedido(
Id  BIGINT IDENTITY(1,1) Primary key,
IdCliente  BIGINT ,
DataCriacao DATETIME2(3) NOT NULL  DEFAULT GETDATE(),
ValorTotal Decimal(12,2) NOT NULL,
Status varchar(20)  NULL,
FOREIGN KEY (IdCliente) REFERENCES Cliente(Id)
)

END

IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItensPedido]') AND type in (N'U'))
BEGIN
create table ItensPedido(
Id  BIGINT IDENTITY(1,1) Primary key,
IdPedido  BIGINT ,
IdProduto BIGINT,
Quantidade INT NULL ,
DataCriacao DATETIME2(3) NOT NULL DEFAULT GETDATE()
FOREIGN KEY (IdPedido) REFERENCES Pedido(Id),
FOREIGN KEY (IdProduto) REFERENCES Produto(Id),
)

END



--inserts

SET IDENTITY_INSERT [Categoria] ON

IF  NOT EXISTS (SELECT 1 FROM Categoria where Id = 1)
BEGIN
INSERT INTO Categoria (Id, Nome) Values(1, 'Lanche')  
END

IF  NOT EXISTS (SELECT 1 FROM Categoria where Id = 2)
BEGIN
INSERT INTO Categoria (Id, Nome) Values(2, 'Acompanhamento')  
END

IF  NOT EXISTS (SELECT 1 FROM Categoria where Id = 3)
BEGIN
INSERT INTO Categoria (Id, Nome) Values(3, 'Bebida')  
END

IF  NOT EXISTS (SELECT 1 FROM Categoria where Id = 4)
BEGIN
INSERT INTO Categoria (Id, Nome) Values(4, 'Sobremesa')  
END

SET IDENTITY_INSERT [Categoria] OFF

--
IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FormaPagamento]') AND type in (N'U'))
BEGIN
create table FormaPagamento(
Id BIGINT IDENTITY(1,1) Primary key,
Nome varchar(100)  NULL ,
DataCriacao DATETIME2(3) NOT NULL  DEFAULT GETDATE(),
)

END
--

IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PedidoFormaPagamento]') AND type in (N'U'))
BEGIN
create table PedidoFormaPagamento(
Id BIGINT IDENTITY(1,1) Primary key,
IdPedido  BIGINT ,
IdFormaPagamento  BIGINT ,
DataCriacao DATETIME2(3) NOT NULL  DEFAULT GETDATE(),
Status varchar(20)  NULL,
FOREIGN KEY (IdPedido) REFERENCES Pedido(Id),
FOREIGN KEY (IdFormaPagamento) REFERENCES FormaPagamento(Id)
)

END
--
--inserts

SET IDENTITY_INSERT [FormaPagamento] ON

IF  NOT EXISTS (SELECT 1 FROM FormaPagamento where Id = 1)
BEGIN
INSERT INTO FormaPagamento (Id, Nome) Values(1,'Pix')  
END

IF  NOT EXISTS (SELECT 1 FROM FormaPagamento where Id = 2)
BEGIN
INSERT INTO FormaPagamento (Id, Nome) Values(2, 'Cartao de credito (mastercard)')  
END

IF  NOT EXISTS (SELECT 1 FROM FormaPagamento where Id = 3)
BEGIN
INSERT INTO FormaPagamento (Id, Nome) Values(3, 'Debito')  
END

IF  NOT EXISTS (SELECT 1 FROM FormaPagamento where Id = 4)
BEGIN
INSERT INTO FormaPagamento (Id, Nome) Values(4, 'Cartao de credito (visa)')  
END

SET IDENTITY_INSERT [FormaPagamento] OFF
--
