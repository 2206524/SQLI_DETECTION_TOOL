using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

namespace SQLIDetector
{
    public static class ArgumentValidation
    {
        #region Helpers
        private static string PadWord(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return string.Empty;
            }
            else
            {
                return text + " ";
            }
        }
        #endregion

        /// <summary>
        /// Throws <see cref="ArgumentException"/> if an argument
        /// <paramref name="value"/> named <paramref name="name"/> is not an
        /// instance of <paramref name="type"/>.
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="name">The name of the argument.</param>
        /// <param name="type">The expected <see cref="Type"/>.</param>
        /// <exception cref="ArgumentException">Thrown if
        /// <paramref name="value"/> is not an instance of
        /// <paramref name="type"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown if
        /// <paramref name="value"/> or <paramref name="type"/> is a null
        /// reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <remarks>This method is useful in implementing
        /// <see cref="IComparable.CompareTo"/>.</remarks>
        /// <example>
        /// The following example shows how to use
        /// <see cref="ArgumentDifferentTypeCheck"/> to simplify an
        /// implementation of <see cref="IComparable.CompareTo"/>.
        /// <code>
        /// using System;
        ///
        /// public class MyClass : IComparable
        /// {
        ///     public MyClass()
        ///     {
        ///     }
        ///
        ///     public int CompareTo(object obj)
        ///     {
        ///         ArgumentValidation.ArgumentDifferentTypeCheck(obj, "obj", this.GetType());
        ///
        ///         // Implement CompareTo() logic here.
        ///     }
        /// }
        /// </code>
        /// </example>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static void DifferentTypeCheck(object value, string name, Type type)
        {
            ArgumentValidation.NullCheck(value, "value");
            ArgumentValidation.NullCheck(type, "type");

            if (value.GetType() != type)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Argument {0}must be of type {1}.", ArgumentValidation.PadWord(name), type.Name), name);
            }
        }

        /// <summary>
        /// Throws <see cref="ArgumentException"/> if an argument
        /// <paramref name="value"/> named <paramref name="name"/> cannot be
        /// cast to <paramref name="type"/>.
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="name">The name of the argument.</param>
        /// <param name="type">The expected <see cref="Type"/>.</param>
        /// <exception cref="ArgumentException">Thrown if
        /// <paramref name="value"/> cannot be cast to
        /// <paramref name="type"/>.</exception>
        /// <remarks>This method is useful in overloading the protected methods
        /// of <see cref="System.Collections.CollectionBase"/>.</remarks>
        /// <exception cref="ArgumentNullException">Thrown if
        /// <paramref name="value"/> or <paramref name="type"/> is a null
        /// reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// The following example shows how to use
        /// <see cref="ArgumentIncompatibleTypeCheck"/> to simplify extending
        /// <see cref="System.Collections.CollectionBase"/>.
        /// <code>
        /// using System;
        ///
        /// public class TimeZoneCollection : CollectionBase
        /// {
        ///     public TimeZoneCollection() : base()
        ///     {
        ///     }
        ///
        ///     public TimeZone this[int index]
        ///     {
        ///         get { return (TimeZone)this.List[index]; }
        ///
        ///         set { this.List[index] = value; }
        ///     }
        ///
        ///     public int Add(TimeZone value)
        ///     {
        ///         return this.List.Add(value);
        ///     }
        ///
        ///     public int IndexOf(TimeZone value)
        ///     {
        ///         return this.List.IndexOf(value);
        ///     }
        ///
        ///     protected override void OnValidate(object value)
        ///     {
        ///         base.OnValidate(value);
        ///
        ///         ArgumentValidation.ArgumentIncompatibleTypeCheck(value, "value",
        ///          typeof(TimeZone));
        ///     }
        ///
        ///     public void Remove(TimeZone value)
        ///     {
        ///         this.List.Remove(value);
        ///     }
        /// }
        /// </code>
        /// </example>
        public static void IncompatibleTypeCheck(object value, string name, Type type)
        {
            ArgumentValidation.NullCheck(value, "value");
            ArgumentValidation.NullCheck(type, "type");

            if (!type.IsAssignableFrom(value.GetType()))
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Argument {0}must be compatible with type {1}.", ArgumentValidation.PadWord(name), type.Name), name);
            }
        }

        /// <summary>
        /// Throws <see cref="ArgumentException"/> if an
        /// <see typeparamref="T"/> argument <paramref name="value"/> 
        /// named <paramref name="name"/> cannot be
        /// cast to <typeparamref name="T"/>.
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="name">The name of the argument.</param>
        /// <typeparam name="T">The type to check against.</typeparam>
        /// <exception cref="ArgumentException">Thrown if
        /// <paramref name="value"/> cannot be cast to
        /// <paramref name="T"/>.</exception>
        /// <remarks>This method is useful in overloading the protected methods
        /// of <see cref="System.Collections.CollectionBase"/>.</remarks>
        /// <exception cref="ArgumentNullException">Thrown if
        /// <paramref name="value"/> or <paramref name="type"/> is a null
        /// reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// The following example shows how to use
        /// <see cref="IncompatibleTypeCheck"/> to simplify extending
        /// <see cref="System.Collections.CollectionBase"/>.
        /// <code>
        /// using System;
        ///
        /// public class TimeZoneCollection : CollectionBase
        /// {
        ///     public TimeZoneCollection() : base()
        ///     {
        ///     }
        ///
        ///     public TimeZone this[int index]
        ///     {
        ///         get { return (TimeZone)this.List[index]; }
        ///
        ///         set { this.List[index] = value; }
        ///     }
        ///
        ///     public int Add(TimeZone value)
        ///     {
        ///         return this.List.Add(value);
        ///     }
        ///
        ///     public int IndexOf(TimeZone value)
        ///     {
        ///         return this.List.IndexOf(value);
        ///     }
        ///
        ///     protected override void OnValidate(object value)
        ///     {
        ///         base.OnValidate(value);
        ///
        ///         ArgumentValidation.IncompatibleTypeCheck&lt;TimeZone&gt;(value, "value");
        ///     }
        ///
        ///     public void Remove(TimeZone value)
        ///     {
        ///         this.List.Remove(value);
        ///     }
        /// }
        /// </code>
        /// </example>
        public static void IncompatibleTypeCheck<T>(object value, string name)
        {
            ArgumentValidation.IncompatibleTypeCheck(value, name, typeof(T));
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if an argument
        /// <paramref name="value"/> named <paramref name="name"/> is a null
        /// reference (<c>Nothing</c> in Visual Basic).
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="name">The name of the argument.</param>
        /// <exception cref="ArgumentNullException">Thrown if
        /// <paramref name="value"/> is a null reference (<c>Nothing</c> in
        /// Visual Basic).</exception>
        /// <example>
        /// The following example shows how to use
        /// <see cref="ArgumentNullCheck"/> to implement argument
        /// validation in a constructor.
        /// <code>
        /// using System;
        ///
        /// public class MyClass
        /// {
        ///     public MyClass(string value)
        ///     {
        ///         ArgumentValidation.ArgumentNullCheck(value, "value");
        ///     }
        /// }
        /// </code>
        /// </example>
        public static void NullCheck(object value, string name)
        {
            if (null == value)
            {
                throw new ArgumentNullException(name, string.Format(CultureInfo.InvariantCulture, "Argument {0}cannot be null.", ArgumentValidation.PadWord(name)));
            }
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if an argument
        /// <paramref name="value"/> named <paramref name="name"/> is a null
        /// reference (<c>Nothing</c> in Visual Basic) or throws
        /// <see cref="ArgumentException"/> if is an empty string.
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="name">The name of the argument.</param>
        /// <exception cref="ArgumentNullException">Thrown if
        /// <paramref name="value"/> is a null reference (<c>Nothing</c> in
        /// Visual Basic).</exception>
        /// <exception cref="ArgumentException">Thrown if
        /// <paramref name="value"/> is a reference to an empty 
        /// string.</exception>
        /// <example>
        /// The following example shows how to use
        /// <see cref="ArgumentEmptyCheck"/> to implement argument
        /// validation in a constructor.
        /// <code>
        /// using System;
        ///
        /// public class MyClass
        /// {
        ///     public MyClass(string value)
        ///     {
        ///         ArgumentValidation.ArgumentEmptyCheck(value, "value");
        ///     }
        /// }
        /// </code>
        /// </example>
        public static void EmptyCheck(string value, string name)
        {
            ArgumentValidation.NullCheck(value, name);

            if (value.Length == 0)
            {
                throw new ArgumentException(name, string.Format(CultureInfo.InvariantCulture, "Argument {0}cannot be empty.", ArgumentValidation.PadWord(name)));
            }
        }

        /// <summary>
        /// Throws <see cref="RankException"/> if an Array argument
        /// <paramref name="value"/> named <paramref name="name"/> does
        /// not have the number of dimensions specified by
        /// <paramref name="rank"/>.
        /// </summary>
        /// <param name="value">The value of the array argument.</param>
        /// <param name="name">The name of the argument.</param>
        /// <param name="rank">The expected number of dimensions.</param>
        /// <exception cref="RankException">Thrown if <paramref name="value"/>
        /// does not have the number of dimensions specified by
        /// <paramref name="rank"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown if
        /// <paramref name="value"/> is a null reference (<c>Nothing</c> in
        /// Visual Basic).</exception>
        public static void ArrayDifferentRank(Array value, string name, int rank)
        {
            ArgumentValidation.NullCheck(value, "value");

            if (value.Rank != rank)
            {
                throw new RankException(string.Format(CultureInfo.InvariantCulture, "Argument {0}must be an array with {1} dimension.", ArgumentValidation.PadWord(name), rank));
            }
        }

        /// <summary>
        /// Throws <see cref="InvalidEnumArgumentException"/> if
        /// argument <paramref name="value"/> named
        /// <paramref name="name"/> is not a constant in
        /// <paramref name="enumType"/>.
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="name">The name of the argument.</param>
        /// <param name="enumType">An enumeration type.</param>
        /// <exception cref="InvalidEnumArgumentException">Thrown if no constant
        /// in <paramref name="enumType"/> has a value equal to
        /// <paramref name="value"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown if
        /// <paramref name="enumType"/> is a null reference (<c>Nothing</c> in
        /// Visual Basic).</exception>
        /// <exception cref="ArgumentException">Thrown if
        /// <paramref name="enumType"/> has the custom attribute
        /// <see cref="FlagsAttribute"/>.</exception>
        /// <exception cref="ArgumentException">Thrown if
        /// <paramref name="enumType.IsEnum"/> is <c>false</c>.</exception>
        /// <exception cref="ArgumentException">Thrown if
        /// the type of <paramref name="value"/> is a different than the
        /// underlying type of <paramref name="enumType"/>.</exception>
        /// <example>
        /// The following example shows how to use
        /// <see cref="ArgumentInvalidEnumValueCheck"/> to implement argument
        /// validation in a constructor.
        /// <code>
        /// using System;
        ///
        /// public class MyClass
        /// {
        ///     public MyClass(MyEnum value)
        ///     {
        ///         ArgumentValidation.ArgumentInvalidEnumValueCheck(value, "value",
        ///          typeof(MyEnum));
        ///     }
        /// }
        ///
        /// public enum MyEnum
        /// {
        ///     MyValue1,
        ///     MyValue2
        /// }
        /// </code>
        /// </example>
        public static void InvalidEnumValueCheck(object value, string name, Type enumType)
        {
            ArgumentValidation.NullCheck(value, "value");
            ArgumentValidation.NullCheck(enumType, "enumType");

            Debug.Assert((value.GetType().IsPrimitive || value.GetType().IsEnum || value.GetType() == typeof(string)), "Expected a primitive type or a String!");

            if (enumType.GetCustomAttributes(typeof(FlagsAttribute), true).Length > 0)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Cannot validate against the type {0} because it has the custom attribute FlagsAttribute.", enumType), "enumType");
            }

            if (!Enum.IsDefined(enumType, value))
            {
                if (value.GetType() == typeof(string))
                {
                    // Let the value argument be int.MaxValue if a string was passed in.
                    throw new InvalidEnumArgumentException(name, int.MaxValue, enumType);
                }
                else
                {
                    int valueInt32 = 0;
                    TypeConverter typeConverter = TypeDescriptor.GetConverter(Enum.GetUnderlyingType(enumType));

                    try
                    {
                        valueInt32 = (int)typeConverter.ConvertTo(value, typeof(int));
                    }
                    catch (OverflowException)
                    {
                        // Let the value argument be 0 if it overflows Int32.
                    }

                    throw new InvalidEnumArgumentException(name, valueInt32, enumType);
                }
            }
        }

        /// <summary>
        /// Throws <see cref="InvalidEnumArgumentException"/> if an
        /// <see typeparamref="T"/> argument <paramref name="value"/> named
        /// <paramref name="name"/> is not a constant in the provided
        /// type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="name">The name of the argument.</param>
        /// <typeparam name="T">The Enum type to check against.</typeparam>
        /// <exception cref="InvalidEnumArgumentException">Thrown if no constant
        /// in <paramref name="enumType"/> has a value equal to
        /// <paramref name="value"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown if
        /// <paramref name="enumType"/> is a null reference (<c>Nothing</c> in
        /// Visual Basic).</exception>
        /// <exception cref="ArgumentException">Thrown if
        /// <paramref name="enumType"/> has the custom attribute
        /// <see cref="FlagsAttribute"/>.</exception>
        /// <exception cref="ArgumentException">Thrown if
        /// <paramref name="enumType.IsEnum"/> is <c>false</c>.</exception>
        /// <exception cref="ArgumentException">Thrown if
        /// the type of <paramref name="value"/> is a different than the
        /// underlying type of <paramref name="enumType"/>.</exception>
        /// <example>
        /// The following example shows how to use
        /// <see cref="InvalidEnumValueCheck"/> to implement argument
        /// validation in a constructor.
        /// <code>
        /// using System;
        ///
        /// public class MyClass
        /// {
        ///     public MyClass(MyEnum value)
        ///     {
        ///         ArgumentValidation.InvalidEnumValueCheck&lt;MyEnum&gt;(value, "value");
        ///     }
        /// }
        ///
        /// public enum MyEnum
        /// {
        ///     MyValue1,
        ///     MyValue2
        /// }
        /// </code>
        /// </example>
        public static void InvalidEnumValueCheck<T>(object value, string name)
        {
            ArgumentValidation.InvalidEnumValueCheck(value, name, typeof(T));
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if 
        /// argument <paramref name="value"/> named
        /// <paramref name="name"/> is less than <paramref name="minValue"/> or
        /// greater than <paramref name="maxValue"/>.
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="name">The name of the argument.</param>
        /// <param name="minValue">The minimum value (inclusive) of
        /// <paramref name="value"/>.</param>
        /// <param name="maxValue">The maximum value (inclusive) of
        /// <paramref name="value"/>.</param>
        /// <typeparam name="T">The type to check against.</typeparam>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if
        /// <paramref name="value"/> is less than <paramref name="minValue"/> or
        /// greater than <paramref name="maxValue"/>.</exception>
        public static void OutOfRangeCheck<T>(T value, string name, T minValue, T maxValue) where T : IComparable
        {
            ArgumentValidation.NullCheck(value, "value");
            ArgumentValidation.IncompatibleTypeCheck(minValue, "minValue", typeof(T));
            ArgumentValidation.IncompatibleTypeCheck(maxValue, "maxValue", typeof(T));

            if (value.CompareTo(minValue) < 0 || 0 < value.CompareTo(maxValue))
            {
                throw new ArgumentOutOfRangeException(name, value, string.Format(CultureInfo.InvariantCulture, "Argument {0}must be greater than or equal to {1} and less than or equal to {2}.", ArgumentValidation.PadWord(name), minValue, maxValue));
            }
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if an
        /// <see cref="T"/> argument <paramref name="value"/> named
        /// <paramref name="name"/> is less than or equal to
        /// <paramref name="lowerBound"/> or greater than or equal to
        /// <paramref name="upperBound"/>.
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="name">The name of the argument.</param>
        /// <param name="lowerBound">The lower bound (exclusive) of
        /// <paramref name="value"/>.</param>
        /// <param name="upperBound">The upper bound (exclusive) of
        /// <paramref name="value"/>.</param>
        /// <typeparam name="T">The type to check against.</typeparam>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if
        /// <paramref name="value"/> is less than or equal to
        /// <paramref name="lowerBound"/> or greater than or equal to
        /// <paramref name="upperBound"/>.</exception>
        public static void OutOfRangeExclusiveCheck<T>(T value, string name, T lowerBound, T upperBound) where T : IComparable
        {
            ArgumentValidation.NullCheck(value, "value");
            ArgumentValidation.DifferentTypeCheck(lowerBound, "lowerBound", typeof(T));
            ArgumentValidation.DifferentTypeCheck(upperBound, "upperBound", typeof(T));

            if (lowerBound.CompareTo(upperBound) == 0)
            {
                throw new ArgumentException("Arguments lowerBound and upperBound cannot be equal.");
            }

            if (value.CompareTo(lowerBound) <= 0 || 0 <= value.CompareTo(upperBound))
            {
                throw new ArgumentOutOfRangeException(name, value, string.Format(CultureInfo.InvariantCulture, "Argument {0}must be greater than {1} and less than {2}.", ArgumentValidation.PadWord(name), lowerBound, upperBound));
            }
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if an
        /// <see cref="T"/> argument <paramref name="value"/> named
        /// <paramref name="name"/> is less than or equal to
        /// <paramref name="lowerBound"/> or greater than
        /// <paramref name="maxValue"/>.
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="name">The name of the argument.</param>
        /// <param name="lowerBound">The lower bound (exclusive) of
        /// <paramref name="value"/>.</param>
        /// <param name="maxValue">The maximum value (inclusive) of
        /// <paramref name="value"/>.</param>
        /// <typeparam name="T">The type to check against.</typeparam>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if
        /// <paramref name="value"/> is less than or equal to
        /// <paramref name="lowerBound"/> or greater than
        /// <paramref name="maxValue"/>.</exception>
        public static void OutOfRangeIncludeMaxCheck<T>(T value, string name, T lowerBound, T maxValue) where T : IComparable
        {
            ArgumentValidation.NullCheck(value, "value");
            ArgumentValidation.IncompatibleTypeCheck(lowerBound, "lowerBound", typeof(T));
            ArgumentValidation.IncompatibleTypeCheck(maxValue, "maxValue", typeof(T));

            if (value.CompareTo(lowerBound) < 0 || 0 <= value.CompareTo(maxValue))
            {
                throw new ArgumentOutOfRangeException(name, value, string.Format(CultureInfo.InvariantCulture, "Argument {0}must be greater than {1} and less than or equal to {2}.", ArgumentValidation.PadWord(name), lowerBound, maxValue));
            }
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if an
        /// <see cref="T"/> argument <paramref name="value"/> named
        /// <paramref name="name"/> is less than <paramref name="minValue"/> or
        /// greater than or equal to <paramref name="upperBound"/>.
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="name">The name of the argument.</param>
        /// <param name="minValue">The minimum value (inclusive) of
        /// <paramref name="value"/>.</param>
        /// <param name="upperBound">The upper bound (exclusive) of
        /// <paramref name="value"/>.</param>
        /// <typeparam name="T">The type to check against.</typeparam>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if
        /// <paramref name="value"/> is less than <paramref name="minValue"/> or
        /// greater than or equal to <paramref name="upperBound"/>.</exception>
        public static void OutOfRangeIncludeMinCheck<T>(T value, string name, T minValue, T upperBound) where T : IComparable
        {
            ArgumentValidation.NullCheck(value, "value");
            ArgumentValidation.IncompatibleTypeCheck(minValue, "minValue", typeof(T));
            ArgumentValidation.IncompatibleTypeCheck(upperBound, "upperBound", typeof(T));

            if (value.CompareTo(minValue) <= 0 || 0 < value.CompareTo(upperBound))
            {
                throw new ArgumentOutOfRangeException(name, value, string.Format(CultureInfo.InvariantCulture, "Argument {0}must be greater than or equal to {1} and less than {2}.", ArgumentValidation.PadWord(name), minValue, upperBound));
            }
        }
    }
}
