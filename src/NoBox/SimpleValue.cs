using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Pankraty.NoBox
{
    [StructLayout(LayoutKind.Explicit)]
    public struct SimpleValue
    {
        private const int DataOffset = 4;

        public SimpleValueType ValueType => _valueType;

        [FieldOffset(0)] private readonly SimpleValueType _valueType;

        #region Data Fields

        [FieldOffset(DataOffset)] private readonly bool      _boolValue;
        [FieldOffset(DataOffset)] private readonly sbyte     _sByteValue;
        [FieldOffset(DataOffset)] private readonly byte      _byteValue;
        [FieldOffset(DataOffset)] private readonly short     _shortValue;
        [FieldOffset(DataOffset)] private readonly ushort    _uShortValue;
        [FieldOffset(DataOffset)] private readonly int       _intValue;
        [FieldOffset(DataOffset)] private readonly uint      _uIntValue;
        [FieldOffset(DataOffset)] private readonly long      _longValue;
        [FieldOffset(DataOffset)] private readonly ulong     _uLongValue;
        [FieldOffset(DataOffset)] private readonly float     _floatValue;
        [FieldOffset(DataOffset)] private readonly double    _doubleValue; 
        [FieldOffset(DataOffset)] private readonly char      _charValue;
        [FieldOffset(DataOffset)] private readonly DateTime  _dateTimeValue;
        [FieldOffset(DataOffset)] private readonly TimeSpan  _timeSpanValue;
        [FieldOffset(DataOffset)] private readonly decimal   _decimalValue;

        #endregion Data Fields

        #region Constructors

        public SimpleValue(bool     value) : this() { _boolValue     = value; _valueType = SimpleValueType.Bool;     }
        public SimpleValue(sbyte    value) : this() { _sByteValue    = value; _valueType = SimpleValueType.SByte;    }
        public SimpleValue(byte     value) : this() { _byteValue     = value; _valueType = SimpleValueType.Byte;     }
        public SimpleValue(short    value) : this() { _shortValue    = value; _valueType = SimpleValueType.Short;    }
        public SimpleValue(ushort   value) : this() { _uShortValue   = value; _valueType = SimpleValueType.UShort;   }
        public SimpleValue(int      value) : this() { _intValue      = value; _valueType = SimpleValueType.Int;      }
        public SimpleValue(uint     value) : this() { _uIntValue     = value; _valueType = SimpleValueType.UInt;     }
        public SimpleValue(long     value) : this() { _longValue     = value; _valueType = SimpleValueType.Long;     }
        public SimpleValue(ulong    value) : this() { _uLongValue    = value; _valueType = SimpleValueType.ULong;    }
        public SimpleValue(float    value) : this() { _floatValue    = value; _valueType = SimpleValueType.Float;    }
        public SimpleValue(double   value) : this() { _doubleValue   = value; _valueType = SimpleValueType.Double;   }
        public SimpleValue(char     value) : this() { _charValue     = value; _valueType = SimpleValueType.Char;     }
        public SimpleValue(DateTime value) : this() { _dateTimeValue = value; _valueType = SimpleValueType.DateTime; }
        public SimpleValue(TimeSpan value) : this() { _timeSpanValue = value; _valueType = SimpleValueType.TimeSpan; }
        public SimpleValue(decimal  value) : this() { _decimalValue = value;  _valueType = SimpleValueType.Decimal;  }

        #endregion Constructors

        #region Implicit Cast

        public static implicit operator bool      (SimpleValue value) { return value._boolValue;     }
        public static implicit operator sbyte     (SimpleValue value) { return value._sByteValue;    }
        public static implicit operator byte      (SimpleValue value) { return value._byteValue;     }
        public static implicit operator short     (SimpleValue value) { return value._shortValue;    }
        public static implicit operator ushort    (SimpleValue value) { return value._uShortValue;   }
        public static implicit operator int       (SimpleValue value) { return value._intValue;      }
        public static implicit operator uint      (SimpleValue value) { return value._uIntValue;     }
        public static implicit operator long      (SimpleValue value) { return value._longValue;     }
        public static implicit operator ulong     (SimpleValue value) { return value._uLongValue;    }
        public static implicit operator float     (SimpleValue value) { return value._floatValue;    }
        public static implicit operator double    (SimpleValue value) { return value._doubleValue;   }
        public static implicit operator char      (SimpleValue value) { return value._charValue;     }
        public static implicit operator DateTime  (SimpleValue value) { return value._dateTimeValue; }
        public static implicit operator TimeSpan  (SimpleValue value) { return value._timeSpanValue; }
        public static implicit operator decimal   (SimpleValue value) { return value._decimalValue;  }

        public static implicit operator SimpleValue (bool       value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (sbyte      value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (byte       value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (short      value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (ushort     value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (int        value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (uint       value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (long       value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (ulong      value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (float      value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (double     value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (char       value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (DateTime   value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (TimeSpan   value) { return new SimpleValue(value); }
        public static implicit operator SimpleValue (decimal    value) { return new SimpleValue(value); }

        #endregion Implicit Cast

        #region ToString

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation using the formatting conventions of the current culture.
        /// </summary>
        /// <exception cref="T:System.FormatException"><paramref name="format">format</paramref> is invalid.</exception>
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
            switch (ValueType)
            {
                case SimpleValueType.Bool:
                    return _boolValue.ToString(provider);
                    
                case SimpleValueType.SByte:
                    return _sByteValue.ToString(format, provider);

                case SimpleValueType.Byte:
                    return _byteValue.ToString(format, provider);

                case SimpleValueType.Short:
                    return _shortValue.ToString(format, provider);

                case SimpleValueType.UShort:
                    return _uShortValue.ToString(format, provider);

                case SimpleValueType.Int:
                    return _intValue.ToString(format, provider);

                case SimpleValueType.UInt:
                    return _uIntValue.ToString(format, provider);

                case SimpleValueType.Long:
                    return _longValue.ToString(format, provider);

                case SimpleValueType.ULong:
                    return _uLongValue.ToString(format, provider);

                case SimpleValueType.Float:
                    return _floatValue.ToString(format, provider);

                case SimpleValueType.Double:
                    return _doubleValue.ToString(format, provider);

                case SimpleValueType.Char:
                    return _charValue.ToString(provider);

                case SimpleValueType.DateTime:
                    return _dateTimeValue.ToString(format, provider);

                case SimpleValueType.TimeSpan:
                    return _timeSpanValue.ToString(format, provider);

                case SimpleValueType.Decimal:
                    return _decimalValue.ToString(format, provider);

                default:
                    throw new ArgumentOutOfRangeException(nameof(ValueType), $"Unrecognized value type {ValueType}");

            }
        }

        #endregion ToString

        /// <summary>
        /// Check if the current instance belong to one of the numeric types.
        /// </summary>
        public bool IsNumber()
        {
            switch (ValueType)
            {
                case SimpleValueType.SByte:
                case SimpleValueType.Byte:
                case SimpleValueType.Short:
                case SimpleValueType.UShort:
                case SimpleValueType.Int:
                case SimpleValueType.UInt:
                case SimpleValueType.Long:
                case SimpleValueType.ULong:
                case SimpleValueType.Float:
                case SimpleValueType.Double:
                case SimpleValueType.Decimal:
                    return true;

                default: 
                    return false;
            }
        }
    }
}