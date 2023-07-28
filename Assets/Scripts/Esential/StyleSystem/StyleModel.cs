using CombTeen.Constant;
using CombTeen.Esential.ActionSystem;
using System.Collections.Generic;

namespace CombTeen.Esential.StyleSystem
{
    public interface IBasicStyleData
    {
        public string Id { get; }
        public IEnumerable<ClassType> CompactibleClassType { get; }

        public IEnumerable<ActionDataSO> ActionIds { get; }
    }
    public interface IStyleModel : IBasicStyleData
    {

    }
}
