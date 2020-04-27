using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pankraty.NoBox.Tests.Common
{
    public static partial class CastSamples
    {
        private static Type invalidCastException = typeof(InvalidCastException);

        #region Default Values

        // Instances of CLR types used for testing

        public static bool             Default_bool              => true;
        public static sbyte            Default_sbyte             => 1;
        public static byte             Default_byte              => 2;
        public static short            Default_short             => 3;
        public static ushort           Default_ushort            => 4;
        public static int              Default_int               => 5;
        public static uint             Default_uint              => 6;
        public static long             Default_long              => 7;
        public static ulong            Default_ulong             => 8;
        public static float            Default_float             => 9;
        public static double           Default_double            => 10.5;
        public static char             Default_char              => 'd';
        public static DateTime         Default_DateTime          => new DateTime(2020, 02, 20);
        public static DateTimeOffset   Default_DateTimeOffset    => new DateTimeOffset(new DateTime(2020, 02, 20), TimeSpan.FromHours(2));
        public static TimeSpan         Default_TimeSpan          => TimeSpan.FromDays(3);
        public static Guid             Default_Guid              => Guid.Parse("264AA8BB-2E31-4731-8CFC-F0F0B82E637E");
        public static decimal          Default_decimal           => 13.5m;
        public static string           Default_string            => "Test string";
        public static SimpleValue      Default_SimpleValue        => new SimpleValue(100);

        #endregion Default Values
        
        /// <summary>
        /// Get valid casts from the specified type as a collection of <see cref="TestCaseData"/>s.
        /// </summary>
        public static IEnumerable<TestCaseData> GetValidCasts(Type fromType)
        {
            return AllCasts
                .Where(cst => cst.IsValid && cst.From == fromType)
                .Select(cst => cst.ToTestCase());
        }

        /// <summary>
        /// Get invalid casts from the specified type as a collection of <see cref="TestCaseData"/>s.
        /// </summary>
        public static IEnumerable<TestCaseData> GetInvalidCasts(Type fromType)
        {
            return AllCasts
                .Where(cst => !cst.IsValid && cst.From == fromType)
                .Select(cst => cst.ToTestCase());
        }
    }
}
