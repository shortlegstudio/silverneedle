﻿//-----------------------------------------------------------------------
// <copyright file="MeasureConversions.cs" company="Short Leg Studio, LLC">
//     Copyright (c) Short Leg Studio, LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SilverNeedle
{
    using System.Collections;
    using UnityEngine;

    /// <summary>
    /// Provides routines for converting measurements to and from readable formats
    /// </summary>
    public static class MeasureConversions  
    {
        /// <summary>
        /// Converts a measurement of inches into a string representation of Feet' Inches"
        /// </summary>
        /// <returns>The measurement in feat</returns>
        /// <param name="val">The value in inches</param>
        public static string InchesToFeetString(int val) 
        {
            var mod = val % 12;
            var ft = val / 12;
            return string.Format("{0}' {1}\"", ft, mod);
        }

        /// <summary>
        /// Converts a measurement of inches into a string representation of Feet' Inches"
        /// </summary>
        /// <returns>The measurement in feat</returns>
        /// <param name="val">The value in inches.</param>
        public static string InchesToFeetString(float val) 
        {
            var mod = val % 12;
            var ft = val / 12;
            return string.Format("{0}' {1}\"", ft, mod);
        }

        public static string ToInchesAndFeet(this int val) 
        {
            return InchesToFeetString(val);
        }

        public static string ToInchesAndFeet(this float val)
        {
            return InchesToFeetString(val);
        }

        public static string ToPoundsString(this int value)
        {
            return string.Format("{0} lbs", value);
        }

    }
}
