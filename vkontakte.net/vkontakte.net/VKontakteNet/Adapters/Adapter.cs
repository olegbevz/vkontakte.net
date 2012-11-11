// -----------------------------------------------------------------------
// <copyright file="Adapter.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace vkontakte.net
{
    using System.Collections.Specialized;
    using System.Linq;
    using System.Net;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    using System.Xml;

    using VKontakteNet;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public abstract class Adapter
    {
        protected Connection _connection;

        public Adapter(Connection connection)
        {
            this._connection = connection;

            ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
        }

        /// <summary>
        /// Публикует текстовое сообщение на стене текущего пользователя
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        public bool WallPost(string message)
        {
            return this.WallPost(this._connection.UserId, message);
        }

        /// <summary>
        /// Публикует текстовое сообщение на стене указанного пользователя
        /// </summary>
        /// <param name="uid">Идентификатор пользователя</param>
        /// <param name="message">Текст сообщения</param>
        public bool WallPost(int uid, string message)
        {
          NameValueCollection qs = new NameValueCollection();
          qs["owner_id"] = uid.ToString();
          qs["message"] = message;
          this.ExecuteRequest("wall.post", qs);
          return true;
        }

        /// <summary>
        /// Возвращает 100 последних записей со стены текущего пользователя
        /// </summary>
        public XmlDocument GetWall()
        {
            return this.GetWall(this._connection.UserId);
        }

        /// <summary>
        /// Возвращает 100 последних записей со стены указанного пользователя
        /// </summary>
        /// <param name="uid">Идентификатор пользователя</param>
        public XmlDocument GetWall(int uid)
        {
          var qs = new NameValueCollection();
          qs["owner_id"] = uid.ToString();
          qs["count"] = "100";
          return this.ExecuteRequest("wall.get", qs);
        }

        /// <summary>
        /// Возвращает название города по коду
        /// </summary>
        /// <param name="id">Код города</param>
        public string GetCity(int id)
        {
            if (id <= 0) { return "нет данных"; }
            NameValueCollection qs = new NameValueCollection();
            qs["api_id"] = this._connection.ApplicationId.ToString();
            //qs["sig"] = this.AccessToken;
            qs["cids"] = id.ToString();
            var city = this.ExecuteRequest("getCities", qs);
            return city.InnerXml;
        }

        /// <summary>
        /// Возвращает название страны по коду
        /// </summary>
        /// <param name="id">Код страны</param>
        /// <returns></returns>
        //public string GetCountry(int id)
        //{
        //  if (id <= 0) { return "нет данных"; }
        //  NameValueCollection qs = new NameValueCollection();
        //  qs["api_id"] = ApplicationId.ToString();
        //  //qs["sig"] = this.AccessToken;
        //  qs["cids"] = id.ToString();
        //  XmlDocument country = ExecuteCommand("getCountries", qs);
        //  return Helper.GetDataFromXmlNode(country.SelectSingleNode("response/country/name"));
        //}

        private static bool ValidateRemoteCertificate(
            object sender,
            X509Certificate certificate,
            X509Chain chain,
            SslPolicyErrors policyErrors)
        {
            return true;
        }

        /// <summary>
        /// Выполняет запрос к API 
        /// </summary>
        /// <param name="name">Имя api-метода</param>
        /// <param name="qs">Дополнительные параметры</param>
        protected XmlDocument ExecuteRequest(string name, NameValueCollection qs)
        {
            var result = new XmlDocument();

            var value = (from item in qs.AllKeys select item + "=" + qs[item]).ToArray();

            var request = string.Format(
                  "https://api.vkontakte.ru/method/{0}.xml?access_token={1}&{2}", 
                  name,
                  this._connection.AccessToken, 
                  string.Join("&", value));

            result.Load(request);

            return result;
        }
    }
}
