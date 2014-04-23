namespace MusicSearcher
{
    using vkontakte.net.Adapters;

    public interface IConnectionContainer
    {
        Connection Connection { get; set; }
    }
}
