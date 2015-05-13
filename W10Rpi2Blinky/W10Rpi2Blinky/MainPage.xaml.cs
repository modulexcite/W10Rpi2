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

        private const int LedPin = 4;
        private GpioPin _pinD4;
        private bool _ledStatus;

        private void _timerBlink_Tick(object sender, object e)
        {
            TextBlockStatus.Text = $"Led Status is {_ledStatus}";
            if (_pinD4 != null)
                _pinD4.Write(_ledStatus ? GpioPinValue.High : GpioPinValue.Low);
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

            Debug.WriteLine("pin count: " + gpio.PinCount);

            GpioOpenStatus openstatus = GpioOpenStatus.PinUnavailable;

            //for (int i = 0; i < gpio.PinCount - 1; i++)
            //{
            //    gpio.TryOpenPin(i, GpioSharingMode.Exclusive, out _pinD4, out openstatus);
            //    Debug.WriteLine("pin: " + i + " status:" + openstatus);
            //    //if (openstatus == GpioOpenStatus.PinOpened)
            //    //    return;
            //}

            _pinD4 = gpio.OpenPin(5);

            if (openstatus == GpioOpenStatus.PinUnavailable || _pinD4 == null)
            {
                return;
            }

            _pinD4.Write(GpioPinValue.High);
            _pinD4.SetDriveMode(GpioPinDriveMode.Output);
        }
    }
}
