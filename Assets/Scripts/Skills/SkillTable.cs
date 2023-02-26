using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill Table/Create Table", fileName = "ST_[Generation]- Name")]
public class SkillTable : ScriptableObject
{
    public TableData[] AllAvaiableSkills;
}
[System.Serializable]
public class TableData
{
    [SerializeField] string dataName;
    public Trait[] RequiredTraits;
    public Skill RequiredSkill;
    public Skill Result;
}

