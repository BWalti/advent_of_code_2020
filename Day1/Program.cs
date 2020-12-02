using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Day1
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var inputContent = await File.ReadAllTextAsync("Input.txt");
            
            var parts = inputContent.Split(Environment.NewLine);
            var integers = parts.Select(int.Parse).OrderBy(i => i).ToList();

            Gold1(integers);
            Gold2(integers);
        }

        private static void Gold2(IReadOnlyList<int> integers)
        {
            for (var a = 0; a < integers.Count - 3; a++)
            for (var b = a + 1; b < integers.Count - 2; b++)
            for (var c = b + 1; c < integers.Count - 1; c++)
            {
                int valueA = integers[a], valueB = integers[b], valueC = integers[c];

                if (valueA + valueB + valueC == 2020)
                {
                    Console.WriteLine(
                        $"A: {a}, B: {b}, valueA: {valueA}, valueB: {valueB}, valueC: {valueC} -> {valueA * valueB * valueC}");
                    return;
                }
            }
        }

        private static void Gold1(IReadOnlyList<int> integers)
        {
            for (var a = 0; a < integers.Count - 2; a++)
            for (var b = a + 1; b < integers.Count - 1; b++)
            {
                int valueA = integers[a], valueB = integers[b];

                if (valueA + valueB == 2020)
                {
                    Console.WriteLine($"A: {a}, B: {b}, valueA: {valueA}, valueB: {valueB} -> {valueA * valueB}");
                    return;
                }
            }
        }
    }
}