using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VKontakteNet
{
    public interface IConnectionContainer
    {
        Connection Connection { get; set; }
    }
}
