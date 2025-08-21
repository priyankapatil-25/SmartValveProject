using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SmartValve
{
    public static class ValvePatternLibrary
    {
        public static Dictionary<string, List<PatternEntity>> Patterns = new Dictionary<string, List<PatternEntity>>();

        public static void Add(string valveName, List<PatternEntity> entities)
        {
            Patterns[valveName] = entities;
        }

        private static string GetFixedPath()
        {
            string folder = @"C:\SmartValve";
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            return Path.Combine(folder, "valve_patterns.json");
        }

        public static void SaveToFile()
        {
            string path = GetFixedPath();
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(Patterns, options);
            File.WriteAllText(path, json);
        }

        public static void LoadFromFile()
        {
            string path = GetFixedPath();
            if (!File.Exists(path))
                return;

            string json = File.ReadAllText(path);
            Patterns = JsonSerializer.Deserialize<Dictionary<string, List<PatternEntity>>>(json);
        }
    }
}
