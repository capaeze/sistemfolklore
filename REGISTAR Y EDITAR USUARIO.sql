USE FOLKLORE

SELECT * FROM USUARIO


CREATE PROC SP_REGISTRARUSUARIO(

@Documento VARCHAR(50),
@NombreCompleto VARCHAR(100),
@Correo VARCHAR(100),
@Clave VARCHAR(100),
@Estado BIT,
@ID_rol int,
@IDusuarioResultado int output,
@Mensaje VARCHAR(500) output

)

AS
BEGIN

SET @IDusuarioResultado = 0
SET @Mensaje = ' '

IF NOT EXISTS(SELECT * FROM USUARIO WHERE Documento = @Documento)
BEGIN

INSERT INTO USUARIO(Documento,NombreCompleto,Correo,Clave,Estado,ID_rol)
VALUES (@Documento,@NombreCompleto,@Correo,@Clave,@Estado,@ID_rol)

SET @IDusuarioResultado = SCOPE_IDENTITY()


END

ELSE 

SET @Mensaje = 'No se puede repetir el documento para mas de un usuario '


END


GO

CREATE PROC SP_EDITARUSUARIO(

@ID_usuario int,
@Documento VARCHAR(50),
@NombreCompleto VARCHAR(100),
@Correo VARCHAR(100),
@Clave VARCHAR(100),
@Estado BIT,
@ID_rol int,
@Respuesta BIT output,
@Mensaje VARCHAR(500) output

)

AS
BEGIN

SET @Respuesta = 0
SET @Mensaje = ' '

IF NOT EXISTS(SELECT * FROM USUARIO WHERE Documento = @Documento AND ID_usuario != @ID_usuario)
BEGIN

UPDATE USUARIO SET
Documento = @Documento,
NombreCompleto = @NombreCompleto,
Correo = @Correo,
Clave = @Clave ,
Estado = @Estado ,
ID_rol = @ID_rol

WHERE ID_usuario = @ID_usuario


SET @Respuesta = 1


END

GO





CREATE PROC SP_ELIMINARUSUARIO(

@ID_usuario int,
@Respuesta BIT output,
@Mensaje VARCHAR(500) output

)

AS
BEGIN

SET @Respuesta = 0
SET @Mensaje = ' '
DECLARE @Pasoregla BIT=1


IF EXISTS(SELECT * FROM VENTA V
INNER JOIN USUARIO U ON U.ID_usuario = V.ID_usuario
WHERE U.ID_usuario = @ID_usuario

)
BEGIN

SET @Pasoregla = 0
SET @Respuesta = 0
SET @Mensaje = @Mensaje + 'No se puede eliminar porque El usuario se encuentra relacionado a una VENTA\n'

END

IF(@Pasoregla = 1)

BEGIN

DELETE FROM USUARIO WHERE ID_usuario= @ID_usuario
SET @Respuesta = 1

END

END





IF NOT EXISTS(SELECT * FROM USUARIO WHERE Documento = @Documento AND ID_usuario != @ID_usuario)
BEGIN

UPDATE USUARIO SET
Documento = @Documento,
NombreCompleto = @NombreCompleto,
Correo = @Correo,
Clave = @Clave ,
Estado = @Estado ,
ID_rol = @ID_rol

WHERE ID_usuario = @ID_usuario


SET @Respuesta = 1


END


ELSE 

SET @Mensaje = 'No se puede repetir el documento para mas de un usuario '


END












DECLARE @Respuesta BIT
DECLARE @Mensaje VARCHAR(500)


EXEC  SP_EDITARUSUARIO 2, '123','Prueba 2','test@gmail.com','456',1,2,@Respuesta OUTPUT,@Mensaje OUTPUT

SELECT @Respuesta

SELECT @Mensaje

SELECT * FROM USUARIO 

















