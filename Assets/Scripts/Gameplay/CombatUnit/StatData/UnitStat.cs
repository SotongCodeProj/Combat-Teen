
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

        public void Set_Ap(int value)
        {
            Ap = value;
        }
        public void Set_Attack(int value)
        {
            Attack = value;
        }
        public void Set_Defense(int value)
        {
            Defense = value;
        }

        public void Set_Health(int value)
        {
            Health = value;
        }

        public void Set_Speed(int value)
        {
            Speed = value;
        }
        #endregion
    }

    public class FinalUniStat : IBasicStat
    {
        private BaseUnitStat baseUnitStat;
        private DynamicUnitStat dynamicStat;

        public FinalUniStat(BaseUnitStat baseUnitStat, DynamicUnitStat dynamicStat)
        {
            this.baseUnitStat = baseUnitStat;
            this.dynamicStat = dynamicStat;
        }

        public int Attack => baseUnitStat.Attack + dynamicStat.Attack;
        public int Defense => baseUnitStat.Defense + dynamicStat.Defense;
        public int Health => baseUnitStat.Health + dynamicStat.Health;
        public int Speed => baseUnitStat.Speed + dynamicStat.Speed;
        public int Ap => baseUnitStat.Ap + dynamicStat.Ap;
    }

    public interface IUnitModifAction : IBasicStat_ModifAction{}
}
