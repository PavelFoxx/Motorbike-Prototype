using System;
using UnityEngine;
using UnityEngine.U2D;
using Random = UnityEngine.Random;

namespace Code.Environment
{
    public class SpriteShapeGenerator : MonoBehaviour
    {
        [SerializeField] private SpriteShapeController spriteShapeController;

        [SerializeField] private float pointStep;
        [SerializeField] private float power;
        [SerializeField] private int pointsCount;
        [SerializeField] private float smoothFactor = 5f;



        private void Start()
        {
            Generate();
            PlaceGroundOnZero();
        }

        private void Generate()
        {
            var randomSeed = Random.Range(Int32.MinValue, Int32.MaxValue);
            spriteShapeController.spline.Clear();

            spriteShapeController.enableTangents = true;
            for (int i = 0; i < pointsCount; i++)
            {
                var y = Mathf.PerlinNoise(i * pointStep, randomSeed);
                var x = i * pointStep;

                y *= power;

                spriteShapeController.spline.InsertPointAt(i, new Vector2(x, y));

                spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                spriteShapeController.spline.SetLeftTangent(i, new Vector3(-1 * smoothFactor, 0));
                spriteShapeController.spline.SetRightTangent(i, new Vector3(1 * smoothFactor, 0));
            }
        }
        private void PlaceGroundOnZero()
        {
            transform.position = -spriteShapeController.spline.GetPosition(3);
        }
    }
}
