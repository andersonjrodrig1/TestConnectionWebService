using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestConnectionWebServiceBO;
using TestConnectionWebServiceEntity;

namespace TestConnectionWebServiceClient
{
    public partial class frmPrincipal : Form
    {
        private List<string> nomesMetodosConsulta = null;

        public frmPrincipal()
        {
            InitializeComponent();
            CenterToScreen();

            rdbSemAutenticacao.Checked = true;
            txtHeaderKeyB.Visible = false;
            txtHeaderValueB.Visible = false;
            lblBody.Visible = false;
            rtbBody.Visible = false;
            txtHeaderKeyA.Enabled = false;
            txtHeaderValueA.Enabled = false;

            nomesMetodosConsulta = new ArquivoBO().BuscarNomeArquivosGravados();
            PreencherTelaMetoodosWebService(nomesMetodosConsulta);
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            this.BuscarDadosWebService();
        }

        private void BuscarDadosWebService()
        {
            if (ValidaCamposObrigatorios())
            {
                string urlWebService = txtUrl.Text;
                string contentType = txtContent.Text;
                string userAgent = txtAgent.Text;
                string body = rtbBody.Text;
                string keyA = txtHeaderKeyA.Text;
                string valueA = txtHeaderValueA.Text;
                string keyB = txtHeaderKeyB.Text;
                string valueB = txtHeaderValueB.Text;

                int metodo = cmbMetodo.SelectedIndex;

                bool isBasic = rdbBasic.Checked ? true : false;
                bool isHeader = rdbHeader.Checked ? true : false;

                rtbResultado.Text = new PaginaBO(urlWebService, keyA, valueA).BuscarDadosWebService(userAgent, contentType, body, metodo, keyB, valueB, isHeader, isBasic);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Informe o Nome do Método", "Atenção!");
                return;
            }

            if (ValidaCamposObrigatorios())
            {
                string nmMetodo = txtNome.Text;
                string urlWebService = txtUrl.Text;
                string contentType = txtContent.Text;
                string userAgent = txtAgent.Text;
                string body = rtbBody.Text;
                string keyA = txtHeaderKeyA.Text;
                string valueA = txtHeaderValueA.Text;
                string keyB = txtHeaderKeyB.Text;
                string valueB = txtHeaderValueB.Text;
                string metodo = cmbMetodo.Text;

                bool isSemAutent = rdbSemAutenticacao.Checked ? true : false;
                bool isComAutent = rdbUserPass.Checked ? true : false;
                bool isBasic = rdbBasic.Checked ? true : false;
                bool isHeader = rdbHeader.Checked ? true : false;

                Arquivo arquivo = new ArquivoBO().GerarArquivo(nmMetodo, urlWebService, metodo, isSemAutent, isComAutent, isBasic, isHeader, keyA, valueA, keyB, valueB, contentType, userAgent, body);
                string retorno = new ArquivoBO().GravarArquivo(arquivo);

                nomesMetodosConsulta = new List<string>();
                nomesMetodosConsulta = new ArquivoBO().BuscarNomeArquivosGravados();
                PreencherTelaMetoodosWebService(nomesMetodosConsulta);

                MessageBox.Show(retorno, "Atenção!");
            }
        }

        private bool ValidaCamposObrigatorios()
        {
            if (string.IsNullOrEmpty(txtUrl.Text))
            {
                MessageBox.Show("Informe a Url do WebService", "Atenção!");
                return false;
            }

            if(cmbMetodo.SelectedIndex < 0)
            {
                MessageBox.Show("Informe o Método", "Atenção!");
                return false;
            }

            if (rdbUserPass.Checked || rdbBasic.Checked)
            {
                if(string.IsNullOrEmpty(txtHeaderKeyA.Text) || string.IsNullOrEmpty(txtHeaderValueA.Text))
                {
                    MessageBox.Show("Informe Usuario e/ou Senha", "Atenção!");
                    return false;
                }
            }

            if (rdbHeader.Checked)
            {
                if (string.IsNullOrEmpty(txtHeaderKeyA.Text) || string.IsNullOrEmpty(txtHeaderValueA.Text) || string.IsNullOrEmpty(txtHeaderKeyB.Text) || string.IsNullOrEmpty(txtHeaderValueB.Text))
                {
                    MessageBox.Show("Informe os dados do Header", "Atenção!");
                    return false;
                }
            }

            return true;
        }

        private void rdbSemAutenticacao_CheckedChanged(object sender, EventArgs e)
        {
            txtHeaderKeyA.Enabled = false;
            txtHeaderValueA.Enabled = false;
            txtHeaderKeyB.Visible = false;
            txtHeaderValueB.Visible = false;
        }

        private void rdbUserPass_Click(object sender, EventArgs e)
        {
            if (cmbMetodo.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione o Método", "Atenção!");
                rdbSemAutenticacao.Checked = true;
            }
            else
            {
                txtHeaderKeyB.Visible = false;
                txtHeaderValueB.Visible = false;
                txtHeaderKeyA.Enabled = true;
                txtHeaderValueA.Enabled = true;
            }
        }

        private void rdbBasic_Click(object sender, EventArgs e)
        {
            if (cmbMetodo.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione o Método", "Atenção!");
                rdbSemAutenticacao.Checked = true;
            }
            else
            {
                txtHeaderKeyB.Visible = false;
                txtHeaderValueB.Visible = false;
                txtHeaderKeyA.Enabled = true;
                txtHeaderValueA.Enabled = true;
            }
        }

        private void rdbHeader_Click(object sender, EventArgs e)
        {
            if (cmbMetodo.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione o Método", "Atenção!");
                rdbSemAutenticacao.Checked = true;
            }
            else
            {
                txtHeaderKeyB.Visible = true;
                txtHeaderValueB.Visible = true;
                txtHeaderKeyA.Enabled = true;
                txtHeaderValueA.Enabled = true;
            }
        }

        private void cmbMetodo_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cmbMetodo.SelectedIndex == 1)
            {
                if (!rdbSemAutenticacao.Checked)
                {
                    txtHeaderKeyB.Visible = true;
                    txtHeaderValueB.Visible = true;
                }
                else
                {
                    txtHeaderKeyB.Visible = false;
                    txtHeaderValueB.Visible = false;
                }

                lblBody.Visible = true;
                rtbBody.Visible = true;
            }
            else
            {
                lblBody.Visible = false;
                rtbBody.Visible = false;
                txtHeaderKeyB.Visible = false;
                txtHeaderValueB.Visible = false;
            }

            txtContent.Text = "application/json";
        }

        private void PreencherTelaMetoodosWebService(List<string> nomeMetodosWebService)
        {
            dgvMetodos.Columns.Add("coluna1", "Métodos WebService");
            dgvMetodos.Columns["coluna1"].ReadOnly = true;
            dgvMetodos.Columns["coluna1"].Width = 197;

            if(dgvMetodos.Rows.Count > 1)
            {
                dgvMetodos.Rows.Clear();
            }

            if (nomeMetodosWebService != null && nomeMetodosWebService.Count > 0)
            {
                foreach (var nome in nomeMetodosWebService)
                {
                    string[] array = new string[1];
                    array[0] = nome;

                    dgvMetodos.Rows.Add(array);
                }
            }
        }

        private void dgvMetodos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvMetodos.Rows[e.RowIndex].Cells["coluna1"].Value != null)
            {
                ArquivoBO arquivoBO = new ArquivoBO();
                Arquivo arquivo = new Arquivo();

                string nomeMetodo = dgvMetodos.Rows[e.RowIndex].Cells["coluna1"].Value.ToString();

                arquivo = arquivoBO.BuscarArquivoPorNome(nomeMetodo);

                if (arquivo != null)
                {
                    txtNome.Text = arquivo.Nome;
                    txtUrl.Text = arquivo.Url_Conexao;
                    cmbMetodo.Text = arquivo.Tipo_Requisicao;

                    if(arquivo.Tipo_Requisicao == MetodosWebService.POST.ToString())
                    {
                        lblBody.Visible = true;
                        rtbBody.Visible = true;
                    }
                    else
                    {
                        lblBody.Visible = false;
                        rtbBody.Visible = false;
                    }

                    if (arquivo.Sem_Autenticacao)
                    {
                        rdbSemAutenticacao.Checked = true;

                        txtHeaderKeyA.Enabled = false;
                        txtHeaderValueA.Enabled = false;
                        txtHeaderKeyB.Visible = false;
                        txtHeaderValueB.Visible = false;

                        txtHeaderKeyA.Text = "";
                        txtHeaderValueA.Text = "";
                    }
                    else if(arquivo.Com_Autenticacao)
                    {
                        rdbUserPass.Checked = true;

                        txtHeaderKeyA.Enabled = true;
                        txtHeaderValueA.Enabled = true;
                        txtHeaderKeyB.Visible = false;
                        txtHeaderValueB.Visible = false;

                        txtHeaderKeyA.Text = arquivo.User_0;
                        txtHeaderValueA.Text = arquivo.Password_0;
                    }
                    else if (arquivo.Autenticacao_Basic)
                    {
                        rdbBasic.Checked = true;

                        txtHeaderKeyA.Enabled = true;
                        txtHeaderValueA.Enabled = true;
                        txtHeaderKeyB.Visible = false;
                        txtHeaderValueB.Visible = false;

                        txtHeaderKeyA.Text = arquivo.User_0;
                        txtHeaderValueA.Text = arquivo.Password_0;
                    }
                    else
                    {
                        rdbHeader.Checked = true;

                        txtHeaderKeyA.Enabled = true;
                        txtHeaderValueA.Enabled = true;

                        txtHeaderKeyB.Visible = true;
                        txtHeaderValueB.Visible = true;
                        txtHeaderKeyB.Enabled = true;
                        txtHeaderValueB.Enabled = true;

                        txtHeaderKeyA.Text = arquivo.User_0;
                        txtHeaderValueA.Text = arquivo.Password_0;                        

                        if(!string.IsNullOrEmpty(arquivo.User_1) && !string.IsNullOrEmpty(arquivo.Password_1))
                        {
                            txtHeaderKeyB.Text = arquivo.User_1;
                            txtHeaderValueB.Text = arquivo.Password_1;                            
                        }
                    }

                    txtContent.Text = arquivo.Content_Type;
                    txtAgent.Text = arquivo.User_Agent;

                    this.BuscarDadosWebService();
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtUrl.Text = "";
            cmbMetodo.Text = "";
            txtHeaderKeyA.Text = "";
            txtHeaderValueA.Text = "";
            txtHeaderKeyA.Text = "";
            txtHeaderValueA.Text = "";
            txtHeaderKeyB.Text = "";
            txtHeaderValueB.Text = "";
            txtContent.Text = "";
            txtAgent.Text = "";
            rtbBody.Text = "";
            rtbResultado.Text = "";

            rdbSemAutenticacao.Checked = true;
            rdbUserPass.Checked = false;
            rdbBasic.Checked = false;
            rdbHeader.Checked = false;

            lblBody.Visible = false;
            rtbBody.Visible = false;
            txtHeaderKeyB.Visible = false;
            txtHeaderValueB.Visible = false;

            txtHeaderKeyA.Enabled = false;
            txtHeaderValueA.Enabled = false;           

        }
    }
}
