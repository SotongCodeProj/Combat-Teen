using CombTeen.Constant.Class;
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
