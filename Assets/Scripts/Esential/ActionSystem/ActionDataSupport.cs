using CombTeen.Gameplay.Unit.Action.Logic;
using CombTeen.Gameplay.Unit.MVC;

namespace CombTeen.Esential.ActionSystem
{
    public class ActionDataSupport : ActionDataSO
    {
#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();
            
            var classData = _logicScript.GetClass();
            if (classData.BaseType == typeof(BaseSupportAction))
            {
                _logicReference = classData.AssemblyQualifiedName;
            }
            else
            {
                _logicReference = string.Empty;
                throw new System.InvalidOperationException($"You script is not {nameof(BaseSupportAction)}");
            }
        }
#endif
        public BaseSupportAction GenerateLogic(CombatUnitControl requester)
        {
            return base.CreateLogic<BaseSupportAction>(requester);
        }
    }
}
