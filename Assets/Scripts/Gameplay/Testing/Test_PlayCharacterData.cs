using CombTeen.Gameplay.Unit.Action.Logic;
using CombTeen.Gameplay.Unit.Action.Object;
using CombTeen.Gameplay.Unit.Status;
using UnityEngine;

namespace CombTeen.Gameplay.DataTransport.TestData
{
    public class Test_PlayCharacterData : MonoBehaviour
    {
        public CharacterData[] PlayersData;
        public CharacterData[] EnemysData;
    }

    [System.Serializable]
    public struct CharacterData
    {
        public string CharacterId;
        public string CharacterName;
        [Header("Status")]
        public CharacterStat BasicStatus;

        [Header("Action")]
        public ActionObject<BaseAttackAction> AttackAction;
        public ActionObject<BaseDefenseAction> DefenseAction;
        public ActionObject<BaseSkillAction>[] SkillsAction;
        public ActionObject<BaseSupportAction> SupportAction;
        public ActionObject<BaseMoveAction> MoveAction;
    }

    [System.Serializable]
    public struct CharacterStat : IBasicStat
    {
        public int Attack => _attack;
        public int Defense => _defense;
        public int Health => _health;
        public int Speed => _speed;
        public int Ap => _ap;

        [SerializeField] private int _attack;
        [SerializeField] private int _defense;
        [SerializeField] private int _health;
        [SerializeField] private int _speed;
        [SerializeField] private int _ap;
    }
}
