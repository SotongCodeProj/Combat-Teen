using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CombTeen.Esential.PlayerData.GeneralInfo
{
    public interface IPlayerGeneralInfo
    {
        public string PlayerName { get; }

    }
    public class PlayerGeneralInfo : IPlayerGeneralInfo
    {
        public string PlayerName { private set; get; }
        
        public PlayerGeneralInfo(string playerName)
        {
            PlayerName = playerName;
        }

    }
}
