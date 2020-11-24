using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp2
{
    #region Основное Меню
    public partial class MainMenu : Form
    {
        static public int taskCount = 0; // Счетчик событий
        static public int currentlyViewedTask = -1; // Отслеживает, какая задача в данный момент находится в окне просмотра задач.
        List<ToDoTask> tasks = new List<ToDoTask>(); // List(список) объекта ToDoTask
        //Конструкторы
        public MainMenu()
        {
            InitializeComponent();
        }
        public MainMenu(Form1 a)
        {
            InitializeComponent();
        }
        //Метод создания нового события
        public void createNewTask(object sender, EventArgs e)
        {
            taskCount++; // Счетчик всех событий
            Event createNew = new Event();

            if (taskCount <= 10) // Запрещает пользователю выполнять более 10 событий
            {
                createNew.ShowDialog();// Переходит к форме создания события
            }
            if (taskCount > 10) // Показывает ошибку в случае превышения лимита событий
            {
                string errorCaption = "Достигнут предел событий";
                MessageBox.Show("Вы достигли лимита событий, которые вы можете сделать, пожалуйста, удалите событие перед созданием нового.", errorCaption);
            }
            if (Event.createTaskButtonClicked == true) //Проверка, что пользователь создает событие
            {
                viewTaskInstruction.Visible = true;
                tasks.Add(new ToDoTask() // Добавление нового события в список
                {
                    taskTitle = createNew.taskTitleTextBox.Text,
                    taskDescription = createNew.taskDescTextBox.Text,
                    taskPriority = createNew.taskPriorityCombo.Text,
                    taskFinish = createNew.taskFinishDate.Text,
                    taskTime = createNew.taskFinishTime.Text,
                });

                setTask(); // Изменяет графический интерфейс(GUI-конструктор) для отображения и создания новых задач

            }
        }

        // Метод-посредник между обновлением графического интерфейса в "updateTaskInfo" и изменениями, внесенными в задачи в другом месте приложения
        public void setTask()
        {
            updateTaskInfo(taskTitle1, taskFinish1, taskTime1, taskPriority1, task1Status, editTask1, deleteButton1, 0);
            updateTaskInfo(taskTitle2, taskFinish2, taskTime2, taskPriority2, task2Status, editButton2, deleteButton2, 1);
            updateTaskInfo(taskTitle3, taskFinish3, taskTime3, taskPriority3, task3Status, editButton3, deleteButton3, 2);
            updateTaskInfo(taskTitle4, taskFinish4, taskTime4, taskPriority4, task4Status, editButton4, deleteButton4, 3);
            updateTaskInfo(taskTitle5, taskFinish5, taskTime5, taskPriority5, task5Status, editButton5, deleteButton5, 4);
            updateTaskInfo(taskTitle6, taskFinish6, taskTime6, taskPriority6, task6Status, editButton6, deleteButton6, 5);
            updateTaskInfo(taskTitle7, taskFinish7, taskTime7, taskPriority7, task7Status, editButton7, deleteButton7, 6);
            updateTaskInfo(taskTitle8, taskFinish8, taskTime8, taskPriority8, task8Status, editButton8, deleteButton8, 7);
            updateTaskInfo(taskTitle9, taskFinish9, taskTime9, taskPriority9, task9Status, editButton9, deleteButton9, 8);
            updateTaskInfo(taskTitle10, taskFinish10, taskTime10, taskPriority10, task10Status, editButton10, deleteButton10, 9);
        }

        // Обновляет графический интерфейс (в частности, таблицу со всеми задачами), чтобы отображать любые новые изменения, сделанные пользователем
        public void updateTaskInfo(Label taskTitle, Label taskFinish, Label taskTime, Label taskPriority, CheckBox status, Button edit, Button delete, int id)
        {
            if (tasks.Count == 0 || tasks.Count <= id) // Если true, то это означает, что задача была удалена, поэтому информация должна быть скрыта.
            {
                taskTitle.Text = "";
                taskFinish.Text = "";
                taskTime.Text = "";
                taskPriority.Text = "";
                status.Hide();
                edit.Hide();
                delete.Hide();
                return;
            }
            else
            {
                taskTitle.Text = tasks[id].taskTitle;
                taskFinish.Text = tasks[id].taskFinish;
                taskTime.Text = tasks[id].taskTime;
                taskPriority.Text = tasks[id].taskPriority;
                bool tempChecked = tasks[id].taskCompletionStatus; // Создана временная переменная для хранения completionStatus
                status.Checked = tasks[id].taskCompletionStatus; // Эта строка вызывала проблемы с неправильным статусом при загрузке файла сохранения, вышеупомянутый временный метод устранил проблему
                tasks[id].taskCompletionStatus = tempChecked; // Делает taskCompletionStatus таким, каким он был изначально
                status.Show();
                edit.Show();
                delete.Show();
            }

        }

        // Кнопки редактирования задач (editTask), каждая кнопка вызывает setEditTask, но отправляет другой номер в зависимости от того, какая кнопка нажата, чтобы убедиться, что правильная задача отредактирована. (номер соответствует позиции списка задач)
        private void editTaskButton1(object sender, EventArgs e) { setEditTask(0); }
        private void editTaskButton2(object sender, EventArgs e) { setEditTask(1); }
        private void editTaskButton3(object sender, EventArgs e) { setEditTask(2); }
        private void editTaskButton4(object sender, EventArgs e) { setEditTask(3); }
        private void editTaskButton5(object sender, EventArgs e) { setEditTask(4); }
        private void editTaskButton6(object sender, EventArgs e) { setEditTask(5); }
        private void editTaskButton7(object sender, EventArgs e) { setEditTask(6); }
        private void editTaskButton8(object sender, EventArgs e) { setEditTask(7); }
        private void editTaskButton9(object sender, EventArgs e) { setEditTask(8); }
        private void editTaskButton10(object sender, EventArgs e) { setEditTask(9); }

        //Открывает новую форму для пользователя, чтобы повторно ввести информацию для редактирования события
        public void setEditTask(int taskId)
        {
            // Открывает форму Создания события. Данные по событию, подлежащие редактированию, отправляются для заполнения полей в новой форме
            Event editTask = new Event(tasks[taskId].taskTitle, tasks[taskId].taskDescription, tasks[taskId].taskPriority, tasks[taskId].taskFinish, tasks[taskId].taskTime);
            editTask.ShowDialog();

            if (Event.createTaskButtonClicked == true) // Проверяет, что пользователь принял новую информацию (иначе он не будет обновлять задачу, если вместо этого будет нажата кнопка закрытия окна)
            {
                // Обновляет список с новой информацией
                tasks[taskId].taskTitle = (editTask.taskTitleTextBox.Text);
                tasks[taskId].taskDescription = (editTask.taskDescTextBox.Text);
                tasks[taskId].taskPriority = (editTask.taskPriorityCombo.Text);
                tasks[taskId].taskFinish = (editTask.taskFinishDate.Text);
                tasks[taskId].taskTime = (editTask.taskFinishTime.Text);

                setTask(); // Обновляет графический интерфейс

                // Если текущая задача редактируется, то она отобразит новую информацию
                if (currentlyViewedTask == taskId)
                    displayTask(taskId);
            }
        }

        // Кнопки удаления задач
        private void deleteTaskButton1(object sender, EventArgs e)
        {
            tasks.RemoveAt(0); // Удаляет задачу из списка ToDoTask в указанной позиции, но не обновляет графический интерфейс
            taskCount--; // Счетчик задач
            if (currentlyViewedTask == 0) // Скрывает задачу, которую удаляют
                hideTask();

            setTask(); // Вызывает setTask () для обновления GUI
        }
        private void deleteTaskButton2(object sender, EventArgs e)
        {
            tasks.RemoveAt(1);
            taskCount--;
            if (currentlyViewedTask == 1)
                hideTask();

            setTask();
        }
        private void deleteTaskButton3(object sender, EventArgs e)
        {
            tasks.RemoveAt(2);
            taskCount--;
            if (currentlyViewedTask == 2)
                hideTask();

            setTask();
        }
        private void deleteTaskButton4(object sender, EventArgs e)
        {
            tasks.RemoveAt(3);
            taskCount--;
            if (currentlyViewedTask == 3)
                hideTask();

            setTask();
        }
        private void deleteTaskButton5(object sender, EventArgs e)
        {
            tasks.RemoveAt(4);
            taskCount--;
            if (currentlyViewedTask == 4)
                hideTask();

            setTask();
        }
        private void deleteTaskButton6(object sender, EventArgs e)
        {
            tasks.RemoveAt(5);
            taskCount--;
            if (currentlyViewedTask == 5)
                hideTask();

            setTask();
        }
        private void deleteTaskButton7(object sender, EventArgs e)
        {
            tasks.RemoveAt(6);
            taskCount--;
            if (currentlyViewedTask == 6)
                hideTask();

            setTask();
        }
        private void deleteTaskButton8(object sender, EventArgs e)
        {
            tasks.RemoveAt(7);
            taskCount--;
            if (currentlyViewedTask == 7)
                hideTask();

            setTask();
        }
        private void deleteTaskButton9(object sender, EventArgs e)
        {
            tasks.RemoveAt(8);
            taskCount--;
            if (currentlyViewedTask == 8)
                hideTask();

            setTask();
        }
        private void deleteTaskButton10(object sender, EventArgs e)
        {
            tasks.RemoveAt(9);
            taskCount--;
            if (currentlyViewedTask == 9)
                hideTask();

            setTask();
        }

        // Просмотр событий в отдельном окне при нажати на событие в колонке
        private void viewTask1(object sender, EventArgs e) { displayTask(0); }
        private void viewTask2(object sender, EventArgs e) { displayTask(1); }
        private void viewTask3(object sender, EventArgs e) { displayTask(2); }
        private void viewTask4(object sender, EventArgs e) { displayTask(3); }
        private void viewTask5(object sender, EventArgs e) { displayTask(4); }
        private void viewTask6(object sender, EventArgs e) { displayTask(5); }
        private void viewTask7(object sender, EventArgs e) { displayTask(6); }
        private void viewTask8(object sender, EventArgs e) { displayTask(7); }
        private void viewTask9(object sender, EventArgs e) { displayTask(8); }
        private void viewTask10(object sender, EventArgs e) { displayTask(9); }

        // Отображает задачу в окне просмотра задач. taskNumber соответствует задачам в списке ToDoTask
        public void displayTask(int taskNumber)
        {

            currentlyViewedTask = taskNumber; // currentlyViewedTask можно использовать для определения того, какая задача просматривается

            viewTaskInstruction.Visible = false; // Скрыть сообщение с инструкцией
            displayTaskTitle.Visible = true; // Показать заголовок
            displayTaskDescription.Visible = true; // Показать описание
            displayTaskPriority.Visible = true; // Отображать метку приоритета
            displayTaskPNumber.Visible = true; // Отображать номер приоритета
            displayTaskFinish.Visible = true; // Показать дату 
            displayTaskFDate.Visible = true; //Показать дату окончания
            displayTaskTime.Visible = true; // Показать время

            // Заполнить вновь отображаемые метки и текстовые поля с информацией о задаче.
            displayTaskTitle.Text = tasks[taskNumber].taskTitle;
            displayTaskDescription.Text = tasks[taskNumber].taskDescription;
            displayTaskPNumber.Text = tasks[taskNumber].taskPriority;
            displayTaskFDate.Text = tasks[taskNumber].taskFinish;
            displayTaskTime.Text = tasks[taskNumber].taskTime;
            if (tasks[taskNumber].taskCompletionStatus == true) // Если задача отмечена как выполненная, то покажет "выполнено"
            {
                taskComplete.Visible = true;
                taskIncomplete.Visible = false;
            }
            if (tasks[taskNumber].taskCompletionStatus == false)   // В противном случае показать "выполняется"
            {
                taskIncomplete.Visible = true;
                taskComplete.Visible = false;
            }
        }

        // Скрывает текущее событие от просмотра задач.
        public void hideTask()
        {
            viewTaskInstruction.Visible = true; // Показать сообщение с инструкцией
            displayTaskTitle.Visible = false; // Скрыть заголовок
            displayTaskDescription.Visible = false; // Скрыть описание
            displayTaskPriority.Visible = false; // Скрыть метку приоритета
            displayTaskPNumber.Visible = false; // Скрыть номер приоритета
            displayTaskFinish.Visible = false; // Скрыть метку даты окончания задачи
            displayTaskFDate.Visible = false; // Скрыть дату окончания задачи
            displayTaskTime.Visible = false; // Скрыть время
            taskComplete.Visible = false; // Скрыть сообщение о завершении
            taskIncomplete.Visible = false; // Скрыть сообщение о выполнении
        }

        // Меняет курсор на руку при наведении курсора на имя задачи. Это подсказывает пользователю, что на него можно нажать
        private void mouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }
        // Меняет курсор на значение по умолчанию, если пользователь перестает наводить курсор на имя задачи.
        private void mouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        // taskCompletionStatus проверяет события. Проверка задачи на завершение 
        private void task1StatusChange(object sender, EventArgs e) { changeTaskStatus(0); }
        private void task2StatusChange(object sender, EventArgs e) { changeTaskStatus(1); }
        private void task3StatusChange(object sender, EventArgs e) { changeTaskStatus(2); }
        private void task4StatusChange(object sender, EventArgs e) { changeTaskStatus(3); }
        private void task5StatusChange(object sender, EventArgs e) { changeTaskStatus(4); }
        private void task6StatusChange(object sender, EventArgs e) { changeTaskStatus(5); }
        private void task7StatusChange(object sender, EventArgs e) { changeTaskStatus(6); }
        private void task8StatusChange(object sender, EventArgs e) { changeTaskStatus(7); }
        private void task9StatusChange(object sender, EventArgs e) { changeTaskStatus(8); }
        private void task10StatusChange(object sender, EventArgs e) { changeTaskStatus(9); }

        // Проверяет задача выполнена/выполняется
        private void changeTaskStatus(int taskNumber)
        {
            if (tasks[taskNumber].taskCompletionStatus == false)
                tasks[taskNumber].taskCompletionStatus = true;
            else if (tasks[taskNumber].taskCompletionStatus == true)
                tasks[taskNumber].taskCompletionStatus = false;

            if (currentlyViewedTask == taskNumber) // Если задание, которое только что было проверено, в данный момент находится в средстве просмотра задач, оно обновит средство просмотра задач для отображения новой информации.
                displayTask(taskNumber);
        }

        // Открывает список задач из текстового файла, файл должен быть правильно отформатирован и в правильном порядке
        private void openTasks(object sender, EventArgs e)
        {
            OpenSaving open = new OpenSaving();
            open.openList(sender, e, tasks);

            hideTask(); // Resetting the task viewer
            setTask(); // Updating the GUI
        }

        // Сохраняет список задач в файл, каждая переменная задачи будет сохранена в каждой строке.
        private void saveTasks(object sender, EventArgs e)
        {
            OpenSaving save = new OpenSaving();
            save.saveList(sender, e, tasks);
        }

        // Сортирует список задач по приоритету: 1 вверху, 3 внизу.
        private void sortByPriority(object sender, EventArgs e)
        {
            if (tasks.Count != 0)
            {
                Sorting sort = new Sorting();
                sort.bubbleSort(tasks);
                setTask();
                hideTask();
            }
            else if (tasks.Count == 0 || tasks.Count == 1) // Не будет сортировать, если не достаточно задач для сортировки.
                MessageBox.Show("Недостаточно задач для сортировки");
        }

        private void sortByDate(object sender, EventArgs e)
        {
            if (tasks.Count != 0)
            {
                Sorting sort = new Sorting();
                sort.dateSort(tasks);
                setTask();
                hideTask();
            }
            else if (tasks.Count == 0 || tasks.Count == 1) // Не будет сортировать, если не достаточно задач для сортировки.
                MessageBox.Show("Недостаточно задач для сортировки");
        }

        private void searchTasks(object sender, EventArgs e)
        {
            string userSearch = searchTextBox.Text;
            TaskSearch searchTask = new TaskSearch();
            if (searchTextBox.Text != "")// Провека от нулевого поиска
            {
                List<ToDoTask> searchResults = searchTask.linearSearch(tasks, userSearch);

                if (searchResults.Count >= 1) // Показывает результаты поиска, только если они есть (уведомление об отсутствии результатов находится в методе searchTask).
                {
                    Calendar displayResults = new Calendar(searchResults, 0);

                    // Открывает Форму Поиска
                    displayResults.ShowDialog();
                }
            }
            if (searchTextBox.Text == "")
            {
                MessageBox.Show("Введите слово для поиска вашего события ", " Не найдено информации условию поиска");
            }
        }
        //Выйти
        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void viewTaskInstruction_Click(object sender, EventArgs e)
        {

        }
    }
    #endregion
    #region Основной объект для хранения ифнормации
    // Основной объект для хранения ифнормации
    public class ToDoTask
    {
        public string taskTitle;        //Название
        public string taskDescription;  //Описание
        public string taskPriority;     //Приоритетность
        public string taskFinish;       //Дата
        public string taskTime;         //Время
        public bool taskCompletionStatus;//Статус выполнения
                                         //Конструкторы
        public ToDoTask()
        {
        }

        public ToDoTask(string ataskTitle, string ataskDescription, string ataskPriority, string ataskFinish, string ataskTime, bool ataskCompletionStatus)
        {
            taskTitle = ataskTitle;                         //Название
            taskDescription = ataskDescription;             //Описание
            taskPriority = ataskPriority;                   //Приоритетность
            taskFinish = ataskFinish;                       //Дата
            taskTime = ataskTime;                           //Время
            taskCompletionStatus = ataskCompletionStatus;   //Статус выполнения
        }
    }
    #endregion
    #region Сортировка
    // Сортировка
    public class Sorting
    {
        public List<ToDoTask> bubbleSort(List<ToDoTask> tasks)//Пузырьковая сортировка
        {
            int[] taskPriorityArray = new int[tasks.Count];//Сортировка по приоритетам

            for (int i = 0; i < tasks.Count; i++)
            {
                // создание массива только для поля приоритетов из объекта событий для сортировки.
                taskPriorityArray[i] = Convert.ToInt32(tasks[i].taskPriority);
            }

            int n = tasks.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (taskPriorityArray[j + 1] < taskPriorityArray[j])
                    {  // Все, что выполняется в "taskPriorityArray", также выполняется и в списке.
                        int tempPriority = taskPriorityArray[j];
                        taskPriorityArray[j] = taskPriorityArray[j + 1];
                        taskPriorityArray[j + 1] = tempPriority;

                        ToDoTask tempList;
                        tempList = tasks[j];
                        tasks[j] = tasks[j + 1];
                        tasks[j + 1] = tempList;
                    }
                }
            }

            return tasks;
        }
        
        public List<ToDoTask> dateSort(List<ToDoTask> tasks)//Список объектов с пунктами событий
        {
            int[] taskFinishlArray = new int[tasks.Count];
                       for (int i = 0; i < tasks.Count; i++)
            {//Новый массив только с пунктами с датой
                taskFinishlArray[i] = Convert.ToInt32(DateTime.Parse(tasks[i].taskFinish).Subtract(new DateTime(1970, 1, 1)).TotalSeconds);

                //richTextBox1.Text = Convert.ToString(taskFinishlArray[i]);
            }
           
            int n = tasks.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (taskFinishlArray[j + 1] < taskFinishlArray[j])
                    {   // Все, что выполняется в "taskTimeArray", также выполняется и в списке.
                        int tempTime = taskFinishlArray[j];
                        taskFinishlArray[j] = taskFinishlArray[j + 1];
                        taskFinishlArray[j + 1] = tempTime;

                        ToDoTask tempList;
                        tempList = tasks[j];
                        tasks[j] = tasks[j + 1];
                        tasks[j + 1] = tempList;
                    }
                }
            }

            return tasks;
        }
    }
    #endregion
    #region Работа с Файлами Открытие/Сохранение
    // Содержит методы для открытия файлов TXT и сохранения в файл TXR.
    public class OpenSaving
    {
        public List<ToDoTask> openList(object sender, EventArgs e, List<ToDoTask> tasks)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "saved ToDo lists";
            open.Filter = "txt files (*.txt)|*.txt";

            if (open.ShowDialog() == DialogResult.OK)
            {
                string fileName = open.FileName;
                MainMenu task = new MainMenu();
                task.setTask();
                // Удаление всех текущих задач, прежде чем открывать новые.
                int taskCountTemp = tasks.Count; // Временный int Temp для цикла 
                for (int i = 0; i < taskCountTemp; i++)
                {
                    tasks.RemoveAt(0);
                }
                MainMenu.taskCount = 0; // сброс счетчика задач

                try
                {
                    // Чтение в новом файле и присвоение каждой строке различной переменной для каждого объекта в списке
                    string[] lines = File.ReadAllLines(fileName);
                    for (int i = 0; i < lines.Length; i = i + 6)
                    {
                        tasks.Add(new ToDoTask()
                        {
                            taskTitle = lines[i],
                            taskDescription = lines[i + 1],
                            taskPriority = lines[i + 2],
                            taskTime = lines[i + 3],
                            taskFinish = lines[i + 4],
                            taskCompletionStatus = Convert.ToBoolean(lines[i + 4])
                        });
                    }
                    MainMenu.taskCount = lines.Length / 6;
                    MainMenu.currentlyViewedTask = -1; // Сброс просмотра задач
                }
                catch (Exception myE)
                {
                    // Задачи будут по-прежнему часто загружаться, но некоторые будут отсутствовать.
                    MessageBox.Show("Этот файл неправильно отформатирован для этого приложения ... \n Возможно, его все еще можно будет открыть, но некоторые или все данные могут быть деформированы / потеряны ", " Ошибка: неправильное форматирование");
                }
            }
            return tasks;
        }

        // Сохранить в текстовый файл. Каждая строка в текстовом файле - это отдельная переменная.
        public void saveList(object sender, EventArgs e, List<ToDoTask> tasks)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.InitialDirectory = "сохранить ToDo lists";
            save.Filter = "txt files (*.txt)|*.txt";
            save.DefaultExt = ".txt";

            DialogResult result = save.ShowDialog();

            if (result == DialogResult.OK)
            {
                FileStream fStream = new FileStream(save.FileName, FileMode.Create);
                StreamWriter sWriter = new StreamWriter(fStream);

                for (int i = 0; i < MainMenu.taskCount; i++)
                {
                    sWriter.WriteLine(tasks[i].taskTitle);
                    sWriter.WriteLine(tasks[i].taskDescription);
                    sWriter.WriteLine(tasks[i].taskPriority);
                    sWriter.WriteLine(tasks[i].taskFinish);
                    sWriter.WriteLine(tasks[i].taskCompletionStatus);
                }
                sWriter.Close();//Закрыть метод saveList
            }
        }
    }
    #endregion
    #region Поиск
    public class TaskSearch
    {
        List<ToDoTask> searchResults = new List<ToDoTask>();
        public List<ToDoTask> linearSearch(List<ToDoTask> tasks, string userSearch)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].taskDescription.Contains(userSearch) || tasks[i].taskTitle.Contains(userSearch) || tasks[i].taskTime.Contains(userSearch) || tasks[i].taskFinish.Contains(userSearch))
                {
                    searchResults.Add(new ToDoTask() // Добавление нового задания к результатам
                    {
                        taskTitle = tasks[i].taskTitle,
                        taskDescription = tasks[i].taskDescription,
                        taskPriority = tasks[i].taskPriority,
                        taskFinish = tasks[i].taskFinish,
                        taskTime = tasks[i].taskTime,
                        taskCompletionStatus = tasks[i].taskCompletionStatus
                    });
                }
                else
                    continue;
            }
            if (searchResults.Count == 0)
                MessageBox.Show("Результаты не найдены. ", " Результаты поиска");
            return searchResults;
        }
    }
    #endregion
    
}