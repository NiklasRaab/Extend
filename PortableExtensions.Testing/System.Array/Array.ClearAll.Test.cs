﻿#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ArrayExTest
    {
        [Test]
        public void ClearAllTestCase ()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };
            array.ClearAll();

            Assert.AreEqual( null, array.GetValue( 0 ) );
            Assert.AreEqual( null, array.GetValue( 1 ) );
            Assert.AreEqual( null, array.GetValue( 2 ) );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ClearAllTestCaseNullCheck ()
        {
            Array array = null;
            array.ClearAll();
        }
    }
}