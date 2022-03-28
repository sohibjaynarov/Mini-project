using System;

namespace dars.Service
{
    internal class Helpers
    {
        public static string Path(Guid Id)
        {
            return $"~/../../../../Data/{Id}.txt";
        }
    }
}
