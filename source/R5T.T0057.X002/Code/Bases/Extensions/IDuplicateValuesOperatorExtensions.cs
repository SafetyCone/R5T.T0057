using System;
using System.Collections.Generic;
using System.Linq;

using R5T.Magyar.IO;

using R5T.T0057;


namespace System
{
    public static class IDuplicateValuesOperatorExtensions
    {
        public static Dictionary<string, string> GetDuplicateValueSelections(this IDuplicateValuesOperator _,
            string duplicateValueSelectionsTextFilePath)
        {
            var lines = FileHelper.ReadAllLinesSynchronous(duplicateValueSelectionsTextFilePath);

            // Assumes {Key}| {Value} format.
            var output = lines
                .Select(xLine => xLine.Split(Characters.Pipe))
                .ToDictionary(
                    xTokens => xTokens[0].Trim(),
                    xTokens => xTokens[1].Trim());

            return output;
        }
    }
}
