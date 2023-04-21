<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="indexSurvey.aspx.cs" Inherits="centroEscolar.gentelella_master.production.binderSurvey.indexSurvey" MasterPageFile="~/gentelella-master/production/binderSurvey/masterSurvay.Master" %>


<asp:content id="Content2" ContentPlaceHolderID="head" runat="server">	
    <link href="https://unpkg.com/aos@2.3.1/dist/aos.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.9.1/font/bootstrap-icons.css" />	
    <link href="css/cssIndex.css" rel="stylesheet" />
    <title>Saber mas...</title>
</asp:content> 
<asp:content id="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <%-- Carousel section --%>
        <div id="carouselExampleCaptions" class="carousel slide" data-bs-ride="false">
            <div class="carousel-indicators">
                <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="1" aria-label="Slide 2"></button>
                <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="2" aria-label="Slide 3"></button>
            </div>
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="Imagenes/desercion.jpg" class="d-block w-100" alt="..." />
                    <div class="carousel-caption">
                        <h5>Desercion Escolar</h5>
                        <p class="parrafo">
                            la deserción escolar se refiere al abandono prematuro del sistema educativo. 
                            Este abandono generalmente comienza como un alejamiento gradual, pero recurrente 
                            que culmina en la separación total de los estudios.
                        </p>
                        <a href="https://www.lucaedu.com/desercion-escolar/" class="botonCarrusel btn btn-warning mt-3">Saber Mas</a>
                    </div>
                </div>
                <div class="carousel-item">
                    <img src="Imagenes/escuela2.jpeg" class="d-block w-100" alt="..." />
                    <div class="carousel-caption">
                        <h5>Encuesta</h5>
                        <p class="parrafo">
                            ¿Quieres ayudarnos a resolver la problematica de la desercion escolar? Preciona nuestro
                            boton de contestar y resuelve una pequeña encuesta que nos sirve para evaluar la situacion
                            de la desercion actualmente
                        </p>
                        <a href="Encuesta.aspx" class="botonCarrusel btn btn-warning mt-3">Contestar</a>
                    </div>
                </div>
                <div class="carousel-item">
                    <img src="Imagenes/escuela5.jpeg" class="d-block w-100" alt="..." />
                    <div class="carousel-caption">
                        <h5>Contactanos</h5>
                        <p class="parrafo">
                            ¿Tienes dudas sobre nuestra encuesta o sobre el sitio en general? Ve a nuestro
                            formulario de contacto y envianos un mensaje con tus dudas y opiniones.
                        </p>
                        <a href="#contact" class="botonCarrusel btn btn-warning mt-3">Contactanos</a>
                    </div>
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>

        <!-- About section -->

        <section id="about" class="about section-padding">
            <div class="container">
                <div class="row" data-aos="fade-up" data-aos-duration="1500">
                    <div class="col-lg-4 col-md-12 col-12">
                        <div class="about-img">
                            <img src="Imagenes/fondoEs1.jpeg" class="img-fluid" />
                        </div>
                    </div>
                    <div class="col-lg-8 col-md-12 col-12 ps-lg-5 mt-md-5">
                        <div class="about-text">
                            <h2>Conocenos</h2>
                            <p class="otrosParrafos">
                                Una nueva esperanza es una empresa que se encarga de realizar encuestas a ciertos 
                                grupos de alumnos, principalmente de grado universitario, con el objetivo de indagar en 
                                sus conflictos del dia a dia y de esta manera poder descubrir el motivo por el cual muchos
                                de ellos no logran cumplir sus objetivos o metas estudiantiles
                            </p>
                            <a href="https://www.lucaedu.com/desercion-escolar/" class="btn btn-warning">Saber Mas</a>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- Services Section -->

        <section id="services" class="services section-padding">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="section-header text-center pb-5" data-aos="zoom-out-down" data-aos-duration="1500">
                            <h2>Nuestros Servicios</h2>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-12 col-md-12 col-lg-4">
                        <div class="card text-white text-center bg-dark pb-2 cardServ" data-aos="fade-right" data-aos-duration="1500">
                            <div class="card-body">
                                <i class="bi bi-slack"></i>
                                <h3 class="card-title">Encuestas sobre desercion</h3>
                                <p class="lead">
                                    Ofrecemos una forma de realizar encuestas sobre desercion escolar de 
                                    manera sencilla y amigable para los alumnos
                                </p>
                                <button class="btn btn-warning text-dark">Read More</button>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-md-12 col-lg-4">
                        <div class="card text-white text-center bg-dark pb-2 cardServ" data-aos="fade-up" data-aos-duration="1500">
                            <div class="card-body">
                                <i class="bi bi-subtract"></i>
                                <h3 class="card-title">Analisis de datos</h3>
                                <p class="lead">
                                    Ofrecemos un analisis de datos de regresion lineal que funciona correctamente
                                    y que ayudara en la busqueda de la resolucion de este problema
                                </p>
                                <button class="btn btn-warning text-dark">Read More</button>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-md-12 col-lg-4">
                        <div class="card text-white text-center bg-dark pb-2 cardServ" data-aos="fade-left" data-aos-duration="1500">
                            <div class="card-body">
                                <i class="bi bi-playstation"></i>
                                <h3 class="card-title">Integridad</h3>
                                <p class="lead">
                                    El manejo de los datos personales obtenidos son manejados de manera integra por lo cual
                                    no existira un mal uso de los mismos en nuestra empresa
                                </p>
                                <button class="btn btn-warning text-dark">Read More</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- Beneficios Seccion -->

        <section id="portfolio" class="portfolio section-padding">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="section-header text-center pb-5" data-aos="zoom-out-down" data-aos-duration="1500">
                            <h2>Beneficios</h2>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-12 col-md-12 col-lg-4">
                        <div class="card text-center bg-white pb-2 cardBene" data-aos="fade-up" data-aos-duration="1500">
                            <div class="card-body text-dark">
                                <div class="img-area mb-4">
                                    <img src="Imagenes/sitioweb.jpg" class="img-fluid imgbene" />
                                    <h3 class="card-title">Sitio web agradable e interactivo</h3>
                                    <p class="lead">
                                        Tener un sitio web agradable e interactivo para los estudiantes en general 
                                        y que esta web pueda usarse como herramienta en otras escuelas para realizar 
                                        las encuestas a su cuerpo estudiantil.
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-md-12 col-lg-4">
                        <div class="card text-center bg-white pb-2 cardBene" data-aos="fade-up" data-aos-duration="1500">
                            <div class="card-body text-dark">
                                <div class="img-area mb-4">
                                    <img src="Imagenes/analisisdatos.jpg" class="img-fluid imgbene" />
                                    <h3 class="card-title">Modelo de analisis de datos</h3>
                                    <p class="lead">
                                        Analizar los datos mediante un modelo de regresión lineal 
                                        para obtener las razones más comunes por las cuales suceden la 
                                        deserción escolar. 
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-md-12 col-lg-4">
                        <div class="card text-center bg-white pb-2 cardBene" data-aos="fade-up" data-aos-duration="1500">
                            <div class="card-body text-dark">
                                <div class="img-area mb-4">
                                    <img src="Imagenes/escuela6.jpeg" class="img-fluid imgbene" />
                                    <h3 class="card-title">Disminuir porcentaje de desercion escolar</h3>
                                    <p class="lead">
                                        Disminuir el porcentaje alto de deserción en la Universidad, 
                                        comenzando por la carrera de Tecnologías de Información y proyectándose 
                                        hacia el resto de la comunidad estudiantil
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!--Team Section -->

        <section id="team" class="team section-padding">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="section-header text-center pb-5" data-aos="fade-up" data-aos-duration="1500">
                            <h2>Desarrolladores</h2>
                        </div>
                    </div>
                </div>
                <div class="row" data-aos="fade-up" data-aos-duration="1500">
                    <div class="col-12 col-md-6 col-lg-4 card-team">
                        <div class="card text-center">
                            <div class="card-body">
                                <img src="Imagenes/team-1.jpg" class="img-fluid rounded-circle imgteam" />
                                <h3 class="card-title py-2">Bruno Gómez</h3>

                                <p class="socials">
                                    <i class="bi bi-twitter text-dark mx-1"></i>
                                    <i class="bi bi-facebook text-dark mx-1"></i>
                                    <i class="bi bi-instagram text-dark mx-1"></i>
                                    <i class="bi bi-linkedin text-dark mx-1"></i>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-md-6 col-lg-4 card-team">
                        <div class="card text-center">
                            <div class="card-body">
                                <img src="Imagenes/team-2.jpeg" class="img-fluid rounded-circle imgteam" />
                                <h3 class="card-title py-2">America Quiroz</h3>

                                <p class="socials">
                                    <i class="bi bi-twitter text-dark mx-1"></i>
                                    <i class="bi bi-facebook text-dark mx-1"></i>
                                    <i class="bi bi-instagram text-dark mx-1"></i>
                                    <i class="bi bi-linkedin text-dark mx-1"></i>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-md-6 col-lg-4 card-team">
                        <div class="card text-center">
                            <div class="card-body">
                                <img src="Imagenes/team-3.jpeg" class="img-fluid rounded-circle imgteam" />
                                <h3 class="card-title py-2">Juan Pablo Velez</h3>

                                <p class="socials">
                                    <i class="bi bi-twitter text-dark mx-1"></i>
                                    <i class="bi bi-facebook text-dark mx-1"></i>
                                    <i class="bi bi-instagram text-dark mx-1"></i>
                                    <i class="bi bi-linkedin text-dark mx-1"></i>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-md-6 col-lg-4">
                        <div class="card text-center">
                            <div class="card-body">
                                <img src="Imagenes/team-4.jpg" class="img-fluid rounded-circle imgteam" />
                                <h3 class="card-title py-2">Israel Cerezo</h3>

                                <p class="socials">
                                    <i class="bi bi-twitter text-dark mx-1"></i>
                                    <i class="bi bi-facebook text-dark mx-1"></i>
                                    <i class="bi bi-instagram text-dark mx-1"></i>
                                    <i class="bi bi-linkedin text-dark mx-1"></i>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-md-6 col-lg-4">
                        <div class="card text-center">
                            <div class="card-body">
                                <img src="Imagenes/team-4.jpg" class="img-fluid rounded-circle imgteam" />
                                <h3 class="card-title py-2">Adolfo Pomposo</h3>

                                <p class="socials">
                                    <i class="bi bi-twitter text-dark mx-1"></i>
                                    <i class="bi bi-facebook text-dark mx-1"></i>
                                    <i class="bi bi-instagram text-dark mx-1"></i>
                                    <i class="bi bi-linkedin text-dark mx-1"></i>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-md-6 col-lg-4">
                        <div class="card text-center">
                            <div class="card-body">
                                <img src="Imagenes/team-4.jpg" class="img-fluid rounded-circle imgteam" />
                                <h3 class="card-title py-2">Yamilex Lara</h3>
                                <p class="socials">
                                    <i class="bi bi-twitter text-dark mx-1"></i>
                                    <i class="bi bi-facebook text-dark mx-1"></i>
                                    <i class="bi bi-instagram text-dark mx-1"></i>
                                    <i class="bi bi-linkedin text-dark mx-1"></i>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- Contact Section -->

        <section id="contact" class="contact section-padding">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="section-header text-center pb-5" data-aos="fade-up" data-aos-duration="1500">
                            <h2>Contactanos</h2>
                        </div>
                    </div>
                </div>

                <div class="row m-0">
                    <div class="col-md-12 p-0 pt-4 pb-4">
                        <form action="#" class="bg-light p-4.m-auto" data-aos="fade-up" data-aos-duration="1500">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="mb-3">
                                        <input type="text" class="form-control" required placeholder="Nombre Completo" />
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="mb-3">
                                        <input type="email" class="form-control" required placeholder="Correo Electronico" />
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="mb-3">
                                        <textarea rows="3" required class="form-control" placeholder="Tu Consulta Aqui"></textarea>
                                    </div>
                                </div>

                                <button class="btn btn-warning btn-lg btn-block mt-3">Enviar</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </section>

        <!-- footer -->

        <footer class="bg-dark p-2 text-center">
            <div class="container">
                <p class="text-white">All Right Reserved @Webside Name</p>
            </div>
        </footer>
    <script src="https://unpkg.com/aos@2.3.1/dist/aos.js"></script>
    <script>
        AOS.init();
    </script>
</asp:content> 
