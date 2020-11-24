using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    //Поиск событий
    public partial class Calendar : Form
    {
        List<ToDoTask> searchResults = new List<ToDoTask>();
        int taskCounter = 0;//Счетчик
        //Конструкторы
        public Calendar()
        {
            InitializeComponent();
        }
        public Calendar(List<ToDoTask> results, int counter)
        {
            InitializeComponent();

            searchResults = results;
            taskCounter = counter;

            // Проверяет, завершено ли событие или нет для отображения правильной метки
            if (searchResults[counter].taskCompletionStatus == true)
                taskComplete.Show();
            else if (searchResults[counter].taskCompletionStatus == false)
                taskIncomplete.Show();

            taskTitle.Text = searchResults[counter].taskTitle;
            taskDescription.Text = searchResults[counter].taskDescription;
            taskPriority.Text = searchResults[counter].taskPriority;
            taskDate.Text = searchResults[counter].taskFinish;
            taskTime.Text = searchResults[counter].taskTime;
        }

        // Каждый раз, когда нажимается следующая кнопка результата, она увеличивает счетчик TaskCounter на 1, а затем отображает новую информацию.
        private void nextResult(object sender, EventArgs e)
        {
            taskCounter++;
            if (taskCounter == searchResults.Count)// Предотвращает исключения от переполнения
            {
                MessageBox.Show("Нет больше результатов для отображения ", " Конец результатов");
                this.Close();
            }
            else
            {
                if (searchResults[taskCounter].taskCompletionStatus == true)
                    taskComplete.Show();
                else if (searchResults[taskCounter].taskCompletionStatus == false)
                    taskIncomplete.Show();

                taskTitle.Text = searchResults[taskCounter].taskTitle;
                taskDescription.Text = searchResults[taskCounter].taskDescription;
                taskPriority.Text = searchResults[taskCounter].taskPriority;
                taskDate.Text = searchResults[taskCounter].taskFinish;
                taskTime.Text = searchResults[taskCounter].taskTime;
            }
        }

                private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
