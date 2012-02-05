namespace WindowsForms_MDI_Escola
{
    partial class FrmPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarAlunosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarTurmasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarMatriculasToolStripMenuItem_Click = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(654, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarAlunosToolStripMenuItem,
            this.cadastrarTurmasToolStripMenuItem,
            this.cadastrarMatriculasToolStripMenuItem_Click});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // cadastrarAlunosToolStripMenuItem
            // 
            this.cadastrarAlunosToolStripMenuItem.Name = "cadastrarAlunosToolStripMenuItem";
            this.cadastrarAlunosToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.cadastrarAlunosToolStripMenuItem.Text = "Cadastrar Alunos";
            this.cadastrarAlunosToolStripMenuItem.Click += new System.EventHandler(this.cadastrarAlunosToolStripMenuItem_Click);
            // 
            // cadastrarTurmasToolStripMenuItem
            // 
            this.cadastrarTurmasToolStripMenuItem.Name = "cadastrarTurmasToolStripMenuItem";
            this.cadastrarTurmasToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.cadastrarTurmasToolStripMenuItem.Text = "Cadastrar Turmas";
            this.cadastrarTurmasToolStripMenuItem.Click += new System.EventHandler(this.cadastrarTurmasToolStripMenuItem_Click);
            // 
            // cadastrarMatriculasToolStripMenuItem_Click
            // 
            this.cadastrarMatriculasToolStripMenuItem_Click.Name = "cadastrarMatriculasToolStripMenuItem_Click";
            this.cadastrarMatriculasToolStripMenuItem_Click.Size = new System.Drawing.Size(168, 22);
            this.cadastrarMatriculasToolStripMenuItem_Click.Text = "Matricular Alunos";
            this.cadastrarMatriculasToolStripMenuItem_Click.Click += new System.EventHandler(this.cadastrarMatriculasToolStripMenuItem_Click_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 273);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Escola - admin";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarAlunosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarTurmasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarMatriculasToolStripMenuItem_Click;
    }
}

