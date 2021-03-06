using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private LevelManager levelManager;

    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        print("Trigger");
        //загружает экран победы в случае соприкосновения с мячом
        levelManager.LoadLevel("Lose");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }
}
