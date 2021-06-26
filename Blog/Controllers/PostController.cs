using Blog.DAO;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{

    public class PostController : Controller
    {

        //dominio/Post/Index
        [HttpGet]
        public IActionResult Index()
        {
            PostDAO dao = new PostDAO();
            var listaDePost = dao.Listar();
            return View(listaDePost); // view tipada
        }

        //dominio/Post/Novo
        [HttpGet]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(Post post)
        {
            PostDAO dao = new PostDAO();
            dao.Adicionar(post);
            return RedirectToAction("Index");
        }

        public IActionResult Categoria([Bind(Prefix = "id")] string categoria)
        {
            PostDAO dao = new PostDAO();
            var listaDePostFiltrada = dao.FiltrarPorCategoria(categoria);
            return View("Index", listaDePostFiltrada);
        }

        public IActionResult Remover(int id)
        {
            PostDAO dao = new PostDAO();
            dao.Remover(id);
            return RedirectToAction("Index");
        }

        public IActionResult Visualizar(int id)
        {
            PostDAO dao = new PostDAO();
            var post = dao.BuscarPorId(id);
            return View(post);
        }

        [HttpPost]
        public IActionResult EditarPost(Post post)
        {
            PostDAO dao = new PostDAO();
            dao.Atualizar(post);
            return RedirectToAction("Index");
        }

        public IActionResult PublicarPost(int id)
        {
            PostDAO dao = new PostDAO();
            dao.Publicar(id);
            return RedirectToAction("Index");
        }
    }
}
