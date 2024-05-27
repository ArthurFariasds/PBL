using System.Collections.Generic;
using System;

namespace PBL.Models
{
    public class RetornoDispositivo
    {
        public int count { get; set; }
        public IList<RetornoDispositivoViewModel> devices { get; set; }
    }
    public class RetornoDispositivoViewModel
    {
        public string device_id { get; set; }
        public string service { get; set; }
        public string service_path { get; set; }
        public string entity_name { get; set; }
        public string entity_type { get; set; }
        public string transport { get; set; }
        public IList<Attribute> attributes { get; set; }
        public IList<object> lazy { get; set; }
        public IList<Command> commands { get; set; }
        public IList<object> static_attributes { get; set; }
        public string protocol { get; set; }
    }
    public class Attribute
    {
        public string object_id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }

    public class Command
    {
        public string object_id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }
}


