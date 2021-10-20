using System;
using System.Collections.Generic;

using R5T.Magyar.IO;

using R5T.T0057;


namespace System
{
    public static class IIgnoredValuesOperatorExtensions
    {
        public static HashSet<string> LoadIgnoredValues(this IIgnoredValuesOperator _,
            string ignoredValuesTextFilePath)
        {
            var values = FileHelper.ReadAllLinesSynchronous(ignoredValuesTextFilePath);

            var output = new HashSet<string>(values);
            return output;
        }

        public static void SaveIgnoredValues(this IIgnoredValuesOperator _,
            string ignoredValuesTextFilePath,
            IEnumerable<string> ignoredValues)
        {
            FileHelper.WriteAllLinesSynchronous(
                ignoredValuesTextFilePath,
                ignoredValues);
        }
    }
}
