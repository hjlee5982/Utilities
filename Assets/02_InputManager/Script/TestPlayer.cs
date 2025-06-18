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
        Debug.Log("[TestPlayer] : 점프키 눌림");
    }

    private void OnInteraction()
    {
        Debug.Log("[TestPlayer] : 상호작용  키 눌림");
    }
}
