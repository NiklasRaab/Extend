﻿#region Using

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [TestCase]
        public void MaximumTestCase()
        {
            var actual = 1.Maximum( 2, 3, 4, 5, 6 );
            Assert.AreEqual( 6, actual );

            actual = 100.Maximum( 2, 3, 4, 5, 6 );
            Assert.AreEqual( 100, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void MaximumTestCaseNullCheck()
        {
            10.Maximum( null );
        }

        [TestCase]
        public void MaximumTestCase1()
        {
            var actual = 1.Maximum( x => x.ToString( CultureInfo.InvariantCulture ), 2, 3, 4, 5, 6 );
            Assert.AreEqual( "6", actual );

            actual = 100.Maximum( x => x.ToString( CultureInfo.InvariantCulture ), 2, 3, 4, 5, 6 );
            Assert.AreEqual( "6", actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void MaximumTestCase1NullCheck()
        {
            10.Maximum( x => x.ToString( CultureInfo.InvariantCulture ), null );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void MaximumTestCase1NullCheck1()
        {
            Func<Int32, Object> func = null;
            10.Maximum( func, 1, 2, 3, 4, 5 );
        }
    }
}