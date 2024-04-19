<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InternaEmpresa.aspx.cs" Inherits="co.itmasters.solucion.web.InternaEmpresa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="css/slider.css" rel="stylesheet" />
    <link rel="stylesheet" href="~/css/MaterPageEmpresa.css" />
    <title>Mi empleo | Empresas</title>
    <link href="./Images/imgInicio/MiEmpleo.ico" type="image/x-icon" rel="shortcut icon" />
</head>
<body>
   <header class="header">


        <!-- OpenMenu -->

        <label  class="iconMenu center pointer" for="chkOpenMenu" id="LblMenu">
            <img src="./images/ImgInicio/menu-bars.svg" alt=""/>
        </label>
        <input class="chkOpenMenu" type="checkbox" id="chkOpenMenu"/>
        <nav class="wrapper-menu-main" id="main-menu">
            <ul class="content-menu">
                <li><a class="item-menu" href="#">Sobre Nosotros</a></li>
                <li><a class="item-menu" href="#">Contenido de Valor</a></li>
                <li><a class="item-menu" href="./InternaEmpresa.aspx">Empresa / Publicar oferta gratis</a></li>
                <li><a class="item-menu" href="#">Centro de Ayuda</a></li>
            </ul>
        </nav>
        <a href="./Index.aspx" class="logo center tooltip">
            <img src="./images/ImgInicio/Logo-horizontal-dark.webp" alt="Home"/>
            <span class="tooltiptext">Inicio</span>
        </a>


        
   
        <a class="loginIcon center" href="./Home/LoginEmpresa.aspx">
            <img src="./images/ImgInicio/user-empresa.svg" alt="Inicia Sesión"/>
        </a>
        <a href="./Home/LoginEmpresa.aspx" class="loginIconDesktop button-ghost">
            <p class="text-normal">Acceder</p>
            <img src="./images/ImgInicio/user-empresa.svg" alt=""/>
            
        </a>
        <a href="./Home/RegistroEmpresa.aspx" class="header-button"><span class="button text-normal">Publicar oferta gratis</span></a>
    </header>
    <main>
        <!-- Banner -->
        <section class="MasterBanner place-center">
            <div  class="MasterBannerContent place-center">

                <h1 class="text-title">
                    Consigue el talento excepcional que has estado buscando
                    <span class="text-title text-highlighted">
                        fácil y
                        rápido.
                    </span>
                </h1>
                <a class="button">Publicar Oferta Gratis</a>
            </div>
        </section>
        <!-- Coworkers -->
        <div class="contentPage place-center">

            <section class="customers wrapper flex flex-col flex-center">
                <h2 class="text-subtitle"><span class="text-subtitle text-highlighted">Nuestros</span> Clientes</h2>
                <div class="wrapper-slider" id="wrapper-slider">
                    <i id="left">
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor" class="w-3 h-3 color-gray-700">
                            <path fill-rule="evenodd" d="M8.22 5.22a.75.75 0 0 1 1.06 0l4.25 4.25a.75.75 0 0 1 0 1.06l-4.25 4.25a.75.75 0 0 1-1.06-1.06L11.94 10 8.22 6.28a.75.75 0 0 1 0-1.06Z" clip-rule="evenodd" />
                        </svg>

                    </i>
                    <div class="carousel" id="carousel">
                        <a href="" class="item-slider">
                            <div class="info-jobs">
                                <h3>Cliente</h3>
                                <p>Descripcion breve del clienteb</p>
                            </div>
                            <img
                                src="Images/ImgInicio/Avatar-Default.jpg"
                                alt="Usuario"
                                draggable="false" />
                        </a>
                        <a href="" class="item-slider">
                            <div class="info-jobs">
                                <h3>Cliente</h3>
                                <p>Descripcion breve del clienteb</p>
                            </div>
                            <img
                                src="Images/ImgInicio/Avatar-Default.jpg"
                                alt="Usuario"
                                draggable="false" />
                        </a>
                        <a href="" class="item-slider">
                            <div class="info-jobs">
                                <h3>Cliente</h3>
                                <p>Descripcion breve del clienteb</p>
                            </div>
                            <img
                                src="Images/ImgInicio/Avatar-Default.jpg"
                                alt="Usuario"
                                draggable="false" />
                        </a>
                        <a href="" class="item-slider">
                            <div class="info-jobs">
                                <h3>Cliente</h3>
                                <p>Descripcion breve del clienteb</p>
                            </div>
                            <img
                                src="Images/ImgInicio/Avatar-Default.jpg"
                                alt="Usuario"
                                draggable="false" />
                        </a>
                        <a href="" class="item-slider">
                            <div class="info-jobs">
                                <h3>Cliente</h3>
                                <p>Descripcion breve del clienteb</p>
                            </div>
                            <img
                                src="Images/ImgInicio/Avatar-Default.jpg"
                                alt="Usuario"
                                draggable="false" />
                        </a>
                        <a href="" class="item-slider">
                            <div class="info-jobs">
                                <h3>Cliente</h3>
                                <p>Descripcion breve del clienteb</p>
                            </div>
                            <img
                                src="Images/ImgInicio/Avatar-Default.jpg"
                                alt="Usuario"
                                draggable="false" />
                        </a>
                        <a href="" class="item-slider">
                            <div class="info-jobs">
                                <h3>Cliente</h3>
                                <p>Descripcion breve del clienteb</p>
                            </div>
                            <img
                                src="Images/ImgInicio/Avatar-Default.jpg"
                                alt="Usuario"
                                draggable="false" />
                        </a>
                    </div>
                    <i id="right">
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor" class="w-3 h-3 color-gray-700">
                            <path fill-rule="evenodd" d="M8.22 5.22a.75.75 0 0 1 1.06 0l4.25 4.25a.75.75 0 0 1 0 1.06l-4.25 4.25a.75.75 0 0 1-1.06-1.06L11.94 10 8.22 6.28a.75.75 0 0 1 0-1.06Z" clip-rule="evenodd" />
                        </svg>
                    </i>
</div>
            </section>

            <section class="benefits">
                <img src="/images/home-empresa-beneficios.webp" alt="Alternate Text" />
                <%--<h2 class="text-subtitle">Beneficios de <span class="text-subtitle text-highlighted">Miempleo.co</span></h2>
                <ul class="place-center">
                    <li class="item-benefit"><img src="./images/ImgInicio/benefit-empresa-1.png" alt=""/><p class="text-semibold">Publicaciónes más economicas</p></li>
                    <li class="item-be8nefit"><img src="./images/ImgInicio/benefit-empresa-2.png" alt=""/><p class="text-semibold">Una preselección más fácil</p></li>
                    <li class="item-benefit"><img src="./images/ImgInicio/benefit-empresa-3.png" alt=""/><p class="text-semibold">Creación de Multiusuarios</p></li>
                    <li class="item-benefit"><img src="./images/ImgInicio/benefit-empresa-4.png" alt=""/><p class="text-semibold">Programa de entrevistas directamente por zoom</p></li>
                </ul>--%>
            </section>
            <!-- About US -->
            <section class="place-center about">
                <h2 class="text-subtitle">¿Quiénes <span class="text-subtitle text-highlighted">somos</span>?</h2>
                <p class="text-normal">Somos un software desarrollado con el objetivo de establecer vínculos laborales entre las empresas y los buscadores de empleo que aspiran aplicar a las vacantes publicadas en las distintas ocupaciones</p>
                <a href="#">
                    <button class="button">¡Quiero saber mas!</button>
                </a>
            </section>
            <!-- Comunnity -->
            <section class="comunnity place-center">
                <h2 class="text-subtitle">Comunidad en<span class="text-subtitle text-highlighted"> miempleo.co</span></h2>
                <div>
                    <ul>
                        <li><h3 class="text-subtitle">20.976</h3><p class="text-subtitle text-highlighted text-semibold">Vacantes</p></li>
                        <li><h3 class="text-subtitle">20.976</h3><p class="text-subtitle text-highlighted text-semibold">Usuarios</p></li>
                        <li><h3 class="text-subtitle">20.976</h3><p class="text-subtitle text-highlighted text-semibold">Empresas</p></li>
                    </ul>
                </div>
            </section>
        </div>
    </main>
    <footer>
        <div class="wrapper footer mobile">

            <a href="#"><img class="logo" src="./images/ImgInicio/MiEmpleo-vertical-1.webp" alt=""/></a>
            <p class="text-big text-semibold">Mi <span class="text-highlighted text-big"> Empleo </span> 
                tu herramienta perfecta para encontrar los mejores talentos</p>
                <a href="#"><button class="button text-normal">Crear Hoja de vida</button></a>
                <div>
                        <ul class="social">
                            <li><a href="https://www.facebook.com/miempleo.co" target="_blank" ><img src="./images/ImgInicio/facebook.svg" alt=""/></a></li>
                            <li><a href="https://www.instagram.com/miempleo.co/" target="_blank"><img src="./images/ImgInicio/group.svg" alt=""/></a></li>
                            <li> <a href="https://www.linkedin.com/company/miempleo-co/" target="_blank">

                                <svg role="img" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg" class="color-white">
    <title>LinkedIn</title>
    <path fill="currentColor" d="M20.447 20.452h-3.554v-5.569c0-1.328-.027-3.037-1.852-3.037-1.853 0-2.136 1.445-2.136 2.939v5.667H9.351V9h3.414v1.561h.046c.477-.9 1.637-1.85 3.37-1.85 3.601 0 4.267 2.37 4.267 5.455v6.286zM5.337 7.433c-1.144 0-2.063-.926-2.063-2.065 0-1.138.92-2.063 2.063-2.063 1.14 0 2.064.925 2.064 2.063 0 1.139-.925 2.065-2.064 2.065zm1.782 13.019H3.555V9h3.564v11.452zM22.225 0H1.771C.792 0 0 .774 0 1.729v20.542C0 23.227.792 24 1.771 24h20.451C23.2 24 24 23.227 24 22.271V1.729C24 .774 23.2 0 22.222 0h.003z"/>

</svg>
                                 </a>

                            </li>
                            <li><a href="#"><img src="./images/ImgInicio/whatsapp.svg" alt=""/></a></li>
                        </ul>
                </div>
            </div>
            <div >
                <nav class="footer desktop">
                    
                    <a href="#"><img class="logo" src="./images/ImgInicio/MiEmpleo-vertical-1.webp" alt=""/></a>
                    <ul class="menu-footer ">
                        <li><a href="#">Inicio</a></li>
                        <li><a href="#">Contenido de Valor</a></li>
                        <li><a href="#">Sobre Nosotros</a></li>
                        <li><a href="#">Empresa/Publicar vacante gratis</a></li>
                      
                    </ul>    
                    <ul class="menu-footer ">
                        <li><a href="#">Dirección</a></li>
                        <li><a href="#">Contactenos</a></li>
                        <li><a href="#">Registrate</a></li>
                        <li><a href="#">PQRF</a></li>
                      
                    </ul>    
                    <div class="footer-social flex flex-col gap-16">
                        <span class="text-item text-semibold ">¡Siguenos!</span>
                        <ul class="social">
                            <li><a href="https://www.facebook.com/miempleo.co" target="_blank"><img src="./images/ImgInicio/facebook.svg" alt=""/></a></li>
                            <li><a href="https://www.instagram.com/miempleo.co/" target="_blank"><img src="./images/ImgInicio/group.svg" alt=""/></a></li>
                            <li><a href="https://www.linkedin.com/company/miempleo-co/" target="_blank" >

                                 <svg role="img" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg" class="color-white">
     <title>LinkedIn</title>
     <path fill="currentColor" d="M20.447 20.452h-3.554v-5.569c0-1.328-.027-3.037-1.852-3.037-1.853 0-2.136 1.445-2.136 2.939v5.667H9.351V9h3.414v1.561h.046c.477-.9 1.637-1.85 3.37-1.85 3.601 0 4.267 2.37 4.267 5.455v6.286zM5.337 7.433c-1.144 0-2.063-.926-2.063-2.065 0-1.138.92-2.063 2.063-2.063 1.14 0 2.064.925 2.064 2.063 0 1.139-.925 2.065-2.064 2.065zm1.782 13.019H3.555V9h3.564v11.452zM22.225 0H1.771C.792 0 0 .774 0 1.729v20.542C0 23.227.792 24 1.771 24h20.451C23.2 24 24 23.227 24 22.271V1.729C24 .774 23.2 0 22.222 0h.003z"/>

 </svg>
                                </a>

                            </li>
                            <li><a href="#"><img src="./images/ImgInicio/whatsapp.svg" alt=""/></a></li>
                        </ul>
                    </div>
                </nav>
                </div>
    </footer>
    <script src="Scripts/Index.js"></script>
    <script type="module" src="Scripts/slider.js"></script>
            <style>
    .footer{
        width:100%;
        margin-left:0;
    }
</style>
</body>
</html>
