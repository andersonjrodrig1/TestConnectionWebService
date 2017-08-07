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
            if (ValidaCamposObrigatorios())
            {
                string urlWebService = txtUrl.Text;
                string contentType = txtContent.Text ;
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

            foreach (var metodo in nomeMetodosWebService)
            {
                dgvMetodos.Rows.Add(metodo);
            }
        }
    }
}
