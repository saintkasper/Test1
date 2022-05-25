namespace тест1пишистирай
{
    partial class CustomElement
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lName = new System.Windows.Forms.Label();
            this.lDescription = new System.Windows.Forms.Label();
            this.lManufacturer = new System.Windows.Forms.Label();
            this.lCost = new System.Windows.Forms.Label();
            this.lDiscount = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.lDiscount);
            this.panel1.Controls.Add(this.lCost);
            this.panel1.Controls.Add(this.lManufacturer);
            this.panel1.Controls.Add(this.lDescription);
            this.panel1.Controls.Add(this.lName);
            this.panel1.Controls.Add(this.pbImage);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(951, 144);
            this.panel1.TabIndex = 0;
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lName.Location = new System.Drawing.Point(147, 3);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(121, 23);
            this.lName.TabIndex = 5;
            this.lName.Text = "Наименование";
            // 
            // lDescription
            // 
            this.lDescription.AutoSize = true;
            this.lDescription.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lDescription.Location = new System.Drawing.Point(147, 32);
            this.lDescription.Name = "lDescription";
            this.lDescription.Size = new System.Drawing.Size(86, 23);
            this.lDescription.TabIndex = 6;
            this.lDescription.Text = "Описание";
            // 
            // lManufacturer
            // 
            this.lManufacturer.AutoSize = true;
            this.lManufacturer.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lManufacturer.Location = new System.Drawing.Point(147, 61);
            this.lManufacturer.Name = "lManufacturer";
            this.lManufacturer.Size = new System.Drawing.Size(140, 23);
            this.lManufacturer.TabIndex = 7;
            this.lManufacturer.Text = "Производитель: ";
            // 
            // lCost
            // 
            this.lCost.AutoSize = true;
            this.lCost.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lCost.Location = new System.Drawing.Point(147, 90);
            this.lCost.Name = "lCost";
            this.lCost.Size = new System.Drawing.Size(57, 23);
            this.lCost.TabIndex = 8;
            this.lCost.Text = "Цена: ";
            // 
            // lDiscount
            // 
            this.lDiscount.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lDiscount.Location = new System.Drawing.Point(432, 3);
            this.lDiscount.Name = "lDiscount";
            this.lDiscount.Size = new System.Drawing.Size(516, 29);
            this.lDiscount.TabIndex = 9;
            this.lDiscount.Text = "Размер скидки: ";
            this.lDiscount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(3, 3);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(138, 138);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // CustomElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.panel1);
            this.Name = "CustomElement";
            this.Size = new System.Drawing.Size(957, 150);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Label lDiscount;
        private System.Windows.Forms.Label lCost;
        private System.Windows.Forms.Label lManufacturer;
        private System.Windows.Forms.Label lDescription;
        private System.Windows.Forms.Label lName;
    }
}
