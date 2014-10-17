﻿#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class IDictionaryExTest
    {
        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void GetOrAddCase1NullCheck ()
        {
            IDictionaryEx.GetOrAdd( null, new KeyValuePair<Object, Object>( new Object(), new Object() ) );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void GetOrAddCase1NullCheck1 ()
        {
            new Dictionary<Object, Object>().GetOrAdd( new KeyValuePair<Object, Object>( null, new Object() ) );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void GetOrAddCase2NullCheck ()
        {
            IDictionaryEx.GetOrAdd( null, new Object(), () => new Object() );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void GetOrAddCase2NullCheck1 ()
        {
            new Dictionary<Object, Object>().GetOrAdd( null, () => new Object() );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void GetOrAddCase2NullCheck2 ()
        {
            Func<Object> func = null;
            new Dictionary<Object, Object>().GetOrAdd( new Object(), func );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void GetOrAddCase3NullCheck ()
        {
            IDictionaryEx.GetOrAdd( null, new Object(), x => new Object() );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void GetOrAddCase3NullCheck1 ()
        {
            new Dictionary<Object, Object>().GetOrAdd( null, x => new Object() );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void GetOrAddCase3NullCheck2 ()
        {
            Func<Object, Object> func = null;
            new Dictionary<Object, Object>().GetOrAdd( new Object(), func );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void GetOrAddCaseNullCheck ()
        {
            IDictionaryEx.GetOrAdd( null, new Object(), new Object() );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void GetOrAddCaseNullCheck1 ()
        {
            new Dictionary<Object, Object>().GetOrAdd( null, new Object() );
        }

        [Test]
        public void GetOrAddTestCase ()
        {
            var dictionary = new Dictionary<String, String>();
            var key = RandomValueEx.GetRandomString();
            var value = RandomValueEx.GetRandomString();

            var actual = dictionary.GetOrAdd( key, value );
            Assert.AreEqual( value, actual );
            Assert.IsTrue( dictionary.Contains( new KeyValuePair<String, String>( key, value ) ) );
            Assert.AreEqual( 1, dictionary.Count );

            actual = dictionary.GetOrAdd( key, value );
            Assert.AreEqual( value, actual );
            Assert.IsTrue( dictionary.Contains( new KeyValuePair<String, String>( key, value ) ) );
            Assert.AreEqual( 1, dictionary.Count );
        }

        [Test]
        public void GetOrAddTestCase1 ()
        {
            var dictionary = new Dictionary<String, String>();
            var keyValuePair = new KeyValuePair<String, String>( RandomValueEx.GetRandomString(),
                                                                 RandomValueEx.GetRandomString() );

            var actual = dictionary.GetOrAdd( keyValuePair );
            Assert.AreEqual( keyValuePair.Value, actual );
            Assert.IsTrue( dictionary.Contains( keyValuePair ) );
            Assert.AreEqual( 1, dictionary.Count );

            actual = dictionary.GetOrAdd( keyValuePair );
            Assert.AreEqual( keyValuePair.Value, actual );
            Assert.IsTrue( dictionary.Contains( keyValuePair ) );
            Assert.AreEqual( 1, dictionary.Count );
        }

        [Test]
        public void GetOrAddTestCase2 ()
        {
            var dictionary = new Dictionary<String, String>();
            var key = RandomValueEx.GetRandomString();
            var value = RandomValueEx.GetRandomString();

            var actual = dictionary.GetOrAdd( key, () => value );
            Assert.AreEqual( value, actual );
            Assert.IsTrue( dictionary.Contains( new KeyValuePair<String, String>( key, value ) ) );
            Assert.AreEqual( 1, dictionary.Count );

            actual = dictionary.GetOrAdd( key, () => value );
            Assert.AreEqual( value, actual );
            Assert.IsTrue( dictionary.Contains( new KeyValuePair<String, String>( key, value ) ) );
            Assert.AreEqual( 1, dictionary.Count );
        }

        [Test]
        public void GetOrAddTestCase3 ()
        {
            var dictionary = new Dictionary<String, String>();
            var key = RandomValueEx.GetRandomString();
            var value = RandomValueEx.GetRandomString();

            var actual = dictionary.GetOrAdd( key, x => value );
            Assert.AreEqual( value, actual );
            Assert.IsTrue( dictionary.Contains( new KeyValuePair<String, String>( key, value ) ) );
            Assert.AreEqual( 1, dictionary.Count );

            actual = dictionary.GetOrAdd( key, x => value );
            Assert.AreEqual( value, actual );
            Assert.IsTrue( dictionary.Contains( new KeyValuePair<String, String>( key, value ) ) );
            Assert.AreEqual( 1, dictionary.Count );
        }
    }
}

/*

		public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> valueFactory)
		{
			dictionary.ThrowIfNull (() => dictionary);
			valueFactory.ThrowIfNull (() => valueFactory);

			if (!dictionary.ContainsKey(key))
				dictionary.Add(key, valueFactory(key));

			return dictionary[key];
		}*/