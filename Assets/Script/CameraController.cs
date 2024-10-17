// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CameraController : MonoBehaviour
// {
//     public Transform target;

//     void Start()
//     {

//     }

//     void Update()
//     {
//         transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;

    private void Start()
    {
        // Temukan player di scene saat dimulai
        FindPlayer();
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            // Set posisi kamera sama dengan posisi player
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
    }

    // Fungsi untuk menemukan player secara otomatis
    private void FindPlayer()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }
}



