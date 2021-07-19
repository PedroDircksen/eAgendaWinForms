using eAgenda.Controladores.ContatoModule;
using eAgenda.Dominio.ContatoModule;
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
    public partial class FormContatos : Form
    {
        Form1 formPrincipal = null;
        ControladorContato controlador = new ControladorContato();

        public FormContatos()
        {
            InitializeComponent();

            PreencherIdContatos();
            CarregarContatos();
        }

        #region Load
        private void PreencherIdContatos()
        {
            var contatos = controlador.SelecionarTodos();
            List<int> idsContatos = new List<int>(); 

            foreach (var item in contatos)
            {
                idsContatos.Add(item.Id);
            }

            cbContatos.DataSource = idsContatos;
        }

        private void CarregarContatos()
        {
            dtContatos.Clear();
            var contatos = controlador.SelecionarTodos();

            foreach (var item in contatos)
            {
                DataRow registro = dtContatos.NewRow();

                registro["Id"] = item.Id;
                registro["Nome"] = item.Nome;
                registro["Telefone"] = item.Telefone;
                registro["E-mail"] = item.Email;
                registro["Empresa"] = item.Empresa;
                registro["Cargo"] = item.Cargo;

                dtContatos.Rows.Add(registro);
            }
        }
        
        private void FormContatos_Load(object sender, EventArgs e)
        {
        }

        #endregion

        #region Click

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            formPrincipal = new Form1();
            formPrincipal.Visible = true;
            this.Visible = false;
        }        

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;

            string telefone = txtTelefone.Text;

            string email = txtEmail.Text;

            string empresa = txtEmpresa.Text;

            string cargo = txtCargo.Text;

            Contato contato = new Contato(nome, email, telefone, empresa, cargo);

            controlador.Editar((int)cbContatos.SelectedItem, contato);

            CarregarContatos();
            PreencherIdContatos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir((int)cbContatos.SelectedItem);

            CarregarContatos();
            PreencherIdContatos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;

            string telefone = txtTelefone.Text;

            string email = txtEmail.Text;

            string empresa = txtEmpresa.Text;

            string cargo = txtCargo.Text;

            Contato contato = new Contato(nome, email, telefone, empresa, cargo);

            controlador.InserirNovo(contato);

            CarregarContatos();
            PreencherIdContatos();
        }

        #endregion

        #region Métodos Complementares
        private void cbContatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var contato = controlador.SelecionarPorId((int)cbContatos.SelectedItem);

            txtNome.Text = contato.Nome;
            txtTelefone.Text = contato.Telefone;
            txtEmail.Text = contato.Email;
            txtEmpresa.Text = contato.Empresa;
            txtCargo.Text = contato.Cargo;

            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        #endregion
    }
}
