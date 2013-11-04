// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GroupAdapter.cs" company="">
//   TODO: Update copyright text.
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace vkontakte.net.Adapters
{
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Xml;

    using vkontakte.net.Models;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class GroupAdapter : Adapter
    {
        public GroupAdapter(Connection connection) : base(connection)
        {
        }

        /// <summary>
        /// Получение списка сообществ пользователя
        /// </summary>
        /// <param name="userId">
        /// Идентификатор пользователя
        /// </param>
        /// <returns>
        /// Список сообществ пользователя
        /// </returns>
        public IEnumerable<Group> GetGroups(int userId)
        {
            var query = new NameValueCollection { { "uid", userId.ToString() }, { "extended", "1" } };

            var document = ExecuteRequest("groups.get", query);

            var nodes = document.SelectNodes("response/group");

            return nodes.Deserialize<Group>();
        }

        /// <summary>
        /// Определение участия пользователя в группе
        /// </summary>
        /// <param name="groupId">
        /// Идентификатор группы
        /// </param>
        /// <param name="userId">
        /// Идентификатор пользователя
        /// </param>
        /// <returns>
        /// Признак участия пользователя в группе
        /// </returns>
        public bool IsGroupMember(int groupId, int userId)
        {
            var query = new NameValueCollection { { "gid", groupId.ToString() }, { "uid", userId.ToString() } };

            var document = this.ExecuteRequest("groups.isMember", query);
            
            if (document.DocumentElement != null)
            {
                return document.DocumentElement.InnerText == "1";
            }

            return false;
        }

        /// <summary>
        /// Получение участников группы
        /// </summary>
        /// <param name="groupId">
        /// Идентификатор группы
        /// </param>
        /// <param name="count">
        /// Максимальное количество участников группы
        /// </param>
        /// <returns>
        /// Участники группы
        /// </returns>
        public IEnumerable<int> GetGroupMembers(int groupId, int count = 1000)
        {
            var query = new NameValueCollection { { "gid", groupId.ToString() }, {"count", count.ToString() } };

            var document = this.ExecuteRequest("groups.getMembers", query);

            var nodes = document.SelectNodes("response/users/uid");

            return nodes.Cast<XmlNode>().Select(node => int.Parse(node.InnerText)).ToArray();
        }
    }
}
