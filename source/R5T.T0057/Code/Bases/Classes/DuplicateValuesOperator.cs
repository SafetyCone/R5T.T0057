using System;


namespace R5T.T0057
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class DuplicateValuesOperator : IDuplicateValuesOperator
    {
        #region Static
        
        public static DuplicateValuesOperator Instance { get; } = new();

        #endregion
    }
}