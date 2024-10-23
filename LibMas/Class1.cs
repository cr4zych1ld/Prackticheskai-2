
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace LibMas
{
    public class Class1
    {
        /// <summary>
        /// Очистка всех элементов программы
        /// </summary>
        /// <param name="dataGrid">Таблица</param>
        /// <param name="mas">Массив</param>
        /// <param name="tbColumnCount">Текстбокс количества колонок</param>
        /// <param name="tbDiapozon">Текстбокс диапозона значений</param>
        /// <param name="listBoxRezult">Листбокс с посчитанным результатом</param>
        public void AllClear(DataGrid dataGrid, int [] mas, TextBox tbColumnCount, TextBox tbDiapozon, ListBox listBoxRezult)
        {
            dataGrid.ItemsSource = null;
            mas = null;
            tbColumnCount.Clear();
            tbDiapozon.Clear();
            listBoxRezult.Items.Clear();
        }

        /// <summary>
        /// Создание пустого массива
        /// </summary>
        /// <param name="count">Количество элементов массива</param>
        /// <returns></returns>
        public int [] CreateIntArray(int count)
        {
            int[] mas = new int[count];
            return mas;
        }

        /// <summary>
        /// Создание и заполнение массива случайными числами в указанном диапозоне
        /// </summary>
        /// <param name="count">Количество значений массива</param>
        /// <param name="diapozon">Диапозон значений массива</param>
        /// <returns></returns>
        public int [] FillIntArray(int count, int diapozon)
        {
            int[] mas = new int[count];
            Random Rand = new Random();
            for (int i = 0; i < mas.Length; i++) mas[i] = Rand.Next(diapozon);
            return mas;
        }

        /// <summary>
        /// Сохранение таблицы со значениями в файл текстового типа
        /// </summary>
        /// <param name="dataGrid">Таблица</param>
        /// <param name="mas">Массив</param>
        public void SaveDataToFile(DataGrid dataGrid, int[] mas)
        {
            SaveFileDialog save = new SaveFileDialog
            {
                DefaultExt = ".txt",
                Filter = "Все файлы (*.*)|*.*|Текстовые файлы|*.txt",
                FilterIndex = 2,
                Title = "Сохранение таблицы"
            };

            if (dataGrid.ItemsSource != null)
            {
                if (save.ShowDialog() == true)
                {
                    using (StreamWriter file = new StreamWriter(save.FileName))
                    {
                        file.WriteLine(mas.Length);
                        for (int i = 0; i < mas.Length; i++)
                        {
                            file.WriteLine(mas[i]);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Нет данных для сохранения.\nВведите значения.", "Ошибка:");
            }
        }

        /// <summary>
        /// Открытие файла с таблицой
        /// </summary>
        /// <param name="dataGrid">Таблица</param>
        /// <param name="mas">Массив</param>
        public void OpenDataToFile(DataGrid dataGrid, int[] mas)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*) | *.* |Текстовые файлы | *.txt";
            open.FilterIndex = 2;
            open.Title = "Сохранение таблицы";

            if (open.ShowDialog() == true)
            {
                StreamReader file = new StreamReader(open.FileName);

                int len = Convert.ToInt32(file.ReadLine());
                mas = new Int32[len];
                for (int i = 0; i < mas.Length; i++)
                {
                    mas[i] = Convert.ToInt32(file.ReadLine());
                }
                file.Close();
            }
        }
    }
}
