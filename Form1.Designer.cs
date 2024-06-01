namespace Interpolation
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ArgumentTable = new System.Windows.Forms.DataGridView();
            this.GenTableBtn = new System.Windows.Forms.Button();
            this.PointCount = new System.Windows.Forms.TextBox();
            this.LagranjBtn = new System.Windows.Forms.Button();
            this.CubicSplineBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArgumentTable)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Location = new System.Drawing.Point(13, 13);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(775, 316);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // ArgumentTable
            // 
            this.ArgumentTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ArgumentTable.Location = new System.Drawing.Point(13, 335);
            this.ArgumentTable.Name = "ArgumentTable";
            this.ArgumentTable.Size = new System.Drawing.Size(775, 68);
            this.ArgumentTable.TabIndex = 1;
            // 
            // GenTableBtn
            // 
            this.GenTableBtn.Location = new System.Drawing.Point(119, 409);
            this.GenTableBtn.Name = "GenTableBtn";
            this.GenTableBtn.Size = new System.Drawing.Size(109, 40);
            this.GenTableBtn.TabIndex = 2;
            this.GenTableBtn.Text = "Установить количество точек";
            this.GenTableBtn.UseVisualStyleBackColor = true;
            this.GenTableBtn.Click += new System.EventHandler(this.GenTableBtn_Click);
            // 
            // PointCount
            // 
            this.PointCount.Location = new System.Drawing.Point(12, 420);
            this.PointCount.Name = "PointCount";
            this.PointCount.Size = new System.Drawing.Size(100, 20);
            this.PointCount.TabIndex = 3;
            // 
            // LagranjBtn
            // 
            this.LagranjBtn.Location = new System.Drawing.Point(234, 409);
            this.LagranjBtn.Name = "LagranjBtn";
            this.LagranjBtn.Size = new System.Drawing.Size(119, 40);
            this.LagranjBtn.TabIndex = 4;
            this.LagranjBtn.Text = "Построить полином Лагранжа";
            this.LagranjBtn.UseVisualStyleBackColor = true;
            this.LagranjBtn.Click += new System.EventHandler(this.LagranjBtn_Click);
            // 
            // CubicSplineBtn
            // 
            this.CubicSplineBtn.Location = new System.Drawing.Point(360, 409);
            this.CubicSplineBtn.Name = "CubicSplineBtn";
            this.CubicSplineBtn.Size = new System.Drawing.Size(120, 40);
            this.CubicSplineBtn.TabIndex = 5;
            this.CubicSplineBtn.Text = "Построить кубический сплайн";
            this.CubicSplineBtn.UseVisualStyleBackColor = true;
            this.CubicSplineBtn.Click += new System.EventHandler(this.CubicSplineBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CubicSplineBtn);
            this.Controls.Add(this.LagranjBtn);
            this.Controls.Add(this.PointCount);
            this.Controls.Add(this.GenTableBtn);
            this.Controls.Add(this.ArgumentTable);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArgumentTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridView ArgumentTable;
        private System.Windows.Forms.Button GenTableBtn;
        private System.Windows.Forms.TextBox PointCount;
        private System.Windows.Forms.Button LagranjBtn;
        private System.Windows.Forms.Button CubicSplineBtn;
    }
}

