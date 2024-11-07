using System;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;

namespace Examen_YYGP_JRCC
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
            this.btnApagarC = new System.Windows.Forms.Button();
            this.btnEncenderC = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.tbFecha = new System.Windows.Forms.TextBox();
            this.lbAviso = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Temperatura = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnApagarC
            // 
            this.btnApagarC.BackColor = System.Drawing.Color.Crimson;
            this.btnApagarC.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnApagarC.Location = new System.Drawing.Point(397, 316);
            this.btnApagarC.Name = "btnApagarC";
            this.btnApagarC.Size = new System.Drawing.Size(98, 53);
            this.btnApagarC.TabIndex = 0;
            this.btnApagarC.Text = "Apagar Servomotor";
            this.btnApagarC.UseVisualStyleBackColor = false;
            this.btnApagarC.Click += new System.EventHandler(this.btnApagarC_Click);
            // 
            // btnEncenderC
            // 
            this.btnEncenderC.BackColor = System.Drawing.Color.DarkGreen;
            this.btnEncenderC.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEncenderC.Location = new System.Drawing.Point(147, 323);
            this.btnEncenderC.Name = "btnEncenderC";
            this.btnEncenderC.Size = new System.Drawing.Size(110, 46);
            this.btnEncenderC.TabIndex = 1;
            this.btnEncenderC.Text = "Encender Servomotor";
            this.btnEncenderC.UseVisualStyleBackColor = false;
            this.btnEncenderC.Click += new System.EventHandler(this.btnEncenderC_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(141, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre de usuario";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(370, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(311, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ingrese la fecha con el formato dia-mes-año";
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(144, 127);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(100, 20);
            this.tbNombre.TabIndex = 4;
            // 
            // tbFecha
            // 
            this.tbFecha.Location = new System.Drawing.Point(436, 127);
            this.tbFecha.Name = "tbFecha";
            this.tbFecha.Size = new System.Drawing.Size(100, 20);
            this.tbFecha.TabIndex = 5;
            // 
            // lbAviso
            // 
            this.lbAviso.AutoSize = true;
            this.lbAviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAviso.Location = new System.Drawing.Point(303, 340);
            this.lbAviso.Name = "lbAviso";
            this.lbAviso.Size = new System.Drawing.Size(64, 16);
            this.lbAviso.TabIndex = 6;
            this.lbAviso.Text = "Apagado";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.SystemColors.Info;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(291, 147);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(110, 46);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar Usuario";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(600, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Temperatura";
            // 
            // Temperatura
            // 
            this.Temperatura.AutoSize = true;
            this.Temperatura.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Temperatura.ForeColor = System.Drawing.Color.Red;
            this.Temperatura.Location = new System.Drawing.Point(599, 316);
            this.Temperatura.Name = "Temperatura";
            this.Temperatura.Size = new System.Drawing.Size(68, 39);
            this.Temperatura.TabIndex = 9;
            this.Temperatura.Text = "0.0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Temperatura);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lbAviso);
            this.Controls.Add(this.tbFecha);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEncenderC);
            this.Controls.Add(this.btnApagarC);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnEncenderC_Click(object sender, EventArgs e)
        {
            if (!ArduinoPort.IsOpen)
            {
                ArduinoPort.Open();

                ArduinoPort.WriteLine("1");
                lbAviso.Text = "Conectado";
            }  // Enviar al puerto serial
         
        }

        private void btnApagarC_Click(object sender, EventArgs e)
        {
            ArduinoPort.Close();
            lbAviso.Text = "Desconectado";
            

        }

        #endregion

        private System.Windows.Forms.Button btnApagarC;
        private System.Windows.Forms.Button btnEncenderC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.TextBox tbFecha;
        private System.Windows.Forms.Label lbAviso;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Temperatura;
    }
}

