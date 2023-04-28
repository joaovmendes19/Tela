using System;
using System.Collections.Generic;   
using System.Linq;
using System.Threading.Tasks;
using Repository;

namespace Models {
    public class Almoxarifado {
        public int id { get; set; }
        public string nome { get; set; }

        public static List<Almoxarifado> Almoxarifados { get; set; } = new List<Almoxarifado>();

        public Almoxarifado(int id, string nome) {
            this.id = id;
            this.nome = nome;
        }

        public Almoxarifado() {}

        public override string ToString() {
            return "Almoxarifado{" +
                    "id=" + id +
                    ", nome='" + nome + '\'' +
                    '}';
        }

        public static void AlteraAlmoxarifado ( int id, string nome) 
        
        {
            using var context = new Context();
            var almoxarifado = context.Almoxarifados.Find(id);
            if (almoxarifado != null)
            {
                almoxarifado.nome = nome;
                context.SaveChanges();
            }
        }

        public static Almoxarifado BuscaAlmoxarifado (int id) 
        {
            Almoxarifado? almoxarifado = Almoxarifados.Find(p => p.id == id);
            if (almoxarifado == null) {
                throw new Exception("Almoxarifado não encontrado");
            }

            return almoxarifado;
        }

        public static void RemoveAlmoxarifado (int id) 
        {
           try{
                using (Context ctx = new Context()) {
                    Almoxarifado almoxarifado = ctx.Almoxarifados.Find(id);
                    ctx.Almoxarifados.Remove(almoxarifado);
                    ctx.SaveChanges();
                }
            } catch (Exception e) {
                throw new Exception(e.Message);
           }
        }

        public static void AdicionaAlmoxarifado(Almoxarifado almoxarifado)

        {  
             try {
                using (Context ctx = new Context()) {
                    ctx.Almoxarifados.Add(almoxarifado);  
                    ctx.SaveChanges();
                }
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public static List<Almoxarifado> ListaAlmoxarifados() 
        {
            try {
                using (Context ctx = new Context()) {
                    return ctx.Almoxarifados.ToList();
                }
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
}
}