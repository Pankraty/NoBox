using System;

namespace Pankraty.NoBox
{
    /// <summary>
    /// A wrapper type that allows storing a simple value or an instance of a reference type
    /// in the same field without boxing simple values.
    /// </summary>
    public readonly struct SimpleValueOr<T> where T : class
    {
        #region Public Properties

        public bool IsValue => _isValue;

        public SimpleValue Value
        {
            get
            {
                if (_isValue)
                    return _value;

                throw new InvalidOperationException($"This instance is not a simple value. Use {nameof(Reference)} property");
            }
        }

        public T Reference
        {
            get
            {
                if (!_isValue)
                    return _reference;

                throw new InvalidOperationException($"This instance is not a reference. Use {nameof(Value)} property");
            }
        }

        #endregion Public Properties

        #region Private Fields

        private readonly bool _isValue;
        private readonly SimpleValue _value;
        private readonly T _reference;

        #endregion Private Fields

        #region Constructors

        public SimpleValueOr(SimpleValue value) : this()
        {
            _isValue = true;
            _value = value;
        }

        public SimpleValueOr(T reference) : this()
        {
            _reference = reference;
        }

        #endregion Constructors

        #region Implicit Casts

        public static implicit operator SimpleValue(SimpleValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator bool(SimpleValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator sbyte(SimpleValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator byte(SimpleValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator short(SimpleValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator ushort(SimpleValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator int(SimpleValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator uint(SimpleValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator long(SimpleValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator ulong(SimpleValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator float(SimpleValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator double(SimpleValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator char(SimpleValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator DateTime(SimpleValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator DateTimeOffset(SimpleValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator TimeSpan(SimpleValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator Guid(SimpleValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator decimal(SimpleValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator T(SimpleValueOr<T> value)
        {
            if (!value._isValue)
                return value._reference;

            throw new InvalidCastException();
        }


        public static implicit operator SimpleValueOr<T> (SimpleValue    value) { return new SimpleValueOr<T>(value); }
        public static implicit operator SimpleValueOr<T> (bool           value) { return new SimpleValueOr<T>(value); }
        public static implicit operator SimpleValueOr<T> (sbyte          value) { return new SimpleValueOr<T>(value); }
        public static implicit operator SimpleValueOr<T> (byte           value) { return new SimpleValueOr<T>(value); }
        public static implicit operator SimpleValueOr<T> (short          value) { return new SimpleValueOr<T>(value); }
        public static implicit operator SimpleValueOr<T> (ushort         value) { return new SimpleValueOr<T>(value); }
        public static implicit operator SimpleValueOr<T> (int            value) { return new SimpleValueOr<T>(value); }
        public static implicit operator SimpleValueOr<T> (uint           value) { return new SimpleValueOr<T>(value); }
        public static implicit operator SimpleValueOr<T> (long           value) { return new SimpleValueOr<T>(value); }
        public static implicit operator SimpleValueOr<T> (ulong          value) { return new SimpleValueOr<T>(value); }
        public static implicit operator SimpleValueOr<T> (float          value) { return new SimpleValueOr<T>(value); }
        public static implicit operator SimpleValueOr<T> (double         value) { return new SimpleValueOr<T>(value); }
        public static implicit operator SimpleValueOr<T> (char           value) { return new SimpleValueOr<T>(value); }
        public static implicit operator SimpleValueOr<T> (DateTime       value) { return new SimpleValueOr<T>(value); }
        public static implicit operator SimpleValueOr<T> (DateTimeOffset value) { return new SimpleValueOr<T>(value); }
        public static implicit operator SimpleValueOr<T> (TimeSpan       value) { return new SimpleValueOr<T>(value); }
        public static implicit operator SimpleValueOr<T> (Guid           value) { return new SimpleValueOr<T>(value); }
        public static implicit operator SimpleValueOr<T> (decimal        value) { return new SimpleValueOr<T>(value); }
        public static implicit operator SimpleValueOr<T> (T              value) { return new SimpleValueOr<T>(value); }

        #endregion Implicit Casts

        #region ToString

        public override string ToString()
        {
            return _isValue
                ? _value.ToString()
                : _reference?.ToString();
        }

        #endregion ToString
    }
}