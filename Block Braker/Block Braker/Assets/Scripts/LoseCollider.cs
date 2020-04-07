using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{

    //When pass through Lose Collider trigger (below camra) 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameStatus>().LoseALife();
    }
}
