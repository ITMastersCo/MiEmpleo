using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using co.itmasters.solucion.vo;
using co.itmasters.solucion.dao;

namespace co.itmasters.solucion.negocio
{
    public class SeguridadNegocio
    {
        SeguridadDao seguridad;

        public List<CredencialesVO> GetCredenciales(int idUser)
        {
            return seguridad.GetCredenciales(idUser);
        }
        public void RegistroUsuarioTokenEmpresa(UsuarioVO Actor)
        {
            seguridad.RegistroUsuarioTokenEmpresa(Actor);
        }
        public void RegistroUsuarioEmpresa(UsuarioVO Actor)
        {

            seguridad.RegistroUsuarioEmpresa(Actor);
        }
        public void RegistroUsuarioCandidato(UsuarioVO Actor)
        {

            seguridad.RegistroUsuarioCandidato(Actor);
        }
        public void ActualizaContrasena(UsuarioVO Actor)
        {

            seguridad.ActualizaContrasena(Actor);
        }
        public Boolean validarToken(UsuarioVO token)
        {
            return seguridad.validarToken(token);
        }


        public void RestablecerContrasena (UsuarioVO Actor)
        {

            seguridad.RestablecerContrasena(Actor);
        }


        public SeguridadNegocio() 
        {
            seguridad = new SeguridadDao();
        }

        public Boolean validarUsuario(String nombreUsuario, String clave)
        {
            return seguridad.validarUsuario(nombreUsuario, clave);
        }


        public UsuarioVO getUsuario(String nombreUsuario)
        {
            return seguridad.getUsuario(nombreUsuario);
        }

        public List<UsuarioVO> buscarPreguntas(UsuarioVO Usuario)
        {
            return seguridad.buscarPreguntas(Usuario);
        }

        public List<UsuarioVO> EnviarRespuestas(UsuarioVO Usuario)
        {
            return seguridad.EnviarRespuestas(Usuario);
        }

    }
}
