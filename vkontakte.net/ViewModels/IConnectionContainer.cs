namespace vkontakte.net.ViewModels
{
    using vkontakte.net.Adapters;

    public interface IConnectionContainer
    {
        Connection Connection { get; set; }
    }
}
