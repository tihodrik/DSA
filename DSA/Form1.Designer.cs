namespace DSA
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Q = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.P = new System.Windows.Forms.TextBox();
            this.userParams = new System.Windows.Forms.GroupBox();
            this.wrongP = new System.Windows.Forms.Label();
            this.wrongQ = new System.Windows.Forms.Label();
            this.Generate = new System.Windows.Forms.Button();
            this.Check = new System.Windows.Forms.Button();
            this.gen = new System.Windows.Forms.TextBox();
            this.ch = new System.Windows.Forms.TextBox();
            this.userInput = new System.Windows.Forms.CheckBox();
            this.message = new System.Windows.Forms.Label();
            this.userParams.SuspendLayout();
            this.SuspendLayout();
            // 
            // text
            // 
            this.text.Location = new System.Drawing.Point(12, 42);
            this.text.Multiline = true;
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(292, 169);
            this.text.TabIndex = 0;
            this.text.TextChanged += new System.EventHandler(this.text_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите текст сообщения";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Введите значение q";
            // 
            // Q
            // 
            this.Q.Location = new System.Drawing.Point(22, 44);
            this.Q.Name = "Q";
            this.Q.Size = new System.Drawing.Size(436, 20);
            this.Q.TabIndex = 4;
            this.Q.TextChanged += new System.EventHandler(this.Q_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Введите значение p";
            // 
            // P
            // 
            this.P.Location = new System.Drawing.Point(22, 103);
            this.P.Name = "P";
            this.P.Size = new System.Drawing.Size(436, 20);
            this.P.TabIndex = 6;
            this.P.TextChanged += new System.EventHandler(this.P_TextChanged);
            // 
            // userParams
            // 
            this.userParams.Controls.Add(this.wrongP);
            this.userParams.Controls.Add(this.wrongQ);
            this.userParams.Controls.Add(this.P);
            this.userParams.Controls.Add(this.label3);
            this.userParams.Controls.Add(this.Q);
            this.userParams.Controls.Add(this.label2);
            this.userParams.Enabled = false;
            this.userParams.Location = new System.Drawing.Point(317, 62);
            this.userParams.Name = "userParams";
            this.userParams.Size = new System.Drawing.Size(476, 149);
            this.userParams.TabIndex = 7;
            this.userParams.TabStop = false;
            // 
            // wrongP
            // 
            this.wrongP.AutoSize = true;
            this.wrongP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wrongP.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.wrongP.Location = new System.Drawing.Point(258, 83);
            this.wrongP.Name = "wrongP";
            this.wrongP.Size = new System.Drawing.Size(200, 17);
            this.wrongP.TabIndex = 8;
            this.wrongP.Text = "Значение p некорректно!";
            this.wrongP.Visible = false;
            // 
            // wrongQ
            // 
            this.wrongQ.AutoSize = true;
            this.wrongQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wrongQ.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.wrongQ.Location = new System.Drawing.Point(258, 24);
            this.wrongQ.Name = "wrongQ";
            this.wrongQ.Size = new System.Drawing.Size(200, 17);
            this.wrongQ.TabIndex = 7;
            this.wrongQ.Text = "Значение q некорректно!";
            this.wrongQ.Visible = false;
            // 
            // Generate
            // 
            this.Generate.Enabled = false;
            this.Generate.Location = new System.Drawing.Point(32, 258);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(360, 23);
            this.Generate.TabIndex = 9;
            this.Generate.Text = "Сгенерировать подпись";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // Check
            // 
            this.Check.Enabled = false;
            this.Check.Location = new System.Drawing.Point(415, 258);
            this.Check.Name = "Check";
            this.Check.Size = new System.Drawing.Size(360, 23);
            this.Check.TabIndex = 10;
            this.Check.Text = "Проверить подпись";
            this.Check.UseVisualStyleBackColor = true;
            this.Check.Click += new System.EventHandler(this.Check_Click);
            // 
            // gen
            // 
            this.gen.Location = new System.Drawing.Point(32, 287);
            this.gen.Multiline = true;
            this.gen.Name = "gen";
            this.gen.ReadOnly = true;
            this.gen.Size = new System.Drawing.Size(360, 46);
            this.gen.TabIndex = 11;
            // 
            // ch
            // 
            this.ch.Location = new System.Drawing.Point(415, 287);
            this.ch.Multiline = true;
            this.ch.Name = "ch";
            this.ch.ReadOnly = true;
            this.ch.Size = new System.Drawing.Size(360, 46);
            this.ch.TabIndex = 12;
            // 
            // userInput
            // 
            this.userInput.AutoSize = true;
            this.userInput.Location = new System.Drawing.Point(317, 39);
            this.userInput.Name = "userInput";
            this.userInput.Size = new System.Drawing.Size(257, 17);
            this.userInput.TabIndex = 8;
            this.userInput.Text = "Использовать пользовательские параметры";
            this.userInput.UseVisualStyleBackColor = true;
            this.userInput.CheckedChanged += new System.EventHandler(this.userInput_CheckedChanged);
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.message.ForeColor = System.Drawing.SystemColors.Highlight;
            this.message.Location = new System.Drawing.Point(305, 238);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(200, 17);
            this.message.TabIndex = 9;
            this.message.Text = "Значение q некорректно!";
            this.message.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 353);
            this.Controls.Add(this.message);
            this.Controls.Add(this.ch);
            this.Controls.Add(this.gen);
            this.Controls.Add(this.Check);
            this.Controls.Add(this.Generate);
            this.Controls.Add(this.userInput);
            this.Controls.Add(this.userParams);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text);
            this.Name = "Form1";
            this.Text = "Form1";
            this.userParams.ResumeLayout(false);
            this.userParams.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Q;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox P;
        private System.Windows.Forms.GroupBox userParams;
        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.Button Check;
        private System.Windows.Forms.TextBox gen;
        private System.Windows.Forms.TextBox ch;
        private System.Windows.Forms.CheckBox userInput;
        private System.Windows.Forms.Label wrongP;
        private System.Windows.Forms.Label wrongQ;
        private System.Windows.Forms.Label message;
    }
}

