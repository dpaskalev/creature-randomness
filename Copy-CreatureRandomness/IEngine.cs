using System;
using System.Collections.Generic;
using System.Text;

namespace Copy_CreatureRandomness
{
    public interface IEngine
    {
        string Name { get; }

        void RunEngine();
    }
}
