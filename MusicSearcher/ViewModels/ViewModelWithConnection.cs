namespace MusicSearcher
{
    using vkontakte.net.Adapters;

    public class ViewModelWithConnection : ViewModelBase, IConnectionContainer
    {
        public ViewModelWithConnection(Connection connection)
        {
            this.Connection = connection;
        }

        public Connection Connection { get; set; }
    }
}
