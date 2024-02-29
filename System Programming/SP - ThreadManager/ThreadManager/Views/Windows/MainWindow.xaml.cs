using System.Windows.Input;
using System.Windows;
using ThreadManager.ViewModels.WindowViewModels;
using System.Windows.Controls;
#nullable disable

namespace ThreadManager;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }

    private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        ListView? view = sender as ListView;

        if (view?.SelectedItem != null)
        {
            Thread thread = (Thread)view.SelectedItem;
            thread.Start();
        }
    }
}