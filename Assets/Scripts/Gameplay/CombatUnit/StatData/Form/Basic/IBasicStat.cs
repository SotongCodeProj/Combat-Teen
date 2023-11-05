
namespace CombTeen.Gameplay.Unit.Status
{
    public interface IBasicStat_ModifAction
    {
        public void AddAttack(int value);
        public void AddDefense(int value);
        public void AddMaxHealth(int value);
        public void AddSpeed(int value);
        public void AddAp(int value);
    }
    public interface IBasicStat
    {
        public int Attack { get; }
        public int Defense { get; }
        public int Health { get; }
        public int Speed { get; }
        public int Ap { get; }
    }
}
