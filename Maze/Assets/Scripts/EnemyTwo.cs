using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    private Vector2 pos1 = new Vector3(0.4f,-2.46f,0f);
     private Vector2 pos2 = new Vector3(0.4f,2.51f,0f);
     public float speed = 1.0f;
 
     void Update() 
     {
         transform.position = Vector3.Lerp (pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
     }
}
