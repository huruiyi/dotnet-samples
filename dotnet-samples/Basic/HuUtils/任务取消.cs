using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace HuUtils
{
    public partial class 任务取消 : Form
    {
        private static BackgroundWorker _worker;
        private int _startFrom;
        private int _end;

        public 任务取消()
        {
            InitializeComponent();

            _worker = new BackgroundWorker();
            _worker.DoWork += _worker_DoWork;
            _worker.WorkerSupportsCancellation = true;
        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (var item in GetPrimes(_startFrom, _end))
            {
                Thread.Sleep(5);
                txtData.Invoke(new EventHandler(Target), item);
            }
        }

        private void Target(object sender, EventArgs e)
        {
            txtData.AppendText(sender + Environment.NewLine);
        }

        private void DisplayPrimes(int obj)
        {
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

        private void BtnStart_Click(object sender, EventArgs e)
        {
            _startFrom = Convert.ToInt32(TxtFrom.Text);
            _end = Convert.ToInt32(TxtTo.Text);
            _worker.RunWorkerAsync();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            _worker.CancelAsync();
        }
    }
}