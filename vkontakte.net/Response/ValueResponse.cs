// -----------------------------------------------------------------------
// <copyright file="BoolResponse.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace vkontakte.net.Response
{
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
            if (this.Result is int)
            {
                this.Result = (T)(object)int.Parse(node.FirstChild.Value);
            }
            else if (this.Result is bool)
            {
                this.Result = (T)(object)(node.FirstChild.Value == "1");
            }
            else
            {
                this.Result = (T)(object)node.FirstChild.Value;
            }
        }
    }
}
