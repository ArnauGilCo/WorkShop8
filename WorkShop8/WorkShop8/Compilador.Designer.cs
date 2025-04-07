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
            SuspendLayout();
            // 
            // Compiler
            // 
            Compiler.Location = new Point(172, 47);
            Compiler.Name = "Compiler";
            Compiler.Size = new Size(226, 70);
            Compiler.TabIndex = 0;
            Compiler.Text = "Compilador expressió";
            Compiler.UseVisualStyleBackColor = true;
            Compiler.Click += Compiler_Click;
            // 
            // txt_Compiler
            // 
            txt_Compiler.Location = new Point(172, 123);
            txt_Compiler.Name = "txt_Compiler";
            txt_Compiler.Size = new Size(465, 27);
            txt_Compiler.TabIndex = 1;
            // 
            // CompilerFile
            // 
            CompilerFile.Location = new Point(404, 47);
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
            txtExpressio.Location = new Point(172, 307);
            txtExpressio.Name = "txtExpressio";
            txtExpressio.Size = new Size(410, 27);
            txtExpressio.TabIndex = 3;
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(250, 237);
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
            lblResultat.Location = new Point(361, 355);
            lblResultat.Name = "lblResultat";
            lblResultat.Size = new Size(50, 20);
            lblResultat.TabIndex = 5;
            lblResultat.Text = "label1";
            // 
            // Compilador
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblResultat);
            Controls.Add(btnCalcular);
            Controls.Add(txtExpressio);
            Controls.Add(CompilerFile);
            Controls.Add(txt_Compiler);
            Controls.Add(Compiler);
            Name = "Compilador";
            Text = "Compilador";
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
    }
}
