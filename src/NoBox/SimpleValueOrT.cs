﻿using Pankraty.NoBox.Converters;
using System;
using System.Collections.Generic;

namespace Pankraty.NoBox
{
    /// <summary>
    /// A wrapper type that allows storing a simple value or an instance of a reference type
    /// in the same field without boxing simple values.
    /// </summary>
    public readonly struct SimpleValueOr<T> : IEquatable<SimpleValueOr<T>>
        where T : class
    {
        #region Static Members

        /// <summary>
        /// Create an instance of <see cref="SimpleValueOr{T}"/> from a generic argument avoiding its boxing
        /// if possible.
        /// </summary>
        /// <typeparam name="Tin">A primitive or a reference type that can be casted to <typeparamref name="T"/></typeparam>
        /// <param name="value">A value to convert to <see cref="SimpleValueOr{T}"/></param>
        /// <returns>An instance of <see cref="SimpleValueOr{T}"/> holding the specified value.</returns>
        public static SimpleValueOr<T> Create<Tin>(Tin value)
        {
            if (SimpleValueConverter.Instance is IValueConverter<Tin, SimpleValue> converter)
            {
                return converter.GetValue(value);
            }

            // A fallback with boxing
            return new SimpleValueOr<T>((T)(object)value);
        }

        #endregion Static Members

        #region Public Properties

        /// <summary>
        /// Check if current instance hold a value of a simple type (true) or a reference (false).
        /// </summary>
        public bool IsValue => _isValue;

        /// <summary>
        /// Get a simple value stored in the current instance.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException" accessor="get">If current instance stores is not of value type (IsValue=false).</exception>
        public SimpleValue Value
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
        private readonly SimpleValue _value;
        private readonly T _reference;

        #endregion Private Fields

        #region Constructors

        /// <summary>
        /// Create a new instance that will store a simple value without boxing.
        /// </summary>
        public SimpleValueOr(SimpleValue value) : this()
        {
            _isValue = true;
            _value = value;
        }

        /// <summary>
        /// Create a new instance that will store a reference to the object of type <typeparamref name="T"/>.
        /// </summary>
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

        public bool Equals(SimpleValueOr<T> other)
        {
            if (IsValue)
            {
                return other.IsValue &&
                       EqualityComparer<SimpleValue>.Default.Equals(_value, other._value);
            }
            else
            {
                return !other.IsValue &&
                       EqualityComparer<T>.Default.Equals(_reference, other._reference);
            }
        }

        public override bool Equals(object obj)
        {
            return obj is SimpleValueOr<T> other && Equals(other);
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

        public static bool operator ==(SimpleValueOr<T> left, SimpleValueOr<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SimpleValueOr<T> left, SimpleValueOr<T> right)
        {
            return !left.Equals(right);
        }

        #endregion IEquatable Implementation
    }
}