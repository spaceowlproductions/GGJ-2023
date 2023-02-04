using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SoftBody : MonoBehaviour
{
    private const float splineOffset = 0.5f;

    [SerializeField]
    public SpriteShapeController spriteShape;

    [SerializeField]
    public Transform[] points;

    private void Awake()
    {
        UpdateVertices();
    }
    // Update is called once per frame
    private void Update()
    {
        UpdateVertices();

    }

    void UpdateVertices()
    {
        for(int i = 0; i < points.Length - 1; i++)
        {
            Vector2 vertex = points[i].localPosition;

            Vector2 towardsCenter = (Vector2.zero - vertex).normalized;

            float colliderRadius = points[i].gameObject.GetComponent<CircleCollider2D>().radius;

            try
            {
                spriteShape.spline.SetPosition(i, (vertex - towardsCenter * colliderRadius));
            }
            catch
            {
                Debug.Log("Points are too close together.  Recaculate.");
                spriteShape.spline.SetPosition(i, (vertex - towardsCenter * (colliderRadius + splineOffset)));
            }

            Vector2 _lt = spriteShape.spline.GetLeftTangent(i);

            Vector2 newRT = Vector2.Perpendicular(towardsCenter) * _lt.magnitude;
            Vector2 newLT = Vector2.zero - (newRT);

            spriteShape.spline.SetLeftTangent(i, newLT);
            spriteShape.spline.SetRightTangent(i, newRT);
        }
    }

}
