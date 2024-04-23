using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab_15_OOP_Dikiy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;
            button4.Click += button4_Click;
            button5.Click += button5_Click;
            button6.Click += button6_Click;
            button7.Click += button7_Click;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1_1.Text))
            {
                MessageBox.Show("Будь ласка, введіть значення для x!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!double.TryParse(textBox1_1.Text, out double x))
            {
                MessageBox.Show("Введіть коректне значення для x!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double result = x - ((Math.Pow(x, 3)) / 3) + ((Math.Pow(x, 5)) / 5);
            result = Math.Round(result, 5);
            label1_1.Text = $"Результат: {result}";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1_2.Text) ||
            string.IsNullOrWhiteSpace(textBox2_2.Text) ||
            string.IsNullOrWhiteSpace(textBox3_2.Text))
            {
                MessageBox.Show("Будь ласка, введіть всі значення для обчислення суми!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBox1_2.Text, out int firstTerm) ||
                !int.TryParse(textBox2_2.Text, out int commonDifference) ||
                !int.TryParse(textBox3_2.Text, out int numberOfTerms))
            {
                MessageBox.Show("Будь ласка, введіть коректні числові значення!");
                return;
            }
            int lastTerm = firstTerm + (numberOfTerms - 1) * commonDifference;
            int sum = numberOfTerms * (firstTerm + lastTerm) / 2;
            label1_2.Text = $"Сума перших {numberOfTerms} членів прогресії: {sum}";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1_3.Text) ||
            string.IsNullOrWhiteSpace(textBox2_3.Text) ||
            string.IsNullOrWhiteSpace(textBox3_3.Text))
            {
                MessageBox.Show("Будь ласка, введіть значення всіх сторін трикутника!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(textBox1_3.Text, out double sideA) ||
                !double.TryParse(textBox2_3.Text, out double sideB) ||
                !double.TryParse(textBox3_3.Text, out double sideC))
            {
                MessageBox.Show("Будь ласка, введіть коректні числові значення!");
                return;
            }

            bool isEquilateral = sideA == sideB && sideB == sideC;

            label1_3.Text = isEquilateral ? "Трикутник є рівностороннім (True)" : "Трикутник НЕ є рівностороннім (False)";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string enteredPassword = textBox1_4.Text;
            string accessLevel = GetAccessB4(enteredPassword);
            if (string.IsNullOrWhiteSpace(textBox1_4.Text))
            {
                MessageBox.Show("Будь ласка, введіть пароль!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            label1_4.Text = "Рівень доступу: " + accessLevel;
            label1_4.ForeColor = accessLevel != "Невірний пароль! Доступ заборонено!" ? Color.Green : Color.Red;
        }
        private string GetAccessB4(string password)
        {
            switch (password)
            {
                case "9583":
                case "1747":
                    return "Модулі баз А, В, С";
                case "3331":
                case "7922":
                    return "Модулі баз В, С";
                case "9455":
                case "8997":
                    return "Модуль бази С";
                default:
                    return "Невірний пароль! Доступ заборонено!";
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1_5.Text, out int N) || N <= 0)
            {
                MessageBox.Show("Будь ласка, введіть додатне ціле число для N!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            textBox2_5.Clear();

            for (int a = 1; a < N; a++)
            {
                for (int b = a; b < N; b++) // b починається з a, щоб уникнути дублювання комбінацій
                {
                    double c = Math.Sqrt(a * a + b * b);
                    if (c == (int)c && c < N) // перевірка, чи c ціле число та менше N
                    {
                        textBox2_5.AppendText($"{a}, {b}, {(int)c}\r\n");
                    }
                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            string input = textBox1_6.Text;
            if (string.IsNullOrWhiteSpace(textBox1_6.Text))
            {
                MessageBox.Show("Будь ласка, введіть значення!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Розділення рядка на числа та переведення у масив
            int[] numbers = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

            // Пошук максимального та мінімального значень
            int max = numbers.Max();
            int min = numbers.Min();

            int maxIndex = Array.IndexOf(numbers, max);
            int minIndex = Array.IndexOf(numbers, min);
            // Ініціалізація змінних для суми та позначення початку та кінця діапазону
            int sum = 0;
            int start = Math.Min(maxIndex, minIndex);
            int end = Math.Max(maxIndex, minIndex);
            // Підрахунок йде з врахуванням мінімального і максимального

            for (int i = start; i <= end; i++)
            {
                sum += numbers[i];
            }

            label2_6.Text = "Результат: " + sum.ToString();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            string input = textBox1_7.Text;
            if (string.IsNullOrWhiteSpace(textBox1_7.Text))
            {
                MessageBox.Show("Будь ласка, введіть рядок!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Пошук двокрапки
            int colonIndex = input.IndexOf(':');

            if (colonIndex >= 0)
            {
                // Підрахунок враховує пробіли!!!
                // Підрахунок перед двокрапкою
                int countBeforeColon = colonIndex;

                label1_7.Text = $"Кількість символів перед двокрапкою: {countBeforeColon}";
            }
            else
            {
                //null
                label1_7.Text = "Двокрапка не знайдена у введеному рядку!";
            }
        }
    }
}
