// -----------------------------------------------------------------------
// <copyright file="BoolResponse.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace VKontakteNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ValueResponse<T> : Response
    {
        public ValueResponse(XmlDocument document) : base(document)
        {
        }

        public T Result { get; set; }

        protected override void DeserialiseResponse(XmlNode node)
        {
            if (Result is int)
            {
                Result = (T)(object)int.Parse(node.FirstChild.Value);
            }
            else if (Result is bool)
            {
                Result = (T)(object)(node.FirstChild.Value == "1");
            }
            else
            {
                Result = (T)(object)node.FirstChild.Value;
            }
        }
    }
}
