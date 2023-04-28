using System;
using System.Collections.Generic;
using System.Linq;
using Models;

    namespace Controllers {

        public class Almoxarifado {
            public static void AdicionaAlmoxarifado (int id, string nome) 
            {
                try {   
                    Models.Almoxarifado.AdicionaAlmoxarifado(new Models.Almoxarifado(id, nome));
                } catch {
                    throw new Exception("ERRO");
                }
            }

            public static void AlteraAlmoxarifado (int id, string nome) 
            {
                Models.Almoxarifado.AlteraAlmoxarifado(id, nome);
            }
    
            public static void RemoveAlmoxarifado (int id) 
            {
                Models.Almoxarifado.RemoveAlmoxarifado(id);
            }

            public static Models.Almoxarifado BuscaAlmoxarifado (int id) 
            {
                return Models.Almoxarifado.BuscaAlmoxarifado(id);
            }
    
            public static List<Models.Almoxarifado> ListaAlmoxarifados () 
            {
                return Models.Almoxarifado.ListaAlmoxarifados();
            }
        }
    }