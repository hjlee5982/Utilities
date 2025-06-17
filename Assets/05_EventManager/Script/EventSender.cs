using UnityEngine;
using UnityEngine.UI;

public class EventSender : MonoBehaviour
{
    #region VARIABLES
    public Button Button;
    #endregion





    #region MONOBEHAVIOUR
    private void Awake()
    {
        Button.onClick.AddListener(ButtonClick);
    }
    #endregion





    #region FUNCTIONS
    public void ButtonClick()
    {
        Debug.Log("[EventSender] : 이벤트 송신");

        JEventManager.SendEvent(new ButtonClickEvent(Random.Range(0,9)));
    }
    #endregion
}
