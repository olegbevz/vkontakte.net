// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Response.cs" company="">
//   TODO: Update copyright text.
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VKontakteNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public abstract class Response
    {
        public Response(XmlDocument document)
        {
            var child = document.DocumentElement;

            if (child.Name == "error")
            {
                Error = new Error();

                var serializer = new XmlSerializer(typeof(Error));

                Error = serializer.Deserialize(new XmlNodeReader(child)) as Error;
            }

            if (child.Name == "response")
            {
                this.DeserialiseResponse(child);
            }
        }

        protected abstract void DeserialiseResponse(XmlNode node);
         
        public Error Error { get; set; }

        /// <summary>
        /// Признак успешного завершения процедуры
        /// </summary>
        public bool Success
        {
            get
            {
                return Error == null;
            }
        }
    }
}
