// Guids.cs
// MUST match guids.h
using System;

namespace Frank.FileHeaderCommand
{
    static class GuidList
    {
        public const string guidFileHeaderCommandPkgString = "759f6e22-b65f-4835-9131-a3a6b622c77c";
        public const string guidFileHeaderCommandCmdSetString = "225d276d-e9a8-46c6-bb4f-6c6b82c821ce";

        public static readonly Guid guidFileHeaderCommandCmdSet = new Guid(guidFileHeaderCommandCmdSetString);
    };
}