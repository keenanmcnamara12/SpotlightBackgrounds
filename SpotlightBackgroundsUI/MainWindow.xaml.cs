using System;
using System.Collections.Generic;
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
using System.Windows.Forms;
using SpotlightBackgrounds;
using System.Text.RegularExpressions;
using Microsoft.Win32.TaskScheduler;
using System.IO;

namespace SpotlightBackgroundsUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        UserSettings settings;
        private const string _taskName = "SpotlightToDesktopBackgrounds";

        public MainWindow()
        {
            settings = new UserSettings();

            InitializeComponent();

            if (!String.IsNullOrWhiteSpace(settings.BackgroundFolderPath))
            {
                txt_BackgroundDirectory.Text = settings.BackgroundFolderPath;
            }

            txt_XDimension.Text = settings.MinPixelWidth.ToString();
            txt_YDimension.Text = settings.MinPixelHeight.ToString();
        }

        ~MainWindow()
        {
            settings.saveUserSettings();
        }

        private void btn_BackgroundDirectoryChooser_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Verify user has write access to the directory. If so, save the path!
                    // This isn't a gaurentee depeding on how the program is being run and
                    // if there are any possible changes in permissions.
                    if (!Program.hasWriteAccessToFolder(dialog.SelectedPath))
                    {
                        System.Windows.MessageBox.Show("Invalid directory, you don't have appropriate permissions. Choose another directory.", "Invalid Direcory");
                    }
                    else
                    {
                        txt_BackgroundDirectory.Text = dialog.SelectedPath;
                        settings.BackgroundFolderPath = dialog.SelectedPath;
                    }
                }
            }
        }

        private void btn_RunOnce_Click(object sender, RoutedEventArgs e)
        {
            // Update settings in the file before running the app.
            // The app relies on the settings file being up to date.
            settings.saveUserSettings();

            // Run the app
            SpotlightBackgrounds.Program.Main(null);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btn_ScheduleTask_Click(object sender, RoutedEventArgs e)
        {
            settings.saveUserSettings();

            // Get the service on the local machine     
            using (TaskService ts = new TaskService())
            {
                // If the task already exists, remove it and we'll add a new entry
                // basically this will allow the user to change the daily time.
                if (ts.RootFolder.Tasks.Exists(_taskName))
                {
                    ts.RootFolder.DeleteTask(_taskName);
                }

                // Create a new task definition and assign properties
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "Copy spotlight images to background folder.";

                // Create a trigger that will fire the task at this time every other day
                td.Triggers.Add(new DailyTrigger { DaysInterval = 1 });

                // Create an action that will run the program whenever the trigger fires
                //   After installing, SpotlightBackgrounds.exe should be in the same directory as
                //   SpotlightBackgroundsUI.exe and absolute path to the executable will be scheduled.
                td.Actions.Add(new ExecAction(AppDomain.CurrentDomain.BaseDirectory + "SpotlightBackgrounds.exe"));

                //if (!td.Validate(false))
                //    Console.WriteLine("Not valid td");

                // Register the task in the root folder
                ts.RootFolder.RegisterTaskDefinition(_taskName, td);
            }
        }

        private void btn_unScheduleTask_Click(object sender, RoutedEventArgs e)
        {
            // Get the service on the local machine     
            using (TaskService ts = new TaskService())
            {
                // Remove the task we just created (don't care for exception if it DNE)
                ts.RootFolder.DeleteTask(_taskName, false);
            }
        }

        private void txt_BackgroundDirectory_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Directory.Exists(txt_BackgroundDirectory.Text))
            {
                settings.BackgroundFolderPath = txt_BackgroundDirectory.Text;
            }
        }

        private void txt_XDimension_TextChanged(object sender, TextChangedEventArgs e)
        {
            settings.MinPixelWidth = Int32.Parse(txt_XDimension.Text);
        }

        private void txt_YDimension_TextChanged(object sender, TextChangedEventArgs e)
        {
            settings.MinPixelHeight = Int32.Parse(txt_YDimension.Text);
        }
    }
}
