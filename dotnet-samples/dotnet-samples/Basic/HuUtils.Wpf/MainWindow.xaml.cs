using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Windows;

namespace HuUtils.Wpf
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        private static BackgroundWorker _worker;
        private int _startFrom;
        private int _end;
        public ObservableCollection<int> PrimeNumbers { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            PrimeNumbers = new ObservableCollection<int>();
            _worker = new BackgroundWorker();
            _worker.DoWork += _worker_DoWork;
            _worker.WorkerSupportsCancellation = true;
            this.DataContext = this;
        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (var item in GetPrimes(_startFrom, _end))
            {
                Thread.Sleep(5);
                Dispatcher.BeginInvoke(new Action<int>(DisplayPrimes), item);
            }
        }

        private void DisplayPrimes(int obj)
        {
            PrimeNumbers.Add(obj);
        }

        private static IEnumerable<int> GetPrimes(int from, int to)
        {
            for (int i = from; i <= to; i++)
            {
                if (!_worker.CancellationPending)
                {
                    bool isPrime = true;
                    int limit = (int)Math.Sqrt(i);
                    for (int j = 2; j <= limit; j++)
                        if (i % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    if (isPrime)
                    {
                        yield return i;
                    }
                }
            }
        }

        private void btnGetPrimes_Click(object sender, RoutedEventArgs e)
        {
            _startFrom = Convert.ToInt32(TxtFrom.Text);
            _end = Convert.ToInt32(TxtTo.Text);
            _worker.RunWorkerAsync();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _worker.CancelAsync();
        }
    }
}