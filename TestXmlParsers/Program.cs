using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace TestXmlParsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestXmlParsers.short.xml");
            RunParsers(stream);
            stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestXmlParsers.long.xml");
            RunParsers(stream);
        }
        public static List<string> SaxResult = new List<string>();
        public static void callback(object e, string d)
        {
            SaxResult.Add(d);
        }
        public static void RunParsers(Stream stream)
        {
            Console.WriteLine($"XML Document {stream.Length / 1024} kB");

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
