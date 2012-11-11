// -----------------------------------------------------------------------
// <copyright file="ArrayResponse.cs" company="">
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
    public class ArrayResponse<T> : Response
    {
        public ArrayResponse(XmlDocument document)
            : base(document)
        {
        }

        protected override void DeserialiseResponse(XmlNode node)
        {
            Result = node.ChildNodes.Deserialize<T>().ToArray();
        }

        /// <summary>
        /// Результат
        /// </summary>
        public T[] Result { get; set; }
    }
}
