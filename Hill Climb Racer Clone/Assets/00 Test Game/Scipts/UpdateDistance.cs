using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateDistance : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI distanceValueText;
    [SerializeField] private Transform playerTransform;

    private Vector2 startPosition;


    private void Start()
    {
        startPosition = playerTransform.position;
    }


    private void Update()
    {
        Vector2 distance = (Vector2)playerTransform.position - startPosition;
        distance.y = 0f;

        if(distance.x < 0)
        {
            distance.x = 0;
        }

        distanceValueText.text = distance.x.ToString("F0") + "m";
    }
}
