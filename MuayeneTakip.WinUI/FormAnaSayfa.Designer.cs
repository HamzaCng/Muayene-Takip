namespace MuayeneTakip.WinUI
{
    partial class FormAnaSayfa
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
            this.menuStripAnaSayfa = new System.Windows.Forms.MenuStrip();
            this.hastaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hastaEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hastaListeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.muayeneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.muayeEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.muayeneListeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripAnaSayfa.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripAnaSayfa
            // 
            this.menuStripAnaSayfa.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStripAnaSayfa.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hastaToolStripMenuItem,
            this.muayeneToolStripMenuItem});
            this.menuStripAnaSayfa.Location = new System.Drawing.Point(0, 0);
            this.menuStripAnaSayfa.Name = "menuStripAnaSayfa";
            this.menuStripAnaSayfa.Size = new System.Drawing.Size(1360, 33);
            this.menuStripAnaSayfa.TabIndex = 1;
            // 
            // hastaToolStripMenuItem
            // 
            this.hastaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hastaEkleToolStripMenuItem,
            this.hastaListeleToolStripMenuItem});
            this.hastaToolStripMenuItem.Name = "hastaToolStripMenuItem";
            this.hastaToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.hastaToolStripMenuItem.Text = "Hasta";
            // 
            // hastaEkleToolStripMenuItem
            // 
            this.hastaEkleToolStripMenuItem.Name = "hastaEkleToolStripMenuItem";
            this.hastaEkleToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.hastaEkleToolStripMenuItem.Text = "Hasta Ekle";
            this.hastaEkleToolStripMenuItem.Click += new System.EventHandler(this.hastaEkleToolStripMenuItem_Click);
            // 
            // hastaListeleToolStripMenuItem
            // 
            this.hastaListeleToolStripMenuItem.Name = "hastaListeleToolStripMenuItem";
            this.hastaListeleToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.hastaListeleToolStripMenuItem.Text = "Hasta Listele";
            this.hastaListeleToolStripMenuItem.Click += new System.EventHandler(this.hastaListeleToolStripMenuItem_Click);
            // 
            // muayeneToolStripMenuItem
            // 
            this.muayeneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.muayeEkleToolStripMenuItem,
            this.muayeneListeleToolStripMenuItem});
            this.muayeneToolStripMenuItem.Name = "muayeneToolStripMenuItem";
            this.muayeneToolStripMenuItem.Size = new System.Drawing.Size(96, 29);
            this.muayeneToolStripMenuItem.Text = "Muayene";
            // 
            // muayeEkleToolStripMenuItem
            // 
            this.muayeEkleToolStripMenuItem.Name = "muayeEkleToolStripMenuItem";
            this.muayeEkleToolStripMenuItem.Size = new System.Drawing.Size(221, 30);
            this.muayeEkleToolStripMenuItem.Text = "Muaye Ekle";
            // 
            // muayeneListeleToolStripMenuItem
            // 
            this.muayeneListeleToolStripMenuItem.Name = "muayeneListeleToolStripMenuItem";
            this.muayeneListeleToolStripMenuItem.Size = new System.Drawing.Size(221, 30);
            this.muayeneListeleToolStripMenuItem.Text = "Muayene Listele";
            // 
            // FormAnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 777);
            this.Controls.Add(this.menuStripAnaSayfa);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripAnaSayfa;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FormAnaSayfa";
            this.Text = "Ana Sayfa";
            this.menuStripAnaSayfa.ResumeLayout(false);
            this.menuStripAnaSayfa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripAnaSayfa;
        private System.Windows.Forms.ToolStripMenuItem hastaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hastaEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hastaListeleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem muayeneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem muayeEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem muayeneListeleToolStripMenuItem;
    }
}

