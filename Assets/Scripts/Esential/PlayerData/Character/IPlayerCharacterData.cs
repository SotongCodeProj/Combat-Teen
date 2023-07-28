using CombTeen.Constant;
namespace CombTeen.Esential.PlayerData.CharacterData
{
    public interface IPlayerCharacterData : ICharacterBasicStat, ICharacterDevelopData
    {

    }

    public interface ICharacterBasicStat
    {
        public int Attack { get; }
        public int Defense { get; }
        public int Health { get; }
        public int Speed { get; }
        public int Ap { get; }
    }

    public interface ICharacterDevelopData
    {
        public ClassType ClassType { get; }
    }
}
