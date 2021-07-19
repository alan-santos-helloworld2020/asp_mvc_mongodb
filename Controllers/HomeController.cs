using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sistema.Models;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace sistema.Controllers
{

    public class HomeController : Controller
    {


        Banco db = new Banco();
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Cadastro()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Clientes model)
        {
            model.data = DateTime.Now.ToString("dd/MM/yyyy");

            if (ModelState.IsValid)
            {
                db.salvar(model);
                return RedirectToAction("Clientes");
            }
            return View(model);
        }

        public IActionResult Clientes()
        {
            return View(db.listar());
        }

        public IActionResult ListarId(string id)
        {
            return View(db.listarId(id));
        }

        [HttpGet]
        [Route("/Homer/Deletar/{id}")]
        public IActionResult Deletar(string id)
        {
            Console.WriteLine(id);
            db.deletar(id);
            return RedirectToAction("Clientes");
        }

        public IActionResult Editar(Clientes cl){

            Console.WriteLine(cl.nome);
            

            return RedirectToAction("Clientes");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
