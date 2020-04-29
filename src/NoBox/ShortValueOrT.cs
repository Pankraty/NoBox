using System;
using System.Collections.Generic;

namespace Pankraty.NoBox
{
    /// <summary>
    /// A wrapper type that allows storing a short simple value or an instance of a reference type
    /// in the same field without boxing simple values.
    /// </summary>
    public readonly struct ShortValueOr<T> : IEquatable<ShortValueOr<T>>
        where T : class
    {
        #region Public Properties

        /// <summary>
        /// Check if current instance hold a value of a simple type (true) or a reference (false).
        /// </summary>
        public bool IsValue => _isValue;

        /// <summary>
        /// Get a simple value stored in the current instance.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException" accessor="get">If current instance stores is not of value type (IsValue=false).</exception>
        public ShortValue Value
        {
            get
            {
                return _isValue switch
                {
                    true => _value,
                    _ => throw new InvalidOperationException(
                        $"This instance is not a simple value. Use {nameof(Reference)} property")
                };
            }
        }

        /// <summary>
        /// Get a reference stored in the current instance.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException" accessor="get">If current instance is of value type (IsValue=true).</exception>
        public T Reference
        {
            get
            {
                return _isValue switch
                {
                    false => _reference,
                    _ => throw new InvalidOperationException(
                        $"This instance is not a reference. Use {nameof(Value)} property")
                };
            }
        }

        #endregion Public Properties

        #region Private Fields

        private readonly bool _isValue;
        private readonly ShortValue _value;
        private readonly T _reference;

        #endregion Private Fields

        #region Constructors

        /// <summary>
        /// Create a new instance that will store a simple value without boxing.
        /// </summary>
        public ShortValueOr(ShortValue value) : this()
        {
            _isValue = true;
            _value = value;
        }

        /// <summary>
        /// Create a new instance that will store a reference to the object of type <typeparamref name="T"/>.
        /// </summary>
        public ShortValueOr(T reference) : this()
        {
            _reference = reference;
        }

        #endregion Constructors

        #region Implicit Casts

        public static implicit operator ShortValue(ShortValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator bool(ShortValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator sbyte(ShortValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator byte(ShortValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator short(ShortValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator ushort(ShortValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator int(ShortValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator uint(ShortValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator long(ShortValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator ulong(ShortValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator float(ShortValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator double(ShortValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator char(ShortValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator DateTime(ShortValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator TimeSpan(ShortValueOr<T> value)
        {
            if (value._isValue)
                return value._value;

            throw new InvalidCastException();
        }

        public static implicit operator T(ShortValueOr<T> value)
        {
            if (!value._isValue)
                return value._reference;

            throw new InvalidCastException();
        }


        public static implicit operator ShortValueOr<T> (ShortValue     value) { return new ShortValueOr<T>(value); }
        public static implicit operator ShortValueOr<T> (bool           value) { return new ShortValueOr<T>(value); }
        public static implicit operator ShortValueOr<T> (sbyte          value) { return new ShortValueOr<T>(value); }
        public static implicit operator ShortValueOr<T> (byte           value) { return new ShortValueOr<T>(value); }
        public static implicit operator ShortValueOr<T> (short          value) { return new ShortValueOr<T>(value); }
        public static implicit operator ShortValueOr<T> (ushort         value) { return new ShortValueOr<T>(value); }
        public static implicit operator ShortValueOr<T> (int            value) { return new ShortValueOr<T>(value); }
        public static implicit operator ShortValueOr<T> (uint           value) { return new ShortValueOr<T>(value); }
        public static implicit operator ShortValueOr<T> (long           value) { return new ShortValueOr<T>(value); }
        public static implicit operator ShortValueOr<T> (ulong          value) { return new ShortValueOr<T>(value); }
        public static implicit operator ShortValueOr<T> (float          value) { return new ShortValueOr<T>(value); }
        public static implicit operator ShortValueOr<T> (double         value) { return new ShortValueOr<T>(value); }
        public static implicit operator ShortValueOr<T> (char           value) { return new ShortValueOr<T>(value); }
        public static implicit operator ShortValueOr<T> (DateTime       value) { return new ShortValueOr<T>(value); }
        public static implicit operator ShortValueOr<T> (TimeSpan       value) { return new ShortValueOr<T>(value); }
        public static implicit operator ShortValueOr<T> (T              value) { return new ShortValueOr<T>(value); }

        #endregion Implicit Casts
        
        #region Explicit Cast

        public Tout CastTo<Tout>()
        {
            if (IsValue)
                return Value.CastTo<Tout>();
            else
            {
                return (Tout)(object)Reference;
            }
        }

        #endregion Explicit Cast

        #region ToString

        public override string ToString()
        {
            return _isValue
                ? _value.ToString()
                : _reference?.ToString();
        }

        #endregion ToString

        #region IEquatable Implementation

        public bool Equals(ShortValueOr<T> other)
        {
            if (IsValue)
            {
                return other.IsValue &&
                       EqualityComparer<ShortValue>.Default.Equals(_value, other._value);
            }
            else
            {
                return !other.IsValue &&
                       EqualityComparer<T>.Default.Equals(_reference, other._reference);
            }
        }

        public override bool Equals(object obj)
        {
            return obj is ShortValueOr<T> other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                if (IsValue)
                {
                    return _value.GetHashCode() * 397;
                }
                else
                {
                    return EqualityComparer<T>.Default.GetHashCode(_reference) * 397;
                }
            }
        }

        public static bool operator ==(ShortValueOr<T> left, ShortValueOr<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ShortValueOr<T> left, ShortValueOr<T> right)
        {
            return !left.Equals(right);
        }

        #endregion IEquatable Implementation
    }
}