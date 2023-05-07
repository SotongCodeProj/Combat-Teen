using System.Linq;
using CombTeen.Gameplay.Tile;
using CombTeen.Gameplay.Tile.Object;
using CombTeen.Gameplay.Unit.Action.Helper;
using CombTeen.Gameplay.Unit.MVC;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CombTeen.Gameplay.Unit.Action.Logic
{
    public class SimpleMoveAction : BaseMoveAction
    {
        public override string ActionId => "A-MOV-000";

        private ActionTileObject _selectedTile;
        public override ITileArea ActionArea => new TileArea
        {
            Up = 1,
            Down = 1,
            Left = 1,
            Right = 1,

            DownLeft = 1,
            DownRight = 1,
            UpLeft = 1,
            UpRight = 1
        };


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
            targetChooseHelper.GetTileWithoutUnit(Owner);
        }
    }
}
