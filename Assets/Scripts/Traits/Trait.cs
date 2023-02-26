using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Traits/Create Trait",fileName = "T[id]-[Name]")]
public class Trait : ScriptableObject
{
    public string TraitName;
    public string TraitId;
    // public TraitLogic traitLogic;
}
