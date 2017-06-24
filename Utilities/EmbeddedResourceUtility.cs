using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Utilities
{
    public static class EmbeddedResourceUtility
    {
        public static IEnumerable<string> GetResourceDataLineTexts(Assembly assembly, string resourceName)
        {
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using(var streamReader = new StreamReader(stream))
            {
                var line = string.Empty;
                while((line = streamReader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
