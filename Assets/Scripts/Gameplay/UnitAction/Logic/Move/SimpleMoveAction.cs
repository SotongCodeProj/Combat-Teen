using System.Linq;
using CombTeen.Gameplay.Tile.Object;
using CombTeen.Gameplay.Unit.Action.Helper;
using Cysharp.Threading.Tasks;


namespace CombTeen.Gameplay.Unit.Action.Logic
{
    public class SimpleMoveAction : BaseMoveAction
    {

        private ActionTileObject _selectedTile;
        protected override UniTask PostState()
        {
            return UniTask.CompletedTask;
        }

        protected override UniTask PreState()
        {
            return UniTask.CompletedTask;
        }

        protected override UniTask ProcessState()
        {
            Owner.SetLocation(_selectedTile);
            return UniTask.CompletedTask;
        }
        public override void SetUnitTargets(TargetChooseHelper targetChooseHelper)
        {
            targetChooseHelper.OnSelectTiles.RemoveAllListeners();
            targetChooseHelper.OnSelectTiles.AddListener(
            (selectedTiles) =>
            {
                _selectedTile = selectedTiles.ElementAt(0);
            });
            targetChooseHelper.GetTileWithoutUnit(Owner, TileArea.BasicArea);
        }
    }
}
