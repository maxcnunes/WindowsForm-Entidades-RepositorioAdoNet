using System;
using System.Windows.Forms;


namespace WindowsForms_MDI_Escola
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void cadastrarAlunosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cad = new FrmCadAluno();
            cad.Visible = true;
        }

        private void cadastrarTurmasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cad = new FrmCadTurmas();
            cad.ShowDialog();
        }

        private void cadastrarMatriculasToolStripMenuItem_Click_Click(object sender, EventArgs e)
        {
            var cad = new FrmCadMatricula();
            cad.Visible = true;
        }
       
    }
}
