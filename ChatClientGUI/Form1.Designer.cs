namespace ChatClientGUI
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.displayConnection_lbl = new System.Windows.Forms.Label();
            this.inMessage_txtbox = new System.Windows.Forms.TextBox();
            this.sendMessage_btn = new System.Windows.Forms.Button();
            this.chatDisplayer_txtbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // displayConnection_lbl
            // 
            this.displayConnection_lbl.AutoSize = true;
            this.displayConnection_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayConnection_lbl.ForeColor = System.Drawing.Color.Red;
            this.displayConnection_lbl.Location = new System.Drawing.Point(314, 9);
            this.displayConnection_lbl.Name = "displayConnection_lbl";
            this.displayConnection_lbl.Size = new System.Drawing.Size(116, 20);
            this.displayConnection_lbl.TabIndex = 0;
            this.displayConnection_lbl.Text = "Not Connected";
            // 
            // inMessage_txtbox
            // 
            this.inMessage_txtbox.Location = new System.Drawing.Point(12, 503);
            this.inMessage_txtbox.Name = "inMessage_txtbox";
            this.inMessage_txtbox.Size = new System.Drawing.Size(334, 20);
            this.inMessage_txtbox.TabIndex = 1;
            this.inMessage_txtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inMessage_txtbox_KeyDown);
            // 
            // sendMessage_btn
            // 
            this.sendMessage_btn.Location = new System.Drawing.Point(355, 501);
            this.sendMessage_btn.Name = "sendMessage_btn";
            this.sendMessage_btn.Size = new System.Drawing.Size(75, 23);
            this.sendMessage_btn.TabIndex = 2;
            this.sendMessage_btn.Text = "SEND";
            this.sendMessage_btn.UseVisualStyleBackColor = true;
            this.sendMessage_btn.Click += new System.EventHandler(this.SendMessage_btn_Click);
            // 
            // chatDisplayer_txtbox
            // 
            this.chatDisplayer_txtbox.Location = new System.Drawing.Point(12, 37);
            this.chatDisplayer_txtbox.Multiline = true;
            this.chatDisplayer_txtbox.Name = "chatDisplayer_txtbox";
            this.chatDisplayer_txtbox.Size = new System.Drawing.Size(418, 458);
            this.chatDisplayer_txtbox.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 535);
            this.Controls.Add(this.chatDisplayer_txtbox);
            this.Controls.Add(this.sendMessage_btn);
            this.Controls.Add(this.inMessage_txtbox);
            this.Controls.Add(this.displayConnection_lbl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label displayConnection_lbl;
        private System.Windows.Forms.TextBox inMessage_txtbox;
        private System.Windows.Forms.Button sendMessage_btn;
        private System.Windows.Forms.TextBox chatDisplayer_txtbox;
    }
}

