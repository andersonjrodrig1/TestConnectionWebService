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
            txtUserB.Visible = false;
            txtSenhaB.Visible = false;
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
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
                if(string.IsNullOrEmpty(txtUserA.Text) || string.IsNullOrEmpty(txtSenhaA.Text))
                {
                    MessageBox.Show("Informe Usuario e/ou Senha", "Atenção!");
                    return false;
                }
            }

            if (rdbHeader.Checked)
            {
                if (string.IsNullOrEmpty(txtUserA.Text) || string.IsNullOrEmpty(txtSenhaA.Text) || string.IsNullOrEmpty(txtUserB.Text) || string.IsNullOrEmpty(txtSenhaB.Text))
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
        }

        private void rdbBasic_Click(object sender, EventArgs e)
        {
            if (cmbMetodo.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione o Método", "Atenção!");
                rdbSemAutenticacao.Checked = true;
            }
        }

        private void rdbHeader_Click(object sender, EventArgs e)
        {
            if (cmbMetodo.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione o Método", "Atenção!");
                rdbSemAutenticacao.Checked = true;
            }
        }

        private void cmbMetodo_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cmbMetodo.SelectedIndex == 1)
            {
                txtUserB.Visible = true;
                txtSenhaB.Visible = true;
            }
            else
            {
                txtUserB.Visible = false;
                txtSenhaB.Visible = false;
            }
        }
    }
}
