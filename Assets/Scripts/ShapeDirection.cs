using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shapedirectiondetection : MonoBehaviour

{
    public string shapeName; // Name of the shape (make sure it's unique)

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private bool isSwipeDetected = false;

    // Minimum distance for a valid swipe
    private float minSwipeDistance = 50f;

    // Define swipe directions (modify as needed)
    public enum SwipeDirection
    {
        Up,
        Down,
        Left,
        Right
    }

    public SwipeDirection requiredSwipeDirection; // Set in the Inspector per shape

    private void OnMouseDown()
    {
        // Capture the start position when mouse is pressed down
        startTouchPosition = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        // Capture the end position when mouse is released
        endTouchPosition = Input.mousePosition;

        // Check if the swipe was detected and validate the direction
        DetectSwipe();
    }

    // Method to detect swipe and compare direction
    private void DetectSwipe()
    {
        Vector2 swipe = endTouchPosition - startTouchPosition;

        // Check if the swipe is long enough to be considered valid
        if (swipe.magnitude >= minSwipeDistance)
        {
            swipe.Normalize(); // Normalize the swipe direction

            // Determine the swipe direction
            if (IsSwipeUp(swipe) && requiredSwipeDirection == SwipeDirection.Up)
            {
                CollectShape();
                GetComponent<Timer>().addTime();
            }
            else if (IsSwipeDown(swipe) && requiredSwipeDirection == SwipeDirection.Down)
            {
                CollectShape();
                GetComponent<Timer>().addTime();
            }
            else if (IsSwipeLeft(swipe) && requiredSwipeDirection == SwipeDirection.Left)
            {
                CollectShape();
                GetComponent<Timer>().addTime();
            }
            else if (IsSwipeRight(swipe) && requiredSwipeDirection == SwipeDirection.Right)
            {
                CollectShape();
                GetComponent<Timer>().addTime();
            }
        }
    }

    // Methods to check for swipe directions
    private bool IsSwipeUp(Vector2 swipe)
    {
        return swipe.y > 0 && Mathf.Abs(swipe.y) > Mathf.Abs(swipe.x);
    }

    private bool IsSwipeDown(Vector2 swipe)
    {
        return swipe.y < 0 && Mathf.Abs(swipe.y) > Mathf.Abs(swipe.x);
    }

    private bool IsSwipeLeft(Vector2 swipe)
    {
        return swipe.x < 0 && Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y);
    }

    private bool IsSwipeRight(Vector2 swipe)
    {
        return swipe.x > 0 && Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y);
    }

    // Call this method when the shape is collected via correct swipe
    private void CollectShape()
    {
        Debug.Log($"Shape {shapeName} collected with a {requiredSwipeDirection} swipe!");



        // Destroy the shape object to simulate it being collected
        Destroy(gameObject);
    }
}