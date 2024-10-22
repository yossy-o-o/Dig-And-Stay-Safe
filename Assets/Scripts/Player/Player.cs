using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    [SerializeField] Tilemap fieldTilemap;//地面のタイルマップ
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Vector3 hitPos = Vector3.zero;

        foreach (ContactPoint2D point in other.contacts)
        {
            hitPos = point.point;
        }
    }
    
}
