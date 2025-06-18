using UnityEngine;

public class TestInventory : MonoBehaviour
{
    private void Start()
    {
        JInputManager.Instance.BindCallback(OnInventoryOpen, "InventoryOpen");
    }

    private void OnInventoryOpen()
    {
        Debug.Log("[TestInventory] : 인벤토리 오픈 키 눌림");
    }

}
