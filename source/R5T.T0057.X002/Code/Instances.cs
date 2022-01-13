using System;

using R5T.T0042;
using R5T.T0044;


namespace R5T.T0057.X002
{
    public static class Instances
    {
        public static IFileSystemOperator FileSystemOperator { get; } = T0044.FileSystemOperator.Instance;
        public static IStringOperator StringOperator { get; } = T0042.StringOperator.Instance;
    }
}
