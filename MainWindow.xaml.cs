using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
//TODO: Make help screen text more appealing?

namespace CMD_Project
{
    public partial class MainWindow : Window
    {
        string language= "en";
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
            oProcess.Start();
            oProcess.StandardInput.WriteLine($"{command}");
            oProcess.StandardInput.Flush();
            oProcess.StandardInput.Close();
            oProcess.WaitForExit();
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

        private void seButton_Click(object sender, RoutedEventArgs e)
        {
            languageGrid.Visibility = Visibility.Collapsed;
            mainGrid.Visibility = Visibility.Visible;
            language = "se";
            echoButton.Content = "Skriv till Fil";
            moveButton.Content = "Flytta Fil";
            typeButton.Content = "Skapa/Läs Fil";
            copyButton.Content = "Kopiera Fil";
            delButton.Content = "Ta Bort Fil";
            mdButton.Content = "Skapa Mapp";
            cdButton.Content = "Byt Mapp";
            dirButton.Content = "Visa Filer";
            treeButton.Content = "Visa Filstruktur";
            rdButton.Content = "Ta Bort Mapp";
            cmdButton.Content = "Kör";
            browseButton.Content = "Bläddra";
            clearButton.Content = "Rensa";
            languageButton.Content = "Språk";
            helpButton.Content = "Hjälp";
            langTextBlock.Text = "Välj språk:";
            seButton.Content = "Svenska";
            enButton.Content = "Engelska";
            echoGuide.Text = "Skriver meddelande till fil/konsol | ex. “echo meddelande” eller “echo meddelande > fil.txt” skapar fil och skriver texten i den.";
            moveGuide.Text = "Flytta fil | ex. “move fil.txt mappNamn” eller “move fil.txt fil2.txt” för att flytta fil till en annan.";
            typeGuide.Text = "Skapa eller läs fil | ex. “type nul > fil.txt” skapar en tom fil, “type fil.txt” läser filens innehåll.";
            copyGuide.Text = "Kopiera fil | ex. “copy fil.txt mappNamn”, eller “copy fil.txt fil2.txt” kopierar filen till en annan fil med namn fil2.";
            delGuide.Text = "Ta bort fil | ex. “del fil.txt” (Obs: Borttagna filer kan ej återhämtas).";
            mdGuide.Text = "Skapa mapp | ex. “md directoryName”.";
            cdGuide.Text = "Byt mapp | ex. “cd mappNamn”, “cd ..” för att flytta upp i en mapp, “cd /” för att flytta till root.";
            rdGuide.Text = "Ta bort mapp | ex. “rd mappNamn”.";
            dirGuide.Text = "Visa filer och mappar i nuvarande mapp | ex. “dir” eller “dir *.txt” för att visa alla filer med txt i nuvarande mapp.";
            treeGuide.Text = "Visa filstruktur under nuvarande mapp | ex. “tree” visar mappstruktur under nuvarande mapp, “tree /f” inkluderar även filer.";
        }
        private void enButton_Click(object sender, RoutedEventArgs e)
        {
            languageGrid.Visibility = Visibility.Collapsed;
            mainGrid.Visibility = Visibility.Visible;
            language = "en";
            echoButton.Content = "Write to File";
            moveButton.Content = "Move";
            typeButton.Content = "Create/Read File";
            copyButton.Content = "Copy File";
            delButton.Content = "Delete File";
            mdButton.Content = "Create Directory";
            cdButton.Content = "Change Directory";
            dirButton.Content = "List Files";
            treeButton.Content = "List Structure";
            rdButton.Content = "Delete Directory";
            cmdButton.Content = "Enter";
            browseButton.Content = "Browse";
            clearButton.Content = "Clear";
            languageButton.Content = "Language";
            helpButton.Content = "Help";
            langTextBlock.Text = "Select language:";
            seButton.Content = "Swedish";
            enButton.Content = "English";
            echoGuide.Text = "Write message to console/file | ex. “echo message”  or “echo message > file.txt” creates file and writes message.";
            moveGuide.Text = "Move file | ex. “move file.txt directoryName” or “move file.txt file2.txt” to move to second file.";
            typeGuide.Text = "Create or read file | ex. “type nul > file.txt” creates an empty file, “type fileName.txt” reads content of file.";
            copyGuide.Text = "Copy file | ex. “copy file.txt directoryName”, or “copy file.txt file2.txt” copies file to a second file.";
            delGuide.Text = "Delete file | ex. “del file.txt” (Attn: Removed files cannot be restored).";
            mdGuide.Text = "Make directory | ex. “md directoryName”.";
            cdGuide.Text = "Change directory | ex. “cd directoryName”, “cd ..” to go up one directory, “cd /” to go to root directory.";
            rdGuide.Text = "Remove directory | ex. “rd directoryName”.";
            dirGuide.Text = "Display files and folders in current directory | ex. “dir” or “dir *.txt” to show all files with “txt” in current directory.";
            treeGuide.Text = "Display file structure | ex. “tree” shows the directory structure under the current directory, “tree /f” includes files.";
        }

        private void languageButton_Click(object sender, RoutedEventArgs e)
        {
            mainGrid.Visibility= Visibility.Collapsed;
            languageGrid.Visibility= Visibility.Visible;
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "echoButton":
                    echoButton.Content = "echo";
                    break;
                case "moveButton":
                    moveButton.Content = "move";
                    break;
                case "typeButton":
                    typeButton.Content = "type";
                    break;
                case "copyButton":
                    copyButton.Content = "copy";
                    break;
                case "delButton":
                    delButton.Content = "del";
                    break;
                case "mdButton":
                    mdButton.Content = "md";
                    break;
                case "cdButton":
                    cdButton.Content = "cd";
                    break;
                case "dirButton":
                    dirButton.Content = "dir";
                    break;
                case "treeButton":
                    treeButton.Content = "tree";
                    break;
                case "rdButton":
                    rdButton.Content = "rd";
                    break;
                default:
                    break;
            }
            
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            if (language == "se")
            {
                switch (button.Name)
                {
                    case "echoButton":
                        echoButton.Content = "Skriv till Fil";
                        break;
                    case "moveButton":
                        moveButton.Content = "Flytta Fil";
                        break;
                    case "typeButton":
                        typeButton.Content = "Skapa/Läs Fil";
                        break;
                    case "copyButton":
                        copyButton.Content = "Kopiera Fil";
                        break;
                    case "delButton":
                        delButton.Content = "Ta Bort Fil";
                        break;
                    case "mdButton":
                        mdButton.Content = "Skapa Mapp";
                        break;
                    case "cdButton":
                        cdButton.Content = "Byt Mapp";
                        break;
                    case "dirButton":
                        dirButton.Content = "Visa Filer";
                        break;
                    case "treeButton":
                        treeButton.Content = "Visa Filstruktur";
                        break;
                    case "rdButton":
                        rdButton.Content = "Ta Bort Mapp";
                        break;
                    default:
                        break;
                }
            }
            else if (language == "en")
            {
                switch (button.Name)
                {
                    case "echoButton":
                    echoButton.Content = "Write to File";
                    break;
                case "moveButton":
                    moveButton.Content = "Move File";
                    break;
                case "typeButton":
                    typeButton.Content = "Create/Read File";
                    break;
                case "copyButton":
                    copyButton.Content = "Copy File";
                    break;
                case "delButton":
                    delButton.Content = "Delete File";
                    break;
                case "mdButton":
                    mdButton.Content = "Create Directory";
                    break;
                case "cdButton":
                    cdButton.Content = "Change Directory";
                    break;
                case "dirButton":
                    dirButton.Content = "List Files";
                    break;
                case "treeButton":
                    treeButton.Content = "List Structure";
                    break;
                case "rdButton":
                    rdButton.Content = "Delete Directory";
                    break;
                default:
                    break;
                }
            }
        }


    }
}