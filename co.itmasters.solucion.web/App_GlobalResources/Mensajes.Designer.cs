//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resources {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile el proyecto de Visual Studio.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Web.Application.StronglyTypedResourceProxyBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Mensajes {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Mensajes() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Resources.Mensajes", global::System.Reflection.Assembly.Load("App_GlobalResources"));
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Alumno actualizado exitosamente.
        /// </summary>
        internal static string msgAlumnoActualizadoExito {
            get {
                return ResourceManager.GetString("msgAlumnoActualizadoExito", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Alumno registrado exitosamente.
        /// </summary>
        internal static string msgAlumnoAdicionadoExito {
            get {
                return ResourceManager.GetString("msgAlumnoAdicionadoExito", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Alumno NO pudo se ingresado o actualizado correctamente.
        /// </summary>
        internal static string msgAlumnoError {
            get {
                return ResourceManager.GetString("msgAlumnoError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a No existe alumno para este código.  Puede ingresar información como alumno nuevo..
        /// </summary>
        internal static string msgAlumnoNoEncontrado {
            get {
                return ResourceManager.GetString("msgAlumnoNoEncontrado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Funcionario actualizado exitosamente.
        /// </summary>
        internal static string msgFuncionarioActualizadoExito {
            get {
                return ResourceManager.GetString("msgFuncionarioActualizadoExito", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Funcionario NO pudo se ingresado o actualizado correctamente.
        /// </summary>
        internal static string msgFuncionarioError {
            get {
                return ResourceManager.GetString("msgFuncionarioError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Funcionario no existe.  Puede ingresar información como persona nueva.
        /// </summary>
        internal static string msgFuncionarioNoEncontrado {
            get {
                return ResourceManager.GetString("msgFuncionarioNoEncontrado", resourceCulture);
            }
        }
    }
}
