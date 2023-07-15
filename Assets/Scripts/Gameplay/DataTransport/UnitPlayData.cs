using CombTeen.Esential.ActionSystem;
using CombTeen.Gameplay.Unit.Action.Logic;
using CombTeen.Gameplay.Unit.Status;
using UnityEngine;

namespace CombTeen.Gameplay.DataTransport
{
    public class UnitPlayData
    {
        [System.Serializable]
        public struct CharacterData
        {
            public string CharacterId;
            public string CharacterName;
            [Header("Status")]
            public CharacterStat BasicStatus;

            [Header("Action")]
            public ActionDataAttack AttackAction;
            public ActionDataDefense DefenseAction;
            public ActionDataSkill[] SkillsAction;
            public ActionDataSupport SupportAction;
            public ActionDataMove MoveAction;
        }

        [System.Serializable]
        public struct CharacterStat : IBasicStat
        {
            public int Attack => _attack;
            public int Defense => _defense;
            public int Health => _health;
            public int Speed => _speed;
            public int Ap => _ap;

            public int _attack;
            public int _defense;
            public int _health;
            public int _speed;
            public int _ap;
        }

    }
}
