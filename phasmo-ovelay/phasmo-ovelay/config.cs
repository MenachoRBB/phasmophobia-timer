using System.IO;
using Newtonsoft.Json;

namespace phasmo_ovelay
{
    public class Config
    {
        public string StartStopKey { get; set; }
        public string ResetKey { get; set; }
        public string ToggleVisibilityKey { get; set; }

        // Cargar la configuración desde el archivo JSON
        public static Config LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<Config>(json);
            }
            return new Config(); // Devuelve una nueva instancia si el archivo no existe
        }
    }
}
