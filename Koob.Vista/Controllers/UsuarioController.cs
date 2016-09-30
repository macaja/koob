using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using usuario = Koob.Dominio.Usuario;
using Koob.Repositorio;
using fachada = Koob.Vista.Models;
using logInFacade = Koob.Vista.Models.LoginViewModel;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using servicio = Koob.Vista.Models.API;

namespace Koob.Vista.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioRepository usuarioRepository;

        // GET: Usuario
        public ActionResult Index()
        {
            usuarioRepository = new UsuarioRepository();
            var usuarios = usuarioRepository.ObtenerUsuarios();
            return View(usuarios);
        }
        
        // GET: Libros del usuario
        public ActionResult Libros()
        {
            
            return View();
        }

        // GET: Usuario/Details/5

        public ActionResult Details(int id)
        {
            usuarioRepository = new UsuarioRepository();
            var empleado = usuarioRepository.ObtenerPorID(id);
            return View(empleado);
        }

        [HttpGet]
        public ActionResult logIn()
        {
            return View();
        }

        //POST: Usuario/LogIn
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(logInFacade login)
        {
            if (ModelState.IsValid) //Verificar que el modelo de datos sea valido en cuanto a la definición de las propiedades
            {
                usuarioRepository = new UsuarioRepository();
                var model = usuarioRepository.logueo(login.usu_email, login.usu_password);

                if (model==true)//Verificar que el email y clave exista utilizando el método privado 
                {
                    FormsAuthentication.SetAuthCookie(login.usu_email, false); //crea variable de usuario 
                    return RedirectToAction("Index", "Home");  //dirigir controlador home vista Index una vez se a autenticado en el sistema
                }
                else
                {
                    ModelState.AddModelError("", "Datos incorrectos"); //adicionar mensaje de error al model 
                }
            }
            return View(login);
        }

        //GET: Usuario/LogOff
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(fachada.RegisterViewModel model)
        {
            try
            {
                usuarioRepository = new UsuarioRepository();
                //model.usu_codigo = 1;
                AutoMapper.Mapper.CreateMap<fachada.RegisterViewModel, Dominio.Usuario>();
               var usu = AutoMapper.Mapper.Map<Dominio.Usuario>(model);
                usuarioRepository.InsertarUsuario(usu);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
        // Get: Ingresar
        public ActionResult IngresarLibro()
        {
            CategoriasRepository categoriasRepository = new CategoriasRepository();
            var categorias = categoriasRepository.ObtenerCategorias();
            var categoriasSelect = from cat in categorias
                                   select new SelectListItem()
                                   {
                                       Text = cat.cat_nombre,
                                       Value = cat.cat_codigo.ToString()
                                   };

            ViewBag.ListItems = categoriasSelect;
            return View();
        }

        [HttpPost]
        public ActionResult IngresarLibro(fachada.Libro model)
        {
            string url = @"https://www.googleapis.com/books/v1/volumes?q=isbn:" + model.lib_isbn;
            var json = new WebClient().DownloadString(url);
            var libros = JsonConvert.DeserializeObject<servicio.Libro>(json);
            try
            {                
                int totalItems = libros.totalItems;                
                if (totalItems >= 1)
                {      
                    var t = User.Identity.Name;
                    string titulo = libros.items[0].volumeInfo.title;
                    int longitudAutores= libros.items[0].volumeInfo.authors.Count;
                    string autores = libros.items[0].volumeInfo.authors[0];
                    if (longitudAutores > 1)
                    {
                        for(int i = 1; i< longitudAutores; i++)
                        {
                            autores = autores + " , "+libros.items[0].volumeInfo.authors[i];
                        }
                    }                    
                    string imagen = libros.items[0].volumeInfo.imageLinks.smallThumbnail;
                    int longitudImagen = imagen.Length;
                    imagen = imagen.Substring(7,longitudImagen-7);
                    string sinopsis = libros.items[0].volumeInfo.description;
                    LibrosRepository librosRepository = new LibrosRepository();
                    AutoMapper.Mapper.CreateMap<fachada.Libro, Dominio.Libro>();
                    var lib = AutoMapper.Mapper.Map<Dominio.Libro>(model);
                    lib.usu_email = t;
                    lib.lib_titulo = titulo;
                    lib.lib_autores = autores;
                    lib.lib_imagen = imagen;
                    lib.lib_sinopsis = sinopsis;
                    librosRepository.InsertarLibro(lib);
                    return RedirectToAction("Index", "Libro");                    
                }
                else
                {
                    return View(model);
                }
               
            }
            catch(Exception e)
            {
                var error = e.ToString();
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
