using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleAtividades
{
    public partial class frmPrimeira : Form
    {
        AcessoFuncionario func = new AcessoFuncionario();
        public frmPrimeira()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TI.Conexao.criar_Conexao();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (func.buscarfunc(txtLogin.Text, txtSenha.Text))
            {
                MessageBox.Show("Bem-vindo " + func.Nome.ToString() + "");
                func.guardarnome(func.Nome.ToString());
                TelaInicio tela = new TelaInicio();
                tela.Text = "Bem-vindo "+ func.Nome.ToString() + "! ("+DateTime.Now.ToLongDateString() + " às " + DateTime.Now.ToShortTimeString() +")";
                this.Hide();
                tela.ShowDialog();
                this.Show();
            }
            
        }
    }
}
