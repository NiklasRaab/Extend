﻿#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class TimeSpanExTest
    {
        [Test]
        public void FutureTestCase ()
        {
            var expected = DateTime.Now.Add( TimeSpan.FromDays( 1 ) );
            var actual = TimeSpan.FromDays( 1 ).Future();

            Assert.AreEqual( expected.Day, actual.Day );
        }
    }
}