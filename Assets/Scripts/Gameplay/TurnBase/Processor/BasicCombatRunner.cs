using System.Linq;
using CombTeen.Gameplay.State;
using CombTeen.Gameplay.StateModel;
using Cysharp.Threading.Tasks;
using TBS.Core;
using TBS.Core.Runner;
using UnityEngine;

namespace CombTeen.Gameplay.StateRunner
{
    public class BasicCombatRunner : IStateProcessor<BasicCombatModel>
    {
        public TBS_State _currentState { private set; get; }
        public int LoopIndex { private set; get; } = 0;
        public BasicCombatModel Data { protected set; get; }
        public bool DoneLoopState { private set; get; } = false;
        private bool _keepRun = false;

        public BasicCombatRunner(BasicStartBattleState startBattle,

                                PlayerChooseActionState playerChooseAction,
                                CalculateActionOrderState calculateAction,
                                PlayUnitActionState playUnitAction,
                                CheckBattleStatusState checkBattleStatus,

                                BasicEndBattleState endBattle)
        {
            Data = new BasicCombatModel(startBattle,
                                        playerChooseAction,
                                        calculateAction,
                                        playUnitAction,
                                        checkBattleStatus,
                                        endBattle);
            checkBattleStatus.OnBattleDone.AddListener(Terminate);
        }

        public async UniTask RunAsync()
        {
            _keepRun = true;
            await BeginProcess();

            while (_keepRun)
            {
                await LoopProcess();
                await UniTask.WaitUntil(() => DoneLoopState);
                Next();
            }

            await EndProcess();
        }
        public void Terminate()
        {
            _keepRun = false;
            Debug.LogWarning("Process Terminated");
        }
        public void Next()
        {
            if (!_currentState.Equals(TBS_State.Loop) || !DoneLoopState) { Debug.LogWarning("Error whenNext"); return; }
            LoopIndex = (LoopIndex + 1) >= Data.LoopStates.Count() ?
                            0 : LoopIndex + 1;

        }

        private async UniTask BeginProcess()

        {
            LoopIndex = 0;
            _currentState = TBS_State.Start;

            await using (IStartState start = Data.StartState)
            {
                await start.PreState;
                await start.ProcessSate;
                await start.PostState;
            }
        }
        private async UniTask LoopProcess()
        {
            DoneLoopState = false;
            _currentState = TBS_State.Loop;
            var targetState = Data.LoopStates.ElementAt(LoopIndex);

            await using (ILoopState target = targetState)
            {
                await target.PreState;
                await target.ProcessSate;
                await target.PostState;
            }
            DoneLoopState = true;
        }
        private async UniTask EndProcess()
        {
            if (!_currentState.Equals(TBS_State.Loop)) return;

            _currentState = TBS_State.End;
            await using (IEndState endState = Data.EndState)
            {
                await endState.PreState;
                await endState.ProcessSate;
                await endState.PostState;
            }
        }
    }
}
