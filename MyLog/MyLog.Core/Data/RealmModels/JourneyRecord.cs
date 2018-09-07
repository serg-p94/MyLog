using System;
using Realms;

namespace MyLog.Core.Data.RealmModels
{
    public class JourneyRecord : RealmObject
    {
        public string Header { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}
