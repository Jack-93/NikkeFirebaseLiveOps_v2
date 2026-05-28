[System.Serializable]
public class PlayerData
{
    public string nickname;
    public int level;
    public int gold;
    public bool tutorialCompleted;

    public InventoryData inventory;

    public PlayerData() // initialize default values
    {
        nickname = "NewPlayer";
        level = 1;
        gold = 1000;
        tutorialCompleted = false;

        inventory = new InventoryData();
    }
}