using System;
using System.Collections.Generic;
using System.Linq;

    namespace Controllers {

        public class Saldo {
            public static void AdicionaSaldo (int id, int produtoId, int almoxarifadoId, int quantidade) 
            {
                try {   
                    Models.Saldo.AdicionaSaldo(new Models.Saldo(id, produtoId, almoxarifadoId, quantidade));
                } catch {
                    throw new Exception("ERRO");
                }
            }

            public static void AlteraSaldo (int id, int produtoId, int almoxarifadoId, int quantidade) 
            {
                Models.Saldo.AlteraSaldo(id, produtoId, almoxarifadoId, quantidade);
            }
    
            public static void RemoveSaldo (int id) 
            {
                Models.Saldo.RemoveSaldo(id);
            }

         
            public static List<Models.Saldo> ListaSaldos () 
            {
                return Models.Saldo.ListaSaldos();
            }
        }
    }