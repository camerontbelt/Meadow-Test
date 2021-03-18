using System;
using System.Threading;
using Meadow.Devices;
using Meadow.Hardware;

namespace Meadow.App
{
    class LedApp : App<F7Micro, LedApp>
    {
        private IDigitalOutputPort redLed;
        private IDigitalOutputPort blueLed;
        private IDigitalOutputPort greenLed;

        public LedApp()
        {
            CreateOutputs();
            ShowLights();
        }

        public void CreateOutputs()
        {
            redLed = Device.CreateDigitalOutputPort(Device.Pins.OnboardLedRed);
            blueLed = Device.CreateDigitalOutputPort(Device.Pins.OnboardLedBlue);
            greenLed = Device.CreateDigitalOutputPort(Device.Pins.OnboardLedGreen);
        }

        public void ShowLights()
        {
            var state = false;

            while (true)
            {
                state = !state;

                Console.WriteLine($"State: {state}");

                redLed.State = state;
                Thread.Sleep(200);
                greenLed.State = state;
                Thread.Sleep(200);
                blueLed.State = state;
                Thread.Sleep(200);
            }
        }
    }
}