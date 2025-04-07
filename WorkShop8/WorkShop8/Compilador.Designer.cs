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
            txt_Compiler.Location = new Point(224, 123);
            txt_Compiler.Name = "txt_Compiler";
            txt_Compiler.Size = new Size(331, 27);
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
            // Compilador
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}
