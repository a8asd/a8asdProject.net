﻿using NUnit.Framework;
using TheProject.Test.Features;

namespace TheProject.Test.Unit
{
    public class LocationTest
    {
        [Test]
        public void DistanceBetweenSameLocationIsZero()
        {
            LuberLocation from = new LuberLocation(23,24);
            LuberLocation to = new LuberLocation(23,24);
            Assert.AreEqual(0,from.Distance(to));
        }

        [Test]
        public void DistanceBetweenOneDegreeEachWay()
        {
            var from = new LuberLocation(1.0,1.0);
            var to = new LuberLocation(2.0,2.0);
            Assert.AreEqual(128.129,from.Distance(to),.001);
        }

        [Test]
        public void LondonToBristol()
        {
            var from = new LuberLocation(51.5656944, -0.10395);
            var to = new LuberLocation(51.44931, -2.601203);
            Assert.AreEqual(160.345, from.Distance(to),.001);
        }
    }
}
