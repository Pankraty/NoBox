using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pankraty.NoBox.Tests.Common
{
    public static class CastSamples
    {
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

        #endregion Default Values

        #region Simple Values

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

        #endregion Simple Values

        private static Type invalidCastException = typeof(InvalidCastException);

        /// <summary>
        /// All casts that have to covered with unit tests
        /// </summary>
        private static CastDefinition[] AllCasts =
        {
            #region From SimpleValue to every type

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
