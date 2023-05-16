using CombTeen.Gameplay.DataTransport;
using TMPro;
using UnityEngine;

public class PrepareUnitView : MonoBehaviour
{
    [Header("Status")]
    public TMP_InputField Attack;
    public TMP_InputField Defense;
    public TMP_InputField Health;
    public TMP_InputField Speed;
    public TMP_InputField AP;

    [Header("Action")]
    public TMP_Dropdown AttackAction;
    public TMP_Dropdown DefenseAction;
    public TMP_Dropdown SkillAction;
    public TMP_Dropdown SupportAction;
    public TMP_Dropdown MoveAction;

    public void SetDefault(UnitPlayData.CharacterData characterData)
    {
        Attack.text = characterData.BasicStatus.Attack.ToString();
        Defense.text = characterData.BasicStatus.Defense.ToString();
        Health.text = characterData.BasicStatus.Health.ToString();
        Speed.text = characterData.BasicStatus.Speed.ToString();
        AP.text = characterData.BasicStatus.Ap.ToString();
    }

    public void RandomAction(int attack, int defense, int skill, int support, int move)
    {
        AttackAction.value = attack;
        DefenseAction.value = defense;
        SkillAction.value = skill;
        SupportAction.value = support;
        MoveAction.value = move;
    }
    
}
