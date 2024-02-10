using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour {

    [SerializeField] private Key.KeyType keyType;

    public Key.KeyType GetKeyType() {
        return keyType;
    }

    public void OpenDoor() {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(true);
    }

}
