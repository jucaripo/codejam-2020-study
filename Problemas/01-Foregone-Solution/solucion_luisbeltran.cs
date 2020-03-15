using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ForegoneSolution
{
    public class CodeJamProblem : IDisposable
    {
        public int CurrentCaseNumber
        {
            get;
            private set;
        }

        public int StartTime
        {
            get;
            private set;
        }

        public int ElapsedTime
        {
            get;
            private set;
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    this.ElapsedTime = Environment.TickCount - this.StartTime;

                    //Console.WriteLine("Elapsed time: {0:#,#0}ms", this.ElapsedTime);
                    //Console.Beep();
                    //Console.ReadKey(true);
                }
            }

            disposed = true;
        }

        public CodeJamProblem()
        {
            this.CurrentCaseNumber = 1;
            this.StartTime = Environment.TickCount;
        }

        // Print several values as part of the result
        public void WriteCaseOutput(params object[] values)
        {
            var parts = new string[values.Length];
            for (int i = 0; i < parts.Length; i++)
                parts[i] = values[i].ToString();
            WriteCaseOutput(string.Join(" ", parts));
        }

        // Print null, empty result
        public void WriteCaseOutput() => WriteCaseOutput((string)null);

        // Print a result
        private void WriteCaseOutput(string value)
        {
            WriteLine("Case #{0:#0}: {1}", this.CurrentCaseNumber, value);
            this.CurrentCaseNumber++;
        }

        // Print a string with format and values
        public void WriteLine(string format, params object[] arg) => Console.WriteLine(format, arg);

        // Print a string
        public void WriteLine(string line) => Console.WriteLine(line);

        // Print several lines
        public void WriteLines(string[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
                WriteLine(lines[i]);
        }

        // Print a vector (one-dimension array) in one line
        public void WriteArray<T>(T[] values)
        {
            var parts = new string[values.Length];
            for (int i = 0; i < parts.Length; i++)
                parts[i] = values[i].ToString();
            WriteLine(string.Join(" ", parts));
        }

        // Print a jagged array (array of arrays) in several lines
        public void WriteArrays<T>(T[][] entries)
        {
            for (int i = 0; i < entries.Length; i++)
                WriteArray(entries[i]);
        }

        // Read a jagged array (N lines)
        public T[][] ReadArrays<T>(int N, Func<string, T> converter)
        {
            var entries = new T[N][];
            for (int i = 0; i < entries.Length; i++)
                entries[i] = ReadArray(converter);
            return entries;
        }

        // Read a vector (one-dimension array)
        public T[] ReadArray<T>(Func<string, T> converter)
        {
            var parts = ReadParts();
            var values = new T[parts.Length];
            for (int i = 0; i < values.Length; i++)
                values[i] = converter(parts[i]);
            return values;
        }

        // Read N lines (returns a string array)
        public string[] ReadLines(int N)
        {
            var lines = new string[N];
            for (int i = 0; i < lines.Length; i++)
                lines[i] = ReadLine();
            return lines;
        }

        // Read a full line (values separated by spaces, returns a string array)
        public string[] ReadParts() => ReadLine().Split(' ');

        // Read a line (returns a string)
        public string ReadLine() => Console.ReadLine();

        // Read a single value (converted to T type)
        public T ReadValue<T>(Func<string, T> converter) => converter(ReadLine());
    }

    public static class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> intConverter = (value) => int.Parse(value);
            Func<string, short> shortConverter = (value) => short.Parse(value);
            Func<string, long> longConverter = (value) => long.Parse(value);
            Func<string, bool> boolConverter = (value) => bool.Parse(value);

            Func<string, string> upperCaseConverter = (value) => value.ToUpper();
            Func<string, string> lowerCaseConverter = (value) => value.ToLower();

            Func<string, int> oppositeNumberConverter = (value) =>
            {
                var number = intConverter(value);
                return -number;
            };

            using (var problem = new CodeJamProblem())
            {
                var T = problem.ReadValue<int>(intConverter);
                {
                    for (int t = 0; t < T; t++)
                    {
                        var N = problem.ReadLine();
                        var digits = N.Length;

                        var A = new StringBuilder();
                        var B = new StringBuilder();

                        for (int i = 0; i < digits; i++)
                        {
                            if (N[i] == '4')
                            {
                                A.Append('2');
                                B.Append('2');
                            }
                            else
                            {
                                A.Append(N[i]);
                                B.Append('0');
                            }
                        }

                        problem.WriteCaseOutput(A.ToString(), B.ToString());
                    }
                }
            }

            //Console.WriteLine("Press a key to end the program...");
            //Console.ReadKey();
        }
    }
}
