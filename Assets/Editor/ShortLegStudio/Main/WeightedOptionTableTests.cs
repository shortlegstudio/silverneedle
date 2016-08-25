﻿// //-----------------------------------------------------------------------
// // <copyright file="WeightedOptionTableTests.cs" company="Short Leg Studio, LLC">
// //     Copyright (c) Short Leg Studio, LLC. All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------
using System;
using NUnit.Framework;
using System.Linq;
using ShortLegStudio;

namespace Main.Utility
{
    [TestFixture]
    public class WeightedOptionTableTests
    {
        [Test]
        public void CanAddOptionsAndItTracksTheRanges()
        {
            var table = new WeightedOptionTable<string>();
            table.AddEntry("Foo", 30);
            table.AddEntry("Bar", 20);
            table.AddEntry("Woo", 3);

            var options = table.All().ToArray();
            Assert.AreEqual(3, options.Count());
            Assert.AreEqual(30, options[0].MaximumValue);
            Assert.AreEqual(50, options[1].MaximumValue);
            Assert.AreEqual(31, options[1].MinimumValue);
        }

        [Test]
        public void PullsAnOptionOutBasedOnWeightedValue()
        {
            var table = new WeightedOptionTable<string>();
            table.AddEntry("Foo", 30);
            table.AddEntry("Bar", 20);
            table.AddEntry("Woo", 3);

            Assert.AreEqual("Foo", table.GetOption(23));
            Assert.AreEqual("Bar", table.GetOption(31));
            Assert.AreEqual("Woo", table.GetOption(53));
        }

        [Test]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ThrowsAnExceptionIfValueDoesNotMeetExpectations()
        {
            var table = new WeightedOptionTable<string>();
            table.AddEntry("Foo", 30);
            table.AddEntry("Bar", 20);
            table.GetOption(160);
        }

        [Test]
        public void RandomlySelectsOptionBasedOnWeightedValue()
        {
            var table = new WeightedOptionTable<string>();
            table.AddEntry("Foo", 30);
            table.AddEntry("Bar", 10);

            var foo = 0;
            var bar = 0;
            // Run ten thousand times and it should select FOO a few more times
            for (int i = 0; i < 10000; i++)
            {
                string option = table.ChooseRandomly();
                if (option == "Foo")
                {
                    foo++;
                }
                else
                {
                    bar++;
                }
                    
            }
        }
    }
}

