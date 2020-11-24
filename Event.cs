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
{//Создаем событие
    public partial class Event : Form
    {
        public static bool createTaskButtonClicked;
        //Конструкторы
        public Event()
        {
            InitializeComponent();
            taskFinishDate.MinDate = DateTime.Today; // Запрещает пользователю выбирать дату окончания в прошлом
            taskFinishTime.Format = DateTimePickerFormat.Time; //Переводит дату во время
        }
        // Конструктор для редактирования задач.
        public Event(string title, string description, string priority, string finish, string time)
        {
            InitializeComponent();
            taskFinishTime.Format = DateTimePickerFormat.Time; //Переводит дату во время
            // Проверяет данные при импорте файла сохранения с датой меньше MinDate.
            if (Convert.ToDateTime(finish) < taskFinishDate.MinDate)
                taskFinishDate.Text = Convert.ToString(DateTime.Today);
            else
                taskFinishDate.Text = finish;
            taskFinishTime.Text = time;
            // Обновляет поля любой текущей информацией о задаче.
            createTaskButtonClicked = false;
            taskTitleTextBox.Text = title;
            taskDescTextBox.Text = description;
            taskPriorityCombo.Text = priority;
            
           // task.ShowDialog();
        }

        static public int taskCount = 0; // Счетчик задач
        static public int currentlyViewedTask = -1; // Отслеживает, какая задача в данный момент находится в окне просмотра задач
        List<ToDoTask> tasks = new List<ToDoTask>(); // Список(List) объекта ToDoTasks

        private void createTaskButton_Click(object sender, EventArgs e)
        {
            string format = "d MMMM yyyy"; // формат даты
            string errorCaption = "Обнаружена ошибка на входе"; //используется в заголовке моих ошибок в Messageboxes
            string dateMessage = "Вы специально указали сегодняшнюю дату, как дату окончания вашей задачи?"; // используется в сообщении об ошибке dateTime
            MessageBoxButtons buttons = MessageBoxButtons.YesNo; // используется в сообщении об ошибке dateTime
            DialogResult result; // используется в сообщении об ошибке dateTime

            // Если конечной датой является сегодняшняя дата, спрашивает, сделал ли пользователь ошибку
            if (taskFinishDate.Text == DateTime.Today.ToString(format))
            {
                result = MessageBox.Show(dateMessage, errorCaption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (taskTitleTextBox.Text != "" && taskDescTextBox.Text != "" && taskPriorityCombo.Text != "")
                    {
                        createTaskButtonClicked = true;
                        this.Close();
                    }
                }
            }

            // Проверка, что пользователь ввел данные во все поля перед закрытием
            if (taskTitleTextBox.Text == "")
                MessageBox.Show("Вы забыли дать название вашей задаче!", errorCaption);
            if (taskDescTextBox.Text == "")
                MessageBox.Show("Вы забыли дать описание вашей задачи!", errorCaption);
            if (taskPriorityCombo.Text == "")
                MessageBox.Show("Вы забыли дать вашей задаче приоритет!", errorCaption);
            if (taskFinishTime.Text == "")
                MessageBox.Show("Вы забыли указать время вашей задаче!", errorCaption);
            else if (taskFinishTime.Text != "" && taskTitleTextBox.Text != "" && taskDescTextBox.Text != "" && taskPriorityCombo.Text != "" && taskFinishDate.Text != DateTime.Today.ToString(format))
            {
                createTaskButtonClicked = true;
                this.Close();
            }
            MainMenu task = new MainMenu();
            
        }
        //Выход
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void taskFinishDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
            taskFinishTime.Value.ToLongTimeString();
        }
    }
}
