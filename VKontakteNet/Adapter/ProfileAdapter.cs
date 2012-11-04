// -----------------------------------------------------------------------
// <copyright file="ProfileAdapter.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace VKontakteNet
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ProfileAdapter : Adapter
    {
        public ProfileAdapter(Connection connection) : base(connection)
        {
                 
        }

        #region - Получение данных о пользователе -

        /// <summary>
        /// Возвращает профиль текущего пользователя
        /// </summary>
        public T GetProfile<T>()
        {
            return GetProfile<T>(_connection.UserId);
        }

        /// <summary>
        /// Метод возвращает профиль пользователя
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        public T GetProfile<T>(int id)
        {
            return GetProfile<T>(new[] { id })[0];
        }

        /// <summary>
        /// Возвращает профиль указанного пользователя
        /// </summary>
        /// <param name="ids">Список идентификаторов</param>
        public T[] GetProfile<T>(int[] ids)
        {
            var query = new NameValueCollection();

            query["uids"] = ids.WithComma();

            query["fields"] = Helper.GetAttributesNames(typeof(T)).WithComma();

            var document = ExecuteRequest("getProfiles", query);

            return Helper.Deserialize<T>(document.SelectNodes("response/user"));
        }

        #endregion

        #region - Получение данных о друзьях -

        /// <summary>
        /// Возвращает список друзей текущего пользователя
        /// </summary>
        public T[] GetFriends<T>()
        {
            return GetFriends<T>(_connection.UserId);
        }

        public T[] GetFriends<T>(int id)
        {
            var query = new NameValueCollection();

            query["uid"] = id.ToString();

            query["fields"] = Helper.GetAttributesNames(typeof(T)).WithComma();

            var document = ExecuteRequest("friends.get", query);

            if (document != null)
            {
                return Helper.Deserialize<T>(document.SelectNodes("response/user"));
            }
            else
            {
                return new T[0];
            }
        }

        #endregion
    }
}
