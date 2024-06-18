-- cmbOcupacionesPersonaPostulacion
INSERT INTO Basicas.Lista (IdLista, Nombre, Consulta, Descripcion, Activo, UsuarioCrea, FechaCrea)
VALUES (
(SELECT maX(IdLista) FROM Basicas.Lista) +1,
'cmbOcupacionesPersonaPostulacion', 
'SELECT DISTINCT eo.idOcupacion AS id, eo.nomOcupacion AS nombre  
  FROM
  Basicas.EducacionOcupacion AS eo 
  INNER JOIN Ofertas.Ofertas AS oo ON eo.idOcupacion = oo.idOcupacion 
  OR eo.idOcupacion = oo.idOcupacion1 OR eo.idOcupacion = oo.idOcupacion2 
  OR eo.idOcupacion = oo.idOcupacion3 OR eo.idOcupacion = oo.idOcupacion4 
  OR eo.idOcupacion = oo.idOcupacion5 OR eo.idOcupacion = oo.idOcupacion6 
  OR eo.idOcupacion = oo.idOcupacion7 OR eo.idOcupacion = oo.idOcupacion8 
  OR eo.idOcupacion = oo.idOcupacion9 OR eo.idOcupacion = oo.idOcupacion10 
  INNER JOIN Ofertas.Postulacion OP ON OO.idOferta = OP.idOferta
  inner join Actores.Personas AP on OP.idPersona = AP.idPersona
  WHERE (eo.estado = 1) 
  AND GETDATE() BETWEEN OO.fechaPublicacion AND OO.fechaVencimiento
  and AP.idUsuario = ?' ,
'Lista de ocupaciones que se encuentra en las aplicaciondes de la persona',
1,
'AdmonIT',
GETDATE()
);





SELECT * FROM Basicas.Lista ORDER BY FechaCrea desc