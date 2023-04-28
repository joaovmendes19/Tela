using System;
using System.Windows.Forms;

namespace Views {
    
    public class Almoxarifados {
        
        public static void ListarAlmoxarifado() {
            Form almoxarifados = new Form();
            almoxarifados.Text = "ALMOXARIFADO";
            almoxarifados.Size = new System.Drawing.Size(400, 384);
            almoxarifados.StartPosition = FormStartPosition.CenterScreen;
            almoxarifados.FormBorderStyle = FormBorderStyle.FixedSingle;
            almoxarifados.MaximizeBox = false;
            almoxarifados.MinimizeBox = false;

            ListView listaAlmox = new ListView();
            listaAlmox.Size = new System.Drawing.Size(376, 300);
            listaAlmox.Location = new System.Drawing.Point(4, 0);
            listaAlmox.View = View.Details;
            listaAlmox.Columns.Add("Id", 50);
            listaAlmox.Columns.Add("Nome", 322);
            listaAlmox.FullRowSelect = true;
            listaAlmox.GridLines = true;

            List<Models.Almoxarifado> almoxarifadosList = Controllers.Almoxarifado.ListaAlmoxarifados();
            foreach (Models.Almoxarifado almoxarifado in almoxarifadosList) {
                ListViewItem item = new ListViewItem(almoxarifado.id.ToString());
                item.SubItems.Add(almoxarifado.nome);
                listaAlmox.Items.Add(item);
            }

            Button btnAdd = new Button();
            btnAdd.Text = "Adicionar";
            btnAdd.Top = 300;
            btnAdd.Left = 4;
            btnAdd.Size = new System.Drawing.Size(90, 25);
            btnAdd.Click += (sender, e) => {
                almoxarifados.Close();
                almoxarifados.Dispose();
                AdicionarAlmox();   
            };
            
            
            Button btnEdit = new Button();
            btnEdit.Text = "Editar";
            btnEdit.Top = 300;
            btnEdit.Left = 100;
            btnEdit.Size = new System.Drawing.Size(90, 25);
            btnEdit.Click += (sender, e) => {
                string id = listaAlmox.SelectedItems[0].Text;
                almoxarifados.Close();
                almoxarifados.Dispose();
                EditarAlmox(Int32.Parse(id));
                almoxarifados.Close();
            };


            Button BtnRemove = new Button();
            BtnRemove.Text = "Remove";
            BtnRemove.Top = 300;
            BtnRemove.Left = 195;
            BtnRemove.Size = new System.Drawing.Size(90, 25);
            BtnRemove.Click += (sender, e) => {
                string id = listaAlmox.SelectedItems[0].Text;
                RemoverAlmox(Int32.Parse(id));
                almoxarifados.Dispose();
                almoxarifados.Close();  
            };

            Button BtnVoltar = new Button();
            BtnVoltar.Text = "Voltar";
            BtnVoltar.Top = 300;
            BtnVoltar.Left = 290;
            BtnVoltar.Size = new System.Drawing.Size(90, 25);
            BtnVoltar.Click += (sender, e) => {
                almoxarifados.Hide();
                almoxarifados.Close();
                almoxarifados.Dispose();
            };

            almoxarifados.Controls.Add(listaAlmox);
            almoxarifados.Controls.Add(btnAdd);
            almoxarifados.Controls.Add(btnEdit);
            almoxarifados.Controls.Add(BtnRemove);
            almoxarifados.Controls.Add(BtnVoltar);
            almoxarifados.ShowDialog();
        } 

            public static void AdicionarAlmox() {
            Form adicionarAlmox = new Form();
            adicionarAlmox.Text = "Adicionar Almoxarifado";
            adicionarAlmox.Size = new System.Drawing.Size(235, 163);
            adicionarAlmox.StartPosition = FormStartPosition.CenterScreen;
            adicionarAlmox.FormBorderStyle = FormBorderStyle.FixedSingle;
            adicionarAlmox.MaximizeBox = false;
            adicionarAlmox.MinimizeBox = false;

            Label lblId= new Label();
            lblId.Text = "Id";
            lblId.Top = 25;
            lblId.Left = 10;
            lblId.Size = new System.Drawing.Size(100, 25);

            TextBox txtId = new TextBox();
            txtId.Top = 25;
            txtId.Left = 110;
            txtId.Size = new System.Drawing.Size(100, 25);


            Label lblNome = new Label();
            lblNome.Text = "Nome";
            lblNome.Top = 60;
            lblNome.Left = 10;
            lblNome.Size = new System.Drawing.Size(100, 25);

            TextBox txtNome = new TextBox();
            txtNome.Top = 60;
            txtNome.Left = 110;
            txtNome.Size = new System.Drawing.Size(100, 25);

            Button btnSalvar = new Button();
            btnSalvar.Text = "Salvar";
            btnSalvar.Top = 95;
            btnSalvar.Left = 10;
            btnSalvar.Size = new System.Drawing.Size(100, 25);
            btnSalvar.Click += (sender, e) => {
                try
                {
                    Controllers.Almoxarifado.AdicionaAlmoxarifado(int.Parse(txtId.Text), txtNome.Text);
                    adicionarAlmox.Hide();
                    adicionarAlmox.Close();
                    adicionarAlmox.Dispose();
                    ListarAlmoxarifado();
                }
                catch
                {
                    MessageBox.Show("Erro ao adicionar produto");
                }
                finally 
                {
                    adicionarAlmox.Hide();
                    adicionarAlmox.Close();
                    adicionarAlmox.Dispose();
                    ListarAlmoxarifado();                    
                }
                               
            };

            Button btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.Top = 95;
            btnCancelar.Left = 110;
            btnCancelar.Size = new System.Drawing.Size(100, 25);
            btnCancelar.Click += (sender, e) => {
                adicionarAlmox.Close();
            };

            adicionarAlmox.Controls.Add(lblId);
            adicionarAlmox.Controls.Add(txtId);
            adicionarAlmox.Controls.Add(lblNome);
            adicionarAlmox.Controls.Add(txtNome);
            adicionarAlmox.Controls.Add(btnSalvar);
            adicionarAlmox.Controls.Add(btnCancelar);
            adicionarAlmox.ShowDialog();
        }


        public static void EditarAlmox(int id) {
        
            Form editar = new Form();
            editar.Text = "Editar Almoxarifado";
            editar.Size = new System.Drawing.Size(400, 400);
            editar.StartPosition = FormStartPosition.CenterScreen;
            editar.FormBorderStyle = FormBorderStyle.FixedSingle;
            editar.MaximizeBox = false;
            editar.MinimizeBox = false;

            

            

            Label lblNome = new Label();
            lblNome.Text = "Nome";
            lblNome.Top = 25;
            lblNome.Left = 0;
            lblNome.Size = new System.Drawing.Size(100, 25);

            TextBox txtNome = new TextBox();
            txtNome.Top = 25;
            txtNome.Left = 100;
            txtNome.Size = new System.Drawing.Size(100, 25);


            Button btnSalvar = new Button();
            btnSalvar.Text = "Salvar";
            btnSalvar.Top = 75;
            btnSalvar.Left = 0;
            btnSalvar.Size = new System.Drawing.Size(100, 25);
            btnSalvar.Click += (sender, e) => {
                Controllers.Almoxarifado.AlteraAlmoxarifado(id, txtNome.Text);
                editar.Hide();
                editar.Close();
                editar.Dispose();
                ListarAlmoxarifado();
            };

            Button btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.Top = 75;
            btnCancelar.Left = 100;
            btnCancelar.Size = new System.Drawing.Size(100, 25);
            btnCancelar.Click += (sender, e) => {
                editar.Close();
                editar.Dispose();
            };

            
            editar.Controls.Add(lblNome);
            editar.Controls.Add(txtNome);
            editar.Controls.Add(btnSalvar);
            editar.Controls.Add(btnCancelar);
            editar.ShowDialog();
    }


    public static void RemoverAlmox(int id) {

        Form remove = new Form();
        remove.Text = "Remover Almoxarifado";
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
            Controllers.Almoxarifado.RemoveAlmoxarifado(id);
            remove.Close();
            remove.Dispose();
            ListarAlmoxarifado();          
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
            ListarAlmoxarifado();
        };

        remove.Controls.Add(sim);
        remove.Controls.Add(nao);   
        remove.ShowDialog();
    }
    }
}