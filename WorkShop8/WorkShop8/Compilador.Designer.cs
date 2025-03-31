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
            SuspendLayout();
            // 
            // Compiler
            // 
            Compiler.Location = new Point(279, 160);
            Compiler.Name = "Compiler";
            Compiler.Size = new Size(226, 70);
            Compiler.TabIndex = 0;
            Compiler.Text = "Compilador";
            Compiler.UseVisualStyleBackColor = true;
            // 
            // txt_Compiler
            // 
            txt_Compiler.Location = new Point(222, 236);
            txt_Compiler.Name = "txt_Compiler";
            txt_Compiler.Size = new Size(331, 27);
            txt_Compiler.TabIndex = 1;
            // 
            // Compilador
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}
