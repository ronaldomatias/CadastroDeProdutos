namespace ProjetoCadastro.View
{
    partial class TelaListaProdutos
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
            this.gridViewTelaListaProdutos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTelaListaProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewTelaListaProdutos
            // 
            this.gridViewTelaListaProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewTelaListaProdutos.Location = new System.Drawing.Point(187, 62);
            this.gridViewTelaListaProdutos.Name = "gridViewTelaListaProdutos";
            this.gridViewTelaListaProdutos.Size = new System.Drawing.Size(362, 342);
            this.gridViewTelaListaProdutos.TabIndex = 0;
            // 
            // TelaListaProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridViewTelaListaProdutos);
            this.Name = "TelaListaProdutos";
            this.Text = "TelaListaProdutos";
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTelaListaProdutos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridViewTelaListaProdutos;
    }
}