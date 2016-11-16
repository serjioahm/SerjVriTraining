using System;

namespace VersionAttribute
{
    [AttributeUsage(AttributeTargets.Class |
               AttributeTargets.Struct |
               AttributeTargets.Interface |
               AttributeTargets.Enum |
               AttributeTargets.Method)]
    public class Attributes : Attribute
    {
        public string Version { get; set; }

        public Attributes(string version)
        {
            this.Version = version;
        }

    }

}
