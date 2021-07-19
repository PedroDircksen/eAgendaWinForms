using eAgenda.Controladores.TarefaModule;
using eAgenda.Dominio.TarefaModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class FormTarefas : Form
    {
        Form1 formPrincipal;
        ControladorTarefa controlador = new ControladorTarefa();

        public FormTarefas()
        {
            InitializeComponent();
            PreencherPrioridade();
        }

        #region Load
        private void FormTarefas_Load(object sender, EventArgs e)
        {
            var tarefasConcluidas = controlador.SelecionarTodasTarefasConcluidas();
            var tarefasPendentes = controlador.SelecionarTodasTarefasPendentes();

            if (tarefasConcluidas != null)
            {
                ConcluidasDataGridView.DataSource = tarefasConcluidas;
                ConfigurarTabela_TarefasConcluidas();
            }
            if (tarefasPendentes != null)
            {
                PendentesDataGridView.DataSource = tarefasPendentes;
                ConfigurarTabela_TarefasPendentes();
            }
        }
        private void PreencherPrioridade()
        {
            cbPrioridade.Items.Clear();

            PrioridadeEnum[] priodidades = new PrioridadeEnum[]
            {
                PrioridadeEnum.Alta,
                PrioridadeEnum.Normal,
                PrioridadeEnum.Baixa,
            };

            foreach (var item in priodidades)
            {
                cbPrioridade.Items.Add(item);
            }
        }

        #endregion

        #region Click
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            formPrincipal = new Form1();
            formPrincipal.Visible = true;
            this.Visible = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text;

            DateTime data = DateTime.Now;

            PrioridadeEnum prioridade = (PrioridadeEnum)cbPrioridade.SelectedItem;

            Tarefa tarefa = new Tarefa(titulo, data, prioridade);

            tarefa.Percentual = (int)numericUpDownPercentual.Value;

            controlador.InserirNovo(tarefa);

            AtualizarGrid_Tarefas();

            Limpar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var tarefasConcluidas = controlador.SelecionarTodasTarefasConcluidas();
            var tarefasPendentes = controlador.SelecionarTodasTarefasPendentes();

            ExcluirTarefasPendentes(tarefasPendentes);
            ExcluirTarefasConcluidas(tarefasConcluidas);

            AtualizarGrid_Tarefas();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text;

            DateTime data = DateTime.Now;

            PrioridadeEnum prioridade = (PrioridadeEnum)cbPrioridade.SelectedItem;

            int percentual = (int)numericUpDownPercentual.Value;

            Tarefa tarefa = new Tarefa(titulo, data, prioridade);

            tarefa.Percentual = percentual;

            var tarefasConcluidas = controlador.SelecionarTodasTarefasConcluidas();
            var tarefasPendentes = controlador.SelecionarTodasTarefasPendentes();

            if (tabControl1.SelectedTab == tabControl1.TabPages["Pendentes"])
                EditarTarefasPendentes(tarefasPendentes, tarefa);

            if (tabControl1.SelectedTab == tabControl1.TabPages["Concluídas"])
                EditarTarefasConcluidas(tarefasConcluidas, tarefa);

            AtualizarGrid_Tarefas();

            Limpar();
        }

        private void PendentesDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTitulo.Text = PendentesDataGridView.CurrentRow.Cells[1].Value.ToString();
            cbPrioridade.Text = PendentesDataGridView.CurrentRow.Cells[2].Value.ToString();
            numericUpDownPercentual.Value = (int)PendentesDataGridView.CurrentRow.Cells[4].Value;
        }

        private void ConcluidasDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTitulo.Text = ConcluidasDataGridView.CurrentRow.Cells[1].Value.ToString();
            cbPrioridade.Text = ConcluidasDataGridView.CurrentRow.Cells[2].Value.ToString();
            numericUpDownPercentual.Value = (int)ConcluidasDataGridView.CurrentRow.Cells[4].Value;
        }

        #endregion

        #region Métodos Complementares
        private void Limpar()
        {
            txtTitulo.Text = "";
            cbPrioridade.Text = "";
            numericUpDownPercentual.Value = 0;
        }

        private void ConfigurarTabela_TarefasPendentes()
        {
            PendentesDataGridView.Columns[0].HeaderText = "ID";
            PendentesDataGridView.Columns[1].HeaderText = "Título";
            PendentesDataGridView.Columns[2].HeaderText = "Prioridade";
            PendentesDataGridView.Columns[3].HeaderText = "Data de Criação";
            PendentesDataGridView.Columns[4].HeaderText = "Percentual Concluído";

            PendentesDataGridView.Columns[5].Visible = false;
        }

        private void ConfigurarTabela_TarefasConcluidas()
        {
            ConcluidasDataGridView.Columns[0].HeaderText = "ID";
            ConcluidasDataGridView.Columns[1].HeaderText = "Título";
            ConcluidasDataGridView.Columns[2].HeaderText = "Prioridade";
            ConcluidasDataGridView.Columns[3].HeaderText = "Data de Criação";
            ConcluidasDataGridView.Columns[5].HeaderText = "Data de Conclusão";

            ConcluidasDataGridView.Columns[4].Visible = false;
        }

        private void AtualizarGrid_Tarefas()
        {
            FormTarefas_Load(null, null);
        }

        private void ExcluirTarefasConcluidas(List<Tarefa> tarefasConcluidas)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["Concluídas"]
                            && tarefasConcluidas.Count != 0)
            {
                int id = Convert.ToInt32(ConcluidasDataGridView.CurrentRow.Cells[0].Value);
                controlador.Excluir(id);
            }
        }

        private void ExcluirTarefasPendentes(List<Tarefa> tarefasPendentes)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["Pendentes"]
                            && tarefasPendentes.Count != 0)
            {
                int id = Convert.ToInt32(PendentesDataGridView.CurrentRow.Cells[0].Value);
                controlador.Excluir(id);
            }
        }

        private void EditarTarefasConcluidas(List<Tarefa> tarefasConcluidas, Tarefa tarefa)
        {
            if (tarefasConcluidas.Count != 0)
            {
                int id = Convert.ToInt32(ConcluidasDataGridView.CurrentRow.Cells[0].Value);
                controlador.Editar(id, tarefa);
            }
        }

        private void EditarTarefasPendentes(List<Tarefa> tarefasPendentes, Tarefa tarefa)
        {
            if (tarefasPendentes.Count != 0)
            {
                int id = Convert.ToInt32(PendentesDataGridView.CurrentRow.Cells[0].Value);
                controlador.Editar(id, tarefa);
            }
        }

        #endregion

    }
}
