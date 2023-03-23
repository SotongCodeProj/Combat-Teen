using System.Collections;
using System.Collections.Generic;
using CombTeen.Gameplay.Tile;

namespace CombTeen.Gameplay.Unit.MVC.Factory
{
    public class UnitControlFactory
    {
        private ITileController _tileController;

        public UnitControlFactory(ITileController tileController)
        {
            _tileController = tileController;
        }

        // public BasePlayerUnit GeneratePlayerUnit(CombatUnitView unitView)
        // {
        //     var player = new BasePlayerUnit(_tileController);
        //     player.Setup(unitView);
        //     return player;
        // }

        // public BaseEnemyUnit GenerateEnemyUnit(CombatUnitView unitView)
        // {
        //     var enemy = new BaseEnemyUnit(_tileController);
        //     enemy.Setup(unitView);
        //     return enemy;
        // }
    }
}
