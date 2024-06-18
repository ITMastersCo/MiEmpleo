-- Mis Aplicaiones



INSERT INTO Seguridad.Formulario(idFormulario,
nomFormulario, 
rutaIcono,
direccion, 
idPadre, 
visible, 
orden, 
activo, 
usuarioCrea,
fechaCrea)
VALUES (
(SELECT MAX(idFormulario)from Seguridad.Formulario) + 1,
'Mis Aplicaciones',
'<svg xmlns="http://www.w3.org/2000/svg"class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor">
  <path d="M9 2a2 2 0 00-2 2v8a2 2 0 002 2h6a2 2 0 002-2V6.414A2 2 0 0016.414 5L14 2.586A2 2 0 0012.586 2H9z" />
  <path d="M3 8a2 2 0 012-2v10h8a2 2 0 01-2 2H5a2 2 0 01-2-2V8z" />
</svg>',
'1',
null,
1,
2,
1,
'AdmonIT',
GETDATE()
)



INSERT INTO Seguridad.FormularioRol
(
idFormularioRol,
idFormulario,
idRol,
activo,
usuarioCrea,
fechaCrea
)
values 
(
(SELECT MAX(idFormularioRol)from Seguridad.FormularioRol) + 1,
(SELECT idFormulario FROM Seguridad.Formulario WHERE nomFormulario = 'Mis Aplicaciones'),
2,
1,
'AdmonIT',
GETDATE()
)


-- Aplicaiones

INSERT INTO Seguridad.Formulario(idFormulario,
nomFormulario, 
rutaIcono,
direccion, 
idPadre, 
visible, 
orden, 
activo, 
usuarioCrea,
fechaCrea)
VALUES (
(SELECT MAX(idFormulario)from Seguridad.Formulario) + 1,
'Aplicado',
'<svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
  <path stroke-linecap="round" stroke-linejoin="round" d="M8 7v8a2 2 0 002 2h6M8 7V5a2 2 0 012-2h4.586a1 1 0 01.707.293l4.414 4.414a1 1 0 01.293.707V15a2 2 0 01-2 2h-2M8 7H6a2 2 0 00-2 2v10a2 2 0 002 2h8a2 2 0 002-2v-2" />
</svg>',
'Personal/Postulaciones.aspx',
(SELECT idFormulario FROM Seguridad.Formulario WHERE nomFormulario = 'Mis Aplicaciones'),
1,
1,
1,
'AdmonIT',
GETDATE()
)



INSERT INTO Seguridad.FormularioRol
(
idFormularioRol,
idFormulario,
idRol,
activo,
usuarioCrea,
fechaCrea
)
values 
(
(SELECT MAX(idFormularioRol)from Seguridad.FormularioRol) + 1,
(SELECT idFormulario FROM Seguridad.Formulario WHERE nomFormulario = 'Aplicado'),
2,
1,
'AdmonIT',
GETDATE()
)




		