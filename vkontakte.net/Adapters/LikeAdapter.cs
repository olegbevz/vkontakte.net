// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LikeAdapter.cs" company="">
//   TODO: Update copyright text.
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace vkontakte.net.Adapters
{
    using System.Collections.Specialized;

    using vkontakte.net;
    using vkontakte.net.Adapters;
    using vkontakte.net.Response;

    public enum ObjectType
    {
        //запись на стене пользователя или группы
        post,

        //комментарий к записи на стене	
        comment,   
 
		//фотография
        photo,

	    //аудиозапись
        audio,

	    //видеозапись
        video,

	    //заметка
        note,

	    //страница сайта, на котором установлен виджет «Мне нравится»
        sitepage
    }

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class LikeAdapter : Adapter
    {
        public LikeAdapter(Connection connection) : base(connection)
        {
            
        }

        public ValueResponse<int> AddLike(int ownerId, ObjectType type, int itemId)
        {
            var query = new NameValueCollection
                {
                    
                    { "owner_id", ownerId.ToString() },
                    { "type", type.ToString() },
                    { "item_id", itemId.ToString() }
                };

            return new ValueResponse<int>(this.ExecuteRequest("likes.add", query));
        }

        public ValueResponse<int> DeleteLike(int ownerId, ObjectType type, int itemId)
        {
            var query = new NameValueCollection
                {
                    
                    { "owner_id", ownerId.ToString() },
                    { "type", type.ToString() },
                    { "item_id", itemId.ToString() }
                };

            return new ValueResponse<int>(this.ExecuteRequest("likes.delete", query));
        }

        public ValueResponse<bool> ItemIsLiked(int userId,int ownerId, ObjectType type, int itemId)
        {
            var query = new NameValueCollection
                {
                    { "user_id", userId.ToString() },
                    { "owner_id", ownerId.ToString() },
                    { "type", type.ToString() },
                    { "item_id", itemId.ToString() }
                };

            return new ValueResponse<bool>(this.ExecuteRequest("likes.isLiked", query));
        }

        public ArrayResponse<int> GetLikingUsers(int ownerId, ObjectType type, int itemId)
        {
            var query = new NameValueCollection
                {
                    
                    { "owner_id", ownerId.ToString() },
                    { "type", type.ToString() },
                    { "item_id", itemId.ToString() }
                };

            return new ArrayResponse<int>(this.ExecuteRequest("likes.getList", query));
        }
    }
}
