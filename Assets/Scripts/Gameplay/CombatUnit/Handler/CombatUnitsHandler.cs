using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CombTeen.Gameplay.Unit.MVC;
using UnityEngine;

namespace CombTeen.Gameplay.Unit
{
    public class CombatUnitsHandler
    {
        private BasePlayerUnit[] _playerUnits;
        private BaseEnemyUnit[] _enemyUnits;

        private List<CombatUnitControl> _allCurrentUnits = new List<CombatUnitControl>();

        public CombatUnitsHandler(IReadOnlyList<BasePlayerUnit> players, IReadOnlyList<BaseEnemyUnit> enemys)
        {
            _playerUnits = players.ToArray();
            _enemyUnits = enemys.ToArray();
        }

        public BasePlayerUnit[] GetPlayerUnits()
        {
            return _playerUnits;
        }
        public BaseEnemyUnit[] GetEnemyUnits()
        {
            return _enemyUnits;
        }

        public IReadOnlyList<CombatUnitControl> GetAllUnits()
        {
            if (_allCurrentUnits.Count <= 0)
            {
                _allCurrentUnits.AddRange(_playerUnits);
                _allCurrentUnits.AddRange(_enemyUnits);
            }

            return _allCurrentUnits;
        }
    }
}
