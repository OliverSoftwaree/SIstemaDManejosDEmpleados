Create database EmpleadosDB;
Go
use EmpleadosDB;
Go

CREATE TABLE Departamento (
    DepartamentoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL
);

CREATE TABLE Cargo (
    CargoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL
);

CREATE TABLE Empleado (
    EmpleadoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    DepartamentoID INT NOT NULL,
    CargoID INT NOT NULL,
    FechaInicio DATE NOT NULL,
    Salario DECIMAL(18,2) NOT NULL,
    Estado NVARCHAR(20) NOT NULL,
    FOREIGN KEY (DepartamentoID) REFERENCES Departamento(DepartamentoID),
    FOREIGN KEY (CargoID) REFERENCES Cargo(CargoID)
);