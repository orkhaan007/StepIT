using System.Windows;
using System.Diagnostics;
using System.Collections.ObjectModel;
using TaskManager.Models;

namespace TaskManager
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<ProcessInfo> Processes { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Processes = new ObservableCollection<ProcessInfo>();
            processListView.ItemsSource = Processes;
            LoadProcesses();
        }

        private void LoadProcesses()
        {
            Processes.Clear();
            foreach (Process process in Process.GetProcesses())
            {
                Processes.Add(new ProcessInfo(process.Id, process.ProcessName, process.HandleCount, process.Threads.Count, process.MachineName));
            }
        }

        private void EndProcessButton_Click(object sender, RoutedEventArgs e)
        {
            if (processListView.SelectedItem != null)
            {
                ProcessInfo selectedProcess = (ProcessInfo)processListView.SelectedItem;
                Process process = Process.GetProcessById(selectedProcess.Id);
                if (process != null)
                {
                    process.Kill();
                    Processes.Remove(selectedProcess);
                }
                else
                    MessageBox.Show("The selected process could not be terminated.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("Please select a process to terminate.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void CreateProcessButton_Click(object sender, RoutedEventArgs e)
        {
            string processPath = ProcessPathTextBox.Text;

            Process.Start(processPath);
        }


    }
}