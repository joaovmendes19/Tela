using System;
using System.Collections.Generic;   
using System.Linq;
using System.Threading.Tasks;
using Repository;

namespace Models {

    public class Saldo {
        public int id { get; set; }
        //public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
        //public Almoxarifado Almoxerifado { get; set; }
        public int AlmoxerifadoId { get; set; }
        public int Quantidade { get; set; }

        public static List<Saldo> Saldos { get; set; } = new List<Saldo>();

        

        public Saldo(int id, int produtoId, int almoxarifadoId, int quantidade) {
            this.id = id;
            this.ProdutoId = produtoId;
            this.AlmoxerifadoId = almoxarifadoId;
            this.Quantidade = quantidade;
        }

        public Saldo() {}
        
            public override string ToString() {
            return "Saldo{" +
            "id=" + id +
            ", idProduto=" + ProdutoId +
            ", AlmoxerifadoId=" + AlmoxerifadoId +
            ", Quantidade=" + Quantidade +
            '}';
            }

        public static void AlteraSaldo (int id, int produtoId, int almoxarifadoId, int quantidade) 
        {
            try{
                using (Context ctx = new Context()) {
                    Saldo saldo = ctx.Saldos.Find(id);
                    saldo.ProdutoId = produtoId;
                    saldo.AlmoxerifadoId = almoxarifadoId;
                    saldo.Quantidade = quantidade;
                    ctx.Saldos.Update(saldo);
                    ctx.SaveChanges();
                }
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
        

        

        public static void RemoveSaldo (int id) 
        {
            try{
                using (Context ctx = new Context()) {
                    Saldo saldo = ctx.Saldos.Find(id);
                    ctx.Saldos.Remove(saldo);
                    ctx.SaveChanges();
                }
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public static void AdicionaSaldo (Saldo saldo) 
        {
            try{
                using (Context ctx = new Context()) {
                    ctx.Saldos.Add(saldo);
                    ctx.SaveChanges();
                }
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }   

        public static List<Saldo> ListaSaldos () 
        {
            try{
                using (Context ctx = new Context()) {
                    return ctx.Saldos.ToList();
                }
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }   
    }
}