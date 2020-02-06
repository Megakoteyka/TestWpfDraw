using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Threading;

namespace TestGit
{
    internal class ViewModel
    {
        public ObservableCollection<ushort> Data { get; }

        public ICommand StartCommand { get; }
        public ICommand StopCommand { get; }

        private readonly DispatcherTimer _timer;

        public ViewModel()
        {
            Data = new ObservableCollection<ushort>();
            for (var i = 0; i < 512; i++)
                Data.Add((ushort)i);

            _timer = new DispatcherTimer(
                    TimeSpan.FromMilliseconds(20),
                    DispatcherPriority.Render,
                    TimerTick,
                    Dispatcher.CurrentDispatcher)
                {IsEnabled = false};

            StartCommand = new Command(o =>
            {
                _timer.Start();
            });

            StopCommand = new Command(o =>
            {
                _timer.Stop();
            });
        }

        private void TimerTick(object sender, EventArgs e)
        {
            for (var i = 0; i < 512; i++)
                Data[i]++;
        }
    }
}
