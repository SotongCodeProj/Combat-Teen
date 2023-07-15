using CombTeen.Constant;
using System.Collections.Generic;

namespace CombTeen.Esential.StyleSystem
{
    public interface IBasicStyleData
    {
        public string Id { get; }
        public ClassConstant.ClassType ClassType { get; }

        public IEnumerable<string> ActionIds { get; }
    }
    public interface IStyleModel : IBasicStyleData
    {

    }
}
