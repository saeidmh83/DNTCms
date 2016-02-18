using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DNTCms.UnitTests
{
    public static class Helpers
    {
        public static string GetInputFile(string filename)
        {
            //filename=namespace.filename
            var thisAssembly = Assembly.GetExecutingAssembly();
            var stream = thisAssembly.GetManifestResourceStream(filename);
            return new StreamReader(stream).ReadToEnd();
        }
    }
}
