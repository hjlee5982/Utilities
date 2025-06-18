using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    private void Start()
    {
        JInputManager.Instance.BindCallback(OnJump, "Jump");
        JInputManager.Instance.BindCallback(OnInteraction, "Interaction");
    }

    private void OnJump()
    {
        Debug.Log("[TestPlayer] : ����Ű ����");
    }

    private void OnInteraction()
    {
        Debug.Log("[TestPlayer] : ��ȣ�ۿ�  Ű ����");
    }
}
