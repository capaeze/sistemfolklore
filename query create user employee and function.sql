
USE FOLKLORE

SELECT * FROM USUARIO

SELECT * FROM PERMISO



SELECT * FROM ROL

/*
INSERT INTO ROL(Descripcion)
VALUES ('Empleado')

INSERT INTO USUARIO(Documento,NombreCompleto,Correo,Clave,Estado,ID_rol)  /* creamos credenciales a un empleado */
VALUES ('48112737','Empleado','gmail.com','2020',1,2)

*/

SELECT p.ID_rol, p.NombreMenu FROM PERMISO p
INNER JOIN ROL r ON r.ID_rol = p.ID_rol
INNER JOIN USUARIO u ON u.ID_rol = r.ID_rol
WHERE u.ID_usuario = 1

/*COMANDO JOIN REBOTA LOS PERMISOS DEL USUARIO 1*/


INSERT INTO PERMISO (ID_rol,NombreMenu)
VALUES (1,'menuusuarios'),
       (1,'menuventas'),
	   (1,'menuclientes'),
	   (1,'menureportes'),
	   (1,'menuprogramacion'),
	   (1,'menumantenedor')

	   INSERT INTO PERMISO (ID_rol,NombreMenu)
VALUES 
       (2,'menuventas'),
	   (2,'menuclientes'),
	   (2,'menuprogramacion'),
	   (2,'menumantenedor')

	   


	   SELECT ID_rol,NombreMenu FROM PERMISO

	   SELECT u.ID_usuario,u.Documento,u.NombreCompleto,u.Correo,u.Clave,u.Estado,r.ID_rol,r.Descripcion FROM USUARIO u
	   INNER JOIN ROL r ON r.ID_rol= u.ID_rol

	   UPDATE USUARIO SET Estado = 0 WHERE ID_usuario = 2