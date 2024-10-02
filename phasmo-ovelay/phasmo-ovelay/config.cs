using System.IO;
using Newtonsoft.Json;

namespace phasmo_ovelay
{
    public class Config
    {
        public string StartStopKey { get; set; } = "D1"; // Valor por defecto
        public string ResetKey { get; set; } = "D2"; // Valor por defecto
        public string ToggleVisibilityKey { get; set; } = "D3"; // Valor por defecto

        // Cargar la configuración desde el archivo JSON
        public static Config LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var config = JsonConvert.DeserializeObject<Config>(json);

                // Comprobar si las claves son válidas
                if (string.IsNullOrEmpty(config.StartStopKey) ||
                    string.IsNullOrEmpty(config.ResetKey) ||
                    string.IsNullOrEmpty(config.ToggleVisibilityKey))
                {
                    return new Config(); // Devuelve la configuración por defecto
                }

                return config;
            }
            return new Config(); // Devuelve una nueva instancia con valores por defecto si el archivo no existe
        }
    }
}
