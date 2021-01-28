namespace Zu1779.GenUtil
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GenericSize
    {
        private static readonly Dictionary<int, Multiple> _multiples = new Dictionary<int, Multiple>
        {
            [-8] = new (-8, "yocto", 'y'),
            [-7] = new (-7, "zepto", 'z'),
            [-6] = new (-6, "atto", 'a'),
            [-5] = new (-5, "femto", 'f'),
            [-4] = new (-4, "pico", 'p'),
            [-3] = new (-3, "nano", 'n'),
            [-2] = new (-2, "micro", 'µ'),
            [-1] = new (-1, "milli", 'm'),
            [0] = new (0, "", '\0'),
            [1] = new (1, "chilo", 'k'),
            [2] = new (2, "mega", 'M'),
            [3] = new (3, "giga", 'G'),
            [4] = new (4, "tera", 'T'),
            [5] = new (5, "peta", 'P'),
            [6] = new (6, "exa", 'E'),
            [7] = new (7, "zetta", 'Z'),
            [8] = new (8, "yotta", 'Y'),
        };

        public double Value { get; set; }

        public Multiple ToDecimalMultiple() => ToMultiple(1_000);
        public Multiple ToBinaryMultiple() => ToMultiple(1_024);
        public Multiple ToMultiple(double factorValue)
        {
            int factor = (int)Math.Floor(Math.Log(Value, factorValue));
            factor = factor.Cap(-8, 8);
            var response = _multiples[factor];
            return response;
        }
    }

    public enum MeasureEnum
    {
        NotSpecify = 0,
        Bit = 1,
        Byte = 2,
        BinaryBit = 3,
        BinaryByte = 4,
    }

    public class Multiple
    {
        public Multiple() { }
        public Multiple((int factor, string prefix, char symbol) tuple) { }
        public Multiple(int factor, string prefix, char symbol)
        {
            Factor = factor;
            Prefix = prefix;
            Symbol = symbol;
        }

        public int Factor { get; set; }
        public string Prefix { get; set; }
        public char Symbol { get; set; }

    }
}
