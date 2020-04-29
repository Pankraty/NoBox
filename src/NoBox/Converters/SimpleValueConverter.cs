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
        IValueConverter<SimpleValue, SimpleValue   >
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

        #endregion IValueConverter Implementations
    }
}