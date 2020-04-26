using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pankraty.NoBox.Tests.Common
{
    public static class CastSamples
    {

        #region Default Values

        // Instances of CLR types used for testing

        public static bool             DefaultBool            => true;
        public static sbyte            DefaultSByte           => 1;
        public static byte             DefaultByte            => 2;
        public static short            DefaultShort           => 3;
        public static ushort           DefaultUShort          => 4;
        public static int              DefaultInt             => 5;
        public static uint             DefaultUInt            => 6;
        public static long             DefaultLong            => 7;
        public static ulong            DefaultULong           => 8;
        public static float            DefaultFloat           => 9;
        public static double           DefaultDouble          => 10.5;
        public static char             DefaultChar            => 'd';
        public static DateTime         DefaultDateTime        => new DateTime(2020, 02, 20);
        public static DateTimeOffset   DefaultDateTimeOffset  => new DateTimeOffset(new DateTime(2020, 02, 20), TimeSpan.FromHours(2));
        public static TimeSpan         DefaultTimeSpan        => TimeSpan.FromDays(3);
        public static Guid             DefaultGuid            => Guid.Parse("264AA8BB-2E31-4731-8CFC-F0F0B82E637E");
        public static decimal          DefaultDecimal         => 13.5m;
        public static string           DefaultString          => "Test string";
        #endregion Default Values

        #region Default SimpleValue

        // Instances of SimpleValue build from CLR types (the correctness of such casts covered by separate tests)

        public static SimpleValue SimpleBool            => DefaultBool          ;
        public static SimpleValue SimpleSByte           => DefaultSByte         ;
        public static SimpleValue SimpleByte            => DefaultByte          ;
        public static SimpleValue SimpleShort           => DefaultShort         ;
        public static SimpleValue SimpleUShort          => DefaultUShort        ;
        public static SimpleValue SimpleInt             => DefaultInt           ;
        public static SimpleValue SimpleUInt            => DefaultUInt          ;
        public static SimpleValue SimpleLong            => DefaultLong          ;
        public static SimpleValue SimpleULong           => DefaultULong         ;
        public static SimpleValue SimpleFloat           => DefaultFloat         ;
        public static SimpleValue SimpleDouble          => DefaultDouble        ;
        public static SimpleValue SimpleChar            => DefaultChar          ;
        public static SimpleValue SimpleDateTime        => DefaultDateTime      ;
        public static SimpleValue SimpleDateTimeOffset  => DefaultDateTimeOffset;
        public static SimpleValue SimpleTimeSpan        => DefaultTimeSpan      ;
        public static SimpleValue SimpleGuid            => DefaultGuid          ;
        public static SimpleValue SimpleDecimal         => DefaultDecimal       ;

        #endregion Default SimpleValue

        #region Default SimpleValueOr<String>

        // Instances of SimpleValueOr<String> build from CLR types (the correctness of such casts covered by separate tests)

        public static SimpleValueOr<String> SimpleOrTBool           => DefaultBool;
        public static SimpleValueOr<String> SimpleOrTSByte          => DefaultSByte;
        public static SimpleValueOr<String> SimpleOrTByte           => DefaultByte;
        public static SimpleValueOr<String> SimpleOrTShort          => DefaultShort;
        public static SimpleValueOr<String> SimpleOrTUShort         => DefaultUShort;
        public static SimpleValueOr<String> SimpleOrTInt            => DefaultInt;
        public static SimpleValueOr<String> SimpleOrTUInt           => DefaultUInt;
        public static SimpleValueOr<String> SimpleOrTLong           => DefaultLong;
        public static SimpleValueOr<String> SimpleOrTULong          => DefaultULong;
        public static SimpleValueOr<String> SimpleOrTFloat          => DefaultFloat;
        public static SimpleValueOr<String> SimpleOrTDouble         => DefaultDouble;
        public static SimpleValueOr<String> SimpleOrTChar           => DefaultChar;
        public static SimpleValueOr<String> SimpleOrTDateTime       => DefaultDateTime;
        public static SimpleValueOr<String> SimpleOrTDateTimeOffset => DefaultDateTimeOffset;
        public static SimpleValueOr<String> SimpleOrTTimeSpan       => DefaultTimeSpan;
        public static SimpleValueOr<String> SimpleOrTGuid           => DefaultGuid;
        public static SimpleValueOr<String> SimpleOrTDecimal        => DefaultDecimal;
        public static SimpleValueOr<String> SimpleOrTString         => DefaultString;

        #endregion Default SimpleValueOr<String>

        private static Type invalidCastException = typeof(InvalidCastException);

        /// <summary>
        /// All casts that have to covered with unit tests
        /// </summary>
        private static CastDefinition[] AllCasts =
        {
            #region From SimpleValue to every type

            /*
            Casts matrix. 
                V : Allowed cast,
                - : Invalid cast

            +--------------------+---------------------------------------------------------------------+
            |From:|           To:|	1	2	3	4	5	6	7	8	9	10	11	12	13	14	15	16	17 |
            +--------------------+---------------------------------------------------------------------+
            |  1  |bool          |	V	-	-	-	-	-	-	-	-	-	-	-	-	-	-	-	-  |
            |  2  |sbyte         |	-	V	V	V	V	V	V	V	V	V	V	V	-	-	-	-	V  |
            |  3  |byte          |	-	V	V	V	V	V	V	V	V	V	V	V	-	-	-	-	V  |
            |  4  |short         |	-	V	V	V	V	V	V	V	V	V	V	V	-	-	-	-	V  |
            |  5  |ushort        |	-	V	V	V	V	V	V	V	V	V	V	V	-	-	-	-	V  |
            |  6  |int           |	-	V	V	V	V	V	V	V	V	V	V	V	-	-	-	-	V  |
            |  7  |uint          |	-	V	V	V	V	V	V	V	V	V	V	V	-	-	-	-	V  |
            |  8  |long          |	-	V	V	V	V	V	V	V	V	V	V	V	-	-	-	-	V  |
            |  9  |ulong         |	-	V	V	V	V	V	V	V	V	V	V	V	-	-	-	-	V  |
            | 10  |float         |	-	V	V	V	V	V	V	V	V	V	V	V	-	-	-	-	V  |
            | 11  |double        |	-	V	V	V	V	V	V	V	V	V	V	V	-	-	-	-	V  |
            | 12  |char          |	-	V	V	V	V	V	V	V	V	V	V	V	-	-	-	-	V  |
            | 13  |DateTime      |	-	-	-	-	-	-	-	-	-	-	-	-	V	V	-	-	-  |
            | 14  |DateTimeOffset|	-	-	-	-	-	-	-	-	-	-	-	-	-	V	-	-	-  |
            | 15  |TimeSpan      |	-	-	-	-	-	-	-	-	-	-	-	-	-	-	V	-	-  |
            | 16  |Guid          |	-	-	-	-	-	-	-	-	-	-	-	-	-	-	-	V	-  |
            | 17  |decimal       |	-	V	V	V	V	V	V	V	V	V	V	V	-	-	-	-	V  |
            +--------------------+---------------------------------------------------------------------+
            */

            new CastDefinition<SimpleValue,bool             >(SimpleBool           , v => v, DefaultBool),
            new CastDefinition<SimpleValue,sbyte            >(SimpleBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValue,byte             >(SimpleBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValue,short            >(SimpleBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValue,ushort           >(SimpleBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValue,int              >(SimpleBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValue,uint             >(SimpleBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValue,long             >(SimpleBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValue,ulong            >(SimpleBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValue,float            >(SimpleBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValue,double           >(SimpleBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValue,char             >(SimpleBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValue,DateTime         >(SimpleBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValue,DateTimeOffset   >(SimpleBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValue,TimeSpan         >(SimpleBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValue,Guid             >(SimpleBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValue,decimal          >(SimpleBool           , v => v, invalidCastException),


            new CastDefinition<SimpleValue,bool             >(SimpleSByte          , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,sbyte            >(SimpleSByte          , v => v, (sbyte  )DefaultSByte),
            new CastDefinition<SimpleValue,byte             >(SimpleSByte          , v => v, (byte   )DefaultSByte),
            new CastDefinition<SimpleValue,short            >(SimpleSByte          , v => v, (short  )DefaultSByte),
            new CastDefinition<SimpleValue,ushort           >(SimpleSByte          , v => v, (ushort )DefaultSByte),
            new CastDefinition<SimpleValue,int              >(SimpleSByte          , v => v, (int    )DefaultSByte),
            new CastDefinition<SimpleValue,uint             >(SimpleSByte          , v => v, (uint   )DefaultSByte),
            new CastDefinition<SimpleValue,long             >(SimpleSByte          , v => v, (long   )DefaultSByte),
            new CastDefinition<SimpleValue,ulong            >(SimpleSByte          , v => v, (ulong  )DefaultSByte),
            new CastDefinition<SimpleValue,float            >(SimpleSByte          , v => v, (float  )DefaultSByte),
            new CastDefinition<SimpleValue,double           >(SimpleSByte          , v => v, (double )DefaultSByte),
            new CastDefinition<SimpleValue,char             >(SimpleSByte          , v => v, (char   )DefaultSByte),
            new CastDefinition<SimpleValue,DateTime         >(SimpleSByte          , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,DateTimeOffset   >(SimpleSByte          , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,TimeSpan         >(SimpleSByte          , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,Guid             >(SimpleSByte          , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,decimal          >(SimpleSByte          , v => v, (decimal)DefaultSByte),


            new CastDefinition<SimpleValue,bool             >(SimpleByte           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,sbyte            >(SimpleByte           , v => v, (sbyte  )DefaultByte ),
            new CastDefinition<SimpleValue,byte             >(SimpleByte           , v => v, (byte   )DefaultByte ),
            new CastDefinition<SimpleValue,short            >(SimpleByte           , v => v, (short  )DefaultByte ),
            new CastDefinition<SimpleValue,ushort           >(SimpleByte           , v => v, (ushort )DefaultByte ),
            new CastDefinition<SimpleValue,int              >(SimpleByte           , v => v, (int    )DefaultByte ),
            new CastDefinition<SimpleValue,uint             >(SimpleByte           , v => v, (uint   )DefaultByte ),
            new CastDefinition<SimpleValue,long             >(SimpleByte           , v => v, (long   )DefaultByte ),
            new CastDefinition<SimpleValue,ulong            >(SimpleByte           , v => v, (ulong  )DefaultByte ),
            new CastDefinition<SimpleValue,float            >(SimpleByte           , v => v, (float  )DefaultByte ),
            new CastDefinition<SimpleValue,double           >(SimpleByte           , v => v, (double )DefaultByte ),
            new CastDefinition<SimpleValue,char             >(SimpleByte           , v => v, (char   )DefaultByte ),
            new CastDefinition<SimpleValue,DateTime         >(SimpleByte           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,DateTimeOffset   >(SimpleByte           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,TimeSpan         >(SimpleByte           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,Guid             >(SimpleByte           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,decimal          >(SimpleByte           , v => v, (decimal)DefaultByte ),


            new CastDefinition<SimpleValue,bool             >(SimpleShort          , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,sbyte            >(SimpleShort          , v => v, (sbyte  )DefaultShort),
            new CastDefinition<SimpleValue,byte             >(SimpleShort          , v => v, (byte   )DefaultShort),
            new CastDefinition<SimpleValue,short            >(SimpleShort          , v => v, (short  )DefaultShort),
            new CastDefinition<SimpleValue,ushort           >(SimpleShort          , v => v, (ushort )DefaultShort),
            new CastDefinition<SimpleValue,int              >(SimpleShort          , v => v, (int    )DefaultShort),
            new CastDefinition<SimpleValue,uint             >(SimpleShort          , v => v, (uint   )DefaultShort),
            new CastDefinition<SimpleValue,long             >(SimpleShort          , v => v, (long   )DefaultShort),
            new CastDefinition<SimpleValue,ulong            >(SimpleShort          , v => v, (ulong  )DefaultShort),
            new CastDefinition<SimpleValue,float            >(SimpleShort          , v => v, (float  )DefaultShort),
            new CastDefinition<SimpleValue,double           >(SimpleShort          , v => v, (double )DefaultShort),
            new CastDefinition<SimpleValue,char             >(SimpleShort          , v => v, (char   )DefaultShort),
            new CastDefinition<SimpleValue,DateTime         >(SimpleShort          , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,DateTimeOffset   >(SimpleShort          , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,TimeSpan         >(SimpleShort          , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,Guid             >(SimpleShort          , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,decimal          >(SimpleShort          , v => v, (decimal)DefaultShort),


            new CastDefinition<SimpleValue,bool             >(SimpleUShort         , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,sbyte            >(SimpleUShort         , v => v, (sbyte )DefaultUShort),
            new CastDefinition<SimpleValue,byte             >(SimpleUShort         , v => v, (byte  )DefaultUShort),
            new CastDefinition<SimpleValue,short            >(SimpleUShort         , v => v, (short )DefaultUShort),
            new CastDefinition<SimpleValue,ushort           >(SimpleUShort         , v => v, (ushort)DefaultUShort),
            new CastDefinition<SimpleValue,int              >(SimpleUShort         , v => v, (int   )DefaultUShort),
            new CastDefinition<SimpleValue,uint             >(SimpleUShort         , v => v, (uint  )DefaultUShort),
            new CastDefinition<SimpleValue,long             >(SimpleUShort         , v => v, (long  )DefaultUShort),
            new CastDefinition<SimpleValue,ulong            >(SimpleUShort         , v => v, (ulong )DefaultUShort),
            new CastDefinition<SimpleValue,float            >(SimpleUShort         , v => v, (float )DefaultUShort),
            new CastDefinition<SimpleValue,double           >(SimpleUShort         , v => v, (double)DefaultUShort),
            new CastDefinition<SimpleValue,char             >(SimpleUShort         , v => v, (char  )DefaultUShort),
            new CastDefinition<SimpleValue,DateTime         >(SimpleUShort         , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,DateTimeOffset   >(SimpleUShort         , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,TimeSpan         >(SimpleUShort         , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,Guid             >(SimpleUShort         , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,decimal          >(SimpleUShort         , v => v, (decimal)DefaultUShort),


            new CastDefinition<SimpleValue,bool             >(SimpleInt            , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,sbyte            >(SimpleInt            , v => v, (sbyte  )DefaultInt  ),
            new CastDefinition<SimpleValue,byte             >(SimpleInt            , v => v, (byte   )DefaultInt  ),
            new CastDefinition<SimpleValue,short            >(SimpleInt            , v => v, (short  )DefaultInt  ),
            new CastDefinition<SimpleValue,ushort           >(SimpleInt            , v => v, (ushort )DefaultInt  ),
            new CastDefinition<SimpleValue,int              >(SimpleInt            , v => v, (int    )DefaultInt  ),
            new CastDefinition<SimpleValue,uint             >(SimpleInt            , v => v, (uint   )DefaultInt  ),
            new CastDefinition<SimpleValue,long             >(SimpleInt            , v => v, (long   )DefaultInt  ),
            new CastDefinition<SimpleValue,ulong            >(SimpleInt            , v => v, (ulong  )DefaultInt  ),
            new CastDefinition<SimpleValue,float            >(SimpleInt            , v => v, (float  )DefaultInt  ),
            new CastDefinition<SimpleValue,double           >(SimpleInt            , v => v, (double )DefaultInt  ),
            new CastDefinition<SimpleValue,char             >(SimpleInt            , v => v, (char   )DefaultInt  ),
            new CastDefinition<SimpleValue,DateTime         >(SimpleInt            , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,DateTimeOffset   >(SimpleInt            , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,TimeSpan         >(SimpleInt            , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,Guid             >(SimpleInt            , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,decimal          >(SimpleInt            , v => v, (decimal)DefaultInt  ),


            new CastDefinition<SimpleValue,bool             >(SimpleUInt           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,sbyte            >(SimpleUInt           , v => v, (sbyte  )DefaultUInt ),
            new CastDefinition<SimpleValue,byte             >(SimpleUInt           , v => v, (byte   )DefaultUInt ),
            new CastDefinition<SimpleValue,short            >(SimpleUInt           , v => v, (short  )DefaultUInt ),
            new CastDefinition<SimpleValue,ushort           >(SimpleUInt           , v => v, (ushort )DefaultUInt ),
            new CastDefinition<SimpleValue,int              >(SimpleUInt           , v => v, (int    )DefaultUInt ),
            new CastDefinition<SimpleValue,uint             >(SimpleUInt           , v => v, (uint   )DefaultUInt ),
            new CastDefinition<SimpleValue,long             >(SimpleUInt           , v => v, (long   )DefaultUInt ),
            new CastDefinition<SimpleValue,ulong            >(SimpleUInt           , v => v, (ulong  )DefaultUInt ),
            new CastDefinition<SimpleValue,float            >(SimpleUInt           , v => v, (float  )DefaultUInt ),
            new CastDefinition<SimpleValue,double           >(SimpleUInt           , v => v, (double )DefaultUInt ),
            new CastDefinition<SimpleValue,char             >(SimpleUInt           , v => v, (char   )DefaultUInt ),
            new CastDefinition<SimpleValue,DateTime         >(SimpleUInt           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,DateTimeOffset   >(SimpleUInt           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,TimeSpan         >(SimpleUInt           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,Guid             >(SimpleUInt           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,decimal          >(SimpleUInt           , v => v, (decimal)DefaultUInt ),


            new CastDefinition<SimpleValue,bool             >(SimpleLong           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,sbyte            >(SimpleLong           , v => v, (sbyte  )DefaultLong ),
            new CastDefinition<SimpleValue,byte             >(SimpleLong           , v => v, (byte   )DefaultLong ),
            new CastDefinition<SimpleValue,short            >(SimpleLong           , v => v, (short  )DefaultLong ),
            new CastDefinition<SimpleValue,ushort           >(SimpleLong           , v => v, (ushort )DefaultLong ),
            new CastDefinition<SimpleValue,int              >(SimpleLong           , v => v, (int    )DefaultLong ),
            new CastDefinition<SimpleValue,uint             >(SimpleLong           , v => v, (uint   )DefaultLong ),
            new CastDefinition<SimpleValue,long             >(SimpleLong           , v => v, (long   )DefaultLong ),
            new CastDefinition<SimpleValue,ulong            >(SimpleLong           , v => v, (ulong  )DefaultLong ),
            new CastDefinition<SimpleValue,float            >(SimpleLong           , v => v, (float  )DefaultLong ),
            new CastDefinition<SimpleValue,double           >(SimpleLong           , v => v, (double )DefaultLong ),
            new CastDefinition<SimpleValue,char             >(SimpleLong           , v => v, (char   )DefaultLong ),
            new CastDefinition<SimpleValue,DateTime         >(SimpleLong           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,DateTimeOffset   >(SimpleLong           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,TimeSpan         >(SimpleLong           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,Guid             >(SimpleLong           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,decimal          >(SimpleLong           , v => v, (decimal)DefaultLong ),


            new CastDefinition<SimpleValue,bool             >(SimpleULong          , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,sbyte            >(SimpleULong          , v => v, (sbyte  )DefaultULong),
            new CastDefinition<SimpleValue,byte             >(SimpleULong          , v => v, (byte   )DefaultULong),
            new CastDefinition<SimpleValue,short            >(SimpleULong          , v => v, (short  )DefaultULong),
            new CastDefinition<SimpleValue,ushort           >(SimpleULong          , v => v, (ushort )DefaultULong),
            new CastDefinition<SimpleValue,int              >(SimpleULong          , v => v, (int    )DefaultULong),
            new CastDefinition<SimpleValue,uint             >(SimpleULong          , v => v, (uint   )DefaultULong),
            new CastDefinition<SimpleValue,long             >(SimpleULong          , v => v, (long   )DefaultULong),
            new CastDefinition<SimpleValue,ulong            >(SimpleULong          , v => v, (ulong  )DefaultULong),
            new CastDefinition<SimpleValue,float            >(SimpleULong          , v => v, (float  )DefaultULong),
            new CastDefinition<SimpleValue,double           >(SimpleULong          , v => v, (double )DefaultULong),
            new CastDefinition<SimpleValue,char             >(SimpleULong          , v => v, (char   )DefaultULong),
            new CastDefinition<SimpleValue,DateTime         >(SimpleULong          , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,DateTimeOffset   >(SimpleULong          , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,TimeSpan         >(SimpleULong          , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,Guid             >(SimpleULong          , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,decimal          >(SimpleULong          , v => v, (decimal)DefaultULong),


            new CastDefinition<SimpleValue,bool             >(SimpleFloat          , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,sbyte            >(SimpleFloat          , v => v, (sbyte  )DefaultFloat),
            new CastDefinition<SimpleValue,byte             >(SimpleFloat          , v => v, (byte   )DefaultFloat),
            new CastDefinition<SimpleValue,short            >(SimpleFloat          , v => v, (short  )DefaultFloat),
            new CastDefinition<SimpleValue,ushort           >(SimpleFloat          , v => v, (ushort )DefaultFloat),
            new CastDefinition<SimpleValue,int              >(SimpleFloat          , v => v, (int    )DefaultFloat),
            new CastDefinition<SimpleValue,uint             >(SimpleFloat          , v => v, (uint   )DefaultFloat),
            new CastDefinition<SimpleValue,long             >(SimpleFloat          , v => v, (long   )DefaultFloat),
            new CastDefinition<SimpleValue,ulong            >(SimpleFloat          , v => v, (ulong  )DefaultFloat),
            new CastDefinition<SimpleValue,float            >(SimpleFloat          , v => v, (float  )DefaultFloat),
            new CastDefinition<SimpleValue,double           >(SimpleFloat          , v => v, (double )DefaultFloat),
            new CastDefinition<SimpleValue,char             >(SimpleFloat          , v => v, (char   )DefaultFloat),
            new CastDefinition<SimpleValue,DateTime         >(SimpleFloat          , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,DateTimeOffset   >(SimpleFloat          , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,TimeSpan         >(SimpleFloat          , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,Guid             >(SimpleFloat          , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,decimal          >(SimpleFloat          , v => v, (decimal)DefaultFloat),


            new CastDefinition<SimpleValue,bool             >(SimpleDouble         , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,sbyte            >(SimpleDouble         , v => v, (sbyte )DefaultDouble),
            new CastDefinition<SimpleValue,byte             >(SimpleDouble         , v => v, (byte  )DefaultDouble),
            new CastDefinition<SimpleValue,short            >(SimpleDouble         , v => v, (short )DefaultDouble),
            new CastDefinition<SimpleValue,ushort           >(SimpleDouble         , v => v, (ushort)DefaultDouble),
            new CastDefinition<SimpleValue,int              >(SimpleDouble         , v => v, (int   )DefaultDouble),
            new CastDefinition<SimpleValue,uint             >(SimpleDouble         , v => v, (uint  )DefaultDouble),
            new CastDefinition<SimpleValue,long             >(SimpleDouble         , v => v, (long  )DefaultDouble),
            new CastDefinition<SimpleValue,ulong            >(SimpleDouble         , v => v, (ulong )DefaultDouble),
            new CastDefinition<SimpleValue,float            >(SimpleDouble         , v => v, (float )DefaultDouble),
            new CastDefinition<SimpleValue,double           >(SimpleDouble         , v => v, (double)DefaultDouble),
            new CastDefinition<SimpleValue,char             >(SimpleDouble         , v => v, (char  )DefaultDouble),
            new CastDefinition<SimpleValue,DateTime         >(SimpleDouble         , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,DateTimeOffset   >(SimpleDouble         , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,TimeSpan         >(SimpleDouble         , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,Guid             >(SimpleDouble         , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,decimal          >(SimpleDouble         , v => v, (decimal)DefaultDouble),


            new CastDefinition<SimpleValue,bool             >(SimpleChar           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,sbyte            >(SimpleChar           , v => v, (sbyte  )DefaultChar ),
            new CastDefinition<SimpleValue,byte             >(SimpleChar           , v => v, (byte   )DefaultChar ),
            new CastDefinition<SimpleValue,short            >(SimpleChar           , v => v, (short  )DefaultChar ),
            new CastDefinition<SimpleValue,ushort           >(SimpleChar           , v => v, (ushort )DefaultChar ),
            new CastDefinition<SimpleValue,int              >(SimpleChar           , v => v, (int    )DefaultChar ),
            new CastDefinition<SimpleValue,uint             >(SimpleChar           , v => v, (uint   )DefaultChar ),
            new CastDefinition<SimpleValue,long             >(SimpleChar           , v => v, (long   )DefaultChar ),
            new CastDefinition<SimpleValue,ulong            >(SimpleChar           , v => v, (ulong  )DefaultChar ),
            new CastDefinition<SimpleValue,float            >(SimpleChar           , v => v, (float  )DefaultChar ),
            new CastDefinition<SimpleValue,double           >(SimpleChar           , v => v, (double )DefaultChar ),
            new CastDefinition<SimpleValue,char             >(SimpleChar           , v => v, (char   )DefaultChar ),
            new CastDefinition<SimpleValue,DateTime         >(SimpleChar           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,DateTimeOffset   >(SimpleChar           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,TimeSpan         >(SimpleChar           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,Guid             >(SimpleChar           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,decimal          >(SimpleChar           , v => v, (decimal)DefaultChar ),


            new CastDefinition<SimpleValue,bool             >(SimpleDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,sbyte            >(SimpleDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,byte             >(SimpleDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,short            >(SimpleDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,ushort           >(SimpleDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,int              >(SimpleDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,uint             >(SimpleDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,long             >(SimpleDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,ulong            >(SimpleDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,float            >(SimpleDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,double           >(SimpleDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,char             >(SimpleDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,DateTime         >(SimpleDateTime       , v => v, DefaultDateTime      ),
            new CastDefinition<SimpleValue,DateTimeOffset   >(SimpleDateTime       , v => v, (DateTimeOffset)DefaultDateTime),
            new CastDefinition<SimpleValue,TimeSpan         >(SimpleDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,Guid             >(SimpleDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,decimal          >(SimpleDateTime       , v => v, invalidCastException ),


            new CastDefinition<SimpleValue,bool             >(SimpleDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,sbyte            >(SimpleDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,byte             >(SimpleDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,short            >(SimpleDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,ushort           >(SimpleDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,int              >(SimpleDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,uint             >(SimpleDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,long             >(SimpleDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,ulong            >(SimpleDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,float            >(SimpleDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,double           >(SimpleDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,char             >(SimpleDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,DateTime         >(SimpleDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,DateTimeOffset   >(SimpleDateTimeOffset , v => v, DefaultDateTimeOffset),
            new CastDefinition<SimpleValue,TimeSpan         >(SimpleDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,Guid             >(SimpleDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,decimal          >(SimpleDateTimeOffset , v => v, invalidCastException ),


            new CastDefinition<SimpleValue,bool             >(SimpleTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,sbyte            >(SimpleTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,byte             >(SimpleTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,short            >(SimpleTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,ushort           >(SimpleTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,int              >(SimpleTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,uint             >(SimpleTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,long             >(SimpleTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,ulong            >(SimpleTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,float            >(SimpleTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,double           >(SimpleTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,char             >(SimpleTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,DateTime         >(SimpleTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,DateTimeOffset   >(SimpleTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,TimeSpan         >(SimpleTimeSpan       , v => v, DefaultTimeSpan      ),
            new CastDefinition<SimpleValue,Guid             >(SimpleTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,decimal          >(SimpleTimeSpan       , v => v, invalidCastException ),


            new CastDefinition<SimpleValue,bool             >(SimpleGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,sbyte            >(SimpleGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,byte             >(SimpleGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,short            >(SimpleGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,ushort           >(SimpleGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,int              >(SimpleGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,uint             >(SimpleGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,long             >(SimpleGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,ulong            >(SimpleGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,float            >(SimpleGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,double           >(SimpleGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,char             >(SimpleGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,DateTime         >(SimpleGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,DateTimeOffset   >(SimpleGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,TimeSpan         >(SimpleGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValue,Guid             >(SimpleGuid           , v => v, DefaultGuid          ),
            new CastDefinition<SimpleValue,decimal          >(SimpleGuid           , v => v, invalidCastException ),


            new CastDefinition<SimpleValue,bool             >(SimpleDecimal        , v => v, invalidCastException   ),
            new CastDefinition<SimpleValue,sbyte            >(SimpleDecimal        , v => v, (sbyte  )DefaultDecimal),
            new CastDefinition<SimpleValue,byte             >(SimpleDecimal        , v => v, (byte   )DefaultDecimal),
            new CastDefinition<SimpleValue,short            >(SimpleDecimal        , v => v, (short  )DefaultDecimal),
            new CastDefinition<SimpleValue,ushort           >(SimpleDecimal        , v => v, (ushort )DefaultDecimal),
            new CastDefinition<SimpleValue,int              >(SimpleDecimal        , v => v, (int    )DefaultDecimal),
            new CastDefinition<SimpleValue,uint             >(SimpleDecimal        , v => v, (uint   )DefaultDecimal),
            new CastDefinition<SimpleValue,long             >(SimpleDecimal        , v => v, (long   )DefaultDecimal),
            new CastDefinition<SimpleValue,ulong            >(SimpleDecimal        , v => v, (ulong  )DefaultDecimal),
            new CastDefinition<SimpleValue,float            >(SimpleDecimal        , v => v, (float  )DefaultDecimal),
            new CastDefinition<SimpleValue,double           >(SimpleDecimal        , v => v, (double )DefaultDecimal),
            new CastDefinition<SimpleValue,char             >(SimpleDecimal        , v => v, (char   )DefaultDecimal),
            new CastDefinition<SimpleValue,DateTime         >(SimpleDecimal        , v => v, invalidCastException   ),
            new CastDefinition<SimpleValue,DateTimeOffset   >(SimpleDecimal        , v => v, invalidCastException   ),
            new CastDefinition<SimpleValue,TimeSpan         >(SimpleDecimal        , v => v, invalidCastException   ),
            new CastDefinition<SimpleValue,Guid             >(SimpleDecimal        , v => v, invalidCastException   ),
            new CastDefinition<SimpleValue,decimal          >(SimpleDecimal        , v => v, (decimal)DefaultDecimal),
            
            #endregion From SimpleValue to every type

            #region From SimpleValueOr<String> to every type
            
            /*
            Casts matrix. 
                V : Allowed cast,
                - : Invalid cast,
                x : Impossible cast (compiler complains)

            +--------------------+-----------------------------------------------------------------------------+
            |From:|           To:|	1	2	3	4	5	6	7	8	9	10	11	12	13	14	15	16	17	18	19 |
            +--------------------+-----------------------------------------------------------------------------+
            |  1  |bool          |	V	-	-	-	-	-	-	-	-	-	-	-	-	-	-	-	- 	- 	V  |
            |  2  |sbyte         |	-	V	V	V	V	V	V	V	V	V	V	V	-	-	-	-	V 	- 	V  |
            |  3  |byte          |	-	V	V	V	V	V	V	V	V	V	V	V	-	-	-	-	V 	- 	V  |
            |  4  |short         |	-	V	V	V	V	V	V	V	V	V	V	V	-	-	-	-	V 	- 	V  |
            |  5  |ushort        |	-	V	V	V	V	V	V	V	V	V	V	V	-	-	-	-	V 	- 	V  |
            |  6  |int           |	-	V	V	V	V	V	V	V	V	V	V	V	-	-	-	-	V 	- 	V  |
            |  7  |uint          |	-	V	V	V	V	V	V	V	V	V	V	V	-	-	-	-	V 	- 	V  |
            |  8  |long          |	-	V	V	V	V	V	V	V	V	V	V	V	-	-	-	-	V 	- 	V  |
            |  9  |ulong         |	-	V	V	V	V	V	V	V	V	V	V	V	-	-	-	-	V 	- 	V  |
            | 10  |float         |	-	V	V	V	V	V	V	V	V	V	V	V	-	-	-	-	V 	- 	V  |
            | 11  |double        |	-	V	V	V	V	V	V	V	V	V	V	V	-	-	-	-	V 	- 	V  |
            | 12  |char          |	-	V	V	V	V	V	V	V	V	V	V	V	-	-	-	-	V 	- 	V  |
            | 13  |DateTime      |	-	-	-	-	-	-	-	-	-	-	-	-	V	V	-	-	- 	- 	V  |
            | 14  |DateTimeOffset|	-	-	-	-	-	-	-	-	-	-	-	-	-	V	-	-	- 	- 	V  |
            | 15  |TimeSpan      |	-	-	-	-	-	-	-	-	-	-	-	-	-	-	V	-	- 	- 	V  |
            | 16  |Guid          |	-	-	-	-	-	-	-	-	-	-	-	-	-	-	-	V	- 	- 	V  |
            | 17  |decimal       |	-	V	V	V	V	V	V	V	V	V	V	V	-	-	-	-	V 	- 	V  |
            | 18  |T             |	-	-	-	-	-	-	-	-	-	-	-	-	-	-	-	-	- 	V 	-  |
            | 19  |SimpleValue   |																	 	 	   |
            +--------------------+-----------------------------------------------------------------------------+
            */
            
            new CastDefinition<SimpleValueOr<String>,bool             >(SimpleOrTString         , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,sbyte            >(SimpleOrTString         , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,byte             >(SimpleOrTString         , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,short            >(SimpleOrTString         , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,ushort           >(SimpleOrTString         , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,int              >(SimpleOrTString         , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,uint             >(SimpleOrTString         , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,long             >(SimpleOrTString         , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,ulong            >(SimpleOrTString         , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,float            >(SimpleOrTString         , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,double           >(SimpleOrTString         , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,char             >(SimpleOrTString         , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,DateTime         >(SimpleOrTString         , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,DateTimeOffset   >(SimpleOrTString         , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,TimeSpan         >(SimpleOrTString         , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,Guid             >(SimpleOrTString         , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,decimal          >(SimpleOrTString         , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,string           >(SimpleOrTString         , v => v, DefaultString       ),


            new CastDefinition<SimpleValueOr<String>,SimpleValue      >(SimpleOrTBool           , v => v, SimpleBool          ),
            new CastDefinition<SimpleValueOr<String>,SimpleValue      >(SimpleOrTSByte          , v => v, SimpleSByte         ),
            new CastDefinition<SimpleValueOr<String>,SimpleValue      >(SimpleOrTByte           , v => v, SimpleByte          ),
            new CastDefinition<SimpleValueOr<String>,SimpleValue      >(SimpleOrTShort          , v => v, SimpleShort         ),
            new CastDefinition<SimpleValueOr<String>,SimpleValue      >(SimpleOrTUShort         , v => v, SimpleUShort        ),
            new CastDefinition<SimpleValueOr<String>,SimpleValue      >(SimpleOrTInt            , v => v, SimpleInt           ),
            new CastDefinition<SimpleValueOr<String>,SimpleValue      >(SimpleOrTUInt           , v => v, SimpleUInt          ),
            new CastDefinition<SimpleValueOr<String>,SimpleValue      >(SimpleOrTLong           , v => v, SimpleLong          ),
            new CastDefinition<SimpleValueOr<String>,SimpleValue      >(SimpleOrTULong          , v => v, SimpleULong         ),
            new CastDefinition<SimpleValueOr<String>,SimpleValue      >(SimpleOrTFloat          , v => v, SimpleFloat         ),
            new CastDefinition<SimpleValueOr<String>,SimpleValue      >(SimpleOrTDouble         , v => v, SimpleDouble        ),
            new CastDefinition<SimpleValueOr<String>,SimpleValue      >(SimpleOrTChar           , v => v, SimpleChar          ),
            new CastDefinition<SimpleValueOr<String>,SimpleValue      >(SimpleOrTDateTime       , v => v, SimpleDateTime      ),
            new CastDefinition<SimpleValueOr<String>,SimpleValue      >(SimpleOrTDateTimeOffset , v => v, SimpleDateTimeOffset),
            new CastDefinition<SimpleValueOr<String>,SimpleValue      >(SimpleOrTTimeSpan       , v => v, SimpleTimeSpan      ),
            new CastDefinition<SimpleValueOr<String>,SimpleValue      >(SimpleOrTGuid           , v => v, SimpleGuid          ),
            new CastDefinition<SimpleValueOr<String>,SimpleValue      >(SimpleOrTDecimal        , v => v, SimpleDecimal       ),
            new CastDefinition<SimpleValueOr<String>,SimpleValue      >(SimpleOrTString         , v => v, invalidCastException),


            new CastDefinition<SimpleValue,SimpleValueOr<String>      >(SimpleBool           , v => v, SimpleOrTBool          ),
            new CastDefinition<SimpleValue,SimpleValueOr<String>      >(SimpleSByte          , v => v, SimpleOrTSByte         ),
            new CastDefinition<SimpleValue,SimpleValueOr<String>      >(SimpleByte           , v => v, SimpleOrTByte          ),
            new CastDefinition<SimpleValue,SimpleValueOr<String>      >(SimpleShort          , v => v, SimpleOrTShort         ),
            new CastDefinition<SimpleValue,SimpleValueOr<String>      >(SimpleUShort         , v => v, SimpleOrTUShort        ),
            new CastDefinition<SimpleValue,SimpleValueOr<String>      >(SimpleInt            , v => v, SimpleOrTInt           ),
            new CastDefinition<SimpleValue,SimpleValueOr<String>      >(SimpleUInt           , v => v, SimpleOrTUInt          ),
            new CastDefinition<SimpleValue,SimpleValueOr<String>      >(SimpleLong           , v => v, SimpleOrTLong          ),
            new CastDefinition<SimpleValue,SimpleValueOr<String>      >(SimpleULong          , v => v, SimpleOrTULong         ),
            new CastDefinition<SimpleValue,SimpleValueOr<String>      >(SimpleFloat          , v => v, SimpleOrTFloat         ),
            new CastDefinition<SimpleValue,SimpleValueOr<String>      >(SimpleDouble         , v => v, SimpleOrTDouble        ),
            new CastDefinition<SimpleValue,SimpleValueOr<String>      >(SimpleChar           , v => v, SimpleOrTChar          ),
            new CastDefinition<SimpleValue,SimpleValueOr<String>      >(SimpleDateTime       , v => v, SimpleOrTDateTime      ),
            new CastDefinition<SimpleValue,SimpleValueOr<String>      >(SimpleDateTimeOffset , v => v, SimpleOrTDateTimeOffset),
            new CastDefinition<SimpleValue,SimpleValueOr<String>      >(SimpleTimeSpan       , v => v, SimpleOrTTimeSpan      ),
            new CastDefinition<SimpleValue,SimpleValueOr<String>      >(SimpleGuid           , v => v, SimpleOrTGuid          ),
            new CastDefinition<SimpleValue,SimpleValueOr<String>      >(SimpleDecimal        , v => v, SimpleOrTDecimal       ),


            new CastDefinition<SimpleValueOr<String>,bool             >(SimpleOrTBool           , v => v, DefaultBool),
            new CastDefinition<SimpleValueOr<String>,sbyte            >(SimpleOrTBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,byte             >(SimpleOrTBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,short            >(SimpleOrTBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,ushort           >(SimpleOrTBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,int              >(SimpleOrTBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,uint             >(SimpleOrTBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,long             >(SimpleOrTBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,ulong            >(SimpleOrTBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,float            >(SimpleOrTBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,double           >(SimpleOrTBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,char             >(SimpleOrTBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,DateTime         >(SimpleOrTBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,DateTimeOffset   >(SimpleOrTBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,TimeSpan         >(SimpleOrTBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,Guid             >(SimpleOrTBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,decimal          >(SimpleOrTBool           , v => v, invalidCastException),
            new CastDefinition<SimpleValueOr<String>,string           >(SimpleOrTBool           , v => v, invalidCastException),


            new CastDefinition<SimpleValueOr<String>,bool             >(SimpleOrTSByte          , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,sbyte            >(SimpleOrTSByte          , v => v, (sbyte  )DefaultSByte),
            new CastDefinition<SimpleValueOr<String>,byte             >(SimpleOrTSByte          , v => v, (byte   )DefaultSByte),
            new CastDefinition<SimpleValueOr<String>,short            >(SimpleOrTSByte          , v => v, (short  )DefaultSByte),
            new CastDefinition<SimpleValueOr<String>,ushort           >(SimpleOrTSByte          , v => v, (ushort )DefaultSByte),
            new CastDefinition<SimpleValueOr<String>,int              >(SimpleOrTSByte          , v => v, (int    )DefaultSByte),
            new CastDefinition<SimpleValueOr<String>,uint             >(SimpleOrTSByte          , v => v, (uint   )DefaultSByte),
            new CastDefinition<SimpleValueOr<String>,long             >(SimpleOrTSByte          , v => v, (long   )DefaultSByte),
            new CastDefinition<SimpleValueOr<String>,ulong            >(SimpleOrTSByte          , v => v, (ulong  )DefaultSByte),
            new CastDefinition<SimpleValueOr<String>,float            >(SimpleOrTSByte          , v => v, (float  )DefaultSByte),
            new CastDefinition<SimpleValueOr<String>,double           >(SimpleOrTSByte          , v => v, (double )DefaultSByte),
            new CastDefinition<SimpleValueOr<String>,char             >(SimpleOrTSByte          , v => v, (char   )DefaultSByte),
            new CastDefinition<SimpleValueOr<String>,DateTime         >(SimpleOrTSByte          , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,DateTimeOffset   >(SimpleOrTSByte          , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,TimeSpan         >(SimpleOrTSByte          , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,Guid             >(SimpleOrTSByte          , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,decimal          >(SimpleOrTSByte          , v => v, (decimal)DefaultSByte),
            new CastDefinition<SimpleValueOr<String>,string           >(SimpleOrTSByte          , v => v, invalidCastException),


            new CastDefinition<SimpleValueOr<String>,bool             >(SimpleOrTByte           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,sbyte            >(SimpleOrTByte           , v => v, (sbyte  )DefaultByte ),
            new CastDefinition<SimpleValueOr<String>,byte             >(SimpleOrTByte           , v => v, (byte   )DefaultByte ),
            new CastDefinition<SimpleValueOr<String>,short            >(SimpleOrTByte           , v => v, (short  )DefaultByte ),
            new CastDefinition<SimpleValueOr<String>,ushort           >(SimpleOrTByte           , v => v, (ushort )DefaultByte ),
            new CastDefinition<SimpleValueOr<String>,int              >(SimpleOrTByte           , v => v, (int    )DefaultByte ),
            new CastDefinition<SimpleValueOr<String>,uint             >(SimpleOrTByte           , v => v, (uint   )DefaultByte ),
            new CastDefinition<SimpleValueOr<String>,long             >(SimpleOrTByte           , v => v, (long   )DefaultByte ),
            new CastDefinition<SimpleValueOr<String>,ulong            >(SimpleOrTByte           , v => v, (ulong  )DefaultByte ),
            new CastDefinition<SimpleValueOr<String>,float            >(SimpleOrTByte           , v => v, (float  )DefaultByte ),
            new CastDefinition<SimpleValueOr<String>,double           >(SimpleOrTByte           , v => v, (double )DefaultByte ),
            new CastDefinition<SimpleValueOr<String>,char             >(SimpleOrTByte           , v => v, (char   )DefaultByte ),
            new CastDefinition<SimpleValueOr<String>,DateTime         >(SimpleOrTByte           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,DateTimeOffset   >(SimpleOrTByte           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,TimeSpan         >(SimpleOrTByte           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,Guid             >(SimpleOrTByte           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,decimal          >(SimpleOrTByte           , v => v, (decimal)DefaultByte ),
            new CastDefinition<SimpleValueOr<String>,string           >(SimpleOrTByte           , v => v, invalidCastException),


            new CastDefinition<SimpleValueOr<String>,bool             >(SimpleOrTShort          , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,sbyte            >(SimpleOrTShort          , v => v, (sbyte  )DefaultShort),
            new CastDefinition<SimpleValueOr<String>,byte             >(SimpleOrTShort          , v => v, (byte   )DefaultShort),
            new CastDefinition<SimpleValueOr<String>,short            >(SimpleOrTShort          , v => v, (short  )DefaultShort),
            new CastDefinition<SimpleValueOr<String>,ushort           >(SimpleOrTShort          , v => v, (ushort )DefaultShort),
            new CastDefinition<SimpleValueOr<String>,int              >(SimpleOrTShort          , v => v, (int    )DefaultShort),
            new CastDefinition<SimpleValueOr<String>,uint             >(SimpleOrTShort          , v => v, (uint   )DefaultShort),
            new CastDefinition<SimpleValueOr<String>,long             >(SimpleOrTShort          , v => v, (long   )DefaultShort),
            new CastDefinition<SimpleValueOr<String>,ulong            >(SimpleOrTShort          , v => v, (ulong  )DefaultShort),
            new CastDefinition<SimpleValueOr<String>,float            >(SimpleOrTShort          , v => v, (float  )DefaultShort),
            new CastDefinition<SimpleValueOr<String>,double           >(SimpleOrTShort          , v => v, (double )DefaultShort),
            new CastDefinition<SimpleValueOr<String>,char             >(SimpleOrTShort          , v => v, (char   )DefaultShort),
            new CastDefinition<SimpleValueOr<String>,DateTime         >(SimpleOrTShort          , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,DateTimeOffset   >(SimpleOrTShort          , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,TimeSpan         >(SimpleOrTShort          , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,Guid             >(SimpleOrTShort          , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,decimal          >(SimpleOrTShort          , v => v, (decimal)DefaultShort),
            new CastDefinition<SimpleValueOr<String>,string           >(SimpleOrTShort          , v => v, invalidCastException),


            new CastDefinition<SimpleValueOr<String>,bool             >(SimpleOrTUShort         , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,sbyte            >(SimpleOrTUShort         , v => v, (sbyte )DefaultUShort),
            new CastDefinition<SimpleValueOr<String>,byte             >(SimpleOrTUShort         , v => v, (byte  )DefaultUShort),
            new CastDefinition<SimpleValueOr<String>,short            >(SimpleOrTUShort         , v => v, (short )DefaultUShort),
            new CastDefinition<SimpleValueOr<String>,ushort           >(SimpleOrTUShort         , v => v, (ushort)DefaultUShort),
            new CastDefinition<SimpleValueOr<String>,int              >(SimpleOrTUShort         , v => v, (int   )DefaultUShort),
            new CastDefinition<SimpleValueOr<String>,uint             >(SimpleOrTUShort         , v => v, (uint  )DefaultUShort),
            new CastDefinition<SimpleValueOr<String>,long             >(SimpleOrTUShort         , v => v, (long  )DefaultUShort),
            new CastDefinition<SimpleValueOr<String>,ulong            >(SimpleOrTUShort         , v => v, (ulong )DefaultUShort),
            new CastDefinition<SimpleValueOr<String>,float            >(SimpleOrTUShort         , v => v, (float )DefaultUShort),
            new CastDefinition<SimpleValueOr<String>,double           >(SimpleOrTUShort         , v => v, (double)DefaultUShort),
            new CastDefinition<SimpleValueOr<String>,char             >(SimpleOrTUShort         , v => v, (char  )DefaultUShort),
            new CastDefinition<SimpleValueOr<String>,DateTime         >(SimpleOrTUShort         , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,DateTimeOffset   >(SimpleOrTUShort         , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,TimeSpan         >(SimpleOrTUShort         , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,Guid             >(SimpleOrTUShort         , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,decimal          >(SimpleOrTUShort         , v => v, (decimal)DefaultUShort),
            new CastDefinition<SimpleValueOr<String>,string           >(SimpleOrTUShort         , v => v, invalidCastException),


            new CastDefinition<SimpleValueOr<String>,bool             >(SimpleOrTInt            , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,sbyte            >(SimpleOrTInt            , v => v, (sbyte  )DefaultInt  ),
            new CastDefinition<SimpleValueOr<String>,byte             >(SimpleOrTInt            , v => v, (byte   )DefaultInt  ),
            new CastDefinition<SimpleValueOr<String>,short            >(SimpleOrTInt            , v => v, (short  )DefaultInt  ),
            new CastDefinition<SimpleValueOr<String>,ushort           >(SimpleOrTInt            , v => v, (ushort )DefaultInt  ),
            new CastDefinition<SimpleValueOr<String>,int              >(SimpleOrTInt            , v => v, (int    )DefaultInt  ),
            new CastDefinition<SimpleValueOr<String>,uint             >(SimpleOrTInt            , v => v, (uint   )DefaultInt  ),
            new CastDefinition<SimpleValueOr<String>,long             >(SimpleOrTInt            , v => v, (long   )DefaultInt  ),
            new CastDefinition<SimpleValueOr<String>,ulong            >(SimpleOrTInt            , v => v, (ulong  )DefaultInt  ),
            new CastDefinition<SimpleValueOr<String>,float            >(SimpleOrTInt            , v => v, (float  )DefaultInt  ),
            new CastDefinition<SimpleValueOr<String>,double           >(SimpleOrTInt            , v => v, (double )DefaultInt  ),
            new CastDefinition<SimpleValueOr<String>,char             >(SimpleOrTInt            , v => v, (char   )DefaultInt  ),
            new CastDefinition<SimpleValueOr<String>,DateTime         >(SimpleOrTInt            , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,DateTimeOffset   >(SimpleOrTInt            , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,TimeSpan         >(SimpleOrTInt            , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,Guid             >(SimpleOrTInt            , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,decimal          >(SimpleOrTInt            , v => v, (decimal)DefaultInt  ),
            new CastDefinition<SimpleValueOr<String>,string           >(SimpleOrTInt            , v => v, invalidCastException),


            new CastDefinition<SimpleValueOr<String>,bool             >(SimpleOrTUInt           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,sbyte            >(SimpleOrTUInt           , v => v, (sbyte  )DefaultUInt ),
            new CastDefinition<SimpleValueOr<String>,byte             >(SimpleOrTUInt           , v => v, (byte   )DefaultUInt ),
            new CastDefinition<SimpleValueOr<String>,short            >(SimpleOrTUInt           , v => v, (short  )DefaultUInt ),
            new CastDefinition<SimpleValueOr<String>,ushort           >(SimpleOrTUInt           , v => v, (ushort )DefaultUInt ),
            new CastDefinition<SimpleValueOr<String>,int              >(SimpleOrTUInt           , v => v, (int    )DefaultUInt ),
            new CastDefinition<SimpleValueOr<String>,uint             >(SimpleOrTUInt           , v => v, (uint   )DefaultUInt ),
            new CastDefinition<SimpleValueOr<String>,long             >(SimpleOrTUInt           , v => v, (long   )DefaultUInt ),
            new CastDefinition<SimpleValueOr<String>,ulong            >(SimpleOrTUInt           , v => v, (ulong  )DefaultUInt ),
            new CastDefinition<SimpleValueOr<String>,float            >(SimpleOrTUInt           , v => v, (float  )DefaultUInt ),
            new CastDefinition<SimpleValueOr<String>,double           >(SimpleOrTUInt           , v => v, (double )DefaultUInt ),
            new CastDefinition<SimpleValueOr<String>,char             >(SimpleOrTUInt           , v => v, (char   )DefaultUInt ),
            new CastDefinition<SimpleValueOr<String>,DateTime         >(SimpleOrTUInt           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,DateTimeOffset   >(SimpleOrTUInt           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,TimeSpan         >(SimpleOrTUInt           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,Guid             >(SimpleOrTUInt           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,decimal          >(SimpleOrTUInt           , v => v, (decimal)DefaultUInt ),
            new CastDefinition<SimpleValueOr<String>,string           >(SimpleOrTUInt           , v => v, invalidCastException),


            new CastDefinition<SimpleValueOr<String>,bool             >(SimpleOrTLong           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,sbyte            >(SimpleOrTLong           , v => v, (sbyte  )DefaultLong ),
            new CastDefinition<SimpleValueOr<String>,byte             >(SimpleOrTLong           , v => v, (byte   )DefaultLong ),
            new CastDefinition<SimpleValueOr<String>,short            >(SimpleOrTLong           , v => v, (short  )DefaultLong ),
            new CastDefinition<SimpleValueOr<String>,ushort           >(SimpleOrTLong           , v => v, (ushort )DefaultLong ),
            new CastDefinition<SimpleValueOr<String>,int              >(SimpleOrTLong           , v => v, (int    )DefaultLong ),
            new CastDefinition<SimpleValueOr<String>,uint             >(SimpleOrTLong           , v => v, (uint   )DefaultLong ),
            new CastDefinition<SimpleValueOr<String>,long             >(SimpleOrTLong           , v => v, (long   )DefaultLong ),
            new CastDefinition<SimpleValueOr<String>,ulong            >(SimpleOrTLong           , v => v, (ulong  )DefaultLong ),
            new CastDefinition<SimpleValueOr<String>,float            >(SimpleOrTLong           , v => v, (float  )DefaultLong ),
            new CastDefinition<SimpleValueOr<String>,double           >(SimpleOrTLong           , v => v, (double )DefaultLong ),
            new CastDefinition<SimpleValueOr<String>,char             >(SimpleOrTLong           , v => v, (char   )DefaultLong ),
            new CastDefinition<SimpleValueOr<String>,DateTime         >(SimpleOrTLong           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,DateTimeOffset   >(SimpleOrTLong           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,TimeSpan         >(SimpleOrTLong           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,Guid             >(SimpleOrTLong           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,decimal          >(SimpleOrTLong           , v => v, (decimal)DefaultLong ),
            new CastDefinition<SimpleValueOr<String>,string           >(SimpleOrTLong           , v => v, invalidCastException),


            new CastDefinition<SimpleValueOr<String>,bool             >(SimpleOrTULong          , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,sbyte            >(SimpleOrTULong          , v => v, (sbyte  )DefaultULong),
            new CastDefinition<SimpleValueOr<String>,byte             >(SimpleOrTULong          , v => v, (byte   )DefaultULong),
            new CastDefinition<SimpleValueOr<String>,short            >(SimpleOrTULong          , v => v, (short  )DefaultULong),
            new CastDefinition<SimpleValueOr<String>,ushort           >(SimpleOrTULong          , v => v, (ushort )DefaultULong),
            new CastDefinition<SimpleValueOr<String>,int              >(SimpleOrTULong          , v => v, (int    )DefaultULong),
            new CastDefinition<SimpleValueOr<String>,uint             >(SimpleOrTULong          , v => v, (uint   )DefaultULong),
            new CastDefinition<SimpleValueOr<String>,long             >(SimpleOrTULong          , v => v, (long   )DefaultULong),
            new CastDefinition<SimpleValueOr<String>,ulong            >(SimpleOrTULong          , v => v, (ulong  )DefaultULong),
            new CastDefinition<SimpleValueOr<String>,float            >(SimpleOrTULong          , v => v, (float  )DefaultULong),
            new CastDefinition<SimpleValueOr<String>,double           >(SimpleOrTULong          , v => v, (double )DefaultULong),
            new CastDefinition<SimpleValueOr<String>,char             >(SimpleOrTULong          , v => v, (char   )DefaultULong),
            new CastDefinition<SimpleValueOr<String>,DateTime         >(SimpleOrTULong          , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,DateTimeOffset   >(SimpleOrTULong          , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,TimeSpan         >(SimpleOrTULong          , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,Guid             >(SimpleOrTULong          , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,decimal          >(SimpleOrTULong          , v => v, (decimal)DefaultULong),
            new CastDefinition<SimpleValueOr<String>,string           >(SimpleOrTULong          , v => v, invalidCastException),


            new CastDefinition<SimpleValueOr<String>,bool             >(SimpleOrTFloat          , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,sbyte            >(SimpleOrTFloat          , v => v, (sbyte  )DefaultFloat),
            new CastDefinition<SimpleValueOr<String>,byte             >(SimpleOrTFloat          , v => v, (byte   )DefaultFloat),
            new CastDefinition<SimpleValueOr<String>,short            >(SimpleOrTFloat          , v => v, (short  )DefaultFloat),
            new CastDefinition<SimpleValueOr<String>,ushort           >(SimpleOrTFloat          , v => v, (ushort )DefaultFloat),
            new CastDefinition<SimpleValueOr<String>,int              >(SimpleOrTFloat          , v => v, (int    )DefaultFloat),
            new CastDefinition<SimpleValueOr<String>,uint             >(SimpleOrTFloat          , v => v, (uint   )DefaultFloat),
            new CastDefinition<SimpleValueOr<String>,long             >(SimpleOrTFloat          , v => v, (long   )DefaultFloat),
            new CastDefinition<SimpleValueOr<String>,ulong            >(SimpleOrTFloat          , v => v, (ulong  )DefaultFloat),
            new CastDefinition<SimpleValueOr<String>,float            >(SimpleOrTFloat          , v => v, (float  )DefaultFloat),
            new CastDefinition<SimpleValueOr<String>,double           >(SimpleOrTFloat          , v => v, (double )DefaultFloat),
            new CastDefinition<SimpleValueOr<String>,char             >(SimpleOrTFloat          , v => v, (char   )DefaultFloat),
            new CastDefinition<SimpleValueOr<String>,DateTime         >(SimpleOrTFloat          , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,DateTimeOffset   >(SimpleOrTFloat          , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,TimeSpan         >(SimpleOrTFloat          , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,Guid             >(SimpleOrTFloat          , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,decimal          >(SimpleOrTFloat          , v => v, (decimal)DefaultFloat),
            new CastDefinition<SimpleValueOr<String>,string           >(SimpleOrTFloat          , v => v, invalidCastException),


            new CastDefinition<SimpleValueOr<String>,bool             >(SimpleOrTDouble         , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,sbyte            >(SimpleOrTDouble         , v => v, (sbyte )DefaultDouble),
            new CastDefinition<SimpleValueOr<String>,byte             >(SimpleOrTDouble         , v => v, (byte  )DefaultDouble),
            new CastDefinition<SimpleValueOr<String>,short            >(SimpleOrTDouble         , v => v, (short )DefaultDouble),
            new CastDefinition<SimpleValueOr<String>,ushort           >(SimpleOrTDouble         , v => v, (ushort)DefaultDouble),
            new CastDefinition<SimpleValueOr<String>,int              >(SimpleOrTDouble         , v => v, (int   )DefaultDouble),
            new CastDefinition<SimpleValueOr<String>,uint             >(SimpleOrTDouble         , v => v, (uint  )DefaultDouble),
            new CastDefinition<SimpleValueOr<String>,long             >(SimpleOrTDouble         , v => v, (long  )DefaultDouble),
            new CastDefinition<SimpleValueOr<String>,ulong            >(SimpleOrTDouble         , v => v, (ulong )DefaultDouble),
            new CastDefinition<SimpleValueOr<String>,float            >(SimpleOrTDouble         , v => v, (float )DefaultDouble),
            new CastDefinition<SimpleValueOr<String>,double           >(SimpleOrTDouble         , v => v, (double)DefaultDouble),
            new CastDefinition<SimpleValueOr<String>,char             >(SimpleOrTDouble         , v => v, (char  )DefaultDouble),
            new CastDefinition<SimpleValueOr<String>,DateTime         >(SimpleOrTDouble         , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,DateTimeOffset   >(SimpleOrTDouble         , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,TimeSpan         >(SimpleOrTDouble         , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,Guid             >(SimpleOrTDouble         , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,decimal          >(SimpleOrTDouble         , v => v, (decimal)DefaultDouble),
            new CastDefinition<SimpleValueOr<String>,string           >(SimpleOrTDouble         , v => v, invalidCastException),


            new CastDefinition<SimpleValueOr<String>,bool             >(SimpleOrTChar           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,sbyte            >(SimpleOrTChar           , v => v, (sbyte  )DefaultChar ),
            new CastDefinition<SimpleValueOr<String>,byte             >(SimpleOrTChar           , v => v, (byte   )DefaultChar ),
            new CastDefinition<SimpleValueOr<String>,short            >(SimpleOrTChar           , v => v, (short  )DefaultChar ),
            new CastDefinition<SimpleValueOr<String>,ushort           >(SimpleOrTChar           , v => v, (ushort )DefaultChar ),
            new CastDefinition<SimpleValueOr<String>,int              >(SimpleOrTChar           , v => v, (int    )DefaultChar ),
            new CastDefinition<SimpleValueOr<String>,uint             >(SimpleOrTChar           , v => v, (uint   )DefaultChar ),
            new CastDefinition<SimpleValueOr<String>,long             >(SimpleOrTChar           , v => v, (long   )DefaultChar ),
            new CastDefinition<SimpleValueOr<String>,ulong            >(SimpleOrTChar           , v => v, (ulong  )DefaultChar ),
            new CastDefinition<SimpleValueOr<String>,float            >(SimpleOrTChar           , v => v, (float  )DefaultChar ),
            new CastDefinition<SimpleValueOr<String>,double           >(SimpleOrTChar           , v => v, (double )DefaultChar ),
            new CastDefinition<SimpleValueOr<String>,char             >(SimpleOrTChar           , v => v, (char   )DefaultChar ),
            new CastDefinition<SimpleValueOr<String>,DateTime         >(SimpleOrTChar           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,DateTimeOffset   >(SimpleOrTChar           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,TimeSpan         >(SimpleOrTChar           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,Guid             >(SimpleOrTChar           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,decimal          >(SimpleOrTChar           , v => v, (decimal)DefaultChar ),
            new CastDefinition<SimpleValueOr<String>,string           >(SimpleOrTChar           , v => v, invalidCastException),


            new CastDefinition<SimpleValueOr<String>,bool             >(SimpleOrTDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,sbyte            >(SimpleOrTDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,byte             >(SimpleOrTDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,short            >(SimpleOrTDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,ushort           >(SimpleOrTDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,int              >(SimpleOrTDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,uint             >(SimpleOrTDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,long             >(SimpleOrTDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,ulong            >(SimpleOrTDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,float            >(SimpleOrTDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,double           >(SimpleOrTDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,char             >(SimpleOrTDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,DateTime         >(SimpleOrTDateTime       , v => v, DefaultDateTime      ),
            new CastDefinition<SimpleValueOr<String>,DateTimeOffset   >(SimpleOrTDateTime       , v => v, (DateTimeOffset)DefaultDateTime),
            new CastDefinition<SimpleValueOr<String>,TimeSpan         >(SimpleOrTDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,Guid             >(SimpleOrTDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,decimal          >(SimpleOrTDateTime       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,string           >(SimpleOrTDateTime       , v => v, invalidCastException),


            new CastDefinition<SimpleValueOr<String>,bool             >(SimpleOrTDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,sbyte            >(SimpleOrTDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,byte             >(SimpleOrTDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,short            >(SimpleOrTDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,ushort           >(SimpleOrTDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,int              >(SimpleOrTDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,uint             >(SimpleOrTDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,long             >(SimpleOrTDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,ulong            >(SimpleOrTDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,float            >(SimpleOrTDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,double           >(SimpleOrTDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,char             >(SimpleOrTDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,DateTime         >(SimpleOrTDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,DateTimeOffset   >(SimpleOrTDateTimeOffset , v => v, DefaultDateTimeOffset),
            new CastDefinition<SimpleValueOr<String>,TimeSpan         >(SimpleOrTDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,Guid             >(SimpleOrTDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,decimal          >(SimpleOrTDateTimeOffset , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,string           >(SimpleOrTDateTimeOffset , v => v, invalidCastException),


            new CastDefinition<SimpleValueOr<String>,bool             >(SimpleOrTTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,sbyte            >(SimpleOrTTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,byte             >(SimpleOrTTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,short            >(SimpleOrTTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,ushort           >(SimpleOrTTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,int              >(SimpleOrTTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,uint             >(SimpleOrTTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,long             >(SimpleOrTTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,ulong            >(SimpleOrTTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,float            >(SimpleOrTTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,double           >(SimpleOrTTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,char             >(SimpleOrTTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,DateTime         >(SimpleOrTTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,DateTimeOffset   >(SimpleOrTTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,TimeSpan         >(SimpleOrTTimeSpan       , v => v, DefaultTimeSpan      ),
            new CastDefinition<SimpleValueOr<String>,Guid             >(SimpleOrTTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,decimal          >(SimpleOrTTimeSpan       , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,string           >(SimpleOrTTimeSpan       , v => v, invalidCastException),


            new CastDefinition<SimpleValueOr<String>,bool             >(SimpleOrTGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,sbyte            >(SimpleOrTGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,byte             >(SimpleOrTGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,short            >(SimpleOrTGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,ushort           >(SimpleOrTGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,int              >(SimpleOrTGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,uint             >(SimpleOrTGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,long             >(SimpleOrTGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,ulong            >(SimpleOrTGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,float            >(SimpleOrTGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,double           >(SimpleOrTGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,char             >(SimpleOrTGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,DateTime         >(SimpleOrTGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,DateTimeOffset   >(SimpleOrTGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,TimeSpan         >(SimpleOrTGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,Guid             >(SimpleOrTGuid           , v => v, DefaultGuid          ),
            new CastDefinition<SimpleValueOr<String>,decimal          >(SimpleOrTGuid           , v => v, invalidCastException ),
            new CastDefinition<SimpleValueOr<String>,string           >(SimpleOrTGuid           , v => v, invalidCastException),


            new CastDefinition<SimpleValueOr<String>,bool             >(SimpleOrTDecimal        , v => v, invalidCastException   ),
            new CastDefinition<SimpleValueOr<String>,sbyte            >(SimpleOrTDecimal        , v => v, (sbyte  )DefaultDecimal),
            new CastDefinition<SimpleValueOr<String>,byte             >(SimpleOrTDecimal        , v => v, (byte   )DefaultDecimal),
            new CastDefinition<SimpleValueOr<String>,short            >(SimpleOrTDecimal        , v => v, (short  )DefaultDecimal),
            new CastDefinition<SimpleValueOr<String>,ushort           >(SimpleOrTDecimal        , v => v, (ushort )DefaultDecimal),
            new CastDefinition<SimpleValueOr<String>,int              >(SimpleOrTDecimal        , v => v, (int    )DefaultDecimal),
            new CastDefinition<SimpleValueOr<String>,uint             >(SimpleOrTDecimal        , v => v, (uint   )DefaultDecimal),
            new CastDefinition<SimpleValueOr<String>,long             >(SimpleOrTDecimal        , v => v, (long   )DefaultDecimal),
            new CastDefinition<SimpleValueOr<String>,ulong            >(SimpleOrTDecimal        , v => v, (ulong  )DefaultDecimal),
            new CastDefinition<SimpleValueOr<String>,float            >(SimpleOrTDecimal        , v => v, (float  )DefaultDecimal),
            new CastDefinition<SimpleValueOr<String>,double           >(SimpleOrTDecimal        , v => v, (double )DefaultDecimal),
            new CastDefinition<SimpleValueOr<String>,char             >(SimpleOrTDecimal        , v => v, (char   )DefaultDecimal),
            new CastDefinition<SimpleValueOr<String>,DateTime         >(SimpleOrTDecimal        , v => v, invalidCastException   ),
            new CastDefinition<SimpleValueOr<String>,DateTimeOffset   >(SimpleOrTDecimal        , v => v, invalidCastException   ),
            new CastDefinition<SimpleValueOr<String>,TimeSpan         >(SimpleOrTDecimal        , v => v, invalidCastException   ),
            new CastDefinition<SimpleValueOr<String>,Guid             >(SimpleOrTDecimal        , v => v, invalidCastException   ),
            new CastDefinition<SimpleValueOr<String>,decimal          >(SimpleOrTDecimal        , v => v, (decimal)DefaultDecimal),
            new CastDefinition<SimpleValueOr<String>,string           >(SimpleOrTDecimal        , v => v, invalidCastException),
            
            #endregion From SimpleValueOr<String> to every type
        };

        /// <summary>
        /// Get valid casts from the specified type as a collection of <see cref="TestCaseData"/>s.
        /// </summary>
        public static IEnumerable<TestCaseData> GetValidCasts(Type fromType)
        {
            return CastSamples.AllCasts
                .Where(cst => cst.IsValid && cst.From == fromType)
                .Select(cst => cst.ToTestCase());
        }

        /// <summary>
        /// Get invalid casts from the specified type as a collection of <see cref="TestCaseData"/>s.
        /// </summary>
        public static IEnumerable<TestCaseData> GetInvalidCasts(Type fromType)
        {
            return CastSamples.AllCasts
                .Where(cst => !cst.IsValid && cst.From == fromType)
                .Select(cst => cst.ToTestCase());
        }
    }
}
