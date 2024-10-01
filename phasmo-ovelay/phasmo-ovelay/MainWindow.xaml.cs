using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace phasmo_ovelay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Obtener el ancho de la pantalla
            var screenWidth = SystemParameters.PrimaryScreenWidth;
            var screenHeight = SystemParameters.PrimaryScreenHeight;

            // Ajustar el ancho y la altura de la ventana si es necesario
            this.Width = 200;  // Ajusta el ancho según el tamaño del cronómetro
            this.Height = 100; // Ajusta la altura si es necesario

            // Posicionar la ventana en la parte superior del centro de la pantalla
            this.Left = (screenWidth - this.Width) / 2;  // Centrar horizontalmente
            this.Top = 10;  // Un poco por debajo del borde superior
        }
    }
}