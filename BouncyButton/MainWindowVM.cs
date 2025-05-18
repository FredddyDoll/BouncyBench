using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BouncyButton
{
    partial class MainWindowVM:ObservableObject
    {
        [ObservableProperty]
        double left;

        [ObservableProperty]
        double top;

        [ObservableProperty]
        double width = 100;

        [ObservableProperty]
        double height = 100;

        [ObservableProperty]
        double fieldWidth = 300;

        [ObservableProperty]
        double fieldHeight = 300;

        public double StepSizeLeft { get; private set; } = 1;
        public double StepSizeTop { get; private set; } = 1;


        ILogger<MainWindowVM> _logger;

        public MainWindowVM(ILogger<MainWindowVM> logger)
        {
            _logger = logger;
        }

        [RelayCommand(IncludeCancelCommand = true)]
        public async Task RunAsync(CancellationToken t)
        {
            try
            {
                int loopCntr = 0;
                while (!t.IsCancellationRequested)
                {
                    StepSimulation(loopCntr);

                    await Task.Delay(16);
                    loopCntr++;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Stopped");
            }
        }

        //ToDo: Features! RandomizeSpeedCommand
        internal void StepSimulation(int loopCntr)
        {
            Left += StepSizeLeft;
            Top += StepSizeTop;

            StepSizeTop += 0.1;

            if ((Left > FieldWidth - Width) || (Left < 0))
                StepSizeLeft *= -1;

            if ((Top > FieldHeight - Height) || (Top < 0))
                StepSizeTop *= -1;

            //TODO: Why?
            Left += StepSizeLeft;
            Top += StepSizeTop;

            if (loopCntr % 100 == 0)
            {
                StepSizeLeft *= 0.99;
                StepSizeTop *= 1.01;
            }
        }

        [RelayCommand]
        internal void RandomizeSpeed()
        {
            //ToDo: Features! also turn around sometimes!
            StepSizeLeft = Random.Shared.NextDouble() - 0.5;
            StepSizeTop = Random.Shared.NextDouble() - 0.5;
        }
    }
}
