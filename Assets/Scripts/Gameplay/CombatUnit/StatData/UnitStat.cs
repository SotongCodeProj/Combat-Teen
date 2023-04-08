
using UnityEngine;
using UnityEngine.Events;

namespace CombTeen.Gameplay.Unit.Status
{
    public class BaseUnitStat : IBasicStat
    {
        public BaseUnitStat(int attack, int defense, int health, int speed, int ap)
        {
            Attack = attack;
            Defense = defense;
            Health = health;
            Speed = speed;
            Ap = ap;
        }
        #region  Basic Status
        public int Attack { private set; get; }

        public int Defense { private set; get; }

        public int Health { private set; get; }

        public int Speed { private set; get; }

        public int Ap { private set; get; }

        #endregion
    }

    public class DynamicUnitStat : IBasicStat, IUnitModifAction
    {
        #region  Basic Status
        public int Attack { private set; get; }
        public int Defense { private set; get; }
        public int Health { private set; get; }
        public int Speed { private set; get; }
        public int Ap { private set; get; }

        public void AddAp(int value)
        {
            Ap = value;
        }
        public void AddAttack(int value)
        {
            Attack = value;
        }
        public void AddDefense(int value)
        {
            Defense = value;
        }

        public void AddHealth(int value)
        {
            Health = value;
        }

        public void AddSpeed(int value)
        {
            Speed = value;
        }
        #endregion
    }

    public class FinalUnitStat : IBasicStat
    {
        private BaseUnitStat _baseUnitStat;
        private DynamicUnitStat _dynamicStat;

        public FinalUnitStat(BaseUnitStat baseUnitStat, DynamicUnitStat dynamicStat)
        {
            _baseUnitStat = baseUnitStat;
            _dynamicStat = dynamicStat;
        }

        public int Attack => _baseUnitStat.Attack + _dynamicStat.Attack;
        public int Defense => _baseUnitStat.Defense + _dynamicStat.Defense;
        public int Health => _baseUnitStat.Health + _dynamicStat.Health;
        public int Speed => _baseUnitStat.Speed + _dynamicStat.Speed;
        public int Ap => _baseUnitStat.Ap + _dynamicStat.Ap;


    }

    public class CombatUnitStat : IBasicStat,
    IUnitCombatStatModifAction
    {
        private FinalUnitStat _ancorStat;

        public int Attack { private set; get; }
        public int Defense { private set; get; }
        public int Health { private set; get; }
        public int Speed { private set; get; }
        public int Ap { private set; get; }


        public CombatUnitStat(FinalUnitStat ancorStat)
        {
            _ancorStat = ancorStat;

            Attack = ancorStat.Attack;
            Defense = ancorStat.Defense;
            Health = ancorStat.Health;
            Speed = ancorStat.Speed;
            Ap = ancorStat.Ap;
        }
        #region  Modif Action
        public UnityEvent<int> AfterTakeDamageEvent { private set; get; } = new UnityEvent<int>();
        public UnityEvent<int> AfterAddHealthEvent { private set; get; } = new UnityEvent<int>();
        public void TakeDamage(int value)
        {
            Health -= Mathf.Clamp(value, 1, int.MaxValue);
            AfterTakeDamageEvent?.Invoke(Health);
        }
        public void AddHealth(int value)
        {
            Health += Mathf.Clamp(value, 1, int.MaxValue);
            AfterAddHealthEvent?.Invoke(Health);
        }
        #endregion
    }

    public interface IUnitModifAction : IBasicStat_ModifAction { }
    public interface IUnitCombatStatModifAction
    {
        public UnityEvent<int> AfterTakeDamageEvent { get; }
        public UnityEvent<int> AfterAddHealthEvent { get; }

        void AddHealth(int value);
        public void TakeDamage(int value);
    }
}
