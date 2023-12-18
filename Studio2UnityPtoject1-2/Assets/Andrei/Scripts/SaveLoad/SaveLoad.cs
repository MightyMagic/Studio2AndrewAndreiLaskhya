using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    
    [SerializeField] private GameObject playerToSave;
    [SerializeField] private GameObject lanternToSave;
    [SerializeField] string filenameTxt;

    string data;
    Vector3 position;

    void Start()
    {
        //SavePosTxt();
        LoadPosTxt();
    }

    public void SavePosTxt()
    {
        ClearFileAndCashTxt();
        position = playerToSave.transform.position;
        data += SceneManager.GetActiveScene().name + ",";
        data += position.x.ToString() + "," + position.y.ToString() + "," + position.z.ToString() + ",";

        position = lanternToSave.transform.position;
        data += position.x.ToString() + "," + position.y.ToString() + "," + position.z.ToString();

        File.WriteAllText(Application.persistentDataPath + "/" + filenameTxt, data);
        Debug.Log("Position saved");
        Debug.Log(Application.persistentDataPath + "/" + filenameTxt);
    }

    public void LoadPosTxt()
    {
        Debug.Log((Application.persistentDataPath + "/" + filenameTxt));
        if (File.Exists(Application.persistentDataPath + "/" + filenameTxt))
        {
            data = File.ReadAllText(Application.persistentDataPath + "/" + filenameTxt);

            if(data != string.Empty)
            {
                string[] parts = data.Split(',');
                string sceneName = parts[0];
                float x = float.Parse(parts[1]);
                float y = float.Parse(parts[2]);
                float z = float.Parse(parts[3]);

                float lanternX = float.Parse(parts[4]);
                float lanternY = float.Parse(parts[5]);
                float lanternZ = float.Parse(parts[6]);

                Debug.Log(x + "," + "," + y + "," + z);
                if(sceneName == SceneManager.GetActiveScene().name)
                {
                    playerToSave.transform.position = new Vector3(x, y, z);
                    lanternToSave.transform.position = new Vector3(lanternX, lanternY, lanternZ);
                }
                Debug.Log("Position loaded from scene: " + sceneName);
            }

            Debug.Log("Save file exists, but it's empty");
        }
        else
        {
            Debug.Log("Save file does not exist.");
        }
    }

    public void ClearFileAndCashTxt()
    {
        data = string.Empty;
        File.WriteAllText(Application.persistentDataPath + "/" + filenameTxt, string.Empty);
        Debug.Log("File cleared");
    }
}
