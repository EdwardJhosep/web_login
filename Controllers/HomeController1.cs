using Microsoft.AspNetCore.Mvc;
using MI_WEB.Data;
using MI_WEB.Models;
using System.Linq;
using MI_WEB.Data;

namespace MI_WEB.Controllers
{
    public class RegistroController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistroController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Crear un nuevo usuario y guardarlo en la base de datos
                var usuario = new Usuario
                {
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    CorreoElectronico = model.Correo,
                    ContraseñaHash = HashPassword(model.Contraseña), // Debes implementar una función para hacer el hash de la contraseña
                    Salt = GenerateSalt() // Debes implementar una función para generar un salt
                };

                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

                // Redirigir al usuario a una página de éxito o cualquier otra página
                return RedirectToAction("RegistroExitoso");
            }

            return View(model);
        }

        // Otras acciones y métodos auxiliares aquí
    }
}
