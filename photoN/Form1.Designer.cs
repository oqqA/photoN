namespace photoN
{
   partial class Form1
   {
      /// <summary>
      /// Обязательная переменная конструктора.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Освободить все используемые ресурсы.
      /// </summary>
      /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Код, автоматически созданный конструктором форм Windows

      /// <summary>
      /// Требуемый метод для поддержки конструктора — не изменяйте 
      /// содержимое этого метода с помощью редактора кода.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         this.pic = new System.Windows.Forms.PictureBox();
         this.timer1 = new System.Windows.Forms.Timer(this.components);
         this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
         this.radioButton1 = new System.Windows.Forms.RadioButton();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.radioButton2 = new System.Windows.Forms.RadioButton();
         this.button1 = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // pic
         // 
         this.pic.BackColor = System.Drawing.SystemColors.ControlDark;
         this.pic.Dock = System.Windows.Forms.DockStyle.Right;
         this.pic.Location = new System.Drawing.Point(129, 0);
         this.pic.Name = "pic";
         this.pic.Size = new System.Drawing.Size(671, 450);
         this.pic.TabIndex = 0;
         this.pic.TabStop = false;
         this.pic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pic_MouseDown);
         this.pic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pic_MouseMove);
         this.pic.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pic_MouseWheel);
         // 
         // timer1
         // 
         this.timer1.Interval = 20;
         this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
         // 
         // openFileDialog1
         // 
         this.openFileDialog1.FileName = "openFileDialog1";
         this.openFileDialog1.Filter = "(*.obj)|*.obj";
         // 
         // radioButton1
         // 
         this.radioButton1.AutoSize = true;
         this.radioButton1.Checked = true;
         this.radioButton1.Location = new System.Drawing.Point(5, 19);
         this.radioButton1.Name = "radioButton1";
         this.radioButton1.Size = new System.Drawing.Size(94, 17);
         this.radioButton1.TabIndex = 1;
         this.radioButton1.TabStop = true;
         this.radioButton1.Text = "Проволочный";
         this.radioButton1.UseVisualStyleBackColor = true;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.radioButton2);
         this.groupBox1.Controls.Add(this.radioButton1);
         this.groupBox1.Location = new System.Drawing.Point(12, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(107, 66);
         this.groupBox1.TabIndex = 2;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Вид рендера";
         // 
         // radioButton2
         // 
         this.radioButton2.AutoSize = true;
         this.radioButton2.Location = new System.Drawing.Point(6, 42);
         this.radioButton2.Name = "radioButton2";
         this.radioButton2.Size = new System.Drawing.Size(88, 17);
         this.radioButton2.TabIndex = 1;
         this.radioButton2.Text = "Полигонный";
         this.radioButton2.UseVisualStyleBackColor = true;
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(12, 84);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(107, 24);
         this.button1.TabIndex = 3;
         this.button1.Text = "Open";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 450);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.pic);
         this.Name = "Form1";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "N";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
         ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.PictureBox pic;
      private System.Windows.Forms.Timer timer1;
      private System.Windows.Forms.OpenFileDialog openFileDialog1;
      private System.Windows.Forms.RadioButton radioButton1;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.RadioButton radioButton2;
      private System.Windows.Forms.Button button1;
   }
}

