using System;
using System.Windows.Forms;

namespace Views {
    
    public class Produtos {
        
        public static void ListarProduto() {
            Form produtos = new Form();
            produtos.Text = "PRODUTOS";
            produtos.Size = new System.Drawing.Size(400, 384);
            produtos.StartPosition = FormStartPosition.CenterScreen;
            produtos.FormBorderStyle = FormBorderStyle.FixedSingle;
            produtos.MaximizeBox = false;
            produtos.MinimizeBox = false;

            ListView listaProduto = new ListView();
            listaProduto.Size = new System.Drawing.Size(376, 300);
            listaProduto.Location = new System.Drawing.Point(4, 0);
            listaProduto.View = View.Details;
            listaProduto.Columns.Add("Id", 50);
            listaProduto.Columns.Add("Nome", 230);
            listaProduto.Columns.Add("Preço", 92);
            listaProduto.FullRowSelect = true;
            listaProduto.GridLines = true;

            foreach (Models.Produto produto in Controllers.Produto.ListarProdutos()) {
                ListViewItem item = new ListViewItem(produto.id.ToString());
                item.SubItems.Add(produto.nome);
                item.SubItems.Add(produto.preco.ToString());
                listaProduto.Items.Add(item);
            }

            Button btnProduto = new Button();
            btnProduto.Text = "Adicionar";
            btnProduto.Top = 300;
            btnProduto.Left = 4;
            btnProduto.Size = new System.Drawing.Size(90, 25);
            btnProduto.Click += (sender, e) => {
                produtos.Close();
                produtos.Dispose();
                AdicionarProduto();   
            };
            
            
            Button btnEdit = new Button();
            btnEdit.Text = "Editar";
            btnEdit.Top = 300;
            btnEdit.Left = 100;
            btnEdit.Size = new System.Drawing.Size(90, 25);
            btnEdit.Click += (sender, e) => {
                string id = listaProduto.SelectedItems[0].Text;
                produtos.Close();
                produtos.Dispose();
                EditarProduto(Int32.Parse(id));
                produtos.Close();
            };


            Button BtnRemove = new Button();
            BtnRemove.Text = "Remove";
            BtnRemove.Top = 300;
            BtnRemove.Left = 195;
            BtnRemove.Size = new System.Drawing.Size(90, 25);
            BtnRemove.Click += (sender, e) => {
                string id = listaProduto.SelectedItems[0].Text;
                RemoveProduto(Int32.Parse(id));
                produtos.Dispose();
                produtos.Close();  
            };

            Button BtnVoltar = new Button();
            BtnVoltar.Text = "Voltar";
            BtnVoltar.Top = 300;
            BtnVoltar.Left = 290;
            BtnVoltar.Size = new System.Drawing.Size(90, 25);
            BtnVoltar.Click += (sender, e) => {
                produtos.Hide();
                produtos.Close();
                produtos.Dispose();
            };

            produtos.Controls.Add(listaProduto);
            produtos.Controls.Add(btnProduto);
            produtos.Controls.Add(btnEdit);
            produtos.Controls.Add(BtnRemove);
            produtos.Controls.Add(BtnVoltar);
            produtos.ShowDialog();
        } 

          public static void AdicionarProduto() {
            Form adicionarProduto = new Form();
            adicionarProduto.Text = "Adicionar Produto";
            adicionarProduto.Size = new System.Drawing.Size(235, 195);
            adicionarProduto.StartPosition = FormStartPosition.CenterScreen;
            adicionarProduto.FormBorderStyle = FormBorderStyle.FixedSingle;
            adicionarProduto.MaximizeBox = false;
            adicionarProduto.MinimizeBox = false;

            Label lblId= new Label();
            lblId.Text = "Id:";
            lblId.Top = 25;
            lblId.Left = 10;
            lblId.Size = new System.Drawing.Size(100, 25);

            TextBox txtId = new TextBox();
            txtId.Top = 25;
            txtId.Left = 110;
            txtId.Size = new System.Drawing.Size(100, 25);


            Label lblNome = new Label();
            lblNome.Text = "Nome:";
            lblNome.Top = 60;
            lblNome.Left = 10;
            lblNome.Size = new System.Drawing.Size(100, 25);

            TextBox txtNome = new TextBox();
            txtNome.Top = 60;
            txtNome.Left = 110;
            txtNome.Size = new System.Drawing.Size(100, 25);

            Label lblPreco = new Label();
            lblPreco.Text = "Preço:";
            lblPreco.Top = 95;
            lblPreco.Left = 10;
            lblPreco.Size = new System.Drawing.Size(100, 25);

            TextBox txtPreco = new TextBox();
            txtPreco.Top = 95;
            txtPreco.Left = 110;
            txtPreco.Size = new System.Drawing.Size(100, 25);

            Button btnSalvar = new Button();
            btnSalvar.Text = "Salvar";
            btnSalvar.Top = 127;
            btnSalvar.Left = 10;
            btnSalvar.Size = new System.Drawing.Size(100, 25);
            btnSalvar.Click += (sender, e) => {
                try
                {
                    Controllers.Produto.AdicionaProduto(int.Parse(txtId.Text), txtNome.Text, int.Parse(txtPreco.Text));
                    adicionarProduto.Hide();
                    adicionarProduto.Close();
                    adicionarProduto.Dispose();
                    ListarProduto();
                }
                catch
                {
                    MessageBox.Show("Erro ao adicionar produto");
                }
                finally 
                {
                    adicionarProduto.Hide();
                    adicionarProduto.Close();
                    adicionarProduto.Dispose();
                    ListarProduto();                    
                }
                               
            };

            Button btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.Top = 127;
            btnCancelar.Left = 110;
            btnCancelar.Size = new System.Drawing.Size(100, 25);
            btnCancelar.Click += (sender, e) => {
                adicionarProduto.Close();
            };

            adicionarProduto.Controls.Add(lblId);
            adicionarProduto.Controls.Add(txtId);
            adicionarProduto.Controls.Add(lblNome);
            adicionarProduto.Controls.Add(txtNome);
            adicionarProduto.Controls.Add(lblPreco);
            adicionarProduto.Controls.Add(txtPreco);
            adicionarProduto.Controls.Add(btnSalvar);
            adicionarProduto.Controls.Add(btnCancelar);
            adicionarProduto.ShowDialog();
        }


        public static void EditarProduto(int id) {
            
            Form editar = new Form();
            editar.Text = "Editar Produto";
            editar.Size = new System.Drawing.Size(235, 195);
            editar.StartPosition = FormStartPosition.CenterScreen;
            editar.FormBorderStyle = FormBorderStyle.FixedSingle;
            editar.MaximizeBox = false;
            editar.MinimizeBox = false;

          

            Label lblNome = new Label();
            lblNome.Text = "Nome";
            lblNome.Top = 60;
            lblNome.Left = 10;
            lblNome.Size = new System.Drawing.Size(100, 25);

            TextBox txtNome = new TextBox();
            txtNome.Top = 60;
            txtNome.Left = 110;
            txtNome.Size = new System.Drawing.Size(100, 25);
     

            Label lblPreco = new Label();
            lblPreco.Text = "Preço";
            lblPreco.Top = 95;
            lblPreco.Left = 10;
            lblPreco.Size = new System.Drawing.Size(100, 25);

            TextBox txtPreco = new TextBox();
            txtPreco.Top = 95;
            txtPreco.Left = 110;
            txtPreco.Size = new System.Drawing.Size(100, 25);
            

            Button btnSalvar = new Button();
            btnSalvar.Text = "Salvar";
            btnSalvar.Top = 127;
            btnSalvar.Left = 10;
            btnSalvar.Size = new System.Drawing.Size(100, 25);
            btnSalvar.Click += (sender, e) => {
                Controllers.Produto.AlteraProduto(id, txtNome.Text, int.Parse(txtPreco.Text));
                editar.Hide();
                editar.Close();
                editar.Dispose();
                ListarProduto();
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

       
            editar.Controls.Add(lblNome);
            editar.Controls.Add(txtNome);
            editar.Controls.Add(lblPreco);
            editar.Controls.Add(txtPreco);
            editar.Controls.Add(btnSalvar);
            editar.Controls.Add(btnCancelar);
            editar.ShowDialog();
    }


    public static void RemoveProduto(int id) {

        Form remove = new Form();
        remove.Text = "Remover Produto";
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
            Controllers.Produto.RemoveProduto(id);
            remove.Close();
            remove.Dispose();
            ListarProduto();          
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
            ListarProduto();
        };

        remove.Controls.Add(sim);
        remove.Controls.Add(nao);   
        remove.ShowDialog();
    }
    }
}