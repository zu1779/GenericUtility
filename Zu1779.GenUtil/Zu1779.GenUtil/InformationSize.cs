using System;
using System.Collections.Generic;
using Zu1779.GenUtil.Extension.ChainExtension;
using Zu1779.GenUtil.Extension.ComparableExtension;
namespace Zu1779.GenUtil;

public class GenericSize
{
    private static readonly Dictionary<int, Multiple> _multiples = new Dictionary<int, Multiple>
    {
        [-8] = new Multiple(-8, "yocto", 'y'),
        [-7] = new Multiple(-7, "zepto", 'z'),
        [-6] = new Multiple(-6, "atto", 'a'),
        [-5] = new Multiple(-5, "femto", 'f'),
        [-4] = new Multiple(-4, "pico", 'p'),
        [-3] = new Multiple(-3, "nano", 'n'),
        [-2] = new Multiple(-2, "micro", 'µ'),
        [-1] = new Multiple(-1, "milli", 'm'),
        [0] = new Multiple(0, "", '\0'),
        [1] = new Multiple(1, "chilo", 'k'),
        [2] = new Multiple(2, "mega", 'M'),
        [3] = new Multiple(3, "giga", 'G'),
        [4] = new Multiple(4, "tera", 'T'),
        [5] = new Multiple(5, "peta", 'P'),
        [6] = new Multiple(6, "exa", 'E'),
        [7] = new Multiple(7, "zetta", 'Z'),
        [8] = new Multiple(8, "yotta", 'Y'),
    };

    public GenericSize(double value, Multiple? multiple = null)
    {
        BaseValue = value;
        Multiple = multiple;
    }

    public double BaseValue { get; set; }
    public double Value => Multiple == null ? BaseValue : BaseValue / (Math.Pow(Multiple.FactorBase, Multiple.Factor));
    public Multiple? Multiple { get; set; }

    public virtual GenericSize ToMultiple(int? factor, int factorBase = 1024)
    {
        int finalFactor = factor.HasValue ? factor.Value : (int)Math.Floor(Math.Log(BaseValue, factorBase));
        Multiple = _multiples[finalFactor.Cap(-8, 8)];
        Multiple.FactorBase = factorBase;
        return this;
    }

    public override string ToString() => Multiple == null ? Value.ToString() : $"{Value:N2} {Multiple.Symbol}";
}

public class ByteSize : GenericSize
{
    public ByteSize(double value) : base(value) { }
    public override ByteSize ToMultiple(int? factor, int factorBase = 1024) => (ByteSize)base.ToMultiple(factor, factorBase);

    public override string ToString() => base.ToString() + "B";
}

public static class InformationSizeExtension
{
    public static ByteSize kB(this double value) => new ByteSize(value).ToMultiple(1);
    public static ByteSize AB(this double value) => new ByteSize(value).ToMultiple(null);
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
    public Multiple(int factor, string prefix, char symbol)
    {
        Factor = factor;
        Prefix = prefix;
        Symbol = symbol;
    }

    public int Factor { get; set; }
    public string Prefix { get; set; }
    public char Symbol { get; set; }

    public int FactorBase { get; set; }
}
