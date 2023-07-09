using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestXmlParsers
{
    internal class Program
    {
        public static List<string> SaxResult = new List<string>();
        public static void callback(object e, string d)
        {
            SaxResult.Add(d);
        }
        static void Main(string[] args)
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestXmlParsers.file.xml");

            DomParser.DomParser dom = new DomParser.DomParser();
            SaxParser.SaxParser sax = new SaxParser.SaxParser();
            sax.stringevent += callback;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var result = dom.ReadGrandChildren(stream);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine($"DOM: {ts.Ticks}");

            stream.Seek(0, SeekOrigin.Begin);
            stopWatch.Restart();
            sax.ReadGrandChildren(stream);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine($"SAX: {ts.Ticks}");
            SaxResult.Clear();

            stream.Seek(0, SeekOrigin.Begin);
            stopWatch.Restart();
            sax.ReadGrandChildren(stream);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine($"SAX: {ts.Ticks}");
            SaxResult.Clear();

            stream.Seek(0, SeekOrigin.Begin);
            stopWatch.Restart();
            result = dom.ReadGrandChildren(stream);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine($"DOM: {ts.Ticks}");

            stream.Seek(0, SeekOrigin.Begin);
            stopWatch.Restart();
            result = dom.ReadGrandChildren(stream);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine($"DOM: {ts.Ticks}");

            stream.Seek(0, SeekOrigin.Begin);
            stopWatch.Restart();
            sax.ReadGrandChildren(stream);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine($"SAX: {ts.Ticks}");
            SaxResult.Clear();
        }
    }
}
