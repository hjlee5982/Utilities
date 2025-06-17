using UnityEngine;

public class EventReceiver_2 : MonoBehaviour
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
        Debug.Log("[EventReceiver_2] : �̺�Ʈ ���� : " + e.Value.ToString());
    }
    #endregion
}

