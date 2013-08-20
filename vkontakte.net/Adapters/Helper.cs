// -----------------------------------------------------------------------
// <copyright file="Serializer.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace vkontakte.net.Adapters
{
    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Хелпер-функция, возвращающая данные из XmlNode в зависимости от их наличия
        /// </summary>
        /// <param name="node">XmlNode</param>
        public static object GetData(this XmlNode node, Type type)
        {
            object result = null;

            if (node != null & !string.IsNullOrEmpty(node.InnerText))
            {
                if (type == typeof(int))
                {
                    var i = 0;
                    if (int.TryParse(node.InnerText, out i))
                    {
                        result = i;
                    }
                }

                if (type == typeof(string))
                {
                    result = node.InnerText;
                }

                if (type == typeof(bool))
                {
                    result = node.InnerText == "1";
                }

                if (type == typeof(DateTime))
                {
                    result = DateTime.Parse(node.InnerText);
                }
            }

            return result;
        }

        public static string[] GetAttributesNames(Type type)
        {
            var properties = type.GetProperties();

            var result = new string[properties.Count()];

            for (var i = 0; i < properties.Length; i++)
            {
                var attribute = (XmlElementAttribute)properties[i].GetCustomAttributes(true)[0];

                result[i] = attribute.ElementName;
            }

            return result;
        }

        public static T[] Deserialize<T>(this XmlNodeList nodes)
        {
            return (from object node in nodes select Deserialize<T>((XmlNode)node)).ToArray();
        }

        public static T Deserialize<T>(this XmlNode node)
        {
            var properties = typeof(T).GetProperties();

            var constructor = typeof(T).GetConstructor(Type.EmptyTypes);

            var result = constructor.Invoke(new object[] { });

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(true);

                if (attributes.Count() == 0)
                {
                    continue;
                }

                var attribute = (XmlElementAttribute)attributes[0];

                var subNode = node.SelectSingleNode(attribute.ElementName);

                if (subNode != null)
                {
                    var value = subNode.GetData(property.PropertyType);

                    if (value != null)
                    {
                        property.SetValue(result, value, null);
                    }
                }
            }

            return (T)result;
        }

        public static string WithComma(this Array strings)
        {
            var result = string.Empty;

            if (strings.Length == 0)
            {
                return result;
            }

            for (var i = 0; i < strings.Length; i++)
            {
                result += strings.GetValue(i) + ",";
            }

            result = result.Substring(0, result.Length - 1);

            return result;
        }
    }
} 