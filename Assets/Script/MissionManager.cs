using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Pastikan untuk menambahkan ini untuk UI

public class MissionManager : MonoBehaviour
{
    public int totalEnemiesToKill = 5; // Total musuh yang harus dibunuh
    private int enemiesKilled = 0; // Jumlah musuh yang telah dibunuh
    public Text missionText; // Referensi ke UI untuk menampilkan misi

    void Start()
    {
        UpdateMissionText();
    }

    public void EnemyDefeated()
    {
        enemiesKilled++; // Tambah jumlah musuh yang dibunuh
        UpdateMissionText();

        // Periksa apakah misi telah selesai
        if (enemiesKilled >= totalEnemiesToKill)
        {
            MissionCompleted();
        }
    }

    void UpdateMissionText()
    {
        missionText.text = "Kill " + (totalEnemiesToKill - enemiesKilled) + " enemies!";
    }

    void MissionCompleted()
    {
        // Lakukan sesuatu saat misi selesai
        Debug.Log("Mission Completed!");
        // Misalnya, tampilkan pesan atau berikan reward
    }
}
