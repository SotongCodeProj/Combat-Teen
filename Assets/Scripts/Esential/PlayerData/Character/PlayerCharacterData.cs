
using CombTeen.Constant;

namespace CombTeen.Esential.PlayerData.CharacterData
{
    public class PlayerCharacterData : IPlayerCharacterData
    {
        public int Attack { private set; get; }
        public int Defense { private set; get; }
        public int Health { private set; get; }
        public int Speed { private set; get; }
        public int Ap { private set; get; }

        public ClassType ClassType { private set; get; }


        public PlayerCharacterData(int attack =0,
                                   int defense=0,
                                   int health=0,
                                   int speed=0,
                                   int ap=0,
                                   ClassType classType = ClassType.Striker)
        {
            Attack = attack;
            Defense = defense;
            Health = health;
            Speed = speed;
            Ap = ap;
            ClassType = classType;
        }
    }
}
