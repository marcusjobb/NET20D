using System;
using System.Collections.Generic;
using TDD_Nicklas.Interfaces;

namespace TDD_Nicklas.Utility
{
    /// <summary>
    /// Checks the input for the geometric objects constructor to see
    /// if the given input is a usable number for its calculations.
    /// Test Scenario-ID = TS_CheckInputTest_01
    /// </summary>
    public static class CheckInput
    {
        /// <summary>
        /// 1. Checks if user input is number.
        /// 2. Checks if number is not null/default.
        /// </summary>
        /// <param name="input">Input to check against.</param>
        /// <returns>Boolean.</returns>
        public static bool IsValidNumber(params dynamic[] input)
        {
            if (input != null)
            {
                var validInputs = new List<bool>();
                for (int i = 0; i < input.Length; i++)
                {
                    bool isNumber = IsNumber(input[i]);
                    bool isNotNegative = IsNotNegative(input[i], isNumber);
                    bool isMaxValue = IsMaxValue(input[i], isNumber);
                    bool isNotEmpty = IsNotEmpty(input[i], isNotNegative);
                    if (isNumber && isNotNegative && isMaxValue && isNotEmpty) { validInputs.Add(true); }
                    else { validInputs.Add(false); }
                }

                return !validInputs.Contains(false);
            }
            else { return false; }
        }

        /// <summary>
        /// Checks if the input is a number of any of the TypeCodes down below.
        /// If input is a number it passes.
        /// If input is an object it passes.
        /// If not, it fails.
        /// </summary>
        /// <param name="input">Input to be tested.</param>
        /// <returns>Boolean.</returns>
        private static bool IsNumber(dynamic input)
        {
            if (input != null)
            {
                switch (Type.GetTypeCode(input.GetType()))
                {
                    case TypeCode.Byte:
                    case TypeCode.SByte:
                    case TypeCode.UInt16:
                    case TypeCode.UInt32:
                    case TypeCode.UInt64:
                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                    case TypeCode.Decimal:
                    case TypeCode.Double:
                    case TypeCode.Single:
                    case TypeCode.Object:
                        return true;
                    default:
                        return false;
                }
            }
            else { return false; }
        }

        /// <summary>
        /// Checks if the input given is not a negative number.
        /// </summary>
        /// <param name="input">Input to be tested.</param>
        /// <param name="isNumber"></param>
        /// <returns>Boolean.</returns>
        private static bool IsNotNegative(dynamic input, bool isNumber) => input is IGeoObjectable || (isNumber && (float)input >= 0);

        /// <summary>
        /// Checks if the input given is not max value.
        /// </summary>
        /// <param name="input">Input to be tested.</param>
        /// <returns>Boolean.</returns>
        private static bool IsMaxValue(dynamic input, bool isNumber) { return input is IGeoObjectable || (isNumber && input < float.MaxValue); }

        /// <summary>
        /// Checks if the input given is not null or default.
        /// </summary>
        /// <param name="input">Input to be tested.</param>
        /// <param name="isNumber">Boolean.</param>
        /// <returns>Boolean.</returns>
        private static bool IsNotEmpty(dynamic input, bool isNumber) => input is IGeoObjectable || (isNumber && (float)input != default && input != null && input != 0);
    }
}