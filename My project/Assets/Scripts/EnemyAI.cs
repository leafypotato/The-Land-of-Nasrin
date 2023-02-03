using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    private bool movingRight = true;

    public Transform groundDetection;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        //used to calculate if there is ground below the enemy that they can walk on

        if(groundInfo.collider == false)
            //if no ground is found (air)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
                //enemy starts moving to the left
            }
            else
            {
                transform.eulerAngles = new Vector3(0,0,0);
                movingRight = true;
                //enemy starts moving to the right
            }
        }
    }
}
