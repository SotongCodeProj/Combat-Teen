
using CombTeen.Esential.PlayerData.CharacterData;
using CombTeen.Esential.PlayerData.GeneralInfo;

namespace CombTeen.Esential.PlayerData
{
    public class PlayerData
    {
        public IPlayerGeneralInfo GeneralInfo { private set; get; }
        public IPlayerCharacterData ChararcterData { private set; get; }

        public PlayerData(PlayerGeneralInfo generalInfo,
                          PlayerCharacterData chararcterData)
        {
            ChararcterData = chararcterData;
            GeneralInfo = generalInfo;
        }
    }
}
