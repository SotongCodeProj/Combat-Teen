using CombTeen.Gameplay.Unit.Action.Logic;
using CombTeen.Gameplay.Unit.MVC;

namespace CombTeen.Esential.ActionSystem
{
    public class ActionDataMove : ActionDataSO
    {
#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();
            
            var classData = _logicScript.GetClass();
            if (classData.BaseType == typeof(BaseMoveAction))
            {
                _logicReference = classData.AssemblyQualifiedName;
            }
            else
            {
                _logicReference = string.Empty;
                throw new System.InvalidOperationException($"You script is not {nameof(BaseMoveAction)}");
            }
        }
#endif

        public BaseMoveAction GenerateLogic(CombatUnitControl requester)
        {
            return base.CreateLogic<BaseMoveAction>(requester);
        }
    }
}
