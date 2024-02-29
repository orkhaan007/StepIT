using System.Collections.ObjectModel;
using System.Windows.Input;
using ThreadManager.Commands;
using System.Windows;
using ThreadManager.Services;
#nullable disable

namespace ThreadManager.ViewModels.WindowViewModels
{
    public class MainWindowViewModel : NotificationService
    {
        public Semaphore semaphore { get; set; }
        private ObservableCollection<Thread> createdThreads = new ObservableCollection<Thread>();
        private ObservableCollection<Thread> waitingThreads = new ObservableCollection<Thread>();
        private ObservableCollection<Thread> workingThreads = new ObservableCollection<Thread>();

        public ObservableCollection<Thread> CreatedThreads
        {
            get => createdThreads;
            set
            {
                createdThreads = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Thread> WaitingThreads
        {
            get => waitingThreads;
            set
            {
                waitingThreads = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Thread> WorkingThreads
        {
            get => workingThreads;
            set
            {
                workingThreads = value;
                OnPropertyChanged();
            }
        }

        public ICommand CreateNewCommand { get; }

        public MainWindowViewModel()
        {
            CreateNewCommand = new RelayCommand(CreateNew);
            semaphore = new Semaphore(3, 3);
            createdThreads = new ObservableCollection<Thread>();
            workingThreads = new ObservableCollection<Thread>();
            waitingThreads = new ObservableCollection<Thread>();
        }

        private void CreateNew(object parameter)
        {
            Thread newThread = new Thread(() => 
            {
                var th = Thread.CurrentThread;
                Application.Current.Dispatcher.Invoke(() =>
                {
                    CreatedThreads.Remove(th);
                    WaitingThreads.Add(th);
                });

                semaphore.WaitOne();

                Application.Current.Dispatcher.Invoke(() =>
                {
                    WaitingThreads.Remove(th);
                    WorkingThreads.Add(th);
                });
                Thread.Sleep(5000);
                semaphore.Release();

            });

            newThread.Name = "Thread" + newThread.ManagedThreadId;
            CreatedThreads.Add(newThread);
        }
    }
}