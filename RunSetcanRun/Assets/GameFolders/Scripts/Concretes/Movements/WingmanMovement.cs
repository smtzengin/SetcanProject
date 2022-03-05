using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingmanMovement : MonoBehaviour
{
    Vector2 upPos;
    Vector2 downPos;
    Vector2 wingmanVector;
    [SerializeField] float wingmanSpeed; 
    bool x = false;
    void Start()
    {
        upPos = transform.position;
        downPos = new Vector2(upPos.x, upPos.y - 12);
        wingmanVector = new Vector2(0, wingmanSpeed);
    }
    void Update()
    {
        if (transform.position.y >= downPos.y && !x)
        {
            transform.Translate(-wingmanVector * Time.deltaTime);
        }
        else if (transform.position.y <= upPos.y)
        {
            x = true;
            transform.Translate(wingmanVector * Time.deltaTime);
        }
        else
        {
            x = false;
        }
        
    }
}
