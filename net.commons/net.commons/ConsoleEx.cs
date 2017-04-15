using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using net.commons.Extension;

namespace net.commons
{
    public static class ConsoleEx
    {
        private const char ANSI_ESCAPE = (char) 0x1B;

        private static int curX = 0, curY = 0;

        public static void WriteLine(string line, ConsoleColor? foreground = null, ConsoleColor? background = null)
        {
            Write(line, foreground, background);
            Console.WriteLine();
        }

        public static void Write(string line, ConsoleColor? foreground = null, ConsoleColor? background = null)
        {
            var originalFG = Console.ForegroundColor;
            var originalBG = Console.BackgroundColor;
            if (foreground.HasValue)
            {
                Console.ForegroundColor = foreground.Value;
            }
            if (background.HasValue)
            {
                Console.BackgroundColor = background.Value;
            }

            WriteWithAnsiEscapeCode(line, originalFG, originalBG);

            Console.ForegroundColor = originalFG;
            Console.BackgroundColor = originalBG;
        }

        private static void WriteWithAnsiEscapeCode(string line, ConsoleColor foreground, ConsoleColor background)
        {
            var match = Regex.Match(line, "\x1B\\x5B(((?<value>[0-9]+);)*(?<value>[0-9]+))?(?<type>.)");
            if (match.Success)
            {
                Console.Write(line.Substring(0, match.Index));

                while (match != null && match.Success)
                {
                    var valueGroup = match.Groups["value"];
                    var typeGroup = match.Groups["type"];

                    switch (typeGroup.Value)
                    {
                        case "H":
                        case "f":
                            JumpCursor(valueGroup.Captures);
                            break;
                        case "A":
                            JumpCursor(valueGroup.Captures, 1);
                            break;
                        case "B":
                            JumpCursor(valueGroup.Captures, 3);
                            break;
                        case "C":
                            JumpCursor(valueGroup.Captures, 2);
                            break;
                        case "D":
                            JumpCursor(valueGroup.Captures, 0);
                            break;
                        case "s":
                            curX = Console.CursorLeft;
                            curY = Console.CursorTop;
                            break;
                        case "u":
                            Console.CursorLeft = curX;
                            Console.CursorTop = curY;
                            break;
                        case "J":
                            Console.Clear();
                            Console.SetCursorPosition(0, 0);
                            break;
                        case "K":
                            ClearLine(valueGroup.Captures);
                            break;
                        case "m":
                            UpdateGraphicMode(valueGroup.Captures, foreground, background);
                            break;
                    }

                    var startIndex = match.Index + match.Length;
                    match = match.NextMatch();
                    var endIndex = match.Success ? match.Index : line.Length;

                    Console.Write(line.Substring(startIndex, endIndex - startIndex));
                }
            }
        }

        private static void ClearLine(CaptureCollection captures)
        {
            if (captures.Count <= 0 || string.IsNullOrEmpty(captures[0].Value) || captures[0].Value == "0")
            {
                var x = Console.CursorLeft;
                Console.Write(" ".Repeat(Console.BufferWidth - x));
                Console.CursorLeft = x;
            }
            else if (captures[0].Value == "1")
            {
                var x = Console.CursorLeft;
                Console.CursorLeft = 0;
                Console.Write(" ".Repeat(x));
            }
            else if (captures[0].Value == "2")
            {
                var x = Console.CursorLeft;
                Console.CursorLeft = 0;
                Console.Write(" ".Repeat(Console.BufferWidth));
                Console.CursorLeft = x;
            }
        }

        private static void JumpCursor(CaptureCollection captures)
        {
            int x = 0, y = 0;
            if (captures.Count > 0 && !string.IsNullOrEmpty(captures[0].Value))
            {
                int.TryParse(captures[0].Value, out x);
            }
            if (captures.Count > 1 && !string.IsNullOrEmpty(captures[1].Value))
            {
                int.TryParse(captures[1].Value, out y);
            }

            Console.SetCursorPosition(x, y);
        }

        private static void JumpCursor(CaptureCollection captures, int direction)
        {
            int change = 1;
            if (captures.Count > 0 && !string.IsNullOrEmpty(captures[0].Value))
            {
                int.TryParse(captures[0].Value, out change);
            }

            switch (direction)
            {
                case 0:
                    if (Console.CursorLeft - change >= 0)
                    {
                        Console.CursorLeft -= change;
                    }
                    break;
                case 1:
                    if (Console.CursorTop - change >= 0)
                    {
                        Console.CursorTop -= change;
                    }
                    break;
                case 2:
                    if (Console.CursorLeft + change < Console.BufferWidth)
                    {
                        Console.CursorLeft += change;
                    }
                    break;
                case 3:
                    if (Console.CursorTop + change < Console.BufferHeight)
                    {
                        Console.CursorTop += change;
                    }
                    break;
            }
        }

        private static void UpdateGraphicMode(CaptureCollection captures, ConsoleColor foreground, ConsoleColor background)
        {
            foreach (Capture capture in captures)
            {
                if (capture.Value == "0")
                {
                    Console.ForegroundColor = foreground;
                    Console.BackgroundColor = background;
                }
                else if (capture.Value == "1")
                {
                    Console.ForegroundColor = (ConsoleColor) ((int) Console.ForegroundColor ^ 0x08);
                }
                else if (capture.Value.StartsWith("3"))
                {
                    byte value;
                    if (!byte.TryParse(capture.Value.Substring(1), out value))
                        return;
                    Console.ForegroundColor = (ConsoleColor) (ConvertColor(value) | 0x08);
                }
                else if (capture.Value.StartsWith("4"))
                {
                    byte value;
                    if (!byte.TryParse(capture.Value.Substring(1), out value))
                        return;
                    Console.BackgroundColor = (ConsoleColor) ConvertColor(value);
                }
            }
        }

        private static byte ConvertColor(byte value)
        {
            byte result = 0x00;

            if ((value & 0x01) == 0x01)
            {
                //Change first byte
                result |= 0x04;
            }
            if ((value & 0x04) == 0x04)
            {
                //Chnage last byte
                result |= 0x01;
            }

            //Set middle byte
            result |= (byte) (value & 0x02);

            return result;
        }
    }
}