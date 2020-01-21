using System;
using System.IO;

namespace OpenNLP.Configurations
{
    public static class OpenNLPSettingsExtensions
    {
        public static string GetBaseFolder()
        {
            var directoryInfo = new DirectoryInfo(Environment.CurrentDirectory);

            while (directoryInfo.Parent != null && !directoryInfo.Parent.Name.Equals("OpenNLP", StringComparison.InvariantCultureIgnoreCase))
            {
                directoryInfo = directoryInfo.Parent;
            }

            return directoryInfo?.Parent?.FullName;
        }

        public static OpenNLPSettings GetDefaultSettings(this OpenNLPSettings settings)
        {
            var baseFolder = GetBaseFolder();

            if (baseFolder == null)
            {
                return new OpenNLPSettings();
            }

            settings.TrainingDirectory = $"{Path.Combine(baseFolder, "Resources", "Training")}";
            settings.MaximumEntropyModelDirectory = $"{Path.Combine(baseFolder, "Resources", "Models")}";
            settings.WordnetSearchDirectory = $"{Path.Combine(baseFolder, "Resources", "WordNet", "dict")}";

            return settings;
        }
    }
}