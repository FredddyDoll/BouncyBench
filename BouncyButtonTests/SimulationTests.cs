using BouncyButton;
using Microsoft.Extensions.Logging.Abstractions;

namespace BouncyButtonTests
{
    public class SimulationTests
    {
        [Fact]
        public void TurnsAround()
        {
            var vm = new MainWindowVM(NullLogger<MainWindowVM>.Instance);

            for (int i = 0; i < 10000; i++)
                vm.StepSimulation(i);

            Assert.True(
                (vm.Left < vm.FieldWidth - vm.Width) &&
                (vm.Top < vm.FieldHeight - vm.Height) &&
                (vm.Left > 0) &&
                (vm.Top > 0)
                );
        }


        [Fact]
        public void RandomizesSpeed()
        {
            var referenceVm = new MainWindowVM(NullLogger<MainWindowVM>.Instance);
            var vm = new MainWindowVM(NullLogger<MainWindowVM>.Instance);

            vm.RandomizeSpeed();

            Assert.True(
                (vm.StepSizeLeft != referenceVm.StepSizeLeft) &&
                (vm.StepSizeTop != referenceVm.StepSizeTop)
                );
        }

        [Fact]
        public async Task RaisesPropertyChanged()
        {
            var referenceVm = new MainWindowVM(NullLogger<MainWindowVM>.Instance);
            var vm = new MainWindowVM(NullLogger<MainWindowVM>.Instance);


            bool stepSizeChanged = false;
            bool leftChanged = false;
            vm.PropertyChanged += (sender, e) =>
            {
                if(e.PropertyName == nameof(vm.StepSizeLeft))
                    stepSizeChanged = true;

                if (e.PropertyName == nameof(vm.Left))
                    leftChanged = true;
            };


            var cts = new CancellationTokenSource();
            var run = vm.RunAsync(cts.Token);

            vm.RandomizeSpeed();

            cts.CancelAfter(TimeSpan.FromMilliseconds(500));
            await run; // should complete without throwing

            Assert.True(leftChanged, "PropertyChanged \"Left\" not raised");
            Assert.True(stepSizeChanged, "PropertyChanged \"StepSizeLeft\" not raised");
        }
    }
}