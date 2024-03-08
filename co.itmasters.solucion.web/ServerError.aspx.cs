using System;

namespace co.itmasters.academics.web
{
    public partial class ServerError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.Error != null)
            {
                switch (Context.Response.StatusCode)
                {
                    case 401:
                        // Error 401 - No autorizado
                        imgError.Src = "~/Images/Error401.webp";
                        codError.InnerText = "401";
                        titleError.InnerText = "Acceso no autorizado";
                        textError.InnerText = "No tienes permiso para acceder a esta página. Por favor, inicia sesión con las credenciales adecuadas.";
                        break;
                    case 403:
                        // Error 403 - Acceso denegado
                        imgError.Src = "~/Images/Error403.webp";
                        codError.InnerText = "403";
                        titleError.InnerText = "Acceso denegado";
                        textError.InnerText = "No tienes permiso para acceder a esta página. El acceso está prohibido y cualquier intento de acceso no autorizado puede tener implicaciones legales.";
                        break;
                    case 404:
                        // Error 404 - No encontrado
                        imgError.Src = "~/Images/Error404.webp";
                        codError.InnerText = "404";
                        titleError.InnerText = "Página no encontrada";
                        textError.InnerText = "Lo sentimos, la página que estás buscando no se encuentra disponible en este momento.";
                        break;
                    case 405:
                        // Error 405 - Método no permitido
                        imgError.Src = "~/Images/Error405.webp";
                        codError.InnerText = "405";
                        titleError.InnerText = "Método no permitido";
                        textError.InnerText = "El método HTTP utilizado no está permitido para esta solicitud.";
                        break;
                    case 406:
                        // Error 406 - No aceptable
                        imgError.Src = "~/Images/Error406.webp";
                        codError.InnerText = "406";
                        titleError.InnerText = "No aceptable";
                        textError.InnerText = "El servidor no puede generar una respuesta que sea aceptable para el navegador del cliente.";
                        break;
                    case 412:
                        // Error 412 - Falló la precondición
                        imgError.Src = "~/Images/Error412.webp";
                        codError.InnerText = "412";
                        titleError.InnerText = "Falló la precondición";
                        textError.InnerText = "Una o más condiciones establecidas en la solicitud han fallado.";
                        break;
                    case 500:
                        // Error 500 - Error interno del servidor
                        imgError.Src = "~/Images/Error500.webp";
                        codError.InnerText = "500";
                        titleError.InnerText = "Error interno del servidor";
                        textError.InnerText = "Se ha producido un error interno en el servidor. Por favor, inténtalo de nuevo más tarde.";
                        break;
                    case 501:
                        // Error 501 - No implementado
                        imgError.Src = "~/Images/Error501.webp";
                        codError.InnerText = "501";
                        titleError.InnerText = "No implementado";
                        textError.InnerText = "El servidor no reconoce el método de solicitud o carece de la capacidad para completarlo.";
                        break;
                    case 502:
                        // Error 502 - Puerta de enlace incorrecta
                        imgError.Src = "~/Images/Error502.webp";
                        codError.InnerText = "502";
                        titleError.InnerText = "Puerta de enlace incorrecta";
                        textError.InnerText = "El servidor recibió una respuesta no válida de un servidor ascendente mientras intentaba cumplir la solicitud.";
                        break;
                    default:
                        // Otros códigos de error
                        imgError.Src = "~/Images/ErrorGenerico.webp";
                        codError.InnerText = Context.Response.StatusCode.ToString();
                        titleError.InnerText = "Error";
                        textError.InnerText = "Se ha producido un error inesperado. Por favor, inténtalo de nuevo más tarde.";
                        break;
                }
            }
        }
    }
}
