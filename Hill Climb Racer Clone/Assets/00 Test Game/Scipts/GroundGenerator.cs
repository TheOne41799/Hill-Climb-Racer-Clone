using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;


[ExecuteInEditMode]
public class GroundGenerator : MonoBehaviour
{
    [SerializeField] private SpriteShapeController groundShapeController;

    [SerializeField, Range(5f, 100f)] private int levelLength = 50;
    [SerializeField, Range(1f, 50f)] private float widthMultiplier = 2f;
    [SerializeField, Range(1f, 50f)] private float heightMultipler = 2f;
    [SerializeField, Range(0f, 1f)] private float curveSmoothness = 0.5f;
    [SerializeField] private float noiseStep = 0.5f;
    [SerializeField] private float bottom = 10f;

    private Vector3 lastPosition;

    [SerializeField] private float xDifficulty = 0.1f;
    [SerializeField] private float yDifficulty = 0.1f;


    private void OnValidate()
    {
        groundShapeController.spline.Clear();

        for(int i = 0; i < levelLength; i++)
        {
            lastPosition = transform.position + new Vector3(i * widthMultiplier,
                                                            Mathf.PerlinNoise(0, i * noiseStep) * heightMultipler);

            groundShapeController.spline.InsertPointAt(i, lastPosition);

            if( i != 0 && i != levelLength - 1 )
            {
                groundShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);

                groundShapeController.spline.SetLeftTangent(i, curveSmoothness * widthMultiplier * Vector3.left);
                groundShapeController.spline.SetRightTangent(i, curveSmoothness * widthMultiplier * Vector3.right);
            }

            widthMultiplier += xDifficulty;
            heightMultipler += yDifficulty;
        }

        groundShapeController.spline.InsertPointAt(levelLength, 
                                                   new Vector3(lastPosition.x, transform.position.y - bottom));

        groundShapeController.spline.InsertPointAt(levelLength + 1, 
                                                   new Vector3(transform.position.x, transform.position.y - bottom));
    }
}
