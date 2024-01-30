using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using co.itmasters.solucion.web.SeguridadService;
using System.Collections.Generic;
using co.itmasters.solucion.vo;

namespace co.itmasters.solucion.web.Code
{
    public class PersonalProvider : MembershipProvider
    {
        private SeguridadServiceClient seguridadSvc;

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            seguridadSvc = new SeguridadServiceClient();
            UsuarioVO usuario = seguridadSvc.getUsuario(username);
            //Cerrar el servicio
            seguridadSvc.Close();

            UserVO user = new UserVO();
      
            user.IdUsuario = usuario.IdUsuario;
            user.NomUsuario = usuario.NomUsuario;
            user.TipIdentificacion = usuario.TipIdentificacion;
            user.NumIdentificacion = usuario.NumIdentificacion;
            user.NombreCompleto = usuario.NombreCompleto;
            user.esAdmon = usuario.esAdmon;
            user.tipoUsuario = usuario.tipoUsuario;
            user.diligenciaFormulario = usuario.diligenciaFormulario;
            user.Avatar = usuario.Avatar;
            user.WebSite = usuario.WebSite;
            user.Rol = usuario.Rol.ToList<RolVO>();
            user.Formulario = usuario.Formulario.ToList<FormularioVO>();
            return user;
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            try
            {
                seguridadSvc = new SeguridadServiceClient();
                bool res = seguridadSvc.validarUsuario(username, password);

                return res;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                //Cerrar el servicio
                seguridadSvc.Close();
            }
        }
    }
}
