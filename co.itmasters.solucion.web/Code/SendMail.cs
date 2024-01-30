using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using co.itmasters.solucion.web.SeguimientoService;
using co.itmasters.solucion.vo;



namespace co.itmasters.solucion.web.Code
{
    public class SendMail
    {
        private UserVO user;
      //  private SeguimientoServiceClient Seguimiento = new SeguimientoServiceClient();
        MessageVo Message = new MessageVo();

        public void SendMailToOfficial(string CodigoFuncionario, int colegio, int IdMessage)
        {
            Message.IdColegio = colegio;
            Message.CodigoFuncionario = CodigoFuncionario;
            Message.IdMessage = IdMessage;
            Message = Seguimiento.MessageDataOfficial(Message)[0];
            if (Message.NotificacionPorCorreo)
            {
                SendMailTo(Message);
            }
        }

        public void SendMailToStudent(String id, int colegio, int menssage)
        {

            Message.IdColegio = colegio;
            Message.Personas = id;
            Message.IdMessage = menssage;
            Message = Seguimiento.MessageData(Message)[0];
            if (Message.NotificacionPorCorreo)
            {
                SendMailTo(Message);
            }
        }

        public void SendMailTo(MessageVo mailTo)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(mailTo.SmtpClient);

                mail.From = new MailAddress(mailTo.EmailFrom);
                if (!string.IsNullOrEmpty(mailTo.Contacto1) && mailTo.Contacto1 != mailTo.Contacto2 && mailTo.Contacto1 != mailTo.Contacto3)
                {
                    mail.To.Add(mailTo.Contacto1);
                }
                if (!string.IsNullOrEmpty(mailTo.Contacto2) && mailTo.Contacto2 != mailTo.Contacto1 && mailTo.Contacto2 != mailTo.Contacto3)
                {
                    mail.To.Add(mailTo.Contacto2);
                }
                if (!string.IsNullOrEmpty(mailTo.Contacto3) && mailTo.Contacto3 != mailTo.Contacto1 && mailTo.Contacto3 != mailTo.Contacto2)
                {
                    mail.To.Add(mailTo.Contacto3);
                }
                if (!string.IsNullOrEmpty(mailTo.CorreoFuncionario))
                {
                    mail.To.Add(mailTo.CorreoFuncionario);
                }
                mail.Subject = mailTo.MessageSubject;
                mail.Body = mailTo.MessageBody;
                mail.IsBodyHtml = true;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(mailTo.EmailFrom, mailTo.EmailFromPW);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

            }
            catch (Exception err)
            {
                LogWeb.Write("Mail error :" + err.Message, LogWeb.ERROR);
                throw;

            }
        }

    }
}