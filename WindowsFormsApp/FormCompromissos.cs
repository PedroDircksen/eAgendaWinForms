using eAgenda.Controladores.CompromissoModule;
using eAgenda.Controladores.ContatoModule;
using eAgenda.Dominio.CompromissoModule;
using eAgenda.Dominio.ContatoModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class FormCompromissos : Form
    {
        Form1 formPrincipal = null;
        private readonly ControladorContato controladorContato;
        private readonly ControladorCompromisso controladorCompromisso;

        public FormCompromissos()
        {
            controladorContato = new ControladorContato();
            controladorCompromisso = new ControladorCompromisso();

            InitializeComponent();

            PreencherCbContatos();
            PreencherIdCompromissos();
            CarregarCompromissosFuturosDataGrid();
            CarregarCompromissosPassadosDataGrid();
        }

        #region Load
        private void CarregarCompromissosFuturosDataGrid()
        {
            dtCompromissosFuturos.Clear();
            var compromissos = controladorCompromisso.SelecionarCompromissosFuturos(DateTime.Today, dtPickerCompromissosFuturos.Value);

            foreach (var item in compromissos)
            {
                DataRow registro = dtCompromissosFuturos.NewRow();

                registro["Id"] = item.Id;
                registro["Assunto"] = item.Assunto;
                registro["Local"] = item.Local;
                registro["Data"] = item.Data;
                registro["Hora de Início"] = item.HoraInicio;
                registro["Hora de Término"] = item.HoraTermino;
                registro["Contato"] = item.Contato;

                dtCompromissosFuturos.Rows.Add(registro);
            }
        }

        private void CarregarCompromissosPassadosDataGrid()
        {
            dtCompromissosPassados.Clear();
            var compromissos = controladorCompromisso.SelecionarCompromissosPassados(DateTime.Today);

            foreach (var item in compromissos)
            {
                DataRow registro = dtCompromissosPassados.NewRow();

                registro["Id"] = item.Id;
                registro["Assunto"] = item.Assunto;
                registro["Local"] = item.Local;
                registro["Data"] = item.Data;
                registro["Hora de Início"] = item.HoraInicio;
                registro["Hora de Término"] = item.HoraTermino;
                registro["Contato"] = item.Contato;

                dtCompromissosPassados.Rows.Add(registro);
            }
        }

        private void PreencherIdCompromissos()
        {
            var compromissos = controladorCompromisso.SelecionarTodos();
            List<int> idsCompromissos = new List<int>();

            foreach (var item in compromissos)
            {
                idsCompromissos.Add(item.Id);
            }

            cbIdCompromissos.DataSource = idsCompromissos;
        }

        private void PreencherCbContatos()
        {
            var contatos = controladorContato.SelecionarTodos();
            foreach (var item in contatos)
            {
                cbContatos.Items.Add(item);
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
            string assunto = txtAssunto.Text;
            string local = txtLocal.Text;
            DateTime data = datetimeData.Value;
            Contato contato = (Contato)cbContatos.SelectedItem;

            string[] strHoraInicio = txtHoraInicio.Text.Split(':');
            TimeSpan horaInicio = new TimeSpan(int.Parse(strHoraInicio[0]), int.Parse(strHoraInicio[1]), 0);

            string[] strHoraTermino = txtHoraTermino.Text.Split(':');
            TimeSpan horaTermino = new TimeSpan(int.Parse(strHoraInicio[0]), int.Parse(strHoraInicio[1]), 0);

            Compromisso compromisso = new Compromisso(assunto, local, local, data, horaInicio, horaTermino, contato);

            controladorCompromisso.InserirNovo(compromisso);

            PreencherIdCompromissos();
            CarregarCompromissosFuturosDataGrid();
            CarregarCompromissosPassadosDataGrid();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string assunto = txtAssunto.Text;
            string local = txtLocal.Text;
            DateTime data = datetimeData.Value;
            Contato contato = (Contato)cbContatos.SelectedItem;

            string[] strHoraInicio = txtHoraInicio.Text.Split(':');
            TimeSpan horaInicio = new TimeSpan(int.Parse(strHoraInicio[0]), int.Parse(strHoraInicio[1]), 0);

            string[] strHoraTermino = txtHoraTermino.Text.Split(':');
            TimeSpan horaTermino = new TimeSpan(int.Parse(strHoraInicio[0]), int.Parse(strHoraInicio[1]), 0);

            Compromisso compromisso = new Compromisso(assunto, local, local, data, horaInicio, horaTermino, contato);

            int id = (int)cbIdCompromissos.SelectedItem;

            controladorCompromisso.Editar(id, compromisso);

            PreencherIdCompromissos();
            CarregarCompromissosFuturosDataGrid();
            CarregarCompromissosPassadosDataGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controladorCompromisso.Excluir((int)cbIdCompromissos.SelectedItem);

            PreencherIdCompromissos();
            CarregarCompromissosFuturosDataGrid();
            CarregarCompromissosPassadosDataGrid();
        }

        #endregion

        #region Métodos Complementares
        private void cbIdCompromissos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var compromissoSelecionado = controladorCompromisso.SelecionarPorId((int)cbIdCompromissos.SelectedItem);
            txtAssunto.Text = compromissoSelecionado.Assunto;
            txtLocal.Text = compromissoSelecionado.Local;
            datetimeData.Value = compromissoSelecionado.Data;
            cbContatos.SelectedItem = compromissoSelecionado.Contato;
            txtHoraInicio.Text = compromissoSelecionado.HoraInicio.ToString();
            txtHoraTermino.Text = compromissoSelecionado.HoraInicio.ToString();
        }

        private void dtPickerCompromissosFuturos_ValueChanged(object sender, EventArgs e)
        {
            CarregarCompromissosFuturosDataGrid();
        }

        #endregion
    }
}
