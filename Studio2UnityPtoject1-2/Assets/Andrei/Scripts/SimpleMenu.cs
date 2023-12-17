using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SimpleMenu : MonoBehaviour
{
    [SerializeField] string sceneToLoad;
    [SerializeField] string filenameTxt;

    string data;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;

    }


    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ContinueGame()
    {
        if (File.Exists(Application.persistentDataPath + "/" + filenameTxt))
        {
            data = File.ReadAllText(Application.persistentDataPath + "/" + filenameTxt);

            if (data != string.Empty)
            {
                string[] parts = data.Split(',');
                string sceneName = parts[0];
                float x = float.Parse(parts[1]);
                float y = float.Parse(parts[2]);
                float z = float.Parse(parts[3]);

                float lanternX = float.Parse(parts[4]);
                float lanternY = float.Parse(parts[5]);
                float lanternZ = float.Parse(parts[6]);

                SceneManager.LoadScene(sceneName);
            }
            
        }
        else
        {
            data = string.Empty;
            File.WriteAllText(Application.persistentDataPath + "/" + filenameTxt, string.Empty);
            Debug.Log("File cleared");
            StartGame();
        }

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
