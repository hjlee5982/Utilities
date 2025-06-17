using UnityEngine;
using UnityEngine.UI;

public class AudioSceneManager : MonoBehaviour
{
    #region VARIABLES
    [Header("UI 컨트롤러")]
    public Button BGM_Play_Button;
    public Button BGM_Stop_Button;
    public Button SFX_Play_Button;
    public Toggle BGM_Toggle;
    public Toggle SFX_Toggle;
    public Slider BGM_Volume_Slider;
    public Slider SFX_Volume_Slider;

    [Header("오디오 설정 정보")]
    private JAudioManager.AudioSettingData _audioSettingData = new JAudioManager.AudioSettingData();
    #endregion





    #region MONOBEHAVIOUR
    private void Awake()
    {
        BGM_Play_Button.onClick.AddListener(PlayBGM);
        BGM_Stop_Button.onClick.AddListener(StopBGM);
        SFX_Play_Button.onClick.AddListener(PlaySFX);

        BGM_Toggle.onValueChanged.AddListener(ToggleBGM);
        SFX_Toggle.onValueChanged.AddListener(ToggleSFX);
        BGM_Toggle.SetIsOnWithoutNotify(false);
        SFX_Toggle.SetIsOnWithoutNotify(false);

        BGM_Volume_Slider.onValueChanged.AddListener(SetBGMVolume);
        SFX_Volume_Slider.onValueChanged.AddListener(SetSFXVolume);
        BGM_Volume_Slider.SetValueWithoutNotify(0.5f);
        SFX_Volume_Slider.SetValueWithoutNotify(0.5f);
    }

    private void Start()
    {
        // 이 부분은 데이터 매니저에서 로드해 온 값으로 설정하면 됨
        // EX) _audioSettingData = JDataLoader.Instance.AudioSettingData;
        {
            _audioSettingData.BGM_Slider_Value = 0.5f;
            _audioSettingData.SFX_Slider_Value = 0.5f;
            _audioSettingData.BGM_Toggle_Value = false;
            _audioSettingData.SFX_Toggle_Value = false;
        }
        
        BGM_Volume_Slider.SetValueWithoutNotify(_audioSettingData.BGM_Slider_Value);
        SFX_Volume_Slider.SetValueWithoutNotify(_audioSettingData.SFX_Slider_Value);
        BGM_Toggle       .SetIsOnWithoutNotify (_audioSettingData.BGM_Toggle_Value);
        SFX_Toggle       .SetIsOnWithoutNotify (_audioSettingData.SFX_Toggle_Value);

        JAudioManager.Instance.InitializeAudioSettingData(_audioSettingData);
    }
    #endregion





    #region FUNTIONS
    private void PlayBGM()
    {
        JAudioManager.Instance.PlayBGM("BGM_0");
    }

    private void StopBGM()
    {
        JAudioManager.Instance.StopBGM();
    }

    private void PlaySFX()
    {
        JAudioManager.Instance.PlaySFX("SFX_0");
    }

    private void ToggleBGM(bool mute)
    {
        BGM_Volume_Slider.interactable = !mute;

        JAudioManager.Instance.ToggleBGM(mute);
    }

    private void ToggleSFX(bool mute)
    {
        SFX_Volume_Slider.interactable = !mute;

        JAudioManager.Instance.ToggleSFX(mute);
    }

    private void SetBGMVolume(float volume)
    {
        JAudioManager.Instance.SetBGMVolume(volume);
    }

    private void SetSFXVolume(float volume)
    {
        JAudioManager.Instance.SetSFXVolume(volume);
    }
    #endregion
}
