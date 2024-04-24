
namespace ProjetoControleVendas.br.com.projeto.view
{
    partial class frmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroDeClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultaDeClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFuncionarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroDeFuncionarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultaDeFuncionarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFornecedores = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroDeFornecedores = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultaDeFornecedores = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroDeProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultaDeProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVendas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNovaVenda = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHistoricoDeVendas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConfiguracoes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTrocarDeUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSairDoSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtData = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCliente,
            this.menuFuncionarios,
            this.menuFornecedores,
            this.menuProdutos,
            this.menuVendas,
            this.menuConfiguracoes});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(933, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuCliente
            // 
            this.menuCliente.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastroDeClientes,
            this.menuConsultaDeClientes});
            this.menuCliente.Image = global::ProjetoControleVendas.Properties.Resources.Custom_Icon_Design_Pretty_Office_2_Man;
            this.menuCliente.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuCliente.Name = "menuCliente";
            this.menuCliente.Size = new System.Drawing.Size(93, 36);
            this.menuCliente.Text = "Clientes";
            this.menuCliente.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // menuCadastroDeClientes
            // 
            this.menuCadastroDeClientes.Name = "menuCadastroDeClientes";
            this.menuCadastroDeClientes.Size = new System.Drawing.Size(182, 22);
            this.menuCadastroDeClientes.Text = "Cadastro de Clientes";
            this.menuCadastroDeClientes.Click += new System.EventHandler(this.menuCadastroDeClientes_Click);
            // 
            // menuConsultaDeClientes
            // 
            this.menuConsultaDeClientes.Name = "menuConsultaDeClientes";
            this.menuConsultaDeClientes.Size = new System.Drawing.Size(182, 22);
            this.menuConsultaDeClientes.Text = "Consulta de Clientes";
            this.menuConsultaDeClientes.Click += new System.EventHandler(this.menuConsultaDeClientes_Click);
            // 
            // menuFuncionarios
            // 
            this.menuFuncionarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastroDeFuncionarios,
            this.menuConsultaDeFuncionarios});
            this.menuFuncionarios.Image = global::ProjetoControleVendas.Properties.Resources.Hopstarter_Sleek_Xp_Basic_Preppy;
            this.menuFuncionarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuFuncionarios.Name = "menuFuncionarios";
            this.menuFuncionarios.Size = new System.Drawing.Size(119, 36);
            this.menuFuncionarios.Text = "Funcionários";
            this.menuFuncionarios.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // menuCadastroDeFuncionarios
            // 
            this.menuCadastroDeFuncionarios.Name = "menuCadastroDeFuncionarios";
            this.menuCadastroDeFuncionarios.Size = new System.Drawing.Size(208, 22);
            this.menuCadastroDeFuncionarios.Text = "Cadastro de Funcionários";
            this.menuCadastroDeFuncionarios.Click += new System.EventHandler(this.menuCadastroDeFuncionarios_Click);
            // 
            // menuConsultaDeFuncionarios
            // 
            this.menuConsultaDeFuncionarios.Name = "menuConsultaDeFuncionarios";
            this.menuConsultaDeFuncionarios.Size = new System.Drawing.Size(208, 22);
            this.menuConsultaDeFuncionarios.Text = "Consulta de Funcionários";
            this.menuConsultaDeFuncionarios.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // menuFornecedores
            // 
            this.menuFornecedores.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastroDeFornecedores,
            this.menuConsultaDeFornecedores});
            this.menuFornecedores.Image = global::ProjetoControleVendas.Properties.Resources.Aha_Soft_Free_Large_Boss_Caucasian_Boss;
            this.menuFornecedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuFornecedores.Name = "menuFornecedores";
            this.menuFornecedores.Size = new System.Drawing.Size(122, 36);
            this.menuFornecedores.Text = "Fornecedores";
            // 
            // menuCadastroDeFornecedores
            // 
            this.menuCadastroDeFornecedores.Name = "menuCadastroDeFornecedores";
            this.menuCadastroDeFornecedores.Size = new System.Drawing.Size(211, 22);
            this.menuCadastroDeFornecedores.Text = "Cadastro de Fornecedores";
            this.menuCadastroDeFornecedores.Click += new System.EventHandler(this.menuCadastroDeFornecedores_Click);
            // 
            // menuConsultaDeFornecedores
            // 
            this.menuConsultaDeFornecedores.Name = "menuConsultaDeFornecedores";
            this.menuConsultaDeFornecedores.Size = new System.Drawing.Size(211, 22);
            this.menuConsultaDeFornecedores.Text = "Consulta de Fornecedores";
            this.menuConsultaDeFornecedores.Click += new System.EventHandler(this.menuConsultaDeFornecedores_Click);
            // 
            // menuProdutos
            // 
            this.menuProdutos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastroDeProdutos,
            this.menuConsultaDeProdutos});
            this.menuProdutos.Image = global::ProjetoControleVendas.Properties.Resources.Custom_Icon_Design_Flatastic_2_Product;
            this.menuProdutos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuProdutos.Name = "menuProdutos";
            this.menuProdutos.Size = new System.Drawing.Size(99, 36);
            this.menuProdutos.Text = "Produtos";
            // 
            // menuCadastroDeProdutos
            // 
            this.menuCadastroDeProdutos.Name = "menuCadastroDeProdutos";
            this.menuCadastroDeProdutos.Size = new System.Drawing.Size(188, 22);
            this.menuCadastroDeProdutos.Text = "Cadastro de Produtos";
            this.menuCadastroDeProdutos.Click += new System.EventHandler(this.menuCadastroDeProdutos_Click);
            // 
            // menuConsultaDeProdutos
            // 
            this.menuConsultaDeProdutos.Name = "menuConsultaDeProdutos";
            this.menuConsultaDeProdutos.Size = new System.Drawing.Size(188, 22);
            this.menuConsultaDeProdutos.Text = "Consulta de Produtos";
            this.menuConsultaDeProdutos.Click += new System.EventHandler(this.menuConsultaDeProdutos_Click);
            // 
            // menuVendas
            // 
            this.menuVendas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNovaVenda,
            this.menuHistoricoDeVendas});
            this.menuVendas.Image = global::ProjetoControleVendas.Properties.Resources.Aha_Soft_Large_Business_Cash_register;
            this.menuVendas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuVendas.Name = "menuVendas";
            this.menuVendas.Size = new System.Drawing.Size(88, 36);
            this.menuVendas.Text = "Vendas";
            // 
            // menuNovaVenda
            // 
            this.menuNovaVenda.Name = "menuNovaVenda";
            this.menuNovaVenda.Size = new System.Drawing.Size(178, 22);
            this.menuNovaVenda.Text = "Nova Venda";
            this.menuNovaVenda.Click += new System.EventHandler(this.menuNovaVenda_Click);
            // 
            // menuHistoricoDeVendas
            // 
            this.menuHistoricoDeVendas.Name = "menuHistoricoDeVendas";
            this.menuHistoricoDeVendas.Size = new System.Drawing.Size(178, 22);
            this.menuHistoricoDeVendas.Text = "Histórico de Vendas";
            this.menuHistoricoDeVendas.Click += new System.EventHandler(this.menuHistoricoDeVendas_Click);
            // 
            // menuConfiguracoes
            // 
            this.menuConfiguracoes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTrocarDeUsuario,
            this.menuSairDoSistema});
            this.menuConfiguracoes.Image = global::ProjetoControleVendas.Properties.Resources.Dtafalonso_Android_Lollipop_Settings;
            this.menuConfiguracoes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuConfiguracoes.Name = "menuConfiguracoes";
            this.menuConfiguracoes.Size = new System.Drawing.Size(128, 36);
            this.menuConfiguracoes.Text = "Configurações";
            // 
            // menuTrocarDeUsuario
            // 
            this.menuTrocarDeUsuario.Name = "menuTrocarDeUsuario";
            this.menuTrocarDeUsuario.Size = new System.Drawing.Size(180, 22);
            this.menuTrocarDeUsuario.Text = "Trocar de Usuário";
            this.menuTrocarDeUsuario.Click += new System.EventHandler(this.menuTrocarDeUsuario_Click);
            // 
            // menuSairDoSistema
            // 
            this.menuSairDoSistema.Name = "menuSairDoSistema";
            this.menuSairDoSistema.Size = new System.Drawing.Size(180, 22);
            this.menuSairDoSistema.Text = "Sair do Sistema";
            this.menuSairDoSistema.Click += new System.EventHandler(this.menuSairDoSistema_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.txtData,
            this.toolStripStatusLabel3,
            this.txtHora,
            this.toolStripStatusLabel5,
            this.txtUsuario});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(933, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(65, 17);
            this.toolStripStatusLabel1.Text = "Data Atual:";
            // 
            // txtData
            // 
            this.txtData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(75, 17);
            this.txtData.Text = "17/08/2023";
            this.txtData.Click += new System.EventHandler(this.txtData_Click);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusLabel3.Text = "Hora Atual:";
            // 
            // txtHora
            // 
            this.txtHora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(39, 17);
            this.txtHora.Text = "10:30";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(93, 17);
            this.toolStripStatusLabel5.Text = "Usuário Logado:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(33, 17);
            this.txtUsuario.Text = "Filipi";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(933, 450);
            this.ControlBox = false;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMenu";
            this.Text = "Menu Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuCliente;
        private System.Windows.Forms.ToolStripMenuItem menuCadastroDeClientes;
        private System.Windows.Forms.ToolStripMenuItem menuConsultaDeClientes;
        private System.Windows.Forms.ToolStripMenuItem menuFuncionarios;
        private System.Windows.Forms.ToolStripMenuItem menuCadastroDeFuncionarios;
        private System.Windows.Forms.ToolStripMenuItem menuConsultaDeFuncionarios;
        private System.Windows.Forms.ToolStripMenuItem menuFornecedores;
        private System.Windows.Forms.ToolStripMenuItem menuCadastroDeFornecedores;
        private System.Windows.Forms.ToolStripMenuItem menuConsultaDeFornecedores;
        private System.Windows.Forms.ToolStripMenuItem menuCadastroDeProdutos;
        private System.Windows.Forms.ToolStripMenuItem menuConsultaDeProdutos;
        private System.Windows.Forms.ToolStripMenuItem menuVendas;
        private System.Windows.Forms.ToolStripMenuItem menuNovaVenda;
        private System.Windows.Forms.ToolStripMenuItem menuConfiguracoes;
        private System.Windows.Forms.ToolStripMenuItem menuTrocarDeUsuario;
        private System.Windows.Forms.ToolStripMenuItem menuSairDoSistema;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel txtData;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel txtHora;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        public System.Windows.Forms.ToolStripMenuItem menuProdutos;
        public System.Windows.Forms.ToolStripMenuItem menuHistoricoDeVendas;
        public System.Windows.Forms.ToolStripStatusLabel txtUsuario;
        private System.Windows.Forms.Timer timer1;
    }
}