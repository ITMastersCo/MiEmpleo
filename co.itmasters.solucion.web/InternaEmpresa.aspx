<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InternaEmpresa.aspx.cs" Inherits="co.itmasters.solucion.web.InternaEmpresa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
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
            <img src="./images/ImgInicio/LOGO-dark.png" alt="Home"/>
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

            <section class="customers wrapper">
                <h2 class="text-subtitle"> <span class="text-subtitle text-highlighted">Nuestros</span> Aliados</h2>
                <div class="slider">
                    <span><img class="arrowLeft" src="./images/ImgInicio/flecha-empresa.svg" alt=""/></span>
                    <div class="carousel">
                        <article class="customers-content">
                            <img src="./images/ImgInicio/userComment.png" alt=""/>
                            <h3 class="text-highlighted text-big">Diego Ramirez</h3>
                            <p class="text-normal">Gracias a ellos consegi un empleo en lo que me fguata y puedo tener un trabajo remunerado</p>
                            <img src="./images/ImgInicio/Calificacion.png" alt=""/>
                        </article>
                    </div>
                    <span><img  class="arrowRight" src="./images/ImgInicio/flecha-empresa.svg" alt=""/></span>
                </div>
            </section> 
            <section class="benefits">
                <h2 class="text-subtitle">Beneficios de <span class="text-subtitle text-highlighted">Miempleo.co</span></h2>
                <ul class="place-center">
                    <li class="item-benefit"><img src="./images/ImgInicio/benefit-empresa-1.png" alt=""/><p class="text-semibold">Publicaciónes más economicas</p></li>
                    <li class="item-benefit"><img src="./images/ImgInicio/benefit-empresa-2.png" alt=""/><p class="text-semibold">Una preselección más fácil</p></li>
                    <li class="item-benefit"><img src="./images/ImgInicio/benefit-empresa-3.png" alt=""/><p class="text-semibold">Creación de Multiusuarios</p></li>
                    <li class="item-benefit"><img src="./images/ImgInicio/benefit-empresa-4.png" alt=""/><p class="text-semibold">Programa de entrevistas directamente por zoom</p></li>
                </ul>
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

            <a href="#"><img class="logo" src="./images/ImgInicio/LOGO-Empresas.png" alt=""/></a>
            <p class="text-big text-semibold">Mi <span class="text-highlighted text-big"> Empleo </span> 
                tu herramienta perfecta para encontrar los mejores talentos</p>
                <a href="#"><button class="button text-normal">Crear Hoja de vida</button></a>
                <div>
                        <ul class="social">
                            <li><a href="#"><img src="./images/ImgInicio/facebook.svg" alt=""/></a></li>
                            <li><a href="#"><img src="./images/ImgInicio/group.svg" alt=""/></a></li>
                            <li><a href="#"><img src="./images/ImgInicio/gmiail.svg" alt=""/></a></li>
                            <li><a href="#"><img src="./images/ImgInicio/whatsapp.svg" alt=""/></a></li>
                        </ul>
                </div>
            </div>
            <div >
                <nav class="footer desktop">
                    
                    <a href="#"><img class="logo" src="./images/ImgInicio/LOGO-Empresas.png" alt=""/></a>
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
                    <div class="footer-social">
                        <a href="#"><button class="button text-normal">¡Siguenos!</button></a>
                        <ul class="social">
                            <li><a href="#"><img src="./images/ImgInicio/facebook.svg" alt=""/></a></li>
                            <li><a href="#"><img src="./images/ImgInicio/group.svg" alt=""/></a></li>
                            <li><a href="#"><img src="./images/ImgInicio/gmiail.svg" alt=""/></a></li>
                            <li><a href="#"><img src="./images/ImgInicio/whatsapp.svg" alt=""/></a></li>
                        </ul>
                    </div>
                </nav>
                </div>
    </footer>
    <script src="Scripts/Index.js"></script>
</body>
</html>
