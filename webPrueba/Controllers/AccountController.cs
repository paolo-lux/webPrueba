using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webPrueba.Models;
using webPrueba.Helpers;
using System.Security.Claims;
using Newtonsoft.Json;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using webPrueba.Clases;
using webPrueba.DataAccess.Security;

namespace webPrueba.Controllers
{
    public class AccountController : Controller
    {

        /// <summary>
        /// Pantalla principal en la cual se inicia sesión
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult LogOn()
        {
            AccountVM model = new AccountVM();
            return View(model);
        }
        /// <summary>
        // Metodo Post para iniciar sesión
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult LogOn(AccountVM model)
        {
            //Valida que el usuario exista en la base de datos
            AccountVM userData =  daSecurity.ValidateLogin(model.usuarioID);
            //Valida el Hash del usuario
            //string Hash = Security.getHash(model.password + model.Salt);
            //Si el Hash es correcto inicia sesión
            //if (Hash == model.Hash)
            if(model.usuarioID == "admin")
            {
               
                IdentitySignin(userData, true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Result"] = new ResultViewModel
                {
                    Success = false,
                    Message = "Usuario o contraseña incorrectos"
                };

                return View();
            }
        }
        /// <summary>
        /// Evento llamado por la pantalla para cerrar la sesión del cliente.
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOff()
        {
            IdentitySignout();
            return RedirectToAction("LogOn");
        }
        /// <summary>
        /// Metodo que guarda la información en Claims y lo prepara para guardarlo en una cookie.
        /// </summary>
        /// <param name="appUserState">Clase cin la información del Cliente</param>
        /// <param name="providerKey">llave de Encriptación</param>
        /// <param name="isPersistent">Identifica si la cookie va a vivir fuera del login</param>
        public void IdentitySignin(AccountVM appUserState, bool isPersistent = false)
        {
            var claims = new List<Claim>();

            // Crea los Claims en donde se guardara la información en la Cookie
            claims.Add(new Claim(ClaimTypes.NameIdentifier, appUserState.usuarioID));
            claims.Add(new Claim(ClaimTypes.Name, appUserState.nombre));
            claims.Add(new Claim(ClaimTypes.Email, appUserState.correo));


            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
            //Crea la Cookie con la información de la sesión
            AuthenticationManager.SignIn(new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = isPersistent,
                ExpiresUtc = DateTime.UtcNow.AddHours(2)
            }, identity);
        }

        /// <summary>
        /// Termina la sesión del Usuario
        /// </summary>
        public void IdentitySignout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie,
                                            DefaultAuthenticationTypes.ExternalCookie);
        }
        /// <summary>
        /// Define el metodo de autentificación
        /// </summary>
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}