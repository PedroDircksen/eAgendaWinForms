
namespace WindowsFormsApp
{
    partial class FormTarefas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTarefas));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Pendentes = new System.Windows.Forms.TabPage();
            this.PendentesDataGridView = new System.Windows.Forms.DataGridView();
            this.Concluídas = new System.Windows.Forms.TabPage();
            this.ConcluidasDataGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LabelPercentual = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.numericUpDownPercentual = new System.Windows.Forms.NumericUpDown();
            this.cbPrioridade = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Pendentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PendentesDataGridView)).BeginInit();
            this.Concluídas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConcluidasDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPercentual)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 210);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(507, 251);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tarefas";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Pendentes);
            this.tabControl1.Controls.Add(this.Concluídas);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(3, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(501, 222);
            this.tabControl1.TabIndex = 0;
            // 
            // Pendentes
            // 
            this.Pendentes.Controls.Add(this.PendentesDataGridView);
            this.Pendentes.Location = new System.Drawing.Point(4, 25);
            this.Pendentes.Name = "Pendentes";
            this.Pendentes.Padding = new System.Windows.Forms.Padding(3);
            this.Pendentes.Size = new System.Drawing.Size(493, 193);
            this.Pendentes.TabIndex = 0;
            this.Pendentes.Text = "Pendentes";
            this.Pendentes.UseVisualStyleBackColor = true;
            // 
            // PendentesDataGridView
            // 
            this.PendentesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PendentesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PendentesDataGridView.Location = new System.Drawing.Point(3, 3);
            this.PendentesDataGridView.MultiSelect = false;
            this.PendentesDataGridView.Name = "PendentesDataGridView";
            this.PendentesDataGridView.ReadOnly = true;
            this.PendentesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PendentesDataGridView.Size = new System.Drawing.Size(487, 187);
            this.PendentesDataGridView.TabIndex = 0;
            this.PendentesDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PendentesDataGridView_CellContentDoubleClick);
            // 
            // Concluídas
            // 
            this.Concluídas.Controls.Add(this.ConcluidasDataGridView);
            this.Concluídas.Location = new System.Drawing.Point(4, 25);
            this.Concluídas.Name = "Concluídas";
            this.Concluídas.Padding = new System.Windows.Forms.Padding(3);
            this.Concluídas.Size = new System.Drawing.Size(493, 193);
            this.Concluídas.TabIndex = 1;
            this.Concluídas.Text = "Concluídas";
            this.Concluídas.UseVisualStyleBackColor = true;
            // 
            // ConcluidasDataGridView
            // 
            this.ConcluidasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConcluidasDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConcluidasDataGridView.Location = new System.Drawing.Point(3, 3);
            this.ConcluidasDataGridView.MultiSelect = false;
            this.ConcluidasDataGridView.Name = "ConcluidasDataGridView";
            this.ConcluidasDataGridView.ReadOnly = true;
            this.ConcluidasDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ConcluidasDataGridView.Size = new System.Drawing.Size(487, 187);
            this.ConcluidasDataGridView.TabIndex = 0;
            this.ConcluidasDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ConcluidasDataGridView_CellContentDoubleClick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(453, 476);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "Voltar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(116, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(307, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(446, 167);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 31);
            this.button2.TabIndex = 4;
            this.button2.Text = "Excluir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(362, 167);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(63, 31);
            this.button3.TabIndex = 5;
            this.button3.Text = "Editar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(278, 167);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(63, 31);
            this.button4.TabIndex = 4;
            this.button4.Text = "Salvar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Título";
            // 
            // LabelPercentual
            // 
            this.LabelPercentual.AutoSize = true;
            this.LabelPercentual.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LabelPercentual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPercentual.Location = new System.Drawing.Point(8, 174);
            this.LabelPercentual.Name = "LabelPercentual";
            this.LabelPercentual.Size = new System.Drawing.Size(85, 20);
            this.LabelPercentual.TabIndex = 8;
            this.LabelPercentual.Text = "Percentual";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(274, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Prioridade";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(99, 134);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(120, 20);
            this.txtTitulo.TabIndex = 10;
            // 
            // numericUpDownPercentual
            // 
            this.numericUpDownPercentual.Location = new System.Drawing.Point(99, 174);
            this.numericUpDownPercentual.Name = "numericUpDownPercentual";
            this.numericUpDownPercentual.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownPercentual.TabIndex = 13;
            // 
            // cbPrioridade
            // 
            this.cbPrioridade.FormattingEnabled = true;
            this.cbPrioridade.Items.AddRange(new object[] {
            "Alta",
            "Média",
            "Baixa"});
            this.cbPrioridade.Location = new System.Drawing.Point(360, 133);
            this.cbPrioridade.Name = "cbPrioridade";
            this.cbPrioridade.Size = new System.Drawing.Size(149, 21);
            this.cbPrioridade.TabIndex = 14;
            // 
            // FormTarefas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(532, 519);
            this.Controls.Add(this.cbPrioridade);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numericUpDownPercentual);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LabelPercentual);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormTarefas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTarefas";
            this.Load += new System.EventHandler(this.FormTarefas_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.Pendentes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PendentesDataGridView)).EndInit();
            this.Concluídas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ConcluidasDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPercentual)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Pendentes;
        private System.Windows.Forms.TabPage Concluídas;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LabelPercentual;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.NumericUpDown numericUpDownPercentual;
        public System.Windows.Forms.ComboBox cbPrioridade;
        private System.Windows.Forms.DataGridView PendentesDataGridView;
        private System.Windows.Forms.DataGridView ConcluidasDataGridView;
    }
}