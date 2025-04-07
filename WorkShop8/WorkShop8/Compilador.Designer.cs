namespace WorkShop8
{
    partial class Compilador
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Compiler = new Button();
            txt_Compiler = new TextBox();
            CompilerFile = new Button();
            openFileDialog1 = new OpenFileDialog();
            txtExpressio = new TextBox();
            btnCalcular = new Button();
            lblResultat = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            lblMissatge = new Label();
            SuspendLayout();
            // 
            // Compiler
            // 
            Compiler.Location = new Point(172, 75);
            Compiler.Name = "Compiler";
            Compiler.Size = new Size(226, 70);
            Compiler.TabIndex = 0;
            Compiler.Text = "Compilador expressió";
            Compiler.UseVisualStyleBackColor = true;
            Compiler.Click += Compiler_Click;
            // 
            // txt_Compiler
            // 
            txt_Compiler.Location = new Point(172, 151);
            txt_Compiler.Name = "txt_Compiler";
            txt_Compiler.Size = new Size(465, 27);
            txt_Compiler.TabIndex = 1;
            // 
            // CompilerFile
            // 
            CompilerFile.Location = new Point(404, 75);
            CompilerFile.Name = "CompilerFile";
            CompilerFile.Size = new Size(233, 70);
            CompilerFile.TabIndex = 2;
            CompilerFile.Text = "Compilador fitxer ";
            CompilerFile.UseVisualStyleBackColor = true;
            CompilerFile.Click += CompilerFile_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialogCompiler";
            // 
            // txtExpressio
            // 
            txtExpressio.Location = new Point(186, 335);
            txtExpressio.Name = "txtExpressio";
            txtExpressio.Size = new Size(410, 27);
            txtExpressio.TabIndex = 3;
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(264, 265);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(268, 64);
            btnCalcular.TabIndex = 4;
            btnCalcular.Text = "Calculadora notació polaca";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // lblResultat
            // 
            lblResultat.AutoSize = true;
            lblResultat.BackColor = SystemColors.Menu;
            lblResultat.Location = new Point(361, 376);
            lblResultat.Name = "lblResultat";
            lblResultat.Size = new Size(74, 20);
            lblResultat.TabIndex = 5;
            lblResultat.Text = "RESULTAT";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Info;
            textBox1.Location = new Point(284, 232);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(234, 27);
            textBox1.TabIndex = 6;
            textBox1.Text = "CALCULADORA NOTACIÓ POLACA";
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Info;
            textBox2.Location = new Point(294, 42);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(210, 27);
            textBox2.TabIndex = 7;
            textBox2.Text = "COMPILADOR D'EXPRESSIONS";
            // 
            // lblMissatge
            // 
            lblMissatge.AutoSize = true;
            lblMissatge.BackColor = SystemColors.Menu;
            lblMissatge.Location = new Point(361, 191);
            lblMissatge.Name = "lblMissatge";
            lblMissatge.Size = new Size(74, 20);
            lblMissatge.TabIndex = 8;
            lblMissatge.Text = "RESULTAT";
            // 
            // Compilador
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(800, 450);
            Controls.Add(lblMissatge);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(lblResultat);
            Controls.Add(btnCalcular);
            Controls.Add(txtExpressio);
            Controls.Add(CompilerFile);
            Controls.Add(txt_Compiler);
            Controls.Add(Compiler);
            Name = "Compilador";
            Text = "Compilador i Calculadora";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Compiler;
        private TextBox txt_Compiler;
        private Button CompilerFile;
        private OpenFileDialog openFileDialog1;
        private TextBox txtExpressio;
        private Button btnCalcular;
        private Label lblResultat;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label lblMissatge;
    }
}
