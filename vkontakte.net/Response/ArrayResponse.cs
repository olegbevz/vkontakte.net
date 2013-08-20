// -----------------------------------------------------------------------
// <copyright file="ArrayResponse.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace vkontakte.net.Response
{
    using System.Linq;
    using System.Xml;

    using vkontakte.net.Adapters;

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
            this.Result = node.ChildNodes.Deserialize<T>().ToArray();
        }

        /// <summary>
        /// Результат
        /// </summary>
        public T[] Result { get; set; }
    }
}
