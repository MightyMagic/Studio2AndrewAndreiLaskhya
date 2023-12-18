using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;
using UnityEngine.XR;
using System.Security.Cryptography;
using System.Xml;

public class AchievemntSaveLoad : MonoBehaviour
{
    [SerializeField] string filename;
    [SerializeField] int index;
    [SerializeField] int numberOfAllSecrets;

    [SerializeField] GameObject interactiveObject;

    string filePath;
    bool isCollected;

   
    void Start()
    {
        filePath = Application.persistentDataPath + "/" + filename;
        Debug.Log("Achievement file: " + filePath);
       // WriteAchievemts(index, isCollected, true);
    }

    
    void Update()
    {
        
    }

    //void WriteAchievemts(int index, bool isCollected, bool foundSecret)
    //{
    //    if(File.Exists(filePath))
    //    {
    //
    //        //string line = index.ToString() + "," + isCollected.ToString();
    //        byte[] bytes = File.ReadAllBytes(filePath);
    //        string lines = System.Text.Encoding.UTF8.GetString(bytes); ;
    //
    //
    //        string[] subLines = lines.Split('\n');
    //
    //        for(int i = 0; i< subLines.Length; i++)
    //        {
    //            print("subLine: " + subLines[i]);
    //            string[] parts = subLines[i].Split(',');
    //            Debug.Log("parts[0]: " + parts[0]);
    //            //Debug.Log("parts[1]: " + parts[1]);
    //            Debug.Log("parts[Length]: " + parts.Length);
    //            int indexInLine = int.Parse(parts[0]);
    //            //bool boolInLine = bool.Parse(parts[1]);
    //
    //           // if (indexInLine == index & foundSecret & !boolInLine)
    //           // {
    //           //     isCollected = true;
    //           // }
    //        }
    //        interactiveObject.SetActive(false);
    //
    //        // foreach (string subLine in subLines)
    //        // {
    //        //     print("subLine: " + subLine);
    //        //     string[] parts = subLine.Split(',');
    //        //     Debug.Log("parts[0]: " + parts[0]);
    //        //     Debug.Log("parts[1]: " + parts[1]);
    //        //     int indexInLine = int.Parse(parts[0]);
    //        //     bool boolInLine = bool.Parse(parts[1]);
    //        //
    //        //     if(indexInLine == index & foundSecret & !boolInLine)
    //        //     {
    //        //         isCollected = true;
    //        //     }
    //        //     
    //        //     interactiveObject.SetActive(false);
    //        //     
    //        // }
    //
    //        subLines[index] = index.ToString() + "," + true.ToString();
    //
    //        string newLine = String.Empty;
    //
    //        for (int i = 0; i < numberOfAllSecrets; i++)
    //        {
    //            newLine += subLines[i] + "\n";
    //        }
    //
    //        bytes = Encoding.ASCII.GetBytes(newLine);
    //        File.WriteAllBytes(filePath, bytes);
    //    }
    //    else
    //    {
    //        string newLine = String.Empty;
    //
    //        for (int i = 0; i < numberOfAllSecrets; i++)
    //        {
    //            newLine += i.ToString() + "," + false.ToString() + "\n";
    //        }
    //
    //        byte[] bytes = Encoding.ASCII.GetBytes(newLine);
    //        File.WriteAllBytes(filePath, bytes);
    //    }
    //    
    //}

    /*
    void ReadAchievements(int index, bool isCollected)
    {
        if (File.Exists(filePath))
        {
           
            byte[] bytes = File.ReadAllBytes(filePath);
            string lines = System.Text.Encoding.UTF8.GetString(bytes); ;
            string[] subLines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                // Split the line into parts
                string[] parts = line.Split(',');

                if (parts.Length == 2)
                {
                    // Decode integer and boolean values
                    int Index = int.Parse(parts[0]);
                    bool IsCollected = bool.Parse(parts[1]);

                    // Use the decoded values
                    Debug.Log($"Index: {index}, IsCollected: {isCollected}");
                }
                else 
                {
                    Debug.LogWarning("Invalid line format: " + line);
                }
            }
        }
        else
        {
            Debug.LogWarning("File not found: " + filePath);
        }
    }
    */
}
