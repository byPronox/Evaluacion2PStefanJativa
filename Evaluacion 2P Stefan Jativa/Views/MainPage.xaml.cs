using System.Text;
using Evaluacion_2P_Stefan_Jativa.Models;

namespace Evaluacion_2P_Stefan_Jativa.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly string _fileName = Path.Combine(FileSystem.AppDataDirectory, "StefanJativa.txt");



        public MainPage()
        {
            InitializeComponent();
            CargarRecargas();
        }

        private async void Recargar_Clicked(object sender, EventArgs e)
        {
            string numeroTelefono = sjativa_telefonoEntry.Text;
            string nombreUsuario = sjativa_nombreEntry.Text;

            if (string.IsNullOrWhiteSpace(numeroTelefono) || string.IsNullOrWhiteSpace(nombreUsuario))
            {
                await DisplayAlert("Error", "Por favor, complete todos los campos.", "OK");
                return;
            }

            // Crear el objeto de recarga
            Recarga nuevaRecarga = new Recarga
            {
                NumeroTelefono = numeroTelefono,
                NombreUsuario = nombreUsuario,
                Fecha = DateTime.Now.ToString("g")
            };

            // Crear contenido para guardar
            string contenido = $"Nombre: {nuevaRecarga.NombreUsuario}\nNúmero: {nuevaRecarga.NumeroTelefono}\nFecha: {nuevaRecarga.Fecha}\n\n";
            string filepatch = Path.Combine(FileSystem.AppDataDirectory, _fileName);

            // Guardar en el archivo (añadir sin sobrescribir)d
            File.AppendAllText(_fileName, contenido);

            // Mostrar mensaje de éxito
            await DisplayAlert("Éxito", "La recarga fue realizada con éxito.", "OK");

            // Mostrar la última recarga
            sjativa_resultadoLabel.Text = $"Nombre: {nuevaRecarga.NombreUsuario}\nNúmero: {nuevaRecarga.NumeroTelefono}";

            // Limpiar los campos de entrada
            sjativa_telefonoEntry.Text = string.Empty;
            sjativa_nombreEntry.Text = string.Empty;

            // Actualizar la lista de recargas
            CargarRecargas();

            System.Diagnostics.Debug.WriteLine($"Archivo guardado en: {filepatch}");
        }

        private void CargarRecargas()
        {
            // Verificar si el archivo existe
            if (File.Exists(_fileName))
            {
                // Leer todo el contenido del archivo
                string contenido = File.ReadAllText(_fileName);

                // Mostrarlo en el Label
                sjativa_resultadoLabel.Text = contenido;
            }
            else
            {
                sjativa_resultadoLabel.Text = "No hay recargas registradas.";
            }
        }
    }
}
