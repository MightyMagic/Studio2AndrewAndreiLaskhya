using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BinaryTree
{
    public TreeNode Root =null;

    public void Insert(int key, string value)
    {
        Root = InsertItem(Root, key, value);
    }

    public TreeNode InsertItem(TreeNode node, int key, string value)
    {
        TreeNode newNode = new TreeNode(key, value);

        if(node ==null)
        {
            node = newNode;
            return node;
        }

        if(key < node.Key)
        {
            node.LeftChild = InsertItem(node.LeftChild, key, value);
        }
        else
        {
            node.RightChild = InsertItem(node.RightChild, key, value);
        }
        return node;
    }
    
    public string Find(int key)
    {
        TreeNode node = Find(Root, key);
        if (node == null)
            return null;     
        else  
            return node.Value;      
    }

    private TreeNode Find(TreeNode node, int key)
    {
        if(node == null || node.Key == key)
        {
            return node;
        }
        else if(key < node.Key)
        {
            return Find(node.LeftChild, key);
        }
        else if(key > node.Key)
        {
            return Find(node.RightChild, key);
        }

        return null;
    }
}
