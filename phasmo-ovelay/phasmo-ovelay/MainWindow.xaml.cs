using System;
using System.Windows;
using System.Windows.Threading;
using Newtonsoft.Json; // Asegúrate de tener esta referencia
using System.IO;
using System.Windows.Input;

namespace phasmo_ovelay
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer;
        private TimeSpan _time;
        private bool _isHidden; // Para controlar si el cronómetro está oculto
        private Config _config; // Instancia de la clase de configuración
        private GlobalKeyboardHook _globalKeyboardHook; // Instancia del hook global

        public MainWindow()
        {
            InitializeComponent();
            _time = TimeSpan.Zero;
            _isHidden = false; // Inicialmente, el cronómetro no está oculto

            // Cargar la configuración
            LoadConfig();

            // Crear el temporizador con intervalos de 1 segundo
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;

            // Inicializar el hook de teclado global
            _globalKeyboardHook = new GlobalKeyboardHook();
            _globalKeyboardHook.HookKeyboard(); // Enganchar el teclado
            _globalKeyboardHook.KeyPressed += GlobalKeyboardHook_KeyPressed; // Subscribirse al evento

            // Obtener el ancho de la pantalla
            var screenWidth = SystemParameters.PrimaryScreenWidth;

            // Ajustar el ancho y la altura de la ventana si es necesario
            this.Width = 200;  // Ajusta el ancho según el tamaño del cronómetro
            this.Height = 100; // Ajusta la altura si es necesario

            // Posicionar la ventana en la parte superior del centro de la pantalla
            this.Left = (screenWidth - this.Width) / 2;  // Centrar horizontalmente
            this.Top = 10;  // Un poco por debajo del borde superior

            // Mostrar el cronómetro al iniciar
            CronoText.Text = _time.ToString(@"mm\:ss");

            // Manejar el cierre de la ventana para desenganchar el hook
            this.Closing += MainWindow_Closing;
        }

        // Cargar la configuración desde el archivo JSON
        private void LoadConfig()
        {
            string json = File.ReadAllText("config.json");
            _config = JsonConvert.DeserializeObject<Config>(json);
        }

        // Desenganchar el hook al cerrar la aplicación
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _globalKeyboardHook.UnhookKeyboard(); // Desenganchar el hook global
        }

        // Este método será llamado cuando se presione una tecla globalmente
        private void GlobalKeyboardHook_KeyPressed(Key key)
        {
            ProcessKey(key);
        }

        // Función para procesar las teclas presionadas globalmente
        private void ProcessKey(Key key)
        {
            // Verificar las teclas configuradas
            if (key.ToString() == _config.StartStopKey)
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
            else if (key.ToString() == _config.ResetKey)
            {
                ResetCronometro(); // Reiniciar el cronómetro
            }
            else if (key.ToString() == _config.ToggleVisibilityKey)
            {
                ToggleVisibility(); // Cambiar la visibilidad
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

        // Reiniciar el cronómetro
        private void ResetCronometro()
        {
            _time = TimeSpan.Zero; // Reiniciar el tiempo a cero
            CronoText.Text = _time.ToString(@"mm\:ss"); // Actualizar el texto del cronómetro
        }

        // Cambiar la "visibilidad" del cronómetro (mostrar/ocultar texto)
        private void ToggleVisibility()
        {
            if (_isHidden)
            {
                CronoText.Text = _time.ToString(@"mm\:ss"); // Mostrar el cronómetro
                _isHidden = false; // Actualizar estado
            }
            else
            {
                CronoText.Text = ""; // Ocultar el cronómetro
                _isHidden = true; // Actualizar estado
            }
        }

        // Actualizar el cronómetro cada segundo
        private void Timer_Tick(object sender, EventArgs e)
        {
            _time = _time.Add(TimeSpan.FromSeconds(1)); // Aumentar el tiempo en 1 segundo
            if (!_isHidden)
            {
                CronoText.Text = _time.ToString(@"mm\:ss"); // Actualizar el texto del cronómetro solo si es visible
            }
        }
    }
}
