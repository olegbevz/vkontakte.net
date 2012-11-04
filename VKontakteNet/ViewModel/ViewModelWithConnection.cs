using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VKontakteNet
{
    public class ViewModelWithConnection : ViewModelBase, IConnectionContainer
    {
        public ViewModelWithConnection(Connection connection)
        {
            Connection = connection;
        }

        public Connection Connection { get; set; }
    }
}
