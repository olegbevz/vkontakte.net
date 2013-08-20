// -----------------------------------------------------------------------
// <copyright file="GroupAdapter.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace vkontakte.net.Adapters
{
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

        public Group[] GetGroups(int userId)
        {
            var query = new NameValueCollection { { "uid", userId.ToString() }, { "extended", "1" } };

            var document = ExecuteRequest("groups.get", query);

            var nodes = document.SelectNodes("response/group");

            return nodes.Deserialize<Group>();
        }

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

        public int[] GetGroupMembers(int groupId, int count = 1000)
        {
            var query = new NameValueCollection { { "gid", groupId.ToString() }, {"count", count.ToString() } };

            var document = this.ExecuteRequest("groups.getMembers", query);

            var nodes = document.SelectNodes("response/users/uid");

            return nodes.Cast<XmlNode>().Select(node => int.Parse(node.InnerText)).ToArray();
        }
    }
}
