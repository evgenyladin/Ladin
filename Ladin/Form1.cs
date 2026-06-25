using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace Ladin
{
    public partial class Form1 : Form
    {
        private Color primaryColor = Color.FromArgb(41, 128, 185);
        private Color secondaryColor = Color.FromArgb(52, 152, 219);
        private Color accentColor = Color.FromArgb(231, 76, 60);
        private Color successColor = Color.FromArgb(46, 204, 113);
        private Color backgroundColor = Color.FromArgb(245, 246, 250);
        private string currentGroupFile = "";
        private List<Student> allStudents = new List<Student>();
        public Form1()
        {
            InitializeComponent();
            SetupDesign();
            LoadGroups();
        }
        private void SetupDesign()
        {
            this.Text = "Ladin - Управление студентами";
            this.Size = new Size(1000, 700);
            this.BackColor = backgroundColor;
            this.Font = new Font("Segoe UI", 9);
            tabControl1.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            tabControl1.Size = new Size(980, 650);
            tabControl1.Location = new Point(10, 10);
            tabControl1.TabPages[0].Text = "📁 Управление группой";
            tabControl1.TabPages[1].Text = "📊 Общий список курса";
            SetupGroupTab();
            SetupCommonTab();
        }
        private void SetupGroupTab()
        {
            cmbGroups.Font = new Font("Segoe UI", 11);
            cmbGroups.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGroups.BackColor = Color.White;
            cmbGroups.ForeColor = Color.FromArgb(52, 73, 94);
            lstStudents.Font = new Font("Segoe UI", 10);
            lstStudents.BackColor = Color.White;
            lstStudents.ForeColor = Color.FromArgb(52, 73, 94);
            lstStudents.BorderStyle = BorderStyle.FixedSingle;
            txtStudentName.Font = new Font("Segoe UI", 11);
            txtStudentName.BackColor = Color.White;
            txtStudentName.ForeColor = Color.FromArgb(52, 73, 94);
            txtStudentName.BorderStyle = BorderStyle.FixedSingle;
            SetupButton(btnAddStudent, "➕ Добавить студента", successColor);
            SetupButton(btnEditStudent, "✏️ Редактировать", secondaryColor);
            SetupButton(btnDeleteStudent, "🗑️ Удалить", accentColor);
            SetupButton(btnSaveGroup, "💾 Сохранить группу", primaryColor);
            SetupButton(btnNewGroup, "📁 Новая группа", Color.FromArgb(155, 89, 182));
            lblGroup.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblGroup.ForeColor = Color.FromArgb(52, 73, 94);
            lblStudentName.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblStudentName.ForeColor = Color.FromArgb(52, 73, 94);
        }
        private void SetupCommonTab()
        {
            lstCommonList.Font = new Font("Segoe UI", 10);
            lstCommonList.BackColor = Color.White;
            lstCommonList.ForeColor = Color.FromArgb(52, 73, 94);
            lstCommonList.BorderStyle = BorderStyle.FixedSingle;
            SetupButton(btnCreateCommonList, "📋 Создать общий список", primaryColor);
            SetupButton(btnSaveCommonList, "💾 Сохранить общий список", successColor);
            lblCommonInfo.Font = new Font("Segoe UI", 10);
            lblCommonInfo.ForeColor = Color.FromArgb(52, 73, 94);
        }
        private void SetupButton(Button button, string text, Color color)
        {
            button.Text = text;
            button.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            button.BackColor = color;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Size = new Size(200, 40);
            button.Cursor = Cursors.Hand;
            button.MouseEnter += (s, e) => button.BackColor = ControlPaint.Light(color);
            button.MouseLeave += (s, e) => button.BackColor = color;
        }
        private void LoadGroups()
        {
            cmbGroups.Items.Clear();
            string[] groupFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");
            foreach (string file in groupFiles)
            {
                string groupName = Path.GetFileNameWithoutExtension(file);
                if (!string.IsNullOrWhiteSpace(groupName))
                {
                    cmbGroups.Items.Add(groupName);
                }
            }
        }
        private void cmbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGroups.SelectedItem != null)
            {
                currentGroupFile = cmbGroups.SelectedItem.ToString() + ".txt";
                LoadStudentsFromFile();
            }
        }
        private void LoadStudentsFromFile()
        {
            lstStudents.Items.Clear();
            if (File.Exists(currentGroupFile))
            {
                string[] students = File.ReadAllLines(currentGroupFile);
                foreach (string student in students)
                {
                    if (!string.IsNullOrWhiteSpace(student))
                        lstStudents.Items.Add(student);
                }
            }
        }
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            string studentName = txtStudentName.Text.Trim();

            if (string.IsNullOrWhiteSpace(studentName))
            {
                MessageBox.Show("Введите имя студента", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(currentGroupFile))
            {
                MessageBox.Show("Выберите группу сначала", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            lstStudents.Items.Add(studentName);
            txtStudentName.Clear();
            SaveStudentsToFile();
        }

        private void btnEditStudent_Click(object sender, EventArgs e)
        {
            if (lstStudents.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите студента для редактирования", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newName = txtStudentName.Text.Trim();
            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Введите новое имя студента", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lstStudents.Items[lstStudents.SelectedIndex] = newName;
            txtStudentName.Clear();
            SaveStudentsToFile();
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (lstStudents.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите студента для удаления", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Удалить выбранного студента?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lstStudents.Items.RemoveAt(lstStudents.SelectedIndex);
                SaveStudentsToFile();
            }
        }

        private void btnSaveGroup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentGroupFile))
            {
                MessageBox.Show("Выберите группу", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveStudentsToFile();
            MessageBox.Show("Группа сохранена успешно!", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveStudentsToFile()
        {
            if (string.IsNullOrEmpty(currentGroupFile)) return;

            List<string> students = new List<string>();
            foreach (var item in lstStudents.Items)
            {
                students.Add(item.ToString());
            }

            File.WriteAllLines(currentGroupFile, students);
        }
        private void btnNewGroup_Click(object sender, EventArgs e)
        {
            string groupName = Microsoft.VisualBasic.Interaction.InputBox(
                "Введите название новой группы:",
                "Новая группа",
                "Группа_" + (cmbGroups.Items.Count + 1));

            if (!string.IsNullOrWhiteSpace(groupName))
            {
                foreach (char c in Path.GetInvalidFileNameChars())
                {
                    groupName = groupName.Replace(c.ToString(), "");
                }
                string fileName = groupName + ".txt";

                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Close();
                    cmbGroups.Items.Add(groupName);
                    cmbGroups.SelectedItem = groupName;
                    lstStudents.Items.Clear();
                }
                else
                {
                    MessageBox.Show("Группа с таким именем уже существует", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void btnCreateCommonList_Click(object sender, EventArgs e)
        {
            allStudents.Clear();
            lstCommonList.Items.Clear();
            string[] groupFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");
            foreach (string file in groupFiles)
            {
                string groupName = Path.GetFileNameWithoutExtension(file);
                string[] students = File.ReadAllLines(file);
                foreach (string student in students)
                {
                    if (!string.IsNullOrWhiteSpace(student))
                    {
                        allStudents.Add(new Student
                        {
                            FullName = student,
                            GroupName = groupName
                        });
                    }
                }
            }
            var sortedStudents = allStudents
                .OrderByDescending(s => ExtractGroupNumber(s.GroupName))
                .ThenBy(s => s.FullName)
                .ToList();
            foreach (var student in sortedStudents)
            {
                lstCommonList.Items.Add($"{student.GroupName} | {student.FullName}");
            }

            lblCommonInfo.Text = $"Всего студентов: {allStudents.Count} из {groupFiles.Length} групп";
        }
        private int ExtractGroupNumber(string groupName)
        {
            string numbers = new string(groupName.Where(char.IsDigit).ToArray());
            if (int.TryParse(numbers, out int result))
                return result;
            return 0;
        }
        private void btnSaveCommonList_Click(object sender, EventArgs e)
        {
            if (allStudents.Count == 0)
            {
                MessageBox.Show("Сначала создайте общий список", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string fileName = "Общий_список_1_курса.txt";
            List<string> lines = new List<string>();
            lines.Add("=".PadRight(50, '='));
            lines.Add("ОБЩИЙ СПИСОК СТУДЕНТОВ 1 КУРСА");
            lines.Add($"Дата создания: {DateTime.Now:dd.MM.yyyy HH:mm}");
            lines.Add("=".PadRight(50, '='));
            lines.Add("");
            int counter = 1;
            foreach (var student in allStudents
                .OrderByDescending(s => ExtractGroupNumber(s.GroupName))
                .ThenBy(s => s.FullName))
            {
                lines.Add($"{counter++:000}. Группа: {student.GroupName.PadRight(10)} | {student.FullName}");
            }
            lines.Add("");
            lines.Add($"ИТОГО: {allStudents.Count} студентов");
            File.WriteAllLines(fileName, lines, System.Text.Encoding.UTF8);
            MessageBox.Show($"Общий список сохранен в файл: {fileName}", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void lstStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstStudents.SelectedIndex != -1)
            {
                txtStudentName.Text = lstStudents.SelectedItem.ToString();
            }
        }
    }
    public class Student
    {
        public string FullName { get; set; }
        public string GroupName { get; set; }
    }
}
