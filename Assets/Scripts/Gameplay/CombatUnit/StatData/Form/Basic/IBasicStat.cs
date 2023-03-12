
namespace CombTeen.Gameplay.Unit.Status
{
    public interface IBasicStat_ModifAction
    {
        public void Set_Attack(int value);
        public void Set_Defense(int value);
        public void Set_Health(int value);
        public void Set_Speed(int value);
        public void Set_Ap(int value);
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
