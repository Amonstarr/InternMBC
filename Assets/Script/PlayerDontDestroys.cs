// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerDontDestroys : MonoBehaviour
// {
//     private static PlayerDontDestroys instance;

//     private void Awake()
//     {
//         // Cek jika sudah ada Player, maka hancurkan yang baru (singleton pattern)
//         if (instance != null && instance != this)
//         {
//             Destroy(gameObject);
//         }
//         else
//         {
//             instance = this;
//             DontDestroyOnLoad(gameObject); // Jangan hancurkan saat pindah scene
//         }
//     }
// }
