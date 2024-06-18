-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diego Ramirez
-- Create date: 2024-05-14
-- Description:	Postulaciones de persona
-- =============================================
alter PROCEDURE Oferta_PersonaPostulaciones
	@idUsuario int,
	@idOcupacion int,
	@fechaInicia Smalldatetime,
	@fechaFinaliza Smalldatetime
	AS
BEGIN
	
SELECT 		 
		oo.idoferta,
		oo.tituloVacante,
		BR.nomRangoSalarial,
		BC.nomCiudad,
	oo.descripcionVacante,
		(CASE
		WHEN oo.esConfidencial = 1
		THEN
		'CONFIDENCIAL'
		ELSE
		nomEmpresa 
		END
) as nomEmpresa,
(CASE
			WHEN oo.esConfidencial = 1
			THEN 
			SUBSTRING((SELECT object_definition(default_object_id) AS definition --Valor por defecto de la colomna
                    FROM sys.columns
                    WHERE name = 'rutaAvatar' AND object_id = object_id('seguridad.usuarios')), 
                    4, 
                    LEN((SELECT object_definition(default_object_id) AS definition
                        FROM sys.columns
                        WHERE name = 'rutaAvatar' AND object_id = object_id('seguridad.usuarios'))) - 5)
			ELSE rutaAvatar
			END
		) AS rutaAvataR
FROM 
	Ofertas.Postulacion OP
	INNER JOIN Actores.Personas AP ON  OP.idPersona = AP.idPersona
	INNER JOIN Ofertas.Ofertas OO ON OP.idOferta = OO.idOferta 
	INNER JOIN Actores.Empresas AE ON OO.idEmpresa = AE.idEmpresa
	INNER JOIN Seguridad.Usuarios SU ON SU.idUsuario = AE.idUsuario
	INNER JOIN Basicas.RangoSalarial BR ON BR.idRangoSalarial = OO.idRangoSalario
	INNER JOIN Basicas.PaisesEstadosCiudades BC ON OO.idCiudadVacante = BC.idCiudadEstadoPais
		
WHERE 
	AP.idUsuario = @idUsuario
AND
	GETDATE() BETWEEN OO.fechaPublicacion AND OO.fechaVencimiento
AND (oo.idOcupacion = @idOcupacion 
			or @idOcupacion < 1
			or oo.idOcupacion1 = @idOcupacion 
			or oo.idOcupacion2 = @idOcupacion 
			or oo.idOcupacion3 = @idOcupacion 
			or oo.idOcupacion4 = @idOcupacion 
			or oo.idOcupacion5 = @idOcupacion 
			or oo.idOcupacion6 = @idOcupacion 
			or oo.idOcupacion7 = @idOcupacion 
			or oo.idOcupacion8 = @idOcupacion 
			or oo.idOcupacion9 = @idOcupacion 
			or oo.idOcupacion10 = @idOcupacion 
	)
AND OP.fechaCrea between @fechaInicia and  @fechaFinaliza
		 
ORDER BY  OO.fechaCrea DESC

END
GO
