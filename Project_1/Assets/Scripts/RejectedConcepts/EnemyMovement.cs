using System;
using UnityEngine;
/// <summary>
/// This script is design for enemies that have the same movement as that
/// of a dvd logo in a screen before you insert a disk in a dvd player
/// </summary>
public class EnemyMovement : MonoBehaviour
{
    [SerializeField]float moveSpeed = 3f;
    
    Vector2 _direction;
    GameObject _child;

    void Start()
    {
        _child = transform.GetChild(0).gameObject;
        _direction = new Vector2(-1, 1).normalized;
    }

    void Update() 
    {
        transform.Translate(_direction * (moveSpeed * Time.deltaTime));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.contacts[0].normal;
        _direction = Vector2.Reflect(_direction, normal);

        string wall = collision.gameObject.tag;
        if (wall == "CameraEdges_Left" || wall == "CameraEdges_Right")
        {
            _child.GetComponent<SpriteRenderer>().flipX = !_child.GetComponent<SpriteRenderer>().flipX;
        }
    }
}
