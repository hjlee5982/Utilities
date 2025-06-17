using UnityEngine;

public class EventReceiver_1 : MonoBehaviour
{
    #region MONOBEHAVIOUR
    private void OnEnable()
    {
        JEventManager.Subscribe<ButtonClickEvent>(OnButtonClick);
    }

    private void OnDisable()
    {
        JEventManager.Unsubscribe<ButtonClickEvent>(OnButtonClick);
    }
    #endregion





    #region FUNCTIONS
    public void OnButtonClick(ButtonClickEvent e)
    {
        Debug.Log("[EventReceiver_1] : �̺�Ʈ ���� : " + e.Value.ToString());
    }
    #endregion
}
