using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day2
{
    public static class Program
    {
        private static readonly Regex PolicyMatcher = new(@"^(?<min>\d+)-(?<max>\d+) (?<char>\w): (?<password>\w+)$",
            RegexOptions.Compiled);

        public static async Task Main(string[] args)
        {
            var inputContent = await File.ReadAllTextAsync("Input.txt");
            var lines = inputContent.Split(Environment.NewLine);

            Gold1(lines);
            Gold2(lines);
        }

        private static void Gold2(string[] lines)
        {
            var validPasswords = 0;
            var invalidPasswords = 0;

            foreach (var line in lines)
            {
                var matched = PolicyMatcher.Match(line);
                if (!matched.Success) throw new InvalidOperationException("Something went really wrong :)");

                var min = int.Parse(matched.Groups["min"].Value);
                var max = int.Parse(matched.Groups["max"].Value);
                var character = matched.Groups["char"].Value[0];
                var password = matched.Groups["password"].Value;

                var locationA = password[min - 1] == character;
                var locationB = password[max - 1] == character;

                switch (locationA, locationB)
                {
                    case (true, true):
                    case (false, false):
                        invalidPasswords++;
                        break;
                    
                    case (true, false):
                    case (false, true):
                        validPasswords++;
                        break;

                    default:
                        throw new InvalidOperationException("Something went seriously wrong :)");
                }
            }

            Console.WriteLine($"Valid Passwords: {validPasswords}, InvalidPasswords: {invalidPasswords}");
        }

        private static void Gold1(string[] lines)
        {
            var validPasswords = 0;
            var invalidPasswords = 0;

            foreach (var line in lines)
            {
                var matched = PolicyMatcher.Match(line);
                if (!matched.Success) throw new InvalidOperationException("Something went really wrong :)");

                var min = int.Parse(matched.Groups["min"].Value);
                var max = int.Parse(matched.Groups["max"].Value);
                var character = matched.Groups["char"].Value[0];
                var password = matched.Groups["password"].Value;

                var count = password.Count(c => c == character);
                if (min <= count && count <= max)
                    validPasswords++;
                else
                    invalidPasswords++;
            }

            Console.WriteLine($"Valid Passwords: {validPasswords}, InvalidPasswords: {invalidPasswords}");
        }
    }
}