using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class PlayerData : MonoBehaviour
{

    public Transform playerTransform;
    [SerializeField] GameObject playerObject;

    public Transform lanternTransform;
    [SerializeField] GameObject lanternObject;


    [SerializeField] string saveFile;

    string filePath;
    

    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, saveFile);
        //Camera.main.enabled= false;
        // StartCoroutine(Wait());
        // 
        Load();
        //Camera.main.enabled= true;

    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
    }

    public void Save()
    {
        //saveFile = Application.persistentDataPath + saveFile;
        string filePath = Path.Combine(Application.persistentDataPath, saveFile);
        print("File name " + filePath);
        File.WriteAllText(filePath, JsonUtility.ToJson(this));
    }

    public void ResetSave()
    {
        File.Delete(filePath);
    }

    public void Load()
    {
        if (File.Exists(saveFile))
        {
            string jsonContent = File.ReadAllText(filePath);

            PlayerData currenData = JsonUtility.FromJson<PlayerData>(jsonContent);
            playerObject.transform.position = currenData.playerTransform.position;
            lanternObject.transform.position = currenData.lanternTransform.position;
        }
        else
            return;

    }
}
