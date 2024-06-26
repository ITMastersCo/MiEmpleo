﻿using System;
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

namespace co.itmasters.solucion.web.Code
{
    public class GeneraMenu : PageBase
    {
        public string getMenu(UserVO user)
        {
            
            string _Acordeon = $@"
                                    <div id='AccordionContainer' class='AccordionContainer'>
                                       {ElementsAccordion()}
                                    </div>
                                ";
            string _newMenu = $@"
                                   <aside class='wrapper-navbar' id='wrapper-navbar'>
                                        <section class='wrapper-menu' id='wrapper-menu'>
                                        <!--Iconos de menu-->
                                        <div class='wrapper-Icons-menu'>

                                            <svg xmlns='http://www.w3.org/2000/svg' id='OpenMenu-Mobile' class='OpenMenu-Mobile' fill='none' viewBox='0 0 24 24' stroke='currentColor' stroke-width='2'>
                                                <path stroke-linecap='round' stroke-linejoin='round' d='M4 6h16M4 12h16M4 18h16' />
                                            </svg>

                                            <svg xmlns='http://www.w3.org/2000/svg'class='IconOpenMenu' id='IconOpenMenu' fill='none' viewBox='0 0 24 24' stroke='currentColor' stroke-width='2'>
                                                <path stroke-linecap='round' stroke-linejoin='round' d='M4 6h16M4 12h16M4 18h16' />
                                            </svg>

                                        </div>
            
                                        <nav class='nav-menu'>
    
                                          <!--Perfil-->
                                            <div class='menu-profile'>
                                                <div class='menu-profile-content'>
                                                    <a href='../Home/{user.WebSite}'>
                                                        <img class='menu-profile-avatar' src='.{user.Avatar}'/>
                                                    </a>
                                                    <div class='menu-profile-info' id='menu-profile-info'>
                                                        <h2>{user.NombreCompleto}</h2>
                                                        <h3>¡Bienvenido!</h3>
                                                    </div>
                                                </div>
                                            </div>

                                          <!--Acordeon-->
                                         {_Acordeon}    
                                        </nav>
                                    </section>
                                  </aside>
                                  {SelectStyle()}
                                  <script src='./Scripts/MenuAcordeon.js'></script>           
                                            ";
            string ElementsAccordion()
            {
                string htmlText = "";
                int id = 0;
                bool hijoPrevio = false;
                foreach (var formulario in user.Formulario)
                {
                    if (formulario.IdPadre.Equals(null) && formulario.Visible.Equals(true))
                    {
                        if (hijoPrevio)

                            htmlText += "</div>";
                            id++;

                        htmlText += $@"
                                        <div  onclick='runAccordion({id});'>
                                            <div class='AccordionTitle' id='Accordion{id}Title' onselectstart='return false;'>
                                                 
                                                <div class='icon-24'> 
                                                   {formulario.RutaIcono }
                                                </div>
                                                    
                                                 <p id='AccordionTitleText text-normal '> {formulario.NomFormulario}  </p> 
                                            </div>
                                        </div>
                                     ";

                        hijoPrevio = false;
                    }
                    else
                    {
                        if (!hijoPrevio)
                        {
                            htmlText += $"<div id='Accordion{id}Content' class='AccordionContent'>";
                            hijoPrevio = true;
                        }

                       //Validamos si debe estar visualizado.
                        if (formulario.Visible)
                        {
                            htmlText += $@"
                                            <div id='Accordion{id}Content_' class='AccordionElement'>
                                                <a href=' {UrlBasePath()}{formulario.Direccion }'>
                                                    <div class='icon-24'>
                                                        {formulario.RutaIcono }
                                                    </div>                                                  
                                                     {formulario.NomFormulario}
                                                 </a>
                                            </div>
                                           ";
                        }
                    }
                }
                return htmlText;
            }
            string SelectStyle ()
            {
                string htmlLinkCss;
                if (user.tipoUsuario == 1 || user.tipoUsuario == 3 || user.tipoUsuario == 4)
                {
                    htmlLinkCss = "<link rel='stylesheet' href='../css/Empresa.css'>";
                }
                else
                {
                    htmlLinkCss = "<link rel='stylesheet' href='../css/Candidato.css'>";
                }
                return htmlLinkCss;
            }

            return _newMenu;
        }
    }
}
;