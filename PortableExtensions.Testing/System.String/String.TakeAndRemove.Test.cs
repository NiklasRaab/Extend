﻿#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void TakeAndRemoveTestCase ()
        {
            var value = "Test";
            var actual = 2.TakeAndRemove( ref value );

            Assert.AreEqual( "Te", actual );
            Assert.AreEqual( "st", value );
        }

        [Test]
        public void TakeAndRemoveTestCase1 ()
        {
            var value = "Test";
            var actual = 4.TakeAndRemove( ref value );

            Assert.AreEqual( "Test", actual );
            Assert.AreEqual( String.Empty, value );
        }

        [Test]
        public void TakeAndRemoveTestCase2 ()
        {
            var value = "    ";
            var actual = 2.TakeAndRemove( ref value );

            Assert.AreEqual( "  ", actual );
            Assert.AreEqual( "  ", value );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentOutOfRangeException) )]
        public void TakeAndRemoveTestCaseArgumentOutOfRangeException ()
        {
            var value = "Test";
            var actual = 5.TakeAndRemove( ref value );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void TakeAndRemoveTestCaseNullCheck ()
        {
            String value = null;
            var actual = 2.TakeAndRemove( ref value );
        }
    }
}