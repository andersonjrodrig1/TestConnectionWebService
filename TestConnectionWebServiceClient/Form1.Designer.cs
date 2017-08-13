namespace TestConnectionWebServiceClient
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbBody = new System.Windows.Forms.RichTextBox();
            this.lblBody = new System.Windows.Forms.Label();
            this.rdbSemAutenticacao = new System.Windows.Forms.RadioButton();
            this.txtAgent = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHeaderValueB = new System.Windows.Forms.TextBox();
            this.txtHeaderKeyB = new System.Windows.Forms.TextBox();
            this.txtHeaderValueA = new System.Windows.Forms.TextBox();
            this.txtHeaderKeyA = new System.Windows.Forms.TextBox();
            this.rdbBasic = new System.Windows.Forms.RadioButton();
            this.rdbHeader = new System.Windows.Forms.RadioButton();
            this.rdbUserPass = new System.Windows.Forms.RadioButton();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.cmbMetodo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExecutar = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvMetodos = new System.Windows.Forms.DataGridView();
            this.rtbResultado = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetodos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbBody);
            this.groupBox1.Controls.Add(this.lblBody);
            this.groupBox1.Controls.Add(this.rdbSemAutenticacao);
            this.groupBox1.Controls.Add(this.txtAgent);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtContent);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtHeaderValueB);
            this.groupBox1.Controls.Add(this.txtHeaderKeyB);
            this.groupBox1.Controls.Add(this.txtHeaderValueA);
            this.groupBox1.Controls.Add(this.txtHeaderKeyA);
            this.groupBox1.Controls.Add(this.rdbBasic);
            this.groupBox1.Controls.Add(this.rdbHeader);
            this.groupBox1.Controls.Add(this.rdbUserPass);
            this.groupBox1.Controls.Add(this.btnSalvar);
            this.groupBox1.Controls.Add(this.cmbMetodo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnExecutar);
            this.groupBox1.Controls.Add(this.txtUrl);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(267, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(850, 184);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados da Conexão";
            // 
            // rtbBody
            // 
            this.rtbBody.Location = new System.Drawing.Point(647, 106);
            this.rtbBody.Name = "rtbBody";
            this.rtbBody.Size = new System.Drawing.Size(197, 73);
            this.rtbBody.TabIndex = 22;
            this.rtbBody.Text = "";
            // 
            // lblBody
            // 
            this.lblBody.AutoSize = true;
            this.lblBody.Location = new System.Drawing.Point(644, 88);
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(31, 13);
            this.lblBody.TabIndex = 21;
            this.lblBody.Text = "Body";
            // 
            // rdbSemAutenticacao
            // 
            this.rdbSemAutenticacao.AutoSize = true;
            this.rdbSemAutenticacao.Location = new System.Drawing.Point(9, 86);
            this.rdbSemAutenticacao.Name = "rdbSemAutenticacao";
            this.rdbSemAutenticacao.Size = new System.Drawing.Size(112, 17);
            this.rdbSemAutenticacao.TabIndex = 20;
            this.rdbSemAutenticacao.TabStop = true;
            this.rdbSemAutenticacao.Text = "Sem Autenticação";
            this.rdbSemAutenticacao.UseVisualStyleBackColor = true;
            this.rdbSemAutenticacao.CheckedChanged += new System.EventHandler(this.rdbSemAutenticacao_CheckedChanged);
            // 
            // txtAgent
            // 
            this.txtAgent.Location = new System.Drawing.Point(504, 110);
            this.txtAgent.Name = "txtAgent";
            this.txtAgent.Size = new System.Drawing.Size(137, 20);
            this.txtAgent.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(501, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "User Agent";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(361, 110);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(137, 20);
            this.txtContent.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(358, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Content Type";
            // 
            // txtHeaderValueB
            // 
            this.txtHeaderValueB.Location = new System.Drawing.Point(183, 136);
            this.txtHeaderValueB.Name = "txtHeaderValueB";
            this.txtHeaderValueB.Size = new System.Drawing.Size(172, 20);
            this.txtHeaderValueB.TabIndex = 8;
            this.txtHeaderValueB.UseSystemPasswordChar = true;
            // 
            // txtHeaderKeyB
            // 
            this.txtHeaderKeyB.Location = new System.Drawing.Point(9, 136);
            this.txtHeaderKeyB.Name = "txtHeaderKeyB";
            this.txtHeaderKeyB.Size = new System.Drawing.Size(168, 20);
            this.txtHeaderKeyB.TabIndex = 7;
            // 
            // txtHeaderValueA
            // 
            this.txtHeaderValueA.Location = new System.Drawing.Point(183, 110);
            this.txtHeaderValueA.Name = "txtHeaderValueA";
            this.txtHeaderValueA.Size = new System.Drawing.Size(172, 20);
            this.txtHeaderValueA.TabIndex = 6;
            this.txtHeaderValueA.UseSystemPasswordChar = true;
            // 
            // txtHeaderKeyA
            // 
            this.txtHeaderKeyA.Location = new System.Drawing.Point(9, 110);
            this.txtHeaderKeyA.Name = "txtHeaderKeyA";
            this.txtHeaderKeyA.Size = new System.Drawing.Size(168, 20);
            this.txtHeaderKeyA.TabIndex = 5;
            // 
            // rdbBasic
            // 
            this.rdbBasic.AutoSize = true;
            this.rdbBasic.Location = new System.Drawing.Point(232, 86);
            this.rdbBasic.Name = "rdbBasic";
            this.rdbBasic.Size = new System.Drawing.Size(51, 17);
            this.rdbBasic.TabIndex = 12;
            this.rdbBasic.TabStop = true;
            this.rdbBasic.Text = "Basic";
            this.rdbBasic.UseVisualStyleBackColor = true;
            this.rdbBasic.Click += new System.EventHandler(this.rdbBasic_Click);
            // 
            // rdbHeader
            // 
            this.rdbHeader.AutoSize = true;
            this.rdbHeader.Location = new System.Drawing.Point(290, 86);
            this.rdbHeader.Name = "rdbHeader";
            this.rdbHeader.Size = new System.Drawing.Size(65, 17);
            this.rdbHeader.TabIndex = 11;
            this.rdbHeader.TabStop = true;
            this.rdbHeader.Text = "Headers";
            this.rdbHeader.UseVisualStyleBackColor = true;
            this.rdbHeader.Click += new System.EventHandler(this.rdbHeader_Click);
            // 
            // rdbUserPass
            // 
            this.rdbUserPass.AutoSize = true;
            this.rdbUserPass.Location = new System.Drawing.Point(121, 86);
            this.rdbUserPass.Name = "rdbUserPass";
            this.rdbUserPass.Size = new System.Drawing.Size(105, 17);
            this.rdbUserPass.TabIndex = 10;
            this.rdbUserPass.TabStop = true;
            this.rdbUserPass.Text = "User e Password";
            this.rdbUserPass.UseVisualStyleBackColor = true;
            this.rdbUserPass.Click += new System.EventHandler(this.rdbUserPass_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(773, 11);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(71, 23);
            this.btnSalvar.TabIndex = 12;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // cmbMetodo
            // 
            this.cmbMetodo.DisplayMember = "1";
            this.cmbMetodo.FormattingEnabled = true;
            this.cmbMetodo.Items.AddRange(new object[] {
            "GET",
            "POST",
            "PUT",
            "DELETE"});
            this.cmbMetodo.Location = new System.Drawing.Point(688, 59);
            this.cmbMetodo.Name = "cmbMetodo";
            this.cmbMetodo.Size = new System.Drawing.Size(156, 21);
            this.cmbMetodo.TabIndex = 4;
            this.cmbMetodo.SelectedValueChanged += new System.EventHandler(this.cmbMetodo_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(685, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Método";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Url Conexão";
            // 
            // btnExecutar
            // 
            this.btnExecutar.Location = new System.Drawing.Point(697, 11);
            this.btnExecutar.Name = "btnExecutar";
            this.btnExecutar.Size = new System.Drawing.Size(70, 23);
            this.btnExecutar.TabIndex = 11;
            this.btnExecutar.Text = "Executar";
            this.btnExecutar.UseVisualStyleBackColor = true;
            this.btnExecutar.Click += new System.EventHandler(this.btnExecutar_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(9, 60);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(673, 20);
            this.txtUrl.TabIndex = 3;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(83, 13);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(599, 20);
            this.txtNome.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome Método";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvMetodos);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(249, 483);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Métodos";
            // 
            // dgvMetodos
            // 
            this.dgvMetodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMetodos.Location = new System.Drawing.Point(3, 19);
            this.dgvMetodos.Name = "dgvMetodos";
            this.dgvMetodos.Size = new System.Drawing.Size(240, 458);
            this.dgvMetodos.TabIndex = 0;
            this.dgvMetodos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMetodos_CellClick);
            // 
            // rtbResultado
            // 
            this.rtbResultado.BackColor = System.Drawing.SystemColors.Window;
            this.rtbResultado.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rtbResultado.Location = new System.Drawing.Point(267, 204);
            this.rtbResultado.Margin = new System.Windows.Forms.Padding(5);
            this.rtbResultado.Name = "rtbResultado";
            this.rtbResultado.ReadOnly = true;
            this.rtbResultado.Size = new System.Drawing.Size(850, 291);
            this.rtbResultado.TabIndex = 13;
            this.rtbResultado.Text = "";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 509);
            this.Controls.Add(this.rtbResultado);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPrincipal";
            this.Text = "Teste de Conexão de WebService";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetodos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnExecutar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMetodo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtHeaderValueB;
        private System.Windows.Forms.TextBox txtHeaderKeyB;
        private System.Windows.Forms.TextBox txtHeaderValueA;
        private System.Windows.Forms.TextBox txtHeaderKeyA;
        private System.Windows.Forms.RadioButton rdbBasic;
        private System.Windows.Forms.RadioButton rdbHeader;
        private System.Windows.Forms.RadioButton rdbUserPass;
        private System.Windows.Forms.TextBox txtAgent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtbResultado;
        private System.Windows.Forms.RadioButton rdbSemAutenticacao;
        private System.Windows.Forms.RichTextBox rtbBody;
        private System.Windows.Forms.Label lblBody;
        private System.Windows.Forms.DataGridView dgvMetodos;
    }
}

