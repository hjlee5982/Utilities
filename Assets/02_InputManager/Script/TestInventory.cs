using UnityEngine;

public class TestInventory : MonoBehaviour
{
    private void Start()
    {
        JInputManager.Instance.BindCallback(OnInventoryOpen, "InventoryOpen");
    }

    private void OnInventoryOpen()
    {
        Debug.Log("[TestInventory] : �κ��丮 ���� Ű ����");
    }

}
