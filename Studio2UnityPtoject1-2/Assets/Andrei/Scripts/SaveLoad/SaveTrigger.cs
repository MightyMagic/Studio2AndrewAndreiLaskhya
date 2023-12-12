using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTrigger : MonoBehaviour
{
    [SerializeField] Transform playerPosToSave;
    [SerializeField] Transform lanternPosToSave;

    [SerializeField] PlayerData playerData;

    private void OnTriggerEnter(Collider other)
    {
        playerData.playerTransform = playerPosToSave;
        playerData.lanternTransform = lanternPosToSave;
        playerData.Save();
    }
}
