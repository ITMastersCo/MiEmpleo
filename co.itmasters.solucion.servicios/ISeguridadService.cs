using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using co.itmasters.solucion.vo;

namespace co.itmasters.solucion.servicios
{
    [ServiceContract]
    public interface ISeguridadService
    {
        [OperationContract]
        List<CredencialesVO> GetCredenciales(int idUser);

        [OperationContract]
        void RegistroUsuarioTokenEmpresa(UsuarioVO Actor);

        [OperationContract]
        void RegistroUsuarioEmpresa(UsuarioVO Actor);
        [OperationContract]
        void RegistroUsuarioCandidato(UsuarioVO Actor);
        [OperationContract]
        void ActualizaContrasena(UsuarioVO Actor);

        [OperationContract]
        Boolean validarToken(UsuarioVO token);

        [OperationContract]
        void RestablecerContrasena(UsuarioVO Actor);

        [OperationContract]
        Boolean validarUsuario(String nombreUsuario, String clave);

        [OperationContract]
        UsuarioVO getUsuario(String nombreUsuario);

        [OperationContract]
        List<UsuarioVO> buscarPreguntas(UsuarioVO Usuario);

        [OperationContract]
        List<UsuarioVO> EnviarRespuestas(UsuarioVO Usuario);
    }
}
