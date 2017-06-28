namespace HZBitmap
{
    partial class HvsZ
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.picWorld = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtException = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.picWorld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // picWorld
            // 
            this.picWorld.Location = new System.Drawing.Point(35, 102);
            this.picWorld.Name = "picWorld";
            this.picWorld.Size = new System.Drawing.Size(30, 100);
            this.picWorld.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picWorld.TabIndex = 0;
            this.picWorld.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(980, 43);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(183, 42);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(35, 49);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(356, 31);
            this.txtTime.TabIndex = 2;
            // 
            // txtException
            // 
            this.txtException.Location = new System.Drawing.Point(443, 49);
            this.txtException.Name = "txtException";
            this.txtException.ReadOnly = true;
            this.txtException.Size = new System.Drawing.Size(476, 31);
            this.txtException.TabIndex = 3;
            // 
            // chart1
            // 
            chartArea2.AxisX.LineColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX2.LineColor = System.Drawing.Color.Transparent;
            chartArea2.AxisY.LineColor = System.Drawing.Color.Transparent;
            chartArea2.AxisY2.LineColor = System.Drawing.Color.Transparent;
            chartArea2.BorderColor = System.Drawing.Color.Transparent;
            chartArea2.CursorX.AutoScroll = false;
            chartArea2.CursorY.AutoScroll = false;
            chartArea2.CursorY.Interval = 100D;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.HeaderSeparatorColor = System.Drawing.Color.Transparent;
            legend2.ItemColumnSeparatorColor = System.Drawing.Color.Transparent;
            legend2.Name = "Legend1";
            legend2.ShadowColor = System.Drawing.Color.White;
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(653, 102);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Human";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Zombie";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Empty";
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Size = new System.Drawing.Size(510, 578);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "Chart1";
            // 
            // HvsZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 715);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.txtException);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.picWorld);
            this.Name = "HvsZ";
            this.Text = "Human Vs Zombie";
            ((System.ComponentModel.ISupportInitialize)(this.picWorld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picWorld;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.TextBox txtException;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

