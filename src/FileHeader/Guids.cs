// Guids.cs
// MUST match guids.h
namespace Rosen.FileHeader
{
    using System;

    /// <summary>
    /// Guids.
    /// </summary>
    public static class Guids
    {
        /// <summary>
        /// GuidFileHeaderPkgString.
        /// </summary>
        public const string GuidFileHeaderPkgString = "759f6e22-b65f-4835-9131-a3a6b622c77c";

        /// <summary>
        /// GuidFileHeaderCmdSetString.
        /// </summary>
        public const string GuidFileHeaderCmdSetString = "225d276d-e9a8-46c6-bb4f-6c6b82c821ce";

        /// <summary>
        /// GuidFileHeaderCmdSet.
        /// </summary>
        public static readonly Guid GuidFileHeaderCmdSet = new Guid(GuidFileHeaderCmdSetString);
    }
}