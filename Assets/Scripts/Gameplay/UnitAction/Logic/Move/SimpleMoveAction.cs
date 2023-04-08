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
        public override BaseUnitAction InitializeOwner(CombatUnitControl owner)
        {
            return new SimpleMoveAction()
            {
                Owner = owner
            };
        }
        public override async UniTask SetUnitTargets(TargetChooseHelper targetChooseHelper)
        {
            _selectedTile = await targetChooseHelper.GetTileWithoutUnitAsync(Owner);
            Debug.Log($"Player{Owner.UnitBasicInfoData.UnitName} Move to {_selectedTile.name}");
            Owner.SetLocation(_selectedTile);
        }
    }
}
