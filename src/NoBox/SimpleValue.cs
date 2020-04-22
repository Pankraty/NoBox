﻿using System;
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
    }
}