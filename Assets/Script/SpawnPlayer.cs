using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
   void Start()
    {
        GameObject player = GameObject.FindWithTag("Player"); // Cari player
        if (player != null)
        {
            player.transform.position = transform.position; // Pindahkan player ke posisi spawn
        }
    }
}