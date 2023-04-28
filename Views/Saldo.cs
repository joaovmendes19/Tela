using System;
using System.Windows.Forms;

namespace Views {
    
    public class Saldos {
        
        public static void ListarSaldo() {
            Form saldos = new Form();
            saldos.Text = "SALDO";
            saldos.Size = new System.Drawing.Size(400, 384);
            saldos.StartPosition = FormStartPosition.CenterScreen;
            saldos.FormBorderStyle = FormBorderStyle.FixedSingle;
            saldos.MaximizeBox = false;
            saldos.MinimizeBox = false;

            ListView listaSaldo = new ListView();
            listaSaldo.Size = new System.Drawing.Size(376, 300);
            listaSaldo.Location = new System.Drawing.Point(4, 0);
            listaSaldo.View = View.Details;
            listaSaldo.Columns.Add("Id", 50);
            listaSaldo.Columns.Add("Id Produto", 90);
            listaSaldo.Columns.Add("Id Almoxarifado", 120);
            listaSaldo.Columns.Add("Quantidade", 112);
            listaSaldo.FullRowSelect = true;
            listaSaldo.GridLines = true;

            List<Models.Saldo> saldosList = Controllers.Saldo.ListaSaldos();
            foreach (Models.Saldo saldo in saldosList) {
                ListViewItem item = new ListViewItem(saldo.id.ToString());
                item.SubItems.Add(saldo.ProdutoId.ToString());
                item.SubItems.Add(saldo.AlmoxerifadoId.ToString());
                item.SubItems.Add(saldo.Quantidade.ToString());
                listaSaldo.Items.Add(item);
            }

            Button btnSaldo = new Button();
            btnSaldo.Text = "Adicionar";
            btnSaldo.Top = 300;
            btnSaldo.Left = 4;
            btnSaldo.Size = new System.Drawing.Size(90, 25);
            btnSaldo.Click += (sender, e) => {
                saldos.Close();
                saldos.Dispose();
                AdicionarSaldo();   
            };
            
            
            Button btnEdit = new Button();
            btnEdit.Text = "Editar";
            btnEdit.Top = 300;
            btnEdit.Left = 100;
            btnEdit.Size = new System.Drawing.Size(90, 25);
            btnEdit.Click += (sender, e) => {
                string id = listaSaldo.SelectedItems[0].Text;
                saldos.Close();
                saldos.Dispose();
                EditarSaldo(Int32.Parse(id));
                saldos.Close();
            };


            Button BtnRemove = new Button();
            BtnRemove.Text = "Remove";
            BtnRemove.Top = 300;
            BtnRemove.Left = 195;
            BtnRemove.Size = new System.Drawing.Size(90, 25);
            BtnRemove.Click += (sender, e) => {
                string id = listaSaldo.SelectedItems[0].Text;
                RemoveSaldo(Int32.Parse(id));
                saldos.Dispose();
                saldos.Close();  
            };

            Button BtnVoltar = new Button();
            BtnVoltar.Text = "Voltar";
            BtnVoltar.Top = 300;
            BtnVoltar.Left = 290;
            BtnVoltar.Size = new System.Drawing.Size(90, 25);
            BtnVoltar.Click += (sender, e) => {
                saldos.Hide();
                saldos.Close();
                saldos.Dispose();
            };

            saldos.Controls.Add(listaSaldo);
            saldos.Controls.Add(btnSaldo);
            saldos.Controls.Add(btnEdit);
            saldos.Controls.Add(BtnRemove);
            saldos.Controls.Add(BtnVoltar);
            saldos.ShowDialog();
        } 

          public static void AdicionarSaldo() {
            Form adicionarSaldo = new Form();
            adicionarSaldo.Text = "Adicionar Saldo";
            adicionarSaldo.Size = new System.Drawing.Size(235, 195);
            adicionarSaldo.StartPosition = FormStartPosition.CenterScreen;
            adicionarSaldo.FormBorderStyle = FormBorderStyle.FixedSingle;
            adicionarSaldo.MaximizeBox = false;
            adicionarSaldo.MinimizeBox = false;

            Label lblId= new Label();
            lblId.Text = "Id:";
            lblId.Top = 10;
            lblId.Left = 10;
            lblId.Size = new System.Drawing.Size(100, 25);

            TextBox txtId = new TextBox();
            txtId.Top = 10;
            txtId.Left = 110;
            txtId.Size = new System.Drawing.Size(100, 25);

            Label lblIdProduto = new Label();
            lblIdProduto.Text = "Id Produto:";
            lblIdProduto.Top = 40;
            lblIdProduto.Left = 10;
            lblIdProduto.Size = new System.Drawing.Size(100, 25);

            TextBox txtIdProduto = new TextBox();
            txtIdProduto.Top = 40;
            txtIdProduto.Left = 110;
            txtIdProduto.Size = new System.Drawing.Size(100, 25);

            Label lblIdAlmox = new Label();
            lblIdAlmox.Text = "Id Almoxarifado:";
            lblIdAlmox.Top = 70;
            lblIdAlmox.Left = 10;
            lblIdAlmox.Size = new System.Drawing.Size(100, 25);

            TextBox txtIdAlmox = new TextBox();
            txtIdAlmox.Top = 70;
            txtIdAlmox.Left = 110;
            txtIdAlmox.Size = new System.Drawing.Size(100, 25);

            Label lblQuantidade = new Label();
            lblQuantidade.Text = "Quantidade:";
            lblQuantidade.Top = 100;
            lblQuantidade.Left = 10;
            lblQuantidade.Size = new System.Drawing.Size(100, 25);

            TextBox txtQuantidade = new TextBox();
            txtQuantidade.Top = 100;
            txtQuantidade.Left = 110;
            txtQuantidade.Size = new System.Drawing.Size(100, 25);

            Button btnSalvar = new Button();
            btnSalvar.Text = "Salvar";
            btnSalvar.Top = 127;
            btnSalvar.Left = 10;
            btnSalvar.Size = new System.Drawing.Size(100, 25);
            btnSalvar.Click += (sender, e) => {
                try
                {
                    Controllers.Saldo.AdicionaSaldo(int.Parse(txtId.Text), int.Parse(txtIdProduto.Text), int.Parse(txtIdAlmox.Text), int.Parse(txtQuantidade.Text));
                    adicionarSaldo.Hide();
                    adicionarSaldo.Close();
                    adicionarSaldo.Dispose();
                    ListarSaldo();
                }
                catch
                {
                    MessageBox.Show("Erro ao adicionar saldo");
                }
                finally 
                {
                    adicionarSaldo.Hide();
                    adicionarSaldo.Close();
                    adicionarSaldo.Dispose();
                    ListarSaldo();                    
                }
                               
            };

            Button btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.Top = 127;
            btnCancelar.Left = 110;
            btnCancelar.Size = new System.Drawing.Size(100, 25);
            btnCancelar.Click += (sender, e) => {
            adicionarSaldo.Close();
            };

            adicionarSaldo.Controls.Add(lblId);
            adicionarSaldo.Controls.Add(txtId);
            adicionarSaldo.Controls.Add(lblIdProduto);
            adicionarSaldo.Controls.Add(txtIdProduto);
            adicionarSaldo.Controls.Add(lblIdAlmox);
            adicionarSaldo.Controls.Add(txtIdAlmox);
            adicionarSaldo.Controls.Add(lblQuantidade);
            adicionarSaldo.Controls.Add(txtQuantidade);
            adicionarSaldo.Controls.Add(btnSalvar);
            adicionarSaldo.Controls.Add(btnCancelar);
            adicionarSaldo.ShowDialog();
        }


        public static void EditarSaldo(int id) {
           
            Form editar = new Form();
            editar.Text = "Editar Saldo";
            editar.Size = new System.Drawing.Size(235, 195);
            editar.StartPosition = FormStartPosition.CenterScreen;
            editar.FormBorderStyle = FormBorderStyle.FixedSingle;
            editar.MaximizeBox = false;
            editar.MinimizeBox = false;

            Label lblId= new Label();
            lblId.Text = "Id";
            lblId.Top = 10;
            lblId.Left = 10;
            lblId.Size = new System.Drawing.Size(100, 25);

            TextBox txtId = new TextBox();
            txtId.Top = 10;
            txtId.Left = 110;
            txtId.Size = new System.Drawing.Size(100, 25);
            

            Label lblIdAlmox = new Label();
            lblIdAlmox.Text = "Id Produto";
            lblIdAlmox.Top = 40;
            lblIdAlmox.Left = 10;
            lblIdAlmox.Size = new System.Drawing.Size(100, 25);

            TextBox txtIdAlmox = new TextBox();
            txtIdAlmox.Top = 40;
            txtIdAlmox.Left = 110;
            txtIdAlmox.Size = new System.Drawing.Size(100, 25);
            

            Label lblIdProduto = new Label();
            lblIdProduto.Text = "Id Almoxarifado";
            lblIdProduto.Top = 70;
            lblIdProduto.Left = 10;
            lblIdProduto.Size = new System.Drawing.Size(100, 25);

            TextBox txtIdProduto = new TextBox();
            txtIdProduto.Top = 70;
            txtIdProduto.Left = 110;
            txtIdProduto.Size = new System.Drawing.Size(100, 25);
            
            
            Label lblQuantidade = new Label();
            lblQuantidade.Text = "Quantidade";
            lblQuantidade.Top = 100;
            lblQuantidade.Left = 10;
            lblQuantidade.Size = new System.Drawing.Size(100, 25);

            TextBox txtQuantidade = new TextBox();
            txtQuantidade.Top = 100;
            txtQuantidade.Left = 110;
            txtQuantidade.Size = new System.Drawing.Size(100, 25);
            

            Button btnSalvar = new Button();
            btnSalvar.Text = "Salvar";
            btnSalvar.Top = 127;
            btnSalvar.Left = 10;
            btnSalvar.Size = new System.Drawing.Size(100, 25);
            btnSalvar.Click += (sender, e) => {
                Controllers.Saldo.AlteraSaldo(int.Parse(txtId.Text), int.Parse(txtIdAlmox.Text), int.Parse(txtIdProduto.Text), int.Parse(txtQuantidade.Text));
                editar.Hide();
                editar.Close();
                editar.Dispose();
                ListarSaldo();
            };

            Button btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.Top = 127;
            btnCancelar.Left = 110;
            btnCancelar.Size = new System.Drawing.Size(100, 25);
            btnCancelar.Click += (sender, e) => {
                editar.Close();
                editar.Dispose();
            };

            editar.Controls.Add(lblId);
            editar.Controls.Add(txtId);
            editar.Controls.Add(lblIdAlmox);
            editar.Controls.Add(txtIdAlmox);
            editar.Controls.Add(lblIdProduto);
            editar.Controls.Add(txtIdProduto);
            editar.Controls.Add(lblQuantidade);
            editar.Controls.Add(txtQuantidade);
            editar.Controls.Add(btnSalvar);
            editar.Controls.Add(btnCancelar);
            editar.ShowDialog();
    }


    public static void RemoveSaldo(int id) {

        Form remove = new Form();
        remove.Text = "Remover Saldo";
        remove.Size = new System.Drawing.Size(188, 83);
        remove.StartPosition = FormStartPosition.CenterScreen;
        remove.FormBorderStyle = FormBorderStyle.FixedSingle;
        remove.MaximizeBox = false;
        remove.MinimizeBox = false;

        Button sim = new Button();
        sim.Text = "Sim";
        sim.Top = 10;
        sim.Left = 10;
        sim.Size = new System.Drawing.Size(70, 25);
        sim.Click += (sender, e) => {
            Controllers.Saldo.RemoveSaldo(id);
            remove.Close();
            remove.Dispose();
            ListarSaldo();          
        };

        Button nao = new Button();
        nao.Text = "Não";
        nao.Top = 10;
        nao.Left = 90;
        nao.Size = new System.Drawing.Size(70, 25);
        nao.Click += (sender, e) => {
            remove.Hide();
            remove.Close();
            remove.Dispose();
            ListarSaldo();
        };

        remove.Controls.Add(sim);
        remove.Controls.Add(nao);   
        remove.ShowDialog();
    }
    }
}