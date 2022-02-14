using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using R5T.Magyar;

using R5T.T0057;

using Instances = R5T.T0057.X002.Instances;


namespace System
{
    public static class IDuplicateValuesOperatorExtensions
    {
        /// <summary>
        /// Gets a dictionary of values from the {Key}| {Value} format.
        /// </summary>
        public static async Task<Dictionary<string, string>> LoadDuplicateValueSelections(this IDuplicateValuesOperator _,
            string duplicateValueSelectionsTextFilePath)
        {
            var lines = await FileHelper.ReadAllLines(duplicateValueSelectionsTextFilePath);

            // Assumes {Key}| {Value} format.
            var output = lines
                .Where(Instances.StringOperator.IsNotEmpty)
                .Select(xLine => xLine.Split(Characters.Pipe))
                .ToDictionary(
                    xTokens => xTokens[0].Trim(),
                    xTokens => xTokens[1].Trim());

            return output;
        }

        /// <summary>
        /// Gets a dictionary of values from the {Key}| {Value} format.
        /// </summary>
        public static Dictionary<string, string> LoadDuplicateValueSelectionsSync(this IDuplicateValuesOperator _,
            string duplicateValueSelectionsTextFilePath)
        {
            var lines = FileHelper.ReadAllLinesSynchronous(duplicateValueSelectionsTextFilePath);

            // Assumes {Key}| {Value} format.
            var output = lines
                .Where(Instances.StringOperator.IsNotEmpty)
                .Select(xLine => xLine.Split(Characters.Pipe))
                .ToDictionary(
                    xTokens => xTokens[0].Trim(),
                    xTokens => xTokens[1].Trim());

            return output;
        }

        public static async Task SaveDuplicateValueSelections(this IDuplicateValuesOperator _,
            string duplicateValueSelectionsTextFilePath,
            Dictionary<string, string> duplicateValueSelections)
        {
            var lines = duplicateValueSelections
                .Select(xPair => $"{xPair.Key}| {xPair.Value}")
                ;

            await FileHelper.WriteAllLines(duplicateValueSelectionsTextFilePath, lines);
        }

        public static void SaveDuplicateValueSelectionsSync(this IDuplicateValuesOperator _,
            string duplicateValueSelectionsTextFilePath,
            Dictionary<string, string> duplicateValueSelections)
        {
            var lines = duplicateValueSelections
                .Select(xPair => $"{xPair.Key}| {xPair.Value}")
                ;

            FileHelper.WriteAllLinesSynchronous(duplicateValueSelectionsTextFilePath, lines);
        }
    }
}
