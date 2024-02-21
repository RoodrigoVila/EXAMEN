CREATE DATABASE LibreriaLosLectores;

USE LibreriaLosLectores;

CREATE TABLE Clientes (
    ID INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    Genero NVARCHAR(50)
);

CREATE TABLE Libros (
    ID INT PRIMARY KEY IDENTITY,
    Titulo NVARCHAR(100),
    Tipo INT,
    Precio DECIMAL(5, 2)
);

CREATE TABLE Ventas (
    ID INT PRIMARY KEY IDENTITY,
    ClienteID INT FOREIGN KEY REFERENCES Clientes(ID),
    LibroID INT FOREIGN KEY REFERENCES Libros(ID),
    Cantidad INT,
    ImporteBruto DECIMAL(5, 2),
    Descuento DECIMAL(5, 2),
    ImporteNeto AS (ImporteBruto - Descuento)
);

CREATE TABLE Descuentos (
    CantidadMinima INT,
    CantidadMaxima INT,
    TipoLibro INT,
    PorcentajeDescuento DECIMAL(5, 2)
);
