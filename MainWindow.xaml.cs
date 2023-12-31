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


//TODO: Buttons become very spaced out in larger windows, put them all in own size defined grid?
//TODO: Order help guide alphabetically
//TODO: Animate buttons so text changes smoothly?
//TODO: Error handling

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

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            outputBox.Text = ">";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "echoButton":
                    inputBox.Text = "echo";
                    break;
                case "moveButton":
                    inputBox.Text = "move";
                    break;
                case "typeButton":
                    inputBox.Text = "type";
                    break;
                case "copyButton":
                    inputBox.Text = "copy";
                    break;
                case "delButton":
                    inputBox.Text = "del";
                    break;
                case "mdButton":
                    inputBox.Text = "md";
                    break;
                case "cdButton":
                    inputBox.Text = "cd";
                    break;
                case "dirButton":
                    inputBox.Text = "dir";
                    break;
                case "treeButton":
                    inputBox.Text = "tree";
                    break;
                case "rdButton":
                    inputBox.Text = "rd";
                    break;
                default:
                    break;
            }
        }

        private void backbutton_Click(object sender, RoutedEventArgs e)
        {
            helpGrid.Visibility = Visibility.Collapsed;
            mainGrid.Visibility = Visibility.Visible;  
        }

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            mainGrid.Visibility = Visibility.Collapsed;
            helpGrid.Visibility = Visibility.Visible;
        }
    }
}