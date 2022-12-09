using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure
{
    public static class EmbededResourceReader
    {
        public static string GetResource(string path)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            // Resources are named using a fully qualified name.
            Stream stream = assembly.GetManifestResourceStream(path);
            //Read the content of the embedded file
            StreamReader reader = new StreamReader(stream);

            string data = reader.ReadToEnd();
            return data;
        }
    }
}
