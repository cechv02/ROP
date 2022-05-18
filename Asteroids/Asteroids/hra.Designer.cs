namespace Asteroids
{
    partial class formAsteroids
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAsteroids));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timerAsteroids = new System.Windows.Forms.Timer(this.components);
            this.timerSpaceship = new System.Windows.Forms.Timer(this.components);
            this.timerMissile = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timerRotation = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "spaceship0.png");
            this.imageList1.Images.SetKeyName(1, "spaceship45.png");
            this.imageList1.Images.SetKeyName(2, "spaceship90.png");
            this.imageList1.Images.SetKeyName(3, "spaceship135.png");
            this.imageList1.Images.SetKeyName(4, "spaceship180.png");
            this.imageList1.Images.SetKeyName(5, "spaceship225.png");
            this.imageList1.Images.SetKeyName(6, "spaceship270.png");
            this.imageList1.Images.SetKeyName(7, "spaceship315.png");
            this.imageList1.Images.SetKeyName(8, "asteroid.png");
            this.imageList1.Images.SetKeyName(9, "hearts.png");
            this.imageList1.Images.SetKeyName(10, "hearts-1down.png");
            this.imageList1.Images.SetKeyName(11, "hearts-2down.png");
            this.imageList1.Images.SetKeyName(12, "hearts-3down.png");
            // 
            // timerAsteroids
            // 
            this.timerAsteroids.Tick += new System.EventHandler(this.timerAsteroids_Tick);
            // 
            // timerSpaceship
            // 
            this.timerSpaceship.Tick += new System.EventHandler(this.timerSpaceship_Tick);
            // 
            // timerMissile
            // 
            this.timerMissile.Tick += new System.EventHandler(this.timerMissile_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "score:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(139, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 62);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timerRotation
            // 
            this.timerRotation.Tick += new System.EventHandler(this.timerRotation_Tick);
            // 
            // formAsteroids
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Asteroids.Properties.Resources.bg_muchbetter;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 761);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "formAsteroids";
            this.Text = "Asteroids";
            this.Load += new System.EventHandler(this.formAsteroids_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.formAsteroids_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timerAsteroids;
        private System.Windows.Forms.Timer timerSpaceship;
        private System.Windows.Forms.Timer timerMissile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timerRotation;
    }
}

