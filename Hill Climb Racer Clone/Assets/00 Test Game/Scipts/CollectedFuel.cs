using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedFuel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInParent<VehicleController>())
        {
            GameManager.Instance.FuelCollected();
            Destroy(gameObject);
        }
    }
}
