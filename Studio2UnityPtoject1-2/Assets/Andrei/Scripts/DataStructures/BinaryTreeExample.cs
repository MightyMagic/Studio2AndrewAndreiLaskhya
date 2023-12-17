using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BinaryTreeExample : MonoBehaviour
{
    BinaryTree tree = new BinaryTree();

    private void Start()
    {
        tree.Insert(10, "Root");
        tree.Insert(8, "Eight");
        tree.Insert(20, "Twenty");
        tree.Insert(7, "Seven");
        tree.Insert(4, "Four");


        print("Root + Left child: " + tree.Root.LeftChild.Value);
        print("Value by key 7 is " + tree.Find(7));
    }
}
