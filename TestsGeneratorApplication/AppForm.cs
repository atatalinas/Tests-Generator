using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestsGenerator;

namespace TestsGeneratorApplication
{
    public partial class AppForm : System.Windows.Forms.Form
    {
        private List<string> files;
        public AppForm()
        {
            files = new List<string>();
            Width = 670;
            Height = 350;
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }
        private void NumbersOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void NumbersOnly_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, "[^0-9]"))
            {
                textBox.Text = "";
            }
        }

        private void addFilesToList(string[] fileNames)
        {
            foreach (string file in fileNames)
            {
                if (!files.Contains(file))
                {
                    files.Add(file);
                }
            }
        }
        private void btnChooseFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "C# class files (*.cs) | *.cs";
            openFileDlg.Multiselect = true;
            openFileDlg.InitialDirectory = "C:\\Users\\angel\\OneDrive\\Рабочий стол\\BSUIR\\5 сем\\СПП\\TestsGenerator\\Input";
            DialogResult result = openFileDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                addFilesToList(openFileDlg.FileNames);
            }
        }

        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            if (tbMaxRead.Text.Length == 0 || tbMaxProcess.Text.Length == 0 || tbMaxWrite.Text.Length == 0)
            {
                MessageBox.Show("Please, input initial parameters");
                return;
            }

            int maxReadFilesCount = Convert.ToInt32(tbMaxRead.Text);
            int maxProcessTasksCount = Convert.ToInt32(tbMaxProcess.Text);
            int maxWriteFilesCount = Convert.ToInt32(tbMaxWrite.Text);

            if (!(maxReadFilesCount > 0 && maxProcessTasksCount > 0 && maxWriteFilesCount > 0))
            {
                MessageBox.Show("Bad initial parameters");
                return;
            }

            if (files.Count == 0)
            {
                MessageBox.Show("List of files is empty. Choose minimum one class.");
                return;
            }

            TestsGenerator.TestsGenerator generator = new TestsGenerator.TestsGenerator(files, maxReadFilesCount, maxProcessTasksCount, maxWriteFilesCount);
            await generator.Generate();
        }




    }
}
