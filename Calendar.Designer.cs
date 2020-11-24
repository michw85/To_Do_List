namespace WindowsFormsApp2
{
    partial class Calendar
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
            this.taskTitle = new System.Windows.Forms.Label();
            this.taskDescription = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.taskPriority = new System.Windows.Forms.Label();
            this.finishDateLabel = new System.Windows.Forms.Label();
            this.taskDate = new System.Windows.Forms.Label();
            this.taskIncomplete = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.taskComplete = new System.Windows.Forms.Label();
            this.finishTimeLabel = new System.Windows.Forms.Label();
            this.taskTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // taskTitle
            // 
            this.taskTitle.AutoSize = true;
            this.taskTitle.Location = new System.Drawing.Point(13, 13);
            this.taskTitle.Name = "taskTitle";
            this.taskTitle.Size = new System.Drawing.Size(51, 13);
            this.taskTitle.TabIndex = 0;
            this.taskTitle.Text = "Событие";
            // 
            // taskDescription
            // 
            this.taskDescription.Location = new System.Drawing.Point(13, 42);
            this.taskDescription.Name = "taskDescription";
            this.taskDescription.Size = new System.Drawing.Size(278, 119);
            this.taskDescription.TabIndex = 1;
            this.taskDescription.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Приоритетность";
            // 
            // taskPriority
            // 
            this.taskPriority.AutoSize = true;
            this.taskPriority.Location = new System.Drawing.Point(110, 178);
            this.taskPriority.Name = "taskPriority";
            this.taskPriority.Size = new System.Drawing.Size(13, 13);
            this.taskPriority.TabIndex = 3;
            this.taskPriority.Text = "3";
            // 
            // finishDateLabel
            // 
            this.finishDateLabel.AutoSize = true;
            this.finishDateLabel.Location = new System.Drawing.Point(13, 207);
            this.finishDateLabel.Name = "finishDateLabel";
            this.finishDateLabel.Size = new System.Drawing.Size(33, 13);
            this.finishDateLabel.TabIndex = 4;
            this.finishDateLabel.Text = "Дата";
            // 
            // taskDate
            // 
            this.taskDate.AutoSize = true;
            this.taskDate.Location = new System.Drawing.Point(113, 207);
            this.taskDate.Name = "taskDate";
            this.taskDate.Size = new System.Drawing.Size(61, 13);
            this.taskDate.TabIndex = 5;
            this.taskDate.Text = "01.01.2020";
            // 
            // taskIncomplete
            // 
            this.taskIncomplete.AutoSize = true;
            this.taskIncomplete.Location = new System.Drawing.Point(10, 266);
            this.taskIncomplete.Name = "taskIncomplete";
            this.taskIncomplete.Size = new System.Drawing.Size(87, 13);
            this.taskIncomplete.TabIndex = 6;
            this.taskIncomplete.Text = "Выполненяется";
            this.taskIncomplete.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(205, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // taskComplete
            // 
            this.taskComplete.AutoSize = true;
            this.taskComplete.Location = new System.Drawing.Point(113, 266);
            this.taskComplete.Name = "taskComplete";
            this.taskComplete.Size = new System.Drawing.Size(64, 13);
            this.taskComplete.TabIndex = 8;
            this.taskComplete.Text = "Выполнено";
            this.taskComplete.Visible = false;
            // 
            // finishTimeLabel
            // 
            this.finishTimeLabel.AutoSize = true;
            this.finishTimeLabel.Location = new System.Drawing.Point(13, 234);
            this.finishTimeLabel.Name = "finishTimeLabel";
            this.finishTimeLabel.Size = new System.Drawing.Size(40, 13);
            this.finishTimeLabel.TabIndex = 9;
            this.finishTimeLabel.Text = "Время";
            // 
            // taskTime
            // 
            this.taskTime.AutoSize = true;
            this.taskTime.Location = new System.Drawing.Point(113, 234);
            this.taskTime.Name = "taskTime";
            this.taskTime.Size = new System.Drawing.Size(49, 13);
            this.taskTime.TabIndex = 10;
            this.taskTime.Text = "00:00:00";
            // 
            // Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 301);
            this.Controls.Add(this.taskTime);
            this.Controls.Add(this.finishTimeLabel);
            this.Controls.Add(this.taskComplete);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.taskIncomplete);
            this.Controls.Add(this.taskDate);
            this.Controls.Add(this.finishDateLabel);
            this.Controls.Add(this.taskPriority);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.taskDescription);
            this.Controls.Add(this.taskTitle);
            this.Name = "Calendar";
            this.Text = "Calendar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label taskTitle;
        private System.Windows.Forms.RichTextBox taskDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label taskPriority;
        private System.Windows.Forms.Label finishDateLabel;
        private System.Windows.Forms.Label taskDate;
        private System.Windows.Forms.Label taskIncomplete;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label taskComplete;
        private System.Windows.Forms.Label finishTimeLabel;
        private System.Windows.Forms.Label taskTime;
    }
}