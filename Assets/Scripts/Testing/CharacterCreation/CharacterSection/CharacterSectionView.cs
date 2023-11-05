using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CombTeen.Testing.CharacterCreation
{
    public class CharacterSectionView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _characterName;
        [SerializeField] private TMP_Dropdown _classSelection;

        public string CharacterName => _characterName.text;
        public UnityEvent<int> OnChangeClass { private set; get; } = new();
        // Start is called before the first frame update
        void Start()
        {
            _classSelection.onValueChanged.AddListener(OnChangeClass.Invoke);
        }
    }
}
