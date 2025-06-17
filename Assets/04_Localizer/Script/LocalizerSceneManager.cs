using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LocalizerSceneManager : MonoBehaviour
{
    #region VARIABLES
    [Header("UI 컨트롤러")]
    public Button          LanguageChangeButton;
    public TextMeshProUGUI HelloText;

    [Header("언어 인덱스")]
    private int Index = 1;
    #endregion





    #region MONOBEHAVIOUR
    private void Awake()
    {
        LanguageChangeButton.onClick.AddListener(OnLanguageChangeButton);
    }

    private void Start()
    {
        HelloText.text = JLocalizer.Instance.GetText(HelloText.name);
    }
    #endregion





    #region FUNTIONS
    private void OnLanguageChangeButton()
    {
        if(Index == 4)
        {
            Index = 0;
        }

        string language = "";

        switch(Index)
        {
            case 0:
                language = "KR";
                break;
            case 1:
                language = "EN";
                break;
            case 2:
                language = "JP";
                break;
            case 3:
                language = "CN";
                break;
        }

        JLocalizer.Instance.SetCurrentLanguage(language);

        HelloText.text = JLocalizer.Instance.GetText(HelloText.name);

        ++Index;
    }
    #endregion
}
