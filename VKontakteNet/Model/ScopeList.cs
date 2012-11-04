// -----------------------------------------------------------------------
// <copyright file="ScopeList.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace VKontakteNet
{
    /// <summary>
    /// Права приложения
    /// </summary>
    public enum ScopeList
    {
        /// <summary>
        /// Пользователь разрешил отправлять ему уведомления. 
        /// </summary>
        NotifyUser = 1,
        
        /// <summary>
        /// Доступ к друзьям.
        /// </summary>
        AccessToFriends = 2,
        
        /// <summary>
        /// Доступ к фотографиям. 
        /// </summary>
        AccessToPhotos = 4,
        
        /// <summary>
        /// Доступ к аудиозаписям. 
        /// </summary>
        AccessToAudio = 8,
        
        /// <summary>
        /// Доступ к видеозаписям. 
        /// </summary>
        AccessToVideo = 16,
        
        /// <summary>
        /// Доступ к предложениям (устаревшие методы). 
        /// </summary>
        AccessToOffers = 32,

        /// <summary>
        /// Доступ к вопросам (устаревшие методы). 
        /// </summary>
        AccessToQuestions = 64,

        /// <summary>
        /// Доступ к wiki-страницам. 
        /// </summary>
        AccessToWikiPages = 128,

        /// <summary>
        /// Добавление ссылки на приложение в меню слева.
        /// </summary>
        Link = 256,
        
        /// <summary>
        /// Доступ заметкам пользователя. 
        /// </summary>
        AccessToNotes = 2048,
        
        /// <summary>
        /// (для Standalone-приложений) Доступ к расширенным методам работы с сообщениями. 
        /// </summary>
        AccessToMessages = 4096,
        
        /// <summary>
        /// Доступ к обычным и расширенным методам работы со стеной. 
        /// </summary>
        AccessToWall = 8192,
        
        /// <summary>
        /// Доступ к документам пользователя.
        /// </summary>
        AccessToDocuments = 131072
    }
}
