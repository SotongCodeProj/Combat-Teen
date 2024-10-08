using System.Collections.Generic;
using System.Linq;
using CombTeen.Gameplay.Unit.MVC;
using UnityEngine;

namespace CombTeen.Gameplay.Unit
{
    public class CombatUnitsHandler
    {
        private List<BasePlayerUnit> _playerUnits;
        private List<BaseEnemyUnit> _enemyUnits;

        private List<CombatUnitControl> _allCurrentUnits = new List<CombatUnitControl>();

        public CombatUnitsHandler(IReadOnlyList<BasePlayerUnit> players, IReadOnlyList<BaseEnemyUnit> enemys)
        {
            _playerUnits = new List<BasePlayerUnit>(players);
            _enemyUnits = new List<BaseEnemyUnit>(enemys);
        }

        public BasePlayerUnit[] GetPlayerUnits()
        {
            return _playerUnits.ToArray();
        }
        public BaseEnemyUnit[] GetEnemyUnits()
        {
            return _enemyUnits.ToArray();
        }

        public IEnumerable<CombatUnitControl> GetAllUnits()
        {
            if (_allCurrentUnits.Count <= 0)
            {
                _allCurrentUnits.AddRange(_playerUnits);
                _allCurrentUnits.AddRange(_enemyUnits);
            }

            return _allCurrentUnits;
        }

        public CombatUnitControl GetRandomOpenent(CombatUnitControl requestedUnit)
        {
            if (_playerUnits.Contains(requestedUnit))
            {
                return _enemyUnits[Random.Range(0, _enemyUnits.Count)];
            }
            else
                return _playerUnits[Random.Range(0, _enemyUnits.Count)];
        }

        public bool IsAlly(CombatUnitControl requester, CombatUnitControl targetUnit)
        {
            if (_playerUnits.Contains(requester)) return _playerUnits.Contains(targetUnit);
            else return _enemyUnits.Contains(targetUnit);
        }

        public bool IsOpponent(CombatUnitControl requester, CombatUnitControl targetUnit)
        {
            if (_playerUnits.Contains(requester)) return _enemyUnits.Contains(targetUnit);
            else return _playerUnits.Contains(targetUnit);
        }
    }
}
