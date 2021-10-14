using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject[] playerOptions;
    private SelectCharacter selectCharacter;

    public float minX,  maxX;

    private void Awake()
    {
        selectCharacter = GetComponent<SelectCharacter>();
    }

    private void Start()
    {
        Debug.Log(selectCharacter.GetUserName());
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), 0);
        PhotonNetwork.Instantiate(playerOptions[selectCharacter.getCharacter()].name, randomPosition, Quaternion.identity);
    }
}
