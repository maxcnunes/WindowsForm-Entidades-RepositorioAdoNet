using System;
using System.Windows.Forms;
using MDI_Escola.Entidades;
using MDI_Escola.Repositorios;

namespace WindowsForms_MDI_Escola
{
    public partial class FrmCadAluno : Form
    {
        #region Propriedades
        //Repositorio de dados
        private AlunoRepositorio _repositorioAluno;
        #endregion

        #region Metodos
        public FrmCadAluno()
        {
            //Inicializa repositorio de dados
            _repositorioAluno = new AlunoRepositorio();
            InitializeComponent();

            LimparCampos();
        }

        protected void LimparCampos()
        {
            //Limpa todos os campos textos
            lblCodigo.Text =
            txtNome.Text =
            txtEmail.Text =
            txtEndereco.Text =
            txtTelefone.Text = string.Empty;

            //Desmarca todos os campos de marcação e desativa botoes
            rbFem.Checked =
            rbMasc.Checked =
            chkAtivo.Checked =
            btnAlterar.Enabled =
            btnCancelar.Enabled =
            btnExcluir.Enabled = false;

            btnSalvar.Enabled = true;

            //Remove o auto gerador de colunas da datagridview
            dataGridViewAlunos.AutoGenerateColumns = false;

            //Recupera todos os alunos do banco
            dataGridViewAlunos.DataSource = _repositorioAluno.Todos();
        }

        protected Aluno CarregarObjAluno(int id)
        {
            //Carrega obj ALuno com os valores preenchidos nos componnetes da tela
            var aluno = new Aluno
            {
                Id = id,
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                Telefone = txtTelefone.Text,
                Endereco = txtEndereco.Text,
                Ativo = chkAtivo.Checked,
                Genero = (rbMasc.Checked ? 0 : 1)
            };

            return aluno;
        }

        public void AlterarSituacaoBotao(int id, bool situacao)
        {
            //Ativa botoes Salvar e Alterar

            //id = 0 -> Está inserindo um novo registro
            if (id == 0)
                btnSalvar.Enabled = situacao;
            else
                btnAlterar.Enabled = situacao;
        }
        #endregion

        #region Eventos
        private void btnSalvar_Click(object sender, System.EventArgs e)
        {
            //Carrega valores preenchidos nos componentes da tela para o obj Aluno
            var aluno = CarregarObjAluno(0);

            //Insere aluno :
            //-------------- Retorno = true -> Exibe msg 1; Retorno = false -> Exibe msg 2; 
            MessageBox.Show(_repositorioAluno.Inserir(aluno)
                                ? "Incluido com sucesso!"
                                : "Ocorreu um erro ao salvar! Tente novamente.");
            LimparCampos();
        }

        private void dataGridViewAlunos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Recupera o id referente ao registro selecionado
            var id = int.Parse(dataGridViewAlunos.CurrentRow.Cells["Id"].Value.ToString());

            try
            {
                //Recupera o aluno pelo id
                var aluno = _repositorioAluno.Obter(id);

                if (aluno == null)
                {
                    MessageBox.Show("Aluno não encontrado");
                    return;
                }

                //Carrega componentes com os valores retornados do BD
                lblCodigo.Text = aluno.Id.ToString();
                txtNome.Text = aluno.Nome;
                txtEmail.Text = aluno.Email;
                txtEndereco.Text = aluno.Endereco;
                txtTelefone.Text = aluno.Telefone;
                chkAtivo.Checked = aluno.Ativo;
                rbMasc.Checked = (aluno.Genero == 0);
                rbFem.Checked = (aluno.Genero == 1);

                btnSalvar.Enabled = false;
                btnAlterar.Enabled = btnCancelar.Enabled = btnExcluir.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            //Recupera o id do aluno selecionado
            var id = int.Parse(lblCodigo.Text);

            //Carrega o aluno
            var aluno = CarregarObjAluno(id);

            //Atualiza aluno :
            //-------------- Retorno = true -> Exibe msg 1; Retorno = false -> Exibe msg 2; 
            MessageBox.Show(_repositorioAluno.Atualizar(aluno) ? "Iserido com sucesso!" : "Erro ao atulizar");

            //Limpa campos da tela
            LimparCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Limpa campos da tela
            LimparCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //Recupera codigo do aluno selecionado
            var id = int.Parse(lblCodigo.Text);

            //Exibe msg de confirmaçao e verifica se a opçao selecionada foi = 'sim'
            if (MessageBox.Show("Deseja excluir?",
                                "Excluir",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Caso seleciona sim, exclui aluno
                _repositorioAluno.Excluir(id);
            }

            //Limpa campos da tela
            LimparCampos();
        }

        private void txtNome_Leave(object sender, EventArgs e)
        {
            int id;
            //Tenta converter para inteiro, se não der certo define o valor = 0
            int.TryParse(lblCodigo.Text, out id);

            //Verifica se o nome esta disponivel para cadastro
            var disponivel = _repositorioAluno.VerificarNomeDisponivel(txtNome.Text, id);

            //Exibe uma msg caso o nome nao esteja disponivel
            lblMsg.Text = disponivel ? string.Empty : "Este nome não está disponível. Tente outro, por favor.";

            //Libera ou Bloqueia botao, dependendo da disponibilidade
            AlterarSituacaoBotao(id, disponivel);
        }
        #endregion
    }
}
