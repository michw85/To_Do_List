namespace WindowsFormsApp2
{
    partial class Event
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
            this.taskFinishDate = new System.Windows.Forms.DateTimePicker();
            this.titleLable = new System.Windows.Forms.Label();
            this.taskTitleTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.taskDescTextBox = new System.Windows.Forms.RichTextBox();
            this.priorityLabel = new System.Windows.Forms.Label();
            this.taskPriorityCombo = new System.Windows.Forms.ComboBox();
            this.finishDateLabel = new System.Windows.Forms.Label();
            this.createTaskButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.finishTimeLable = new System.Windows.Forms.Label();
            this.taskFinishTime = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // taskFinishDate
            // 
            this.taskFinishDate.Location = new System.Drawing.Point(53, 3);
            this.taskFinishDate.Name = "taskFinishDate";
            this.taskFinishDate.Size = new System.Drawing.Size(200, 20);
            this.taskFinishDate.TabIndex = 7;
            this.taskFinishDate.ValueChanged += new System.EventHandler(this.taskFinishDate_ValueChanged);
            // 
            // titleLable
            // 
            this.titleLable.AutoSize = true;
            this.titleLable.Location = new System.Drawing.Point(4, 70);
            this.titleLable.Name = "titleLable";
            this.titleLable.Size = new System.Drawing.Size(51, 13);
            this.titleLable.TabIndex = 1;
            this.titleLable.Text = "Событие";
            // 
            // taskTitleTextBox
            // 
            this.taskTitleTextBox.Location = new System.Drawing.Point(27, 86);
            this.taskTitleTextBox.Name = "taskTitleTextBox";
            this.taskTitleTextBox.Size = new System.Drawing.Size(200, 20);
            this.taskTitleTextBox.TabIndex = 2;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(4, 109);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(57, 13);
            this.descriptionLabel.TabIndex = 3;
            this.descriptionLabel.Text = "Описание";
            // 
            // taskDescTextBox
            // 
            this.taskDescTextBox.Location = new System.Drawing.Point(27, 136);
            this.taskDescTextBox.Name = "taskDescTextBox";
            this.taskDescTextBox.Size = new System.Drawing.Size(205, 93);
            this.taskDescTextBox.TabIndex = 4;
            this.taskDescTextBox.Text = "";
            // 
            // priorityLabel
            // 
            this.priorityLabel.AutoSize = true;
            this.priorityLabel.Location = new System.Drawing.Point(-3, 238);
            this.priorityLabel.Name = "priorityLabel";
            this.priorityLabel.Size = new System.Drawing.Size(90, 13);
            this.priorityLabel.TabIndex = 5;
            this.priorityLabel.Text = "Приоритетность";
            // 
            // taskPriorityCombo
            // 
            this.taskPriorityCombo.FormattingEnabled = true;
            this.taskPriorityCombo.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.taskPriorityCombo.Location = new System.Drawing.Point(93, 235);
            this.taskPriorityCombo.Name = "taskPriorityCombo";
            this.taskPriorityCombo.Size = new System.Drawing.Size(81, 21);
            this.taskPriorityCombo.TabIndex = 6;
            // 
            // finishDateLabel
            // 
            this.finishDateLabel.AutoSize = true;
            this.finishDateLabel.Location = new System.Drawing.Point(4, 9);
            this.finishDateLabel.Name = "finishDateLabel";
            this.finishDateLabel.Size = new System.Drawing.Size(33, 13);
            this.finishDateLabel.TabIndex = 7;
            this.finishDateLabel.Text = "Дата";
            // 
            // createTaskButton
            // 
            this.createTaskButton.Location = new System.Drawing.Point(237, 228);
            this.createTaskButton.Name = "createTaskButton";
            this.createTaskButton.Size = new System.Drawing.Size(75, 23);
            this.createTaskButton.TabIndex = 8;
            this.createTaskButton.Text = "Сохранить";
            this.createTaskButton.UseVisualStyleBackColor = true;
            this.createTaskButton.Click += new System.EventHandler(this.createTaskButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(237, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Выйти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // finishTimeLable
            // 
            this.finishTimeLable.AutoSize = true;
            this.finishTimeLable.Location = new System.Drawing.Point(0, 39);
            this.finishTimeLable.Name = "finishTimeLable";
            this.finishTimeLable.Size = new System.Drawing.Size(40, 13);
            this.finishTimeLable.TabIndex = 10;
            this.finishTimeLable.Text = "Время";
            // 
            // taskFinishTime
            // 
            this.taskFinishTime.Location = new System.Drawing.Point(47, 39);
            this.taskFinishTime.Name = "taskFinishTime";
            this.taskFinishTime.Size = new System.Drawing.Size(200, 20);
            this.taskFinishTime.TabIndex = 11;
            this.taskFinishTime.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // Event
            // 
            this.ClientSize = new System.Drawing.Size(324, 285);
            this.Controls.Add(this.taskFinishTime);
            this.Controls.Add(this.finishTimeLable);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.createTaskButton);
            this.Controls.Add(this.finishDateLabel);
            this.Controls.Add(this.taskPriorityCombo);
            this.Controls.Add(this.priorityLabel);
            this.Controls.Add(this.taskDescTextBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.taskTitleTextBox);
            this.Controls.Add(this.titleLable);
            this.Controls.Add(this.taskFinishDate);
            this.Name = "Event";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label titleLable;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label priorityLabel;
        private System.Windows.Forms.Label finishDateLabel;
        private System.Windows.Forms.Button createTaskButton;
        public System.Windows.Forms.DateTimePicker taskFinishDate;
        public System.Windows.Forms.TextBox taskTitleTextBox;
        public System.Windows.Forms.RichTextBox taskDescTextBox;
        public System.Windows.Forms.ComboBox taskPriorityCombo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label finishTimeLable;
        public System.Windows.Forms.DateTimePicker taskFinishTime;
    }
}