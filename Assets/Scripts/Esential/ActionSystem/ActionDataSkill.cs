using CombTeen.Gameplay.Unit.Action.Logic;
using CombTeen.Gameplay.Unit.MVC;

namespace CombTeen.Esential.ActionSystem
{
    public class ActionDataSkill : ActionDataSO
    {
#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();
            
            var classData = _logicScript.GetClass();
            if (classData.BaseType == typeof(BaseSkillAction))
            {
                _logicReference = classData.AssemblyQualifiedName;
            }
            else
            {
                _logicReference = string.Empty;
                throw new System.InvalidOperationException($"You script is not {nameof(BaseSkillAction)}");
            }
        }
#endif
        public BaseSkillAction GenerateLogic(CombatUnitControl requester)
        {
            return base.CreateLogic<BaseSkillAction>(requester);
        }
    }
}
