using TMPro;
using UnityEngine;
using System.Text;

public class InventoryUIManager : MonoBehaviour
{

    public TMP_Text inventoryText;

    private void Start()
    {
        RefreshInventoryUI();
    }

    public void AddPotion()
    {
        InventoryManager.Instance
            .AddItem("Potion", 1);

        RefreshInventoryUI();
    }

    public void AddGem()
    {
        InventoryManager.Instance
            .AddItem("Gem", 100);

        RefreshInventoryUI();
    }

    public void RefreshInventoryUI()
    {
        var inventory =
            PlayerDataManager.Instance
            .playerData.inventory.items;

        StringBuilder sb =
            new StringBuilder();

        sb.AppendLine("Inventory");

        foreach (var item in inventory)
        {
            sb.AppendLine(
                $"{item.Key} x{item.Value}"
            );
        }

        inventoryText.text = sb.ToString();
    }
}