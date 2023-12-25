using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CMD_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int lineNumber = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void cmdButton_Click(object sender, RoutedEventArgs e)
        {
            Process oProcess = new Process();
            lineNumber = 0;
            oProcess.StartInfo.FileName = "cmd.exe";
            oProcess.StartInfo.RedirectStandardInput = true;
            oProcess.StartInfo.RedirectStandardOutput = true;
            oProcess.StartInfo.RedirectStandardError = true;
            oProcess.StartInfo.CreateNoWindow = true;
            oProcess.StartInfo.UseShellExecute = false;
            string command = inputBox.Text;
            string line = "";
            //Debug.WriteLine(command);
            oProcess.Start();
            oProcess.StandardInput.WriteLine($"{command}");
            oProcess.StandardInput.Flush();
            oProcess.StandardInput.Close();
            oProcess.WaitForExit();
            //lineNumber = 0;
            //output.Text = ""; //empty string
            /*while ((line = oProcess.StandardError.ReadLine()) != null)
            {
            output.Text = $"E{lineNumber}: {line}\n";
            lineNumber++;
            }
            if (lineNumber == 0) //there is no Error
            {
            lineNumber = 0;
            while ((line = oProcess.StandardOutput.ReadLine()) != null)
            {
            output.Text += $"{lineNumber}: {line}\n";
           lineNumber++;
            }
            }*/
            outputBox.Text += oProcess.StandardOutput.ReadToEnd() + "\n----------------\n\n";
        }
        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.ShowDialog();
        }
    }
}
