using System.Linq;

namespace Inlämning1.Utility
{
    internal static class Verify
    {
        /// <summary>
        /// verify a single input to check if it is null/less than zero
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal static bool VerifyNull(float number)
        {
            if (number < 0)
            {
                return false;
            }
            return number != 0;
        }
        /// <summary>
        /// verify two inputs to check if any are null/less than zero
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        internal static bool VerifyNull(float height, float width)
        {
            if (height < 0 || width < 0)
            {
                return false;
            }
            return height != 0 && width != 0;
        }
        /// <summary>
        /// verify a single input to check if it is a number
        /// </summary>
        /// <param name="side"></param>
        /// <returns></returns>
        internal static bool IsNumber(float side)
        {
            return side.GetType() == typeof(float);
        }
        /// <summary>
        /// Verify two inputs to check if they are all numbers
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        internal static bool IsNumber(float height, float width)
        {
            return height.GetType() == typeof(float) && width.GetType() == typeof(float);
        }
    }
}
