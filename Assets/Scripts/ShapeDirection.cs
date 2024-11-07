using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shapedirectiondetection : MonoBehaviour
{
    public string shapeName; // Name of the shape (make sure it's unique)
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private bool isSwipeDetected = false;
    private float minSwipeDistance = 50f; // Minimum distance for a valid swipe

    public enum SwipeDirection { Up, Down, Left, Right }
    public SwipeDirection requiredSwipeDirection; // Set in the Inspector per shape

    private Spawner spawner; // Reference to the Spawner script

    public void SetSpawner(Spawner spawnerReference)
    {
        spawner = spawnerReference;
    }

    private void OnMouseDown()
    {
        startTouchPosition = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        endTouchPosition = Input.mousePosition;
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        Vector2 swipe = endTouchPosition - startTouchPosition;

        if (swipe.magnitude >= minSwipeDistance)
        {
            swipe.Normalize();

            if (IsSwipeUp(swipe) && requiredSwipeDirection == SwipeDirection.Up ||
                IsSwipeDown(swipe) && requiredSwipeDirection == SwipeDirection.Down ||
                IsSwipeLeft(swipe) && requiredSwipeDirection == SwipeDirection.Left ||
                IsSwipeRight(swipe) && requiredSwipeDirection == SwipeDirection.Right)
            {
                CollectShape();
            }
        }
    }

    private bool IsSwipeUp(Vector2 swipe) => swipe.y > 0 && Mathf.Abs(swipe.y) > Mathf.Abs(swipe.x);
    private bool IsSwipeDown(Vector2 swipe) => swipe.y < 0 && Mathf.Abs(swipe.y) > Mathf.Abs(swipe.x);
    private bool IsSwipeLeft(Vector2 swipe) => swipe.x < 0 && Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y);
    private bool IsSwipeRight(Vector2 swipe) => swipe.x > 0 && Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y);

    private void CollectShape()
    {
        Debug.Log($"Shape {shapeName} collected with a {requiredSwipeDirection} swipe!");

        // Notify the spawner that this shape has been collected
        if (spawner != null)
        {
            spawner.OnShapeCollected();
        }

        // Destroy the shape object to simulate it being collected
        Destroy(gameObject);
    }
}
