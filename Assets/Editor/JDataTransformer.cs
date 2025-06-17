using System.Collections.Generic;
using UnityEditor;
using System.IO;
using UnityEngine;
using ExcelDataReader;
using System.Data;
using Unity.Plastic.Newtonsoft.Json;
using System;

public class JDataTransformer : EditorWindow
{
#if UNITY_EDITOR
    [MenuItem("Data/ExcelToJson")]
    public static void ExcelToJson()
    {
        // ���� ������
        string dataPath = JDataPath.dataPath;

        if (ConvertExcelToJson<ItemData>(dataPath, "ItemData") == false)
        {
            return;
        }
        if (ConvertExcelToJson<MonsterData>(dataPath, "MonsterData") == false)
        {
            return;
        }
        if (ConvertExcelToJson<SkillData>(dataPath, "SkillData") == false)
        {
            return;
        }

        // ���ö�����
        string localizeDataPath = JLocalizeDataPath.dataPath;

        if (ConvertExcelToJson<LocalizeData>(localizeDataPath, "LocalizeData") == false)
        {
            return;
        }


        Debug.Log("Change Success");
    }

    private static bool ConvertExcelToJson<TData>(string filePath, string fileName) where TData : new()
    {
        string excelPath = filePath + "Excel/" + fileName + ".xlsx";

        if(File.Exists(excelPath) == false)
        {
            Debug.LogError($"[JDataTransfomer] : {fileName}.xlsx ������ �����!!");
            return false;
        }

        FileStream stream = File.Open(excelPath, FileMode.Open, FileAccess.Read);
        IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);

        DataSet result = reader.AsDataSet();
        DataTable table = result.Tables[0];

        List<string> headers = new List<string>();

        for(int col = 0; col < table.Columns.Count; col++)
        {
            headers.Add(table.Rows[0][col].ToString());
        }

        List<Dictionary<string, object>> rawData = new List<Dictionary<string, object>>();

        for(int row = 1; row < table.Rows.Count; row++)
        {
            Dictionary<string, object> rowData = new Dictionary<string, object>();

            for(int col = 0; col < table.Columns.Count; col++)
            {
                rowData[headers[col]] = table.Rows[row][col].ToString();
            }

            rawData.Add(rowData);
        }

        // new { Items = rawData }�� �ʵ带 ����� ����Ʈ�� �ٷ� ������ȭ �� �� ����
        // ����Ʈ�� ���δ� Ŭ������ �ʿ���
        //string json = JsonConvert.SerializeObject(new { Items = rawData }, Formatting.Indented);

        string json = JsonConvert.SerializeObject(rawData, Formatting.Indented);
        string jsonPath = filePath + "Json/" + fileName + ".json";

        File.WriteAllText(jsonPath, json);

        return true;
    }
#endif
}
