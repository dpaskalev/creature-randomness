using System;
using System.Collections.Generic;
using System.Text;

namespace CretureRandomness
{
    public interface IGame
    {
        string Name { get; }

        void RunEngine();
    }
}
