using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;

public static class JDataPath
{
    // ������Ʈ ���� ��� Application.dataPath = Assets������
    public static string dataPath = $"{Application.dataPath}/03_DataManager/";

    // Appdata/Locallow/ȸ���̸�/������Ʈ�� 
    public static string persistentPath = $"{Application.persistentDataPath}/";
}

public class JDataManager : MonoBehaviour
{
    #region SINGLETON
    public static JDataManager Instance { get; private set; }

    private bool SingletonInitialize(bool dontDestroy = true)
    {
        if (Instance == null)
        {
            Instance = this;

            if (dontDestroy == true)
            {
                DontDestroyOnLoad(gameObject);
            }
            return true;
        }
        else
        {
            Destroy(gameObject);
            return false;
        }
    }
    #endregion





    #region VARIABLES
    [Header("Addressable")]
    public Dictionary<string, TextAsset> JsonData = new Dictionary<string, TextAsset>();

    [Header("Json Dictionary")]
    public Dictionary<string, ItemData>    ItemData    { get; private set; } = new Dictionary<string, ItemData>();
    public Dictionary<string, MonsterData> MonsterData { get; private set; } = new Dictionary<string, MonsterData>();
    public Dictionary<string, SkillData>   SkillData   { get; private set; } = new Dictionary<string, SkillData>();
    #endregion





    #region MONOBEHAVIOUR
    private void Awake()
    {
        if(SingletonInitialize() == false)
        {
            return; 
        }

        InitializeAddressable();
        InitializeDictionary();
    }
    #endregion





    #region FUNCTIONS
    private void InitializeAddressable()
    {
        var jsonDataOperationHandle = Addressables.LoadAssetsAsync<TextAsset>("GameData" /*��巹���� �� �̸�*/, json => JsonData[json.name] = json);
        jsonDataOperationHandle.WaitForCompletion(); // �Ϸ� �ȱ�ٸ��� ���� ����
    }

    private void InitializeDictionary()
    {
        // ���� json���� �ε�
        ItemData    = LoadJsonToDictionary<string, ItemData>   ("ItemData",    m => m.StringKey);
        MonsterData = LoadJsonToDictionary<string, MonsterData>("MonsterData", m => m.StringKey);
        SkillData   = LoadJsonToDictionary<string, SkillData>  ("SkillData",   m => m.StringKey);
    }

    private Dictionary<TKey, TValue> LoadJsonToDictionary<TKey, TValue>(string fileName, Func<TValue, TKey> keySelector)
    {
        List<TValue> list = JsonConvert.DeserializeObject<List<TValue>>(JsonData[fileName].text);

        return list.ToDictionary(keySelector);
    }
    #endregion
}
