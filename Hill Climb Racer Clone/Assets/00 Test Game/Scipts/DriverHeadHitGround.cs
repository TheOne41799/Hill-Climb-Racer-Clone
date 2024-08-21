using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class DriverHeadHitGround : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<GroundGenerator>())
        {
            GameManager.Instance.GameOver();
        }
    }
}
