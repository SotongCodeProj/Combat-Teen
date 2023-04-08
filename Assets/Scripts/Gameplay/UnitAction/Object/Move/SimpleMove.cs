using CombTeen.Gameplay.Unit.Action.Object;


namespace CombTeen.Gameplay.Unit.Action.Logic
{
    public class SimpleMove : ActionObject<BaseMoveAction>
    {
        public override BaseMoveAction Logic => new SimpleMoveAction();

        
    }
}
