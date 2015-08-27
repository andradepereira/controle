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
    public partial class TelaNovaAtividade : Form
    {
        AcessoAtividade atv = new AcessoAtividade();
        AcessoFuncionario func = new AcessoFuncionario();
        public TelaNovaAtividade()
        {
            InitializeComponent();
        }

        private void TelaNovaAtividade_Load(object sender, EventArgs e)
        {
            txtFunc.Text = funcLogado.Logado1;
            txtData.Text = DateTime.Now.ToShortDateString();
            txthora.Text = DateTime.Now.ToShortTimeString();


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            atv.inserirativ(atv.buscarid(txtFunc.Text), textBox2.Text, txtData.Text, txthora.Text);
            this.Size = new Size(331, 357);
            dataGridView1.DataSource = atv.listartudo();
            dataGridView1.Columns[0].HeaderText = "ID ATIV";
            dataGridView1.Columns[1].HeaderText = "Responsável";
            dataGridView1.Columns[2].HeaderText = "Descrição";
            dataGridView1.Columns[3].HeaderText = "Data";
            dataGridView1.Columns[4].HeaderText = "Horario";


        }
    }
}
