using System;


namespace R5T.T0057
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class IgnoredValuesOperator : IIgnoredValuesOperator
    {
        #region Static
        
        public static IgnoredValuesOperator Instance { get; } = new();

        #endregion
    }
}