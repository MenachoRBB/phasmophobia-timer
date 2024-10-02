using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace phasmo_ovelay
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer;
        private TimeSpan _time;

        public MainWindow()
        {
            InitializeComponent();
            _time = TimeSpan.Zero;

            // Crear el temporizador con intervalos de 1 segundo
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;

            // Registrar el evento de teclado
            this.KeyDown += MainWindow_KeyDown;

            // Obtener el ancho de la pantalla
            var screenWidth = SystemParameters.PrimaryScreenWidth;

            // Ajustar el ancho y la altura de la ventana si es necesario
            this.Width = 200;  // Ajusta el ancho según el tamaño del cronómetro
            this.Height = 100; // Ajusta la altura si es necesario

            // Posicionar la ventana en la parte superior del centro de la pantalla
            this.Left = (screenWidth - this.Width) / 2;  // Centrar horizontalmente
            this.Top = 10;  // Un poco por debajo del borde superior
        }

        // Manejar el evento de tecla pulsada
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D1) // Si se presiona '1', iniciar/detener el cronómetro
            {
                if (_timer.IsEnabled)
                {
                    StopCronometro(); // Detener el cronómetro
                }
                else
                {
                    StartCronometro(); // Iniciar el cronómetro
                }
            }
        }

        // Iniciar el cronómetro
        private void StartCronometro()
        {
            _timer.Start();
        }

        // Detener el cronómetro
        private void StopCronometro()
        {
            _timer.Stop();
        }

        // Actualizar el cronómetro cada segundo
        private void Timer_Tick(object sender, EventArgs e)
        {
            _time = _time.Add(TimeSpan.FromSeconds(1));
            CronoText.Text = _time.ToString(@"mm\:ss");
        }
    }
}
