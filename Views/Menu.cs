using System;
using System.Windows.Forms;

namespace Views {

    public class Menu {

        public static void Menus() {

            Form menu = new Form();
            menu.Text = "Menu";
            menu.Size = new System.Drawing.Size(250, 270);
            menu.StartPosition = FormStartPosition.CenterScreen;
            menu.FormBorderStyle = FormBorderStyle.FixedSingle;
            menu.MaximizeBox = false;
            menu.MinimizeBox = false;

            Button ProdutoBtn = new Button();
            ProdutoBtn.Text = "PRODUTOS";
            ProdutoBtn.AutoSize = true;
            ProdutoBtn.Location = new System.Drawing.Point(80, 35);
            ProdutoBtn.Click += (sender, e) => {
                Produtos.ListarProduto();
            };

            Button AlmoxarifadoBtn = new Button();
            AlmoxarifadoBtn.Text = "ALMOXARIFADO";
            AlmoxarifadoBtn.AutoSize = true;
            AlmoxarifadoBtn.Location = new System.Drawing.Point(80, 70);

            AlmoxarifadoBtn.Click += (sender, e) => {
                Almoxarifados.ListarAlmoxarifado();
            };

            Button saldoBtn = new Button();
            saldoBtn.Text = "SALDO";
            saldoBtn.AutoSize = true;
            saldoBtn.Location = new System.Drawing.Point(80, 105);
            saldoBtn.Click += (sender, e) => {
                Saldos.ListarSaldo();
            };
            
            Button sair = new Button();
            sair.Text = "SAIR";
            sair.AutoSize = true;
            sair.Location = new System.Drawing.Point( 80 , 140);
            sair.Click += (sender, e) => {
                menu.Close();
            };

            menu.Controls.Add(ProdutoBtn);
            menu.Controls.Add(AlmoxarifadoBtn);
            menu.Controls.Add(saldoBtn);
            menu.Controls.Add(sair);
            menu.ShowDialog();
    }
    }
}