using CombTeen.Gameplay.Unit.Action.Logic;
using CombTeen.Gameplay.Unit.Action.Object;
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
        public SkillObject<BaseAttackAction> AttackAction;
        public SkillObject<BaseDefenseAction> DefenseAction;
        public SkillObject<BaseSkillAction>[] SkillsAction;
        public SkillObject<BaseSupportAction> SupportAction;
    }
}
