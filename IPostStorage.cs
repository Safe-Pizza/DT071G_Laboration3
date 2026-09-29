using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration3
{
    public interface IPostStorage
    {
        List<Post> load();

        void Save(List<Post> posts);
    }
}
