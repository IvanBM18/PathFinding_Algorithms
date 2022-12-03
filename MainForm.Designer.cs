/*
 * Created by SharpDevelop.
 * User: ivan8
 * Date: 28/11/2022
 * Time: 01:06 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace P2_Laberinto
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.openImgDialog = new System.Windows.Forms.OpenFileDialog();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.btnOpenImage = new System.Windows.Forms.Button();
			this.btnDFSI = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.buttonAStar = new System.Windows.Forms.Button();
			this.buttonBetterFirst = new System.Windows.Forms.Button();
			this.buttonBFS = new System.Windows.Forms.Button();
			this.buttonRestart = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// openImgDialog
			// 
			this.openImgDialog.FileName = "openImgDialog";
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(12, 12);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(875, 539);
			this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// btnOpenImage
			// 
			this.btnOpenImage.BackColor = System.Drawing.Color.Green;
			this.btnOpenImage.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnOpenImage.Location = new System.Drawing.Point(915, 12);
			this.btnOpenImage.Name = "btnOpenImage";
			this.btnOpenImage.Size = new System.Drawing.Size(204, 62);
			this.btnOpenImage.TabIndex = 1;
			this.btnOpenImage.Text = "Abrir Imagen";
			this.btnOpenImage.UseVisualStyleBackColor = false;
			this.btnOpenImage.Click += new System.EventHandler(this.btnOpenImageClick);
			// 
			// btnDFSI
			// 
			this.btnDFSI.BackColor = System.Drawing.Color.Green;
			this.btnDFSI.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnDFSI.Location = new System.Drawing.Point(6, 33);
			this.btnDFSI.Name = "btnDFSI";
			this.btnDFSI.Size = new System.Drawing.Size(198, 62);
			this.btnDFSI.TabIndex = 2;
			this.btnDFSI.Text = "Busqueda en Profundidad";
			this.btnDFSI.UseVisualStyleBackColor = false;
			this.btnDFSI.Click += new System.EventHandler(this.BtnDFSIClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.buttonAStar);
			this.groupBox1.Controls.Add(this.buttonBetterFirst);
			this.groupBox1.Controls.Add(this.buttonBFS);
			this.groupBox1.Controls.Add(this.btnDFSI);
			this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.groupBox1.Location = new System.Drawing.Point(909, 80);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(210, 321);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Resolver Mediante";
			this.groupBox1.Enter += new System.EventHandler(this.GroupBox1Enter);
			// 
			// buttonAStar
			// 
			this.buttonAStar.BackColor = System.Drawing.Color.Green;
			this.buttonAStar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.buttonAStar.Location = new System.Drawing.Point(6, 237);
			this.buttonAStar.Name = "buttonAStar";
			this.buttonAStar.Size = new System.Drawing.Size(198, 62);
			this.buttonAStar.TabIndex = 5;
			this.buttonAStar.Text = "A*";
			this.buttonAStar.UseVisualStyleBackColor = false;
			this.buttonAStar.Click += new System.EventHandler(this.ButtonAStarClick);
			// 
			// buttonBetterFirst
			// 
			this.buttonBetterFirst.BackColor = System.Drawing.Color.Green;
			this.buttonBetterFirst.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.buttonBetterFirst.Location = new System.Drawing.Point(6, 169);
			this.buttonBetterFirst.Name = "buttonBetterFirst";
			this.buttonBetterFirst.Size = new System.Drawing.Size(198, 62);
			this.buttonBetterFirst.TabIndex = 4;
			this.buttonBetterFirst.Text = "Primero el mejor";
			this.buttonBetterFirst.UseVisualStyleBackColor = false;
			this.buttonBetterFirst.Click += new System.EventHandler(this.ButtonBetterFirstClick);
			// 
			// buttonBFS
			// 
			this.buttonBFS.BackColor = System.Drawing.Color.Green;
			this.buttonBFS.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.buttonBFS.Location = new System.Drawing.Point(6, 101);
			this.buttonBFS.Name = "buttonBFS";
			this.buttonBFS.Size = new System.Drawing.Size(198, 62);
			this.buttonBFS.TabIndex = 3;
			this.buttonBFS.Text = "Busqueda en Anchura";
			this.buttonBFS.UseVisualStyleBackColor = false;
			this.buttonBFS.Click += new System.EventHandler(this.ButtonBFSClick);
			// 
			// buttonRestart
			// 
			this.buttonRestart.BackColor = System.Drawing.Color.Green;
			this.buttonRestart.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.buttonRestart.Location = new System.Drawing.Point(915, 407);
			this.buttonRestart.Name = "buttonRestart";
			this.buttonRestart.Size = new System.Drawing.Size(204, 62);
			this.buttonRestart.TabIndex = 4;
			this.buttonRestart.Text = "Reiniciar";
			this.buttonRestart.UseVisualStyleBackColor = false;
			this.buttonRestart.Click += new System.EventHandler(this.ButtonRestartClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.ClientSize = new System.Drawing.Size(1131, 563);
			this.Controls.Add(this.buttonRestart);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnOpenImage);
			this.Controls.Add(this.pictureBox);
			this.Name = "MainForm";
			this.Text = "P2_Laberinto";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button buttonRestart;
		private System.Windows.Forms.Button buttonBFS;
		private System.Windows.Forms.Button buttonBetterFirst;
		private System.Windows.Forms.Button buttonAStar;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnDFSI;
		private System.Windows.Forms.Button btnOpenImage;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.OpenFileDialog openImgDialog;
		
		
	}
}
