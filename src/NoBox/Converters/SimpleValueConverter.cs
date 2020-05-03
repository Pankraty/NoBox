using System;

namespace Pankraty.NoBox.Converters
{
    internal class SimpleValueConverter:
        IValueConverter<SimpleValue, bool          >,
        IValueConverter<SimpleValue, sbyte         >,
        IValueConverter<SimpleValue, byte          >,
        IValueConverter<SimpleValue, short         >,
        IValueConverter<SimpleValue, ushort        >,
        IValueConverter<SimpleValue, int           >,
        IValueConverter<SimpleValue, uint          >,
        IValueConverter<SimpleValue, long          >,
        IValueConverter<SimpleValue, ulong         >,
        IValueConverter<SimpleValue, float         >,
        IValueConverter<SimpleValue, double        >,
        IValueConverter<SimpleValue, char          >,
        IValueConverter<SimpleValue, DateTime      >,
        IValueConverter<SimpleValue, DateTimeOffset>,
        IValueConverter<SimpleValue, TimeSpan      >,
        IValueConverter<SimpleValue, Guid          >,
        IValueConverter<SimpleValue, decimal       >,
        IValueConverter<SimpleValue, SimpleValue   >,
        IValueConverter<bool          , SimpleValue>,
        IValueConverter<sbyte         , SimpleValue>,
        IValueConverter<byte          , SimpleValue>,
        IValueConverter<short         , SimpleValue>,
        IValueConverter<ushort        , SimpleValue>,
        IValueConverter<int           , SimpleValue>,
        IValueConverter<uint          , SimpleValue>,
        IValueConverter<long          , SimpleValue>,
        IValueConverter<ulong         , SimpleValue>,
        IValueConverter<float         , SimpleValue>,
        IValueConverter<double        , SimpleValue>,
        IValueConverter<char          , SimpleValue>,
        IValueConverter<DateTime      , SimpleValue>,
        IValueConverter<DateTimeOffset, SimpleValue>,
        IValueConverter<TimeSpan      , SimpleValue>,
        IValueConverter<Guid          , SimpleValue>,
        IValueConverter<decimal       , SimpleValue>

    {
        private static readonly Lazy<SimpleValueConverter> _instance = new Lazy<SimpleValueConverter>(
            () => new SimpleValueConverter());

        public static SimpleValueConverter Instance => _instance.Value;

        #region IValueConverter Implementations

        bool IValueConverter<SimpleValue, bool>.GetValue(SimpleValue value) => value;

        sbyte IValueConverter<SimpleValue, sbyte>.GetValue(SimpleValue value) => value;

        byte IValueConverter<SimpleValue, byte>.GetValue(SimpleValue value) => value;

        short IValueConverter<SimpleValue, short>.GetValue(SimpleValue value) => value;

        ushort IValueConverter<SimpleValue, ushort>.GetValue(SimpleValue value) => value;

        int IValueConverter<SimpleValue, int>.GetValue(SimpleValue value) => value;

        uint IValueConverter<SimpleValue, uint>.GetValue(SimpleValue value) => value;

        long IValueConverter<SimpleValue, long>.GetValue(SimpleValue value) => value;

        ulong IValueConverter<SimpleValue, ulong>.GetValue(SimpleValue value) => value;

        float IValueConverter<SimpleValue, float>.GetValue(SimpleValue value) => value;

        double IValueConverter<SimpleValue, double>.GetValue(SimpleValue value) => value;

        char IValueConverter<SimpleValue, char>.GetValue(SimpleValue value) => value;

        DateTime IValueConverter<SimpleValue, DateTime>.GetValue(SimpleValue value) => value;

        DateTimeOffset IValueConverter<SimpleValue, DateTimeOffset>.GetValue(SimpleValue value) => value;

        TimeSpan IValueConverter<SimpleValue, TimeSpan>.GetValue(SimpleValue value) => value;

        Guid IValueConverter<SimpleValue, Guid>.GetValue(SimpleValue value) => value;

        decimal IValueConverter<SimpleValue, decimal>.GetValue(SimpleValue value) => value;

        SimpleValue IValueConverter<SimpleValue, SimpleValue>.GetValue(SimpleValue value) => value;

        SimpleValue IValueConverter<bool, SimpleValue>.GetValue(bool value) => value;

        SimpleValue IValueConverter<sbyte, SimpleValue>.GetValue(sbyte value) => value;

        SimpleValue IValueConverter<byte, SimpleValue>.GetValue(byte value) => value;

        SimpleValue IValueConverter<short, SimpleValue>.GetValue(short value) => value;

        SimpleValue IValueConverter<ushort, SimpleValue>.GetValue(ushort value) => value;

        SimpleValue IValueConverter<int, SimpleValue>.GetValue(int value) => value;

        SimpleValue IValueConverter<uint, SimpleValue>.GetValue(uint value) => value;

        SimpleValue IValueConverter<long, SimpleValue>.GetValue(long value) => value;

        SimpleValue IValueConverter<ulong, SimpleValue>.GetValue(ulong value) => value;

        SimpleValue IValueConverter<float, SimpleValue>.GetValue(float value) => value;

        SimpleValue IValueConverter<double, SimpleValue>.GetValue(double value) => value;

        SimpleValue IValueConverter<char, SimpleValue>.GetValue(char value) => value;

        SimpleValue IValueConverter<DateTime, SimpleValue>.GetValue(DateTime value) => value;

        SimpleValue IValueConverter<DateTimeOffset, SimpleValue>.GetValue(DateTimeOffset value) => value;

        SimpleValue IValueConverter<TimeSpan, SimpleValue>.GetValue(TimeSpan value) => value;

        SimpleValue IValueConverter<Guid, SimpleValue>.GetValue(Guid value) => value;

        SimpleValue IValueConverter<decimal, SimpleValue>.GetValue(decimal value) => value;
 
        #endregion IValueConverter Implementations
    }
}