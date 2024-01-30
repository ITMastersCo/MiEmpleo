using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using co.itmasters.solucion.negocio;
using co.itmasters.solucion.vo;

namespace co.itmasters.solucion.servicios
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class SeguridadService : ISeguridadService, IDisposable
    {
        private SeguridadNegocio _seguridad;
        public void RegistroUsuarioTokenEmpresa(UsuarioVO Actor)
        {
            try
            {

                _seguridad = new SeguridadNegocio();
                _seguridad.RegistroUsuarioTokenEmpresa(Actor);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public void RegistroUsuarioEmpresa(UsuarioVO Actor)
        {
            try
            {

                _seguridad = new SeguridadNegocio();
                _seguridad.RegistroUsuarioEmpresa(Actor);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public void RegistroUsuarioCandidato(UsuarioVO Actor)
        {
            try
            {

                _seguridad = new SeguridadNegocio();
                _seguridad.RegistroUsuarioCandidato(Actor);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public void ActualizaContrasena(UsuarioVO Actor)
        {
            try
            {

                _seguridad = new SeguridadNegocio();
                _seguridad.ActualizaContrasena(Actor);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public Boolean validarToken(UsuarioVO token)
        {
            _seguridad = new SeguridadNegocio();
            try
            {
                bool res = _seguridad.validarToken(token);
                return res;
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(err.Message);
            }
        }
        public void RestablecerContrasena(UsuarioVO Actor)
        {
            try
            {

                _seguridad = new SeguridadNegocio();
                _seguridad.RestablecerContrasena(Actor);
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
        public Boolean validarUsuario(String nombreUsuario, String clave)
        {
            _seguridad = new SeguridadNegocio();
            try
            {
                bool res = _seguridad.validarUsuario(nombreUsuario, clave);
                return res;
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(err.Message);
            }
        }

        public UsuarioVO getUsuario(String nombreUsuario)
        {
            _seguridad = new SeguridadNegocio();
            try
            {
                UsuarioVO _user = _seguridad.getUsuario(nombreUsuario);
                return _user;
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }
               
        public List<UsuarioVO> buscarPreguntas(UsuarioVO Usuario)
        {
            _seguridad = new SeguridadNegocio();
            try
            {
                List<UsuarioVO> _user = _seguridad.buscarPreguntas(Usuario);
                return _user;
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }

        public List<UsuarioVO> EnviarRespuestas(UsuarioVO Usuario)
        {
            _seguridad = new SeguridadNegocio();
            try
            {
                List<UsuarioVO> _user = _seguridad.EnviarRespuestas(Usuario);
                return _user;
            }
            catch (Exception err)
            {
                Log.Write(err.Message, Log.ERROR);
                throw new FaultException(new FaultReason(err.Message));
            }
        }

        /// <summary>
        /// Libera la memoria usada por el objeto, y los objetos internos que se utilicen
        /// </summary>
        public virtual void Dispose()
        {

        }
    }
}
