using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0057;

using Instances = R5T.T0057.X002.Instances;


namespace System
{
    public static class IIgnoredValuesOperatorExtensions
    {
        /// <summary>
        /// Returns an empty hash set if the file does not exist.
        /// </summary>
        public static async Task<HashSet<string>> LoadIgnoredValuesReturnEmptyIfNotExists(this IIgnoredValuesOperator _,
            string ignoredValuesTextFilePath)
        {
            var output = Instances.FileSystemOperator.FileExists(ignoredValuesTextFilePath)
                ? await _.LoadIgnoredValues(ignoredValuesTextFilePath)
                : new HashSet<string>()
                ;

            return output;
        }

        public static async Task<HashSet<string>> LoadIgnoredValues(this IIgnoredValuesOperator _,
            string ignoredValuesTextFilePath)
        {
            var values = await FileHelper.ReadAllLines(ignoredValuesTextFilePath);

            var output = new HashSet<string>(values.ExceptEmpty());
            return output;
        }

        public static HashSet<string> LoadIgnoredValuesSync(this IIgnoredValuesOperator _,
            string ignoredValuesTextFilePath)
        {
            var values = FileHelper.ReadAllLinesSynchronous(ignoredValuesTextFilePath);

            var output = new HashSet<string>(values);
            return output;
        }

        public static async Task SaveIgnoredValues(this IIgnoredValuesOperator _,
            string ignoredValuesTextFilePath,
            IEnumerable<string> ignoredValues)
        {
            await FileHelper.WriteAllLines(
                ignoredValuesTextFilePath,
                ignoredValues);
        }
    }
}
