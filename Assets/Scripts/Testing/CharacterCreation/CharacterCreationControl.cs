using CombTeen.Constant;
using UnityEngine;

namespace CombTeen.Testing.CharacterCreation
{
    public class CharacterCreationControl : MonoBehaviour
    {
        [SerializeField] private CharacterSectionControl _characterSection;
        [SerializeField] private ActionSelectionControl _actionSelection;
        [SerializeField] private CharacterSlotController _characterSlot;

        public void SaveData()
        {
            var name = _characterSection.GetCharacterName();
            var classType = _characterSection.GetClassType();

            Debug.LogFormat("Charcter Saved | Name : {0} - Class : {1}",
                            name, classType);
            Debug.LogFormat("Action Selected || ATK :{0} | DEF :{1} | SKL :{2} | SUP :{3} | MOV:{4}",
                            _actionSelection.SelectedAttackId,
                            _actionSelection.SelectedDefenseId,
                            _actionSelection.SelectedSkillId,
                            _actionSelection.SelectedSupportId,
                            _actionSelection.SelectedMoveId);
            var characteraData = new CharacterSaveData()
            {
                Name = _characterSection.GetCharacterName(),
                ClassType = _characterSection.GetClassType(),

                AttackActionId = _actionSelection.SelectedAttackId,
                DefenseActionId = _actionSelection.SelectedDefenseId,
                SupportActionId = _actionSelection.SelectedSupportId,
                MoveActionId = _actionSelection.SelectedMoveId,

                SkillActionIds = new string[] { _actionSelection.SelectedSkillId }
            };
            Debug.Log($"Save Data on Slot {_characterSlot.SvaeSlot}-{JsonUtility.ToJson(characteraData)}");

        }

        #region Save Data Model Related
        [System.Serializable]
        public struct CharacterSaveData
        {
            public string Name;
            public ClassType ClassType;

            public string AttackActionId;
            public string DefenseActionId;
            public string[] SkillActionIds;
            public string SupportActionId;
            public string MoveActionId;
        }
        private string[] _savedCharacterData;
        #endregion 
    }


}
