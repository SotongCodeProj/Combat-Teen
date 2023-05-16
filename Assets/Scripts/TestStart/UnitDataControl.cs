using System.Collections.Generic;
using CombTeen.Gameplay.DataTransport;
using CombTeen.Gameplay.Unit.Action.Logic;
using CombTeen.Gameplay.Unit.Action.Object;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CombTeen.StartScene
{
    public class UnitDataControl : MonoBehaviour
    {
        private List<UnitPlayData.CharacterData> _players = new List<UnitPlayData.CharacterData>();
        private List<UnitPlayData.CharacterData> _enemies = new List<UnitPlayData.CharacterData>();
        private string _gameScene = "C00 TestingCombat";

        #region  Data

        [Header("Default Data")]
        [SerializeField] private UnitPlayData.CharacterData _defaultPlayer;
        [SerializeField] private UnitPlayData.CharacterData _defaultEnemy;
        [Header("Available Actions")]
        [SerializeField] private ActionObject<BaseAttackAction>[] AttackAction;
        [SerializeField] private ActionObject<BaseDefenseAction>[] DefenseAction;
        [SerializeField] private ActionObject<BaseSkillAction>[] SkillsAction;
        [SerializeField] private ActionObject<BaseSupportAction>[] SupportAction;
        [SerializeField] private ActionObject<BaseMoveAction>[] MoveAction;
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
        
        public void SetDefaultPlayer(PrepareUnitView view)
        {
            view.SetDefault(_defaultPlayer);
        }
        public void SetDefaultEnemy(PrepareUnitView view)
        {
            view.SetDefault(_defaultEnemy);
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
    }
}
