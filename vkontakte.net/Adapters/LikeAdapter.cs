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

    using vkontakte.net.Models;
    using vkontakte.net.Response;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class LikeAdapter : Adapter
    {
        public LikeAdapter(Connection connection) : base(connection)
        {
            
        }

        /// <summary>
        /// Добавление лайка к объекту
        /// </summary>
        /// <param name="ownerId">
        /// Идентификатор владельца объекта
        /// </param>
        /// <param name="type">
        /// Тип объекта
        /// </param>
        /// <param name="itemId">
        /// Идентификатор объекта, к которому добавляется лайк
        /// </param>
        /// <returns>
        /// Результат запроса
        /// </returns>
        public ValueResponse<int> AddLike(int ownerId, LikeContainer type, int itemId)
        {
            var query = new NameValueCollection
                {
                    { "owner_id", ownerId.ToString() },
                    { "type", type.ToString() },
                    { "item_id", itemId.ToString() }
                };

            return new ValueResponse<int>(this.ExecuteRequest("likes.add", query));
        }

        /// <summary>
        /// Удаление лайка
        /// </summary>
        /// <param name="ownerId">
        /// Идентификатор владельца объекта
        /// </param>
        /// <param name="type">
        /// Тип объекта
        /// </param>
        /// <param name="itemId">
        /// Идентификатор объекта, к которому добавляется лайк
        /// </param>
        /// <returns>
        /// Результат запроса
        /// </returns>
        public ValueResponse<int> DeleteLike(int ownerId, LikeContainer type, int itemId)
        {
            var query = new NameValueCollection
                {
                    
                    { "owner_id", ownerId.ToString() },
                    { "type", type.ToString() },
                    { "item_id", itemId.ToString() }
                };

            return new ValueResponse<int>(this.ExecuteRequest("likes.delete", query));
        }

        public ValueResponse<bool> ItemIsLiked(int userId, int ownerId, LikeContainer type, int itemId)
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

        /// <summary>
        /// Получение пользователей которые лайкнули объект
        /// </summary>
        /// <param name="ownerId">
        /// Идентификатор владельца объекта
        /// </param>
        /// <param name="type">
        /// Тип объекта
        /// </param>
        /// <param name="itemId">
        /// идентификатор объекта
        /// </param>
        /// <returns>
        /// Результат запроса
        /// </returns>
        public ArrayResponse<int> GetLikingUsers(int ownerId, LikeContainer type, int itemId)
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
