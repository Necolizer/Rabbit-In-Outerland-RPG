using System.Collections;
using System.Collections.Generic;
//using UnityEditor.UIElements;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 p = transform.position;
        p.x += moveX * speed * Time.deltaTime;
        p.y += moveY * speed * Time.deltaTime;
        transform.position = p;
    }
}

