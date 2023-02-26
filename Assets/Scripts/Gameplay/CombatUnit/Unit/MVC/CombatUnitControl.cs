using System.Collections.Generic;
using CombTeen.Gameplay.DataTransport.TestData;
using CombTeen.Gameplay.Unit.Action.Logic;
using UnityEngine;
namespace CombTeen.Gameplay.Unit.MVC
{
    public abstract class CombatUnitControl
    {
        public abstract string UnitId { get; }
        public CombatUnitModel Data { protected set; get; } = new CombatUnitModel();
        public CombatUnitView View { protected set; get; }

        public void InitialUnitData(CharacterData Character)
        {
            Data.PlayerId = Character.CharacterId;
            Data.UnitName = Character.CharacterName;

            List<BaseSkillAction> skills = new List<BaseSkillAction>();
            for (int i = 0; i < Character.SkillsAction.Length; i++)
            {
                skills.Add(Character.SkillsAction[i].Logic.InitializeOwner(this));
            }

            Data.Initialize(Character.AttackAction.Logic.InitializeOwner(this),
                            Character.DefenseAction.Logic.InitializeOwner(this),
                            Character.SupportAction.Logic.InitializeOwner(this),
                            skills.ToArray());
        }
    }
}
