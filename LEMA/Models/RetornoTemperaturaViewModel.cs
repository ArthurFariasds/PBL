using System.Collections.Generic;
using System;

namespace LEMA.Models
{
    public class RetornoTemperatura
    {
        public IList<ContextResponse> ContextResponses { get; set; }
    }
    public class ContextResponse
    {
        public ContextElement ContextElement { get; set; }
        public StatusCode StatusCode { get; set; }
    }

    public class ContextElement
    {
        public string Id { get; set; }
        public bool IsPattern { get; set; }
        public string Type { get; set; }
        public IList<Attribute> Attributes { get; set; }
    }
    public class Attribute
    {
        public string Name { get; set; }
        public IList<AttributeValues> Values { get; set; }
    }

    public class AttributeValues
    {
        public string _id { get; set; }
        public DateTime recvTime { get; set; }
        public string attrName { get; set; }
        public string attrType { get; set; }
        public double attrValue { get; set; }
    }

    public class StatusCode
    {
        public string Code { get; set; }
        public string ReasonPhrase { get; set; }
    }
}
