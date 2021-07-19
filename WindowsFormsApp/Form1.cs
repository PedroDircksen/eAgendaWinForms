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
    public partial class Form1 : Form
    {
        public FormTarefas formTarefas = new FormTarefas();
        public FormContatos formContatos = new FormContatos();
        public FormCompromissos formCompromissos = new FormCompromissos();
        public Form1()
        {
            InitializeComponent();
        }        

        private void btnTarefa_Click(object sender, EventArgs e)
        {
            formTarefas.Visible = true;
            this.Visible = false;
        }
        private void btnContato_Click(object sender, EventArgs e)
        {
            formContatos.Visible = true;
            this.Visible = false;
        }
        private void btnCompromisso_Click(object sender, EventArgs e)
        {
            formCompromissos.Visible = true;
            this.Visible = false;
        }
    }
}
