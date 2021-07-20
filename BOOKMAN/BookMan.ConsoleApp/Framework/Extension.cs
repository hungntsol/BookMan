namespace BookMan.ConsoleApp.Framework
{
    public class Extension
    {
        /// <summary>
        /// Convert string to Int32
        /// </summary>
        /// <param name="value">string value</param>
        /// <returns>Int32 value</returns>
        public static int ToInt(string value)
        {
            return int.Parse(value);
        }

        /// <summary>
        /// Check convert string to Int32
        /// </summary>
        /// <param name="value">string value</param>
        /// <param name="result">Int32 result</param>
        /// <returns>Int32 result</returns>
        public static bool ToInt(string value, out int result)
        {
            return int.TryParse(value, out result);
        }

        /// <summary>
        /// Convert string to bool value
        /// </summary>
        /// <param name="value">string value</param>
        /// <returns>bool value</returns>
        public static bool ToBool(string value)
        {
            var v = value.ToLower();
            if (v == "Y" || v == "y")
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Convert bool to string yes/no
        /// </summary>
        /// <param name="value">bool value</param>
        /// <param name="format">string format</param>
        /// <returns>string result</returns>
        public static string ToString(bool value, ref string format)
        {
            if (format == "y/n" || format == "Y/N") return value ? "Yes" : "No";
            return value ? "True" : "False";
        }
    }
}