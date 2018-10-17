namespace client_part
{
    partial class client_main
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
            this.cm_tb_ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cm_tb_port = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cm_tb_index = new System.Windows.Forms.TextBox();
            this.cm_btn_send = new System.Windows.Forms.Button();
            this.cm_tb_result = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cm_tb_ip
            // 
            this.cm_tb_ip.Location = new System.Drawing.Point(114, 15);
            this.cm_tb_ip.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cm_tb_ip.Name = "cm_tb_ip";
            this.cm_tb_ip.Size = new System.Drawing.Size(126, 26);
            this.cm_tb_ip.TabIndex = 0;
            this.cm_tb_ip.Text = "192.168.88.217";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP Сервера";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Порт сервера";
            // 
            // cm_tb_port
            // 
            this.cm_tb_port.Location = new System.Drawing.Point(373, 15);
            this.cm_tb_port.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cm_tb_port.Name = "cm_tb_port";
            this.cm_tb_port.Size = new System.Drawing.Size(56, 26);
            this.cm_tb_port.TabIndex = 2;
            this.cm_tb_port.Text = "12088";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(452, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Введите индекс";
            // 
            // cm_tb_index
            // 
            this.cm_tb_index.Location = new System.Drawing.Point(589, 15);
            this.cm_tb_index.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cm_tb_index.Name = "cm_tb_index";
            this.cm_tb_index.Size = new System.Drawing.Size(59, 26);
            this.cm_tb_index.TabIndex = 4;
            // 
            // cm_btn_send
            // 
            this.cm_btn_send.Location = new System.Drawing.Point(673, 12);
            this.cm_btn_send.Name = "cm_btn_send";
            this.cm_btn_send.Size = new System.Drawing.Size(113, 32);
            this.cm_btn_send.TabIndex = 6;
            this.cm_btn_send.Text = "Отправить";
            this.cm_btn_send.UseVisualStyleBackColor = true;
            // 
            // cm_tb_result
            // 
            this.cm_tb_result.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cm_tb_result.Location = new System.Drawing.Point(0, 50);
            this.cm_tb_result.Multiline = true;
            this.cm_tb_result.Name = "cm_tb_result";
            this.cm_tb_result.ReadOnly = true;
            this.cm_tb_result.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.cm_tb_result.Size = new System.Drawing.Size(800, 294);
            this.cm_tb_result.TabIndex = 7;
            // 
            // client_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 344);
            this.Controls.Add(this.cm_tb_result);
            this.Controls.Add(this.cm_btn_send);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cm_tb_index);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cm_tb_port);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cm_tb_ip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "client_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Клиентская часть";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cm_tb_ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cm_tb_port;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cm_tb_index;
        private System.Windows.Forms.Button cm_btn_send;
        private System.Windows.Forms.TextBox cm_tb_result;
    }
}

