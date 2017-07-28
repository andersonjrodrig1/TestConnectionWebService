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

namespace TestConnectionWebServiceClient
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            CenterToScreen();

            rdbSemAutenticacao.Checked = true;
            txtHeaderKeyB.Visible = false;
            txtHeaderValueB.Visible = false;
            lblBody.Visible = false;
            rtbBody.Visible = false;
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            if (ValidaCamposObrigatorios())
            {
                string urlWebService = cmbProtocolo.Text.ToLower() + txtUrl.Text;
                string metodo = cmbMetodo.Text;
                string contentType = txtContent.Text ;
                string userAgent = txtAgent.Text;
                string body = "";
                string usuario = txtHeaderKeyA.Text;
                string senha = txtHeaderValueA.Text;
                string usuarioB = "";
                string senhaB = "";

                rtbResultado.Text = new PaginaBO(urlWebService, usuario, senha).BuscarPagina(userAgent, contentType, body);
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

            }
        }

        private bool ValidaCamposObrigatorios()
        {
            if(cmbProtocolo.SelectedIndex < 0)
            {
                MessageBox.Show("Informe o Protocolo", "Atenção!");
                return false;
            }

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
            }
        }

        private void cmbMetodo_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cmbMetodo.SelectedIndex == 1)
            {
                lblBody.Visible = true;
                rtbBody.Visible = true;
                txtHeaderKeyB.Visible = true;
                txtHeaderValueB.Visible = true;
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
    }
}
