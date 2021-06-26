using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Blog.Infra;
using Blog.Models;

namespace Blog.DAO
{
    public class PostDAO
    {
        // método paraq listar todos os posts...
        public IList<Post> Listar()
        {
            using (BlogContext contexto = new BlogContext())
            {
                var lista = contexto.Posts.ToList();
                return lista;
            }
        }

        public void Adicionar(Post post)
        {
            using (BlogContext contexto = new BlogContext())
            {
                contexto.Posts.Add(post);
                contexto.SaveChanges();
            }
        }

        public IList<Post> FiltrarPorCategoria(string categoria)
        {
            using (BlogContext contexto = new BlogContext())
            {
                var lista = contexto.Posts.Where(p => p.Categoria.Contains(categoria)).ToList();
                return lista;
            }
        }

        public void Remover(int id)
        {
            using (BlogContext context = new BlogContext())
            {
                // recupera o post
                var post = context.Posts.Find(id);
                context.Posts.Remove(post);
                context.SaveChanges();
            }
        }

        public Post BuscarPorId(int id)
        {
            using (BlogContext contexto = new BlogContext())
            {
                var post = contexto.Posts.Find(id);
                return post;
            }
        }

        public void Atualizar(Post post)
        {
            using (BlogContext contexto = new BlogContext())
            {
                contexto.Posts.Update(post);
                contexto.SaveChanges();
            }
        }

        public void Publicar(int id)
        {
            using (BlogContext contexto = new BlogContext())
            {
                // encontrar o post com o id desejado
                var post = contexto.Posts.Find(id);

                // atualiza os dados de publicação
                post.Publicado = true;
                post.DataPublicacao = DateTime.Now;

                // salva no banco de dados
                contexto.SaveChanges();
            }
        }
    }
}
