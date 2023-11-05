using System;
using System.Collections.Generic;
using CombTeen.Gameplay.DataTransport;
using UnityEngine;

public class BridgeData : MonoBehaviour
{
    private IEnumerable<UnitPlayData.CharacterData> _players;
    private IEnumerable<UnitPlayData.CharacterData> _enemies;
    public static BridgeData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    
    public (IEnumerable<UnitPlayData.CharacterData> Players, IEnumerable<UnitPlayData.CharacterData> Enemys) GetCurrentUnitData()
    {
        return (_players, _enemies);
    }

    public void SetUnitData(IEnumerable<UnitPlayData.CharacterData> players, IEnumerable<UnitPlayData.CharacterData> enemys)
    {
        _players = players;
        _enemies = enemys;
    }

}
