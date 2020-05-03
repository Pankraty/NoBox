using System;

namespace Pankraty.NoBox.Converters
{
    internal class ShortValueConverter :
        IValueConverter<ShortValue, bool      >,
        IValueConverter<ShortValue, sbyte     >,
        IValueConverter<ShortValue, byte      >,
        IValueConverter<ShortValue, short     >,
        IValueConverter<ShortValue, ushort    >,
        IValueConverter<ShortValue, int       >,
        IValueConverter<ShortValue, uint      >,
        IValueConverter<ShortValue, long      >,
        IValueConverter<ShortValue, ulong     >,
        IValueConverter<ShortValue, float     >,
        IValueConverter<ShortValue, double    >,
        IValueConverter<ShortValue, char      >,
        IValueConverter<ShortValue, DateTime  >,
        IValueConverter<ShortValue, TimeSpan  >,
        IValueConverter<ShortValue, ShortValue>,
        IValueConverter<bool      , ShortValue>,
        IValueConverter<sbyte     , ShortValue>,
        IValueConverter<byte      , ShortValue>,
        IValueConverter<short     , ShortValue>,
        IValueConverter<ushort    , ShortValue>,
        IValueConverter<int       , ShortValue>,
        IValueConverter<uint      , ShortValue>,
        IValueConverter<long      , ShortValue>,
        IValueConverter<ulong     , ShortValue>,
        IValueConverter<float     , ShortValue>,
        IValueConverter<double    , ShortValue>,
        IValueConverter<char      , ShortValue>,
        IValueConverter<DateTime  , ShortValue>,
        IValueConverter<TimeSpan  , ShortValue>
    {
        private static readonly Lazy<ShortValueConverter> _instance = new Lazy<ShortValueConverter>(
            () => new ShortValueConverter());

        public static ShortValueConverter Instance => _instance.Value;

        #region IValueConverter Implementations

        bool IValueConverter<ShortValue, bool>.GetValue(ShortValue value) => value;

        sbyte IValueConverter<ShortValue, sbyte>.GetValue(ShortValue value) => value;

        byte IValueConverter<ShortValue, byte>.GetValue(ShortValue value) => value;

        short IValueConverter<ShortValue, short>.GetValue(ShortValue value) => value;

        ushort IValueConverter<ShortValue, ushort>.GetValue(ShortValue value) => value;

        int IValueConverter<ShortValue, int>.GetValue(ShortValue value) => value;

        uint IValueConverter<ShortValue, uint>.GetValue(ShortValue value) => value;

        long IValueConverter<ShortValue, long>.GetValue(ShortValue value) => value;

        ulong IValueConverter<ShortValue, ulong>.GetValue(ShortValue value) => value;

        float IValueConverter<ShortValue, float>.GetValue(ShortValue value) => value;

        double IValueConverter<ShortValue, double>.GetValue(ShortValue value) => value;

        char IValueConverter<ShortValue, char>.GetValue(ShortValue value) => value;

        DateTime IValueConverter<ShortValue, DateTime>.GetValue(ShortValue value) => value;

        TimeSpan IValueConverter<ShortValue, TimeSpan>.GetValue(ShortValue value) => value;

        ShortValue IValueConverter<ShortValue, ShortValue>.GetValue(ShortValue value) => value;

        ShortValue IValueConverter<bool, ShortValue>.GetValue(bool value) => value;

        ShortValue IValueConverter<sbyte, ShortValue>.GetValue(sbyte value) => value;

        ShortValue IValueConverter<byte, ShortValue>.GetValue(byte value) => value;

        ShortValue IValueConverter<short, ShortValue>.GetValue(short value) => value;

        ShortValue IValueConverter<ushort, ShortValue>.GetValue(ushort value) => value;

        ShortValue IValueConverter<int, ShortValue>.GetValue(int value) => value;

        ShortValue IValueConverter<uint, ShortValue>.GetValue(uint value) => value;

        ShortValue IValueConverter<long, ShortValue>.GetValue(long value) => value;

        ShortValue IValueConverter<ulong, ShortValue>.GetValue(ulong value) => value;

        ShortValue IValueConverter<float, ShortValue>.GetValue(float value) => value;

        ShortValue IValueConverter<double, ShortValue>.GetValue(double value) => value;

        ShortValue IValueConverter<char, ShortValue>.GetValue(char value) => value;

        ShortValue IValueConverter<DateTime, ShortValue>.GetValue(DateTime value) => value;

        ShortValue IValueConverter<TimeSpan, ShortValue>.GetValue(TimeSpan value) => value;

        #endregion IValueConverter Implementations
    }
}