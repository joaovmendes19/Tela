using System;
using System.Collections.Generic;   
using System.Linq;
using System.Threading.Tasks;
using Repository;


namespace Models {
    public class Produto {
        public int id { get; set; }
        public string nome { get; set; }
        public float preco { get; set; }

        public static List<Produto> Produtos { get; set; } = new List<Produto>();

        public Produto(int id, string nome, float preco) {
            this.id = id;
            this.nome = nome;
            this.preco = preco;
        }

        public Produto() {}

        public override string ToString() {
            return "Produto{" +
                    "id=" + id +
                    ", nome='" + nome + '\'' +
                    ", preco=" + preco +
                    '}';
        }

        public static void AlteraProduto ( int id, string novoNome, float preco) 
        {
            

            
            

        }

        public static Produto BuscaProduto (int id) 
        {
            Produto? produto = Produtos.Find(p => p.id == id);
            if (produto == null) {
                throw new Exception("Produto não encontrado");
            }

            return produto;
        }

        public static void RemoveProduto (int id) 
        {
            try{
                using (Context ctx = new Context()) {
                    var produto = ctx.Produtos.Find(id);
                    ctx.Produtos.Remove(produto);  
                    ctx.SaveChanges();
                }
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public static void AdicionaProduto (Produto produto) 
        {
            try {
                using (Context ctx = new Context()) {
                    ctx.Produtos.Add(produto);  
                    ctx.SaveChanges();
                }
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public static List<Produto> ListaProdutos () 
        {
            try {
                using (Context ctx = new Context()) {
                    return ctx.Produtos.ToList();
                }
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
    }
}