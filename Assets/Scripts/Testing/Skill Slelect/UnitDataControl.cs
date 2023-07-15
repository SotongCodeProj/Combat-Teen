using System.Collections.Generic;
using CombTeen.Gameplay.DataTransport;
using CombTeen.Gameplay.Unit.Action.Logic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CombTeen.Testing.SkillSelection;
using CombTeen.Esential.ActionSystem;

namespace CombTeen.StartScene
{
    public class UnitDataControl : MonoBehaviour
    {
        private List<UnitPlayData.CharacterData> _players = new List<UnitPlayData.CharacterData>();
        private List<UnitPlayData.CharacterData> _enemies = new List<UnitPlayData.CharacterData>();
        private string _gameScene = "C00 TestingCombat";

        #region  Data

        [Header("Random Stat Data")]
        [SerializeField] private RandomStatValue _randomStat;

        [Header("Available Actions")]
        [SerializeField] private ActionDataAttack[] AttackAction;
        [SerializeField] private ActionDataDefense[] DefenseAction;
        [SerializeField] private ActionDataSkill[] SkillsAction;
        [SerializeField] private ActionDataSupport[] SupportAction;
        [SerializeField] private ActionDataMove[] MoveAction;
        #endregion

        [Header("View")]
        [SerializeField] private PrepareUnitView[] _playersView;
        [SerializeField] private PrepareUnitView[] _enemyView;


        public void StartGame()
        {
            for (int i = 0; i < _playersView.Length; i++)
            {
                _players.Add(GenerateCharacterData(_playersView[i]));
                _enemies.Add(GenerateCharacterData(_enemyView[i]));
            }

            BridgeData.Instance.SetUnitData(_players, _enemies);

            SceneManager.LoadScene(_gameScene);
        }
        public void RandomAll()
        {
            foreach (var unit in _playersView)
            {
                SetUniStat(unit);
                RandomSkill(unit);
            }

            foreach (var unit in _enemyView)
            {
                SetUniStat(unit);
                RandomSkill(unit);
            }
        }

        public void SetUniStat(PrepareUnitView view)
        {
            view.SetDefault(_randomStat);
        }
       

        public void RandomSkill(PrepareUnitView view)
        {

            view.RandomAction(Random.Range(0, AttackAction.Length),
                              Random.Range(0, DefenseAction.Length),
                              Random.Range(0, SkillsAction.Length),
                              Random.Range(0, SupportAction.Length),
                              Random.Range(0, MoveAction.Length));
        }

        private UnitPlayData.CharacterData GenerateCharacterData(PrepareUnitView view)
        {
            return new UnitPlayData.CharacterData()
            {
                CharacterId = "C" + view.GetInstanceID(),
                CharacterName = view.name,

                BasicStatus = new CombTeen.Gameplay.DataTransport.UnitPlayData.CharacterStat()
                {
                    _attack = int.Parse(view.Attack.text),
                    _defense = int.Parse(view.Defense.text),
                    _health = int.Parse(view.Health.text),
                    _speed = int.Parse(view.Speed.text),
                    _ap = int.Parse(view.AP.text)
                },


                AttackAction = AttackAction[view.AttackAction.value],
                DefenseAction = DefenseAction[view.DefenseAction.value],
                SkillsAction = new[] { SkillsAction[view.DefenseAction.value] },
                SupportAction = SupportAction[view.SupportAction.value],
                MoveAction = MoveAction[view.MoveAction.value],

            };
        }

        [System.Serializable]
        public struct RandomStatValue
        {
            [Min(1)]
            public int Attack;
            [Min(1)]
            public int Defense;
            [Min(15)]
            public int Health;
            [Range(1, 5)]
            public int Speed;
            [Range(3, 5)]
            public int Ap;
        }
    }

}
