using Pankraty.NoBox.Converters;
using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Pankraty.NoBox
{
    [StructLayout(LayoutKind.Explicit)]
    public readonly struct SimpleValue : IEquatable<SimpleValue>
    {
        private const int DataOffset = 4;

        public SimpleValueType ValueType => _valueType;

        [FieldOffset(0)] private readonly SimpleValueType _valueType;

        #region Data Fields

        [FieldOffset(DataOffset)] private readonly bool           _boolValue;
        [FieldOffset(DataOffset)] private readonly sbyte          _sByteValue;
        [FieldOffset(DataOffset)] private readonly byte           _byteValue;
        [FieldOffset(DataOffset)] private readonly short          _shortValue;
        [FieldOffset(DataOffset)] private readonly ushort         _uShortValue;
        [FieldOffset(DataOffset)] private readonly int            _intValue;
        [FieldOffset(DataOffset)] private readonly uint           _uIntValue;
        [FieldOffset(DataOffset)] private readonly long           _longValue;
        [FieldOffset(DataOffset)] private readonly ulong          _uLongValue;
        [FieldOffset(DataOffset)] private readonly float          _floatValue;
        [FieldOffset(DataOffset)] private readonly double         _doubleValue; 
        [FieldOffset(DataOffset)] private readonly char           _charValue;
        [FieldOffset(DataOffset)] private readonly DateTime       _dateTimeValue;
        [FieldOffset(DataOffset)] private readonly DateTimeOffset _dateTimeOffsetValue;
        [FieldOffset(DataOffset)] private readonly TimeSpan       _timeSpanValue;
        [FieldOffset(DataOffset)] private readonly Guid           _guidValue;
        [FieldOffset(DataOffset)] private readonly decimal        _decimalValue;

        #endregion Data Fields

        #region Static Members

        /// <summary>
        /// Create an instance of <see cref="SimpleValue"/> from a generic argument/
        /// </summary>
        /// <typeparam name="Tin">A primitive type</typeparam>
        /// <param name="value">A value to convert to <see cref="SimpleValue"/></param>
        /// <returns>An instance of <see cref="SimpleValue"/> holding the specified value.</returns>
        public static SimpleValue Create<Tin>(Tin value)
        {
            var converter = SimpleValueConverter.Instance as IValueConverter<Tin, SimpleValue>
                            ?? throw new InvalidCastException();

            return converter.GetValue(value);
        }

        #endregion Static Members

        #region Constructors

        public SimpleValue(bool           value) : this() { _boolValue           = value; _valueType = SimpleValueType.Bool;           }
        public SimpleValue(sbyte          value) : this() { _sByteValue          = value; _valueType = SimpleValueType.SByte;          }
        public SimpleValue(byte           value) : this() { _byteValue           = value; _valueType = SimpleValueType.Byte;           }
        public SimpleValue(short          value) : this() { _shortValue          = value; _valueType = SimpleValueType.Short;          }
        public SimpleValue(ushort         value) : this() { _uShortValue         = value; _valueType = SimpleValueType.UShort;         }
        public SimpleValue(int            value) : this() { _intValue            = value; _valueType = SimpleValueType.Int;            }
        public SimpleValue(uint           value) : this() { _uIntValue           = value; _valueType = SimpleValueType.UInt;           }
        public SimpleValue(long           value) : this() { _longValue           = value; _valueType = SimpleValueType.Long;           }
        public SimpleValue(ulong          value) : this() { _uLongValue          = value; _valueType = SimpleValueType.ULong;          }
        public SimpleValue(float          value) : this() { _floatValue          = value; _valueType = SimpleValueType.Float;          }
        public SimpleValue(double         value) : this() { _doubleValue         = value; _valueType = SimpleValueType.Double;         }
        public SimpleValue(char           value) : this() { _charValue           = value; _valueType = SimpleValueType.Char;           }
        public SimpleValue(DateTime       value) : this() { _dateTimeValue       = value; _valueType = SimpleValueType.DateTime;       }
        public SimpleValue(DateTimeOffset value) : this() { _dateTimeOffsetValue = value; _valueType = SimpleValueType.DateTimeOffset; }
        public SimpleValue(TimeSpan       value) : this() { _timeSpanValue       = value; _valueType = SimpleValueType.TimeSpan;       }
        public SimpleValue(Guid           value) : this() { _guidValue           = value; _valueType = SimpleValueType.Guid;           }
        public SimpleValue(decimal        value) : this() { _decimalValue        = value; _valueType = SimpleValueType.Decimal;        }

        #endregion Constructors

        #region Implicit Cast
        
        public static implicit operator bool          (SimpleValue value)
        {
            if (value.ValueType == SimpleValueType.Bool)
                return value._boolValue;

            throw new InvalidCastException();
        }

        public static implicit operator sbyte         (SimpleValue value)
        {
            return value.ValueType switch
            {
                SimpleValueType.SByte    => (sbyte) value._sByteValue,
                SimpleValueType.Byte     => (sbyte) value._byteValue,
                SimpleValueType.Short    => (sbyte) value._shortValue,
                SimpleValueType.UShort   => (sbyte) value._uShortValue,
                SimpleValueType.Int      => (sbyte) value._intValue,
                SimpleValueType.UInt     => (sbyte) value._uIntValue,
                SimpleValueType.Long     => (sbyte) value._longValue,
                SimpleValueType.ULong    => (sbyte) value._uLongValue,
                SimpleValueType.Float    => (sbyte) value._floatValue,
                SimpleValueType.Double   => (sbyte) value._doubleValue,
                SimpleValueType.Char     => (sbyte) value._charValue,
                SimpleValueType.Decimal  => (sbyte) value._decimalValue,
                _                        => throw new InvalidCastException()
            };
        }

        public static implicit operator byte          (SimpleValue value) 
        {
            return value.ValueType switch
            {
                SimpleValueType.SByte    => (byte) value._sByteValue,
                SimpleValueType.Byte     => (byte) value._byteValue,
                SimpleValueType.Short    => (byte) value._shortValue,
                SimpleValueType.UShort   => (byte) value._uShortValue,
                SimpleValueType.Int      => (byte) value._intValue,
                SimpleValueType.UInt     => (byte) value._uIntValue,
                SimpleValueType.Long     => (byte) value._longValue,
                SimpleValueType.ULong    => (byte) value._uLongValue,
                SimpleValueType.Float    => (byte) value._floatValue,
                SimpleValueType.Double   => (byte) value._doubleValue,
                SimpleValueType.Char     => (byte) value._charValue,
                SimpleValueType.Decimal  => (byte) value._decimalValue,
                _                        => throw new InvalidCastException()
            };
        }

        public static implicit operator short         (SimpleValue value) 
        {
            return value.ValueType switch
            {
                SimpleValueType.SByte    => (short) value._sByteValue,
                SimpleValueType.Byte     => (short) value._byteValue,
                SimpleValueType.Short    => (short) value._shortValue,
                SimpleValueType.UShort   => (short) value._uShortValue,
                SimpleValueType.Int      => (short) value._intValue,
                SimpleValueType.UInt     => (short) value._uIntValue,
                SimpleValueType.Long     => (short) value._longValue,
                SimpleValueType.ULong    => (short) value._uLongValue,
                SimpleValueType.Float    => (short) value._floatValue,
                SimpleValueType.Double   => (short) value._doubleValue,
                SimpleValueType.Char     => (short) value._charValue,
                SimpleValueType.Decimal  => (short) value._decimalValue,
                _                        => throw new InvalidCastException()
            };
        }

        public static implicit operator ushort        (SimpleValue value)
        {
            return value.ValueType switch
            {
                SimpleValueType.SByte    => (ushort) value._sByteValue,
                SimpleValueType.Byte     => (ushort) value._byteValue,
                SimpleValueType.Short    => (ushort) value._shortValue,
                SimpleValueType.UShort   => (ushort) value._uShortValue,
                SimpleValueType.Int      => (ushort) value._intValue,
                SimpleValueType.UInt     => (ushort) value._uIntValue,
                SimpleValueType.Long     => (ushort) value._longValue,
                SimpleValueType.ULong    => (ushort) value._uLongValue,
                SimpleValueType.Float    => (ushort) value._floatValue,
                SimpleValueType.Double   => (ushort) value._doubleValue,
                SimpleValueType.Char     => (ushort) value._charValue,
                SimpleValueType.Decimal  => (ushort) value._decimalValue,
                _                        => throw new InvalidCastException()
            };

        }

        public static implicit operator int           (SimpleValue value) 
        {
            return value.ValueType switch
            {
                SimpleValueType.SByte    => (int) value._sByteValue,
                SimpleValueType.Byte     => (int) value._byteValue,
                SimpleValueType.Short    => (int) value._shortValue,
                SimpleValueType.UShort   => (int) value._uShortValue,
                SimpleValueType.Int      => (int) value._intValue,
                SimpleValueType.UInt     => (int) value._uIntValue,
                SimpleValueType.Long     => (int) value._longValue,
                SimpleValueType.ULong    => (int) value._uLongValue,
                SimpleValueType.Float    => (int) value._floatValue,
                SimpleValueType.Double   => (int) value._doubleValue,
                SimpleValueType.Char     => (int) value._charValue,
                SimpleValueType.Decimal  => (int) value._decimalValue,
                _                        => throw new InvalidCastException()
            };

        }

        public static implicit operator uint          (SimpleValue value) 
        {
            return value.ValueType switch
            {
                SimpleValueType.SByte    => (uint) value._sByteValue,
                SimpleValueType.Byte     => (uint) value._byteValue,
                SimpleValueType.Short    => (uint) value._shortValue,
                SimpleValueType.UShort   => (uint) value._uShortValue,
                SimpleValueType.Int      => (uint) value._intValue,
                SimpleValueType.UInt     => (uint) value._uIntValue,
                SimpleValueType.Long     => (uint) value._longValue,
                SimpleValueType.ULong    => (uint) value._uLongValue,
                SimpleValueType.Float    => (uint) value._floatValue,
                SimpleValueType.Double   => (uint) value._doubleValue,
                SimpleValueType.Char     => (uint) value._charValue,
                SimpleValueType.Decimal  => (uint) value._decimalValue,
                _                        => throw new InvalidCastException()
            };
        }

        public static implicit operator long          (SimpleValue value) 
        {
            return value.ValueType switch
            {
                SimpleValueType.SByte    => (long) value._sByteValue,
                SimpleValueType.Byte     => (long) value._byteValue,
                SimpleValueType.Short    => (long) value._shortValue,
                SimpleValueType.UShort   => (long) value._uShortValue,
                SimpleValueType.Int      => (long) value._intValue,
                SimpleValueType.UInt     => (long) value._uIntValue,
                SimpleValueType.Long     => (long) value._longValue,
                SimpleValueType.ULong    => (long) value._uLongValue,
                SimpleValueType.Float    => (long) value._floatValue,
                SimpleValueType.Double   => (long) value._doubleValue,
                SimpleValueType.Char     => (long) value._charValue,
                SimpleValueType.Decimal  => (long) value._decimalValue,
                _                        => throw new InvalidCastException()
            };
        }

        public static implicit operator ulong         (SimpleValue value) 
        {
            return value.ValueType switch
            {
                SimpleValueType.SByte    => (ulong) value._sByteValue,
                SimpleValueType.Byte     => (ulong) value._byteValue,
                SimpleValueType.Short    => (ulong) value._shortValue,
                SimpleValueType.UShort   => (ulong) value._uShortValue,
                SimpleValueType.Int      => (ulong) value._intValue,
                SimpleValueType.UInt     => (ulong) value._uIntValue,
                SimpleValueType.Long     => (ulong) value._longValue,
                SimpleValueType.ULong    => (ulong) value._uLongValue,
                SimpleValueType.Float    => (ulong) value._floatValue,
                SimpleValueType.Double   => (ulong) value._doubleValue,
                SimpleValueType.Char     => (ulong) value._charValue,
                SimpleValueType.Decimal  => (ulong) value._decimalValue,
                _                        => throw new InvalidCastException()
            };

        }

        public static implicit operator float         (SimpleValue value) 
        {
            return value.ValueType switch
            {
                SimpleValueType.SByte    => (float) value._sByteValue,
                SimpleValueType.Byte     => (float) value._byteValue,
                SimpleValueType.Short    => (float) value._shortValue,
                SimpleValueType.UShort   => (float) value._uShortValue,
                SimpleValueType.Int      => (float) value._intValue,
                SimpleValueType.UInt     => (float) value._uIntValue,
                SimpleValueType.Long     => (float) value._longValue,
                SimpleValueType.ULong    => (float) value._uLongValue,
                SimpleValueType.Float    => (float) value._floatValue,
                SimpleValueType.Double   => (float) value._doubleValue,
                SimpleValueType.Char     => (float) value._charValue,
                SimpleValueType.Decimal  => (float) value._decimalValue,
                _                        => throw new InvalidCastException()
            };
        }

        public static implicit operator double        (SimpleValue value)
        {
            return value.ValueType switch
            {
                SimpleValueType.SByte    => (double) value._sByteValue,
                SimpleValueType.Byte     => (double) value._byteValue,
                SimpleValueType.Short    => (double) value._shortValue,
                SimpleValueType.UShort   => (double) value._uShortValue,
                SimpleValueType.Int      => (double) value._intValue,
                SimpleValueType.UInt     => (double) value._uIntValue,
                SimpleValueType.Long     => (double) value._longValue,
                SimpleValueType.ULong    => (double) value._uLongValue,
                SimpleValueType.Float    => (double) value._floatValue,
                SimpleValueType.Double   => (double) value._doubleValue,
                SimpleValueType.Char     => (double) value._charValue,
                SimpleValueType.Decimal  => (double) value._decimalValue,
                _                        => throw new InvalidCastException()
            };
        }

        public static implicit operator char          (SimpleValue value) 
        {
            return value.ValueType switch
            {
                SimpleValueType.SByte    => (char) value._sByteValue,
                SimpleValueType.Byte     => (char) value._byteValue,
                SimpleValueType.Short    => (char) value._shortValue,
                SimpleValueType.UShort   => (char) value._uShortValue,
                SimpleValueType.Int      => (char) value._intValue,
                SimpleValueType.UInt     => (char) value._uIntValue,
                SimpleValueType.Long     => (char) value._longValue,
                SimpleValueType.ULong    => (char) value._uLongValue,
                SimpleValueType.Float    => (char) value._floatValue,
                SimpleValueType.Double   => (char) value._doubleValue,
                SimpleValueType.Char     => (char) value._charValue,
                SimpleValueType.Decimal  => (char) value._decimalValue,
                _                        => throw new InvalidCastException()
            };
        }

        public static implicit operator DateTime      (SimpleValue value)
        {
            if (value.ValueType == SimpleValueType.DateTime)
                return value._dateTimeValue;

            throw new InvalidCastException();
        }

        public static implicit operator DateTimeOffset(SimpleValue value)
        {
            return value.ValueType switch
            {
                SimpleValueType.DateTime => value._dateTimeValue,
                SimpleValueType.DateTimeOffset => value._dateTimeOffsetValue,
                _ => throw new InvalidCastException()
            };
        }

        public static implicit operator TimeSpan      (SimpleValue value)
        {
            if (value.ValueType == SimpleValueType.TimeSpan)
                return value._timeSpanValue;

            throw new InvalidCastException();
        }

        public static implicit operator Guid          (SimpleValue value)
        {
            if (value.ValueType == SimpleValueType.Guid)
                return value._guidValue;

            throw new InvalidCastException();
        }

        public static implicit operator decimal       (SimpleValue value)
        {
            return value.ValueType switch
            {
                SimpleValueType.SByte    => (decimal) value._sByteValue,
                SimpleValueType.Byte     => (decimal) value._byteValue,
                SimpleValueType.Short    => (decimal) value._shortValue,
                SimpleValueType.UShort   => (decimal) value._uShortValue,
                SimpleValueType.Int      => (decimal) value._intValue,
                SimpleValueType.UInt     => (decimal) value._uIntValue,
                SimpleValueType.Long     => (decimal) value._longValue,
                SimpleValueType.ULong    => (decimal) value._uLongValue,
                SimpleValueType.Float    => (decimal) value._floatValue,
                SimpleValueType.Double   => (decimal) value._doubleValue,
                SimpleValueType.Char     => (decimal) value._charValue,
                SimpleValueType.Decimal  => (decimal) value._decimalValue,
                _                        => throw new InvalidCastException()
            };
        }


        public static implicit operator SimpleValue (bool           value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (sbyte          value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (byte           value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (short          value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (ushort         value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (int            value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (uint           value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (long           value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (ulong          value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (float          value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (double         value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (char           value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (DateTime       value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (DateTimeOffset value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (TimeSpan       value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (Guid           value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (decimal        value) { return new SimpleValue(value); }

        #endregion Implicit Cast

        #region Explicit Cast
        
        public Tout CastTo<Tout>()
        {
            var converter = SimpleValueConverter.Instance as IValueConverter<SimpleValue, Tout>
                            ?? throw new InvalidCastException();

            return converter.GetValue(this);
        }

        #endregion Explicit Cast

        #region ToString

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation using the formatting conventions of the current culture.
        /// </summary>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The date and time is outside the range of dates supported by the calendar used by <paramref name="provider">provider</paramref>.</exception>
        public override string ToString()
        {
            return ToString("", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation using the specified format and the formatting conventions of the current culture.
        /// </summary>
        /// <param name="format">A standard of custom format string (valid formats depend on the underlying type).</param>
        /// <exception cref="T:System.FormatException"><paramref name="format">format</paramref> is invalid.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The date and time is outside the range of dates supported by the calendar used by <paramref name="provider">provider</paramref>.</exception>
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation using the specified culture-specific format information.
        /// </summary>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <exception cref="T:System.FormatException"><paramref name="format">format</paramref> is invalid.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The date and time is outside the range of dates supported by the calendar used by <paramref name="provider">provider</paramref>.</exception>
        public string ToString(IFormatProvider formatProvider)
        {
            return ToString("", formatProvider);
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="format">A standard of custom format string (valid formats depend on the underlying type).</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <exception cref="T:System.FormatException"><paramref name="format">format</paramref> is invalid.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The date and time is outside the range of dates supported by the calendar used by <paramref name="provider">provider</paramref>.</exception>
        public string ToString(string format, IFormatProvider provider)
        {
            return ValueType switch
            {
                SimpleValueType.Bool           => _boolValue.ToString(provider),
                SimpleValueType.SByte          => _sByteValue.ToString(format, provider),
                SimpleValueType.Byte           => _byteValue.ToString(format, provider),
                SimpleValueType.Short          => _shortValue.ToString(format, provider),
                SimpleValueType.UShort         => _uShortValue.ToString(format, provider),
                SimpleValueType.Int            => _intValue.ToString(format, provider),
                SimpleValueType.UInt           => _uIntValue.ToString(format, provider),
                SimpleValueType.Long           => _longValue.ToString(format, provider),
                SimpleValueType.ULong          => _uLongValue.ToString(format, provider),
                SimpleValueType.Float          => _floatValue.ToString(format, provider),
                SimpleValueType.Double         => _doubleValue.ToString(format, provider),
                SimpleValueType.Char           => _charValue.ToString(provider),
                SimpleValueType.DateTime       => _dateTimeValue.ToString(format, provider),
                SimpleValueType.DateTimeOffset => _dateTimeOffsetValue.ToString(format, provider),
                SimpleValueType.TimeSpan       => _timeSpanValue.ToString(format, provider),
                SimpleValueType.Guid           => _guidValue.ToString(format, provider),
                SimpleValueType.Decimal        => _decimalValue.ToString(format, provider),
                _                              => throw new ArgumentOutOfRangeException(nameof(ValueType), $"Unrecognized value type {ValueType}")
            };
        }

        #endregion ToString

        /// <summary>
        /// Check if the current instance belongs to one of the numeric types.
        /// </summary>
        public bool IsNumber()
        {
            return ValueType switch
            {
                SimpleValueType.SByte   => true,
                SimpleValueType.Byte    => true,
                SimpleValueType.Short   => true,
                SimpleValueType.UShort  => true,
                SimpleValueType.Int     => true,
                SimpleValueType.UInt    => true,
                SimpleValueType.Long    => true,
                SimpleValueType.ULong   => true,
                SimpleValueType.Float   => true,
                SimpleValueType.Double  => true,
                SimpleValueType.Decimal => true,
                _                       => false
            };
        }

        #region IEquatable Implementation

        public bool Equals(SimpleValue other)
        {
            return _valueType == other._valueType &&
                   _valueType switch 
                   {
                       SimpleValueType.Bool           => _boolValue           == other._boolValue          ,
                       SimpleValueType.SByte          => _sByteValue          == other._sByteValue         ,
                       SimpleValueType.Byte           => _byteValue           == other._byteValue          ,
                       SimpleValueType.Short          => _shortValue          == other._shortValue         ,
                       SimpleValueType.UShort         => _uShortValue         == other._uShortValue        ,
                       SimpleValueType.Int            => _intValue            == other._intValue           ,
                       SimpleValueType.UInt           => _uIntValue           == other._uIntValue          ,
                       SimpleValueType.Long           => _longValue           == other._longValue          ,
                       SimpleValueType.ULong          => _uLongValue          == other._uLongValue         ,
                       SimpleValueType.Float          => _floatValue          == other._floatValue         ,
                       SimpleValueType.Double         => _doubleValue         == other._doubleValue        ,
                       SimpleValueType.Char           => _charValue           == other._charValue          ,
                       SimpleValueType.DateTime       => _dateTimeValue       == other._dateTimeValue      ,
                       SimpleValueType.DateTimeOffset => _dateTimeOffsetValue == other._dateTimeOffsetValue,
                       SimpleValueType.TimeSpan       => _timeSpanValue       == other._timeSpanValue      ,
                       SimpleValueType.Guid           => _guidValue           == other._guidValue          ,
                       SimpleValueType.Decimal        => _decimalValue        == other._decimalValue       ,
                       _                              => throw new ArgumentOutOfRangeException()
                   };
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int)_valueType;
                hashCode = _valueType switch 
                {
                     SimpleValueType.Bool           => (hashCode * 397) ^ _boolValue.GetHashCode(),
                     SimpleValueType.SByte          => (hashCode * 397) ^ _sByteValue.GetHashCode(),
                     SimpleValueType.Byte           => (hashCode * 397) ^ _byteValue.GetHashCode(),
                     SimpleValueType.Short          => (hashCode * 397) ^ _shortValue.GetHashCode(),
                     SimpleValueType.UShort         => (hashCode * 397) ^ _uShortValue.GetHashCode(),
                     SimpleValueType.Int            => (hashCode * 397) ^ _intValue,
                     SimpleValueType.UInt           => (hashCode * 397) ^ (int)_uIntValue,
                     SimpleValueType.Long           => (hashCode * 397) ^ _longValue.GetHashCode(),
                     SimpleValueType.ULong          => (hashCode * 397) ^ _uLongValue.GetHashCode(),
                     SimpleValueType.Float          => (hashCode * 397) ^ _floatValue.GetHashCode(),
                     SimpleValueType.Double         => (hashCode * 397) ^ _doubleValue.GetHashCode(),
                     SimpleValueType.Char           => (hashCode * 397) ^ _charValue.GetHashCode(),
                     SimpleValueType.DateTime       => (hashCode * 397) ^ _dateTimeValue.GetHashCode(),
                     SimpleValueType.DateTimeOffset => (hashCode * 397) ^ _dateTimeOffsetValue.GetHashCode(),
                     SimpleValueType.TimeSpan       => (hashCode * 397) ^ _timeSpanValue.GetHashCode(),
                     SimpleValueType.Guid           => (hashCode * 397) ^ _guidValue.GetHashCode(),
                     SimpleValueType.Decimal        => (hashCode * 397) ^ _decimalValue.GetHashCode(),
                };

                return hashCode;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is SimpleValue other && Equals(other);
        }


        public static bool operator ==(SimpleValue left, SimpleValue right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SimpleValue left, SimpleValue right)
        {
            return !left.Equals(right);
        }

        #endregion IEquatable Implementation
    }
}
