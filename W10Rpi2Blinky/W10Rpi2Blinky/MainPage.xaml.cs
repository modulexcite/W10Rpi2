using System;
using System.Diagnostics;
using Windows.Devices.Gpio;
using Windows.UI.Xaml;

namespace W10Rpi2Blinky
{
    public sealed partial class MainPage
    {
        private DispatcherTimer _timerBlink;

        public MainPage()
        {
            InitializeComponent();
            InitGpioController();
            Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            _timerBlink = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1000) };
            _timerBlink.Tick += _timerBlink_Tick;
            _timerBlink.Start();
        }

        private GpioPin _pinD4;
        private bool _ledStatus;

        private void _timerBlink_Tick(object sender, object e)
        {
            TextBlockStatus.Text = $"Led Status is {_ledStatus}";
            if (_pinD4 != null)
            {
                _pinD4.Write(_ledStatus ? GpioPinValue.High : GpioPinValue.Low);
            }
            _ledStatus = !_ledStatus;
        }

        private void InitGpioController()
        {
            var gpio = GpioController.GetDefault();
            if (gpio == null)
            {
                _pinD4 = null;
                return;
            }

            GpioOpenStatus openstatus = GpioOpenStatus.PinUnavailable;
            gpio.TryOpenPin(LedPin, GpioSharingMode.Exclusive, out _pinD4, out openstatus);
            Debug.WriteLine("pin: " + LedPin + " status: " + openstatus);

            if (_pinD4 == null)
            {
                return;
            }

            _pinD4.Write(GpioPinValue.High);
            _pinD4.SetDriveMode(GpioPinDriveMode.Output);
        }
        private const int LedPin = 23;

    }
}
