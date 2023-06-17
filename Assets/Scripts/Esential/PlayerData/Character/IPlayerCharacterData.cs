
namespace CombTeen.Esential.PlayerData.CharacterData
{
    public interface IPlayerCharacterData : ICharacterBasicStat
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
}
