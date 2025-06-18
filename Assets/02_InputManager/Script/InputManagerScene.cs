using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputManagerScene : MonoBehaviour
{
    #region VARIABLES
    [Header("UI 컨트롤러")]
    public Button JumpButton;
    public Button InteractionButton;
    public Button InventoryOpenButton;
    public TextMeshProUGUI JumpButtonText;
    public TextMeshProUGUI InteractionButtonText;
    public TextMeshProUGUI InventoryOpenButtonText;

    [Header("변경중인 키")]
    private Button _currentButton;
    private TextMeshProUGUI _currentButtonText;
    #endregion





    #region MONOBEHAVIOUR
    private void Awake()
    {
        JumpButton.onClick         .AddListener(() => { OnButtonClick("Jump", JumpButton,          JumpButtonText); });
        InteractionButton.onClick  .AddListener(() => { OnButtonClick("Interaction", InteractionButton,   InteractionButtonText); });
        InventoryOpenButton.onClick.AddListener(() => { OnButtonClick("InventoryOpen", InventoryOpenButton, InventoryOpenButtonText); });
    }

    private void OnEnable()
    {
        // JEventManager.Subscribe<CompleteRebindKeyEvent>(OnCompleteRebindKeyEvent); 
    }

    private void OnDisable()
    {
        // JEventManager.Unsbscribe<CompleteRebindKeyEvent>(OnCompleteRebindKeyEvent); 
    }
    #endregion





    #region FUNCTIONS
    public void OnButtonClick(string actionName, Button currentButton, TextMeshProUGUI currentButtonText)
    {
        _currentButton = currentButton;
        _currentButtonText = currentButtonText;

        _currentButton.interactable = false;
        _currentButtonText.text = "...";

        JInputManager.Instance.OnRebindKeyEvent(this, actionName);

        // JEventManager.SendEvent(new RebindKeyEvent(actionName))
    }

    public void OnCompleteRebindKeyEvent(string s)
    {
        _currentButton.interactable = true;
        _currentButtonText.text = s;
    }

    //public void OnCompleteRebindKeyEvent(OnCompleteRebindKeyEvent e)
    //{
    //    _currentButton.interactable = true;
    //    _currentButtonText.text = e.Key;
    //}
    #endregion
}
