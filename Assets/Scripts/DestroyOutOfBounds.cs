using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBound : MonoBehaviour
{
    
    void Update()
    {
        if (transform.position.x < -30)
        {
            Destroy(gameObject);
        }
        
}
}
