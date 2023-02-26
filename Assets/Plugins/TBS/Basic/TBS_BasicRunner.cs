using TBS.Core;
using TBS.Core.Runner;

namespace TBS.Basic
{
    public class TBS_BasicRunner : BaseStateProcessor<TBS_BasicModel>
    {
        public void Initialize(TBS_BasicModel data)
        {
            Data = data;
        }

    }
}
