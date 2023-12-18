using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class TreeNode 
{
    public int Key;
    public string Value;

    public TreeNode LeftChild;
    public TreeNode RightChild;

    public TreeNode(int key, string value)
    {
        this.Key = key;
        this.Value = value;
    }
    
}
