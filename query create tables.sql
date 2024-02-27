CREATE TABLE ROL(

ID_rol int PRIMARY KEY IDENTITY,
Descripcion VARCHAR(50),
FechaRegistro DATETIME DEFAULT GETDATE()


)

GO

CREATE TABLE PERMISO(

ID_permiso int PRIMARY KEY IDENTITY,
ID_rol int REFERENCES ROL(ID_rol),
NombreMenu VARCHAR(100),
FechaRegistro DATETIME DEFAULT GETDATE()

)
GO


CREATE TABLE GRUPO_MUSICAL(

ID_grupo int PRIMARY KEY IDENTITY,
Nombre VARCHAR(50),
Descrpcion TEXT,
FechaRegistro DATETIME DEFAULT GETDATE()

)

GO


CREATE TABLE CLIENTE(

ID_cliente int PRIMARY KEY IDENTITY,
Documento VARCHAR(50),
NombreCompleto VARCHAR(50),
Correo VARCHAR(50),
Telefono VARCHAR(50),
FechaRegistro DATETIME DEFAULT GETDATE()

)

GO

CREATE TABLE USUARIO(

ID_usuario int PRIMARY KEY IDENTITY,
Documento VARCHAR(50),
NombreCompleto VARCHAR(50),
Correo VARCHAR(50),
Contraseña VARCHAR(50),
Estado BIT,
ID_rol int REFERENCES ROL(ID_rol),
FechaRegistro DATETIME DEFAULT GETDATE()

)

GO

CREATE TABLE NOCHE_FESTIVAL(

ID_noche int PRIMARY KEY IDENTITY,
Hora_inicio TIME,
Hora_fin TIME,
FechaRegistro DATETIME DEFAULT GETDATE()

)

GO

CREATE TABLE SECTOR_ESTADIO(

ID_sector int PRIMARY KEY IDENTITY,
Nombre VARCHAR(50),
FechaRegistro DATETIME DEFAULT GETDATE()
)

GO

CREATE TABLE BUTACA(

ID_butaca int PRIMARY KEY IDENTITY,
NroButaca int,
ID_sector int REFERENCES SECTOR_ESTADIO(ID_sector),
Fila int,
Estado Bit,
FechaRegistro DATETIME DEFAULT GETDATE()

)

GO

CREATE TABLE CATEGORIA(

ID_categoria int PRIMARY KEY IDENTITY,
Descripcion VARCHAR(50),
FechaRegistro DATETIME DEFAULT GETDATE()
)

GO

CREATE TABLE ENTRADA(

ID_entrada int PRIMARY KEY IDENTITY,
Codigo VARCHAR(50),
ID_categoria int REFERENCES CATEGORIA(ID_categoria),
Precio_venta DECIMAL (10,2) DEFAULT 0,
FechaRegistro DATETIME DEFAULT GETDATE()

)

GO

CREATE TABLE VENTA(

ID_venta int PRIMARY KEY IDENTITY,
ID_usuario int REFERENCES USUARIO(ID_usuario),
TipoDocumento VARCHAR(50),
NumeroDocumento VARCHAR(50),
DocumentoCliente VARCHAR(50),
NombreCliente VARCHAR(50),
MontoPago DECIMAL (10,2),
MontoCambio DECIMAL (10,2),
MontoTotal DECIMAL (10,2),
FechaRegistro DATETIME DEFAULT GETDATE()


)

GO

CREATE TABLE DETALLE_VENTA(

ID_detalleventa int PRIMARY KEY IDENTITY,
ID_venta int REFERENCES VENTA(ID_venta),
ID_entrada int REFERENCES ENTRADA(ID_entrada),
PrecioVenta DECIMAL (10,2),
Cantidad int,
SubTotal DECIMAL (10,2),
FechaRegistro DATETIME DEFAULT GETDATE()



)

GO

CREATE TABLE PROGRAMACION(

ID_programacion int PRIMARY KEY IDENTITY,
ID_grupo int REFERENCES GRUPO_MUSICAL(ID_grupo),
ID_noche int REFERENCES NOCHE_FESTIVAL(ID_noche),
Hora_presentacion TIME,

)