namespace TestsGeneratorApplication
{
    partial class AppForm
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.tbMaxRead = new System.Windows.Forms.TextBox();
            this.tbMaxProcess = new System.Windows.Forms.TextBox();
            this.tbMaxWrite = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChooseFiles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(377, 223);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(101, 41);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // tbMaxRead
            // 
            this.tbMaxRead.Location = new System.Drawing.Point(507, 31);
            this.tbMaxRead.Name = "tbMaxRead";
            this.tbMaxRead.Size = new System.Drawing.Size(100, 22);
            this.tbMaxRead.TabIndex = 1;
            this.tbMaxRead.TextChanged += new System.EventHandler(this.NumbersOnly_TextChanged);
            this.tbMaxRead.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumbersOnly_KeyPress);
            // 
            // tbMaxProcess
            // 
            this.tbMaxProcess.Location = new System.Drawing.Point(507, 86);
            this.tbMaxProcess.Name = "tbMaxProcess";
            this.tbMaxProcess.Size = new System.Drawing.Size(100, 22);
            this.tbMaxProcess.TabIndex = 2;
            this.tbMaxProcess.TextChanged += new System.EventHandler(this.NumbersOnly_TextChanged);
            this.tbMaxProcess.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumbersOnly_KeyPress);
            // 
            // tbMaxWrite
            // 
            this.tbMaxWrite.Location = new System.Drawing.Point(507, 137);
            this.tbMaxWrite.Name = "tbMaxWrite";
            this.tbMaxWrite.Size = new System.Drawing.Size(100, 22);
            this.tbMaxWrite.TabIndex = 3;
            this.tbMaxWrite.TextChanged += new System.EventHandler(this.NumbersOnly_TextChanged);
            this.tbMaxWrite.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumbersOnly_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Количество файлов, загружаемых за раз: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(449, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Максимальное количество одновременно обрабатываемых задач:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(344, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Количество одновременно записываемых файлов:";
            // 
            // btnChooseFiles
            // 
            this.btnChooseFiles.Location = new System.Drawing.Point(195, 223);
            this.btnChooseFiles.Name = "btnChooseFiles";
            this.btnChooseFiles.Size = new System.Drawing.Size(101, 41);
            this.btnChooseFiles.TabIndex = 7;
            this.btnChooseFiles.Text = "Choose files";
            this.btnChooseFiles.UseVisualStyleBackColor = true;
            this.btnChooseFiles.Click += new System.EventHandler(this.btnChooseFiles_Click);
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 303);
            this.Controls.Add(this.btnChooseFiles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbMaxWrite);
            this.Controls.Add(this.tbMaxProcess);
            this.Controls.Add(this.tbMaxRead);
            this.Controls.Add(this.btnGenerate);
            this.Name = "AppForm";
            this.Text = "Tests Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox tbMaxRead;
        private System.Windows.Forms.TextBox tbMaxProcess;
        private System.Windows.Forms.TextBox tbMaxWrite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnChooseFiles;
    }
}

