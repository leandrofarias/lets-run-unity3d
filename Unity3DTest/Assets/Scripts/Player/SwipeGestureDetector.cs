using UnityEngine;

public enum SwipeGestureDirection
{
    None,
    Down,
    Left,
    Right
}

/* 
 * Class to detect sliding gestures on the screen.
 */
public class SwipeGestureDetector
{
    private float fingerStartTime = 0.0f;
    private Vector2 fingerStartPos = Vector2.zero;

    private bool isSwipe = false;
    private float minSwipeDist = 50.0f;
    private float maxSwipeTime = 0.5f;
    
    public SwipeGestureDirection getSwipeGestureDirection(Touch[] touches)
    {
        foreach (Touch touch in touches)
        {
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // New touch
                    isSwipe = true;
                    fingerStartTime = Time.time;
                    fingerStartPos = touch.position;

                    break;
                case TouchPhase.Canceled:
                    // The touch is being canceled
                    isSwipe = false;

                    break;
                case TouchPhase.Ended:
                    float gestureTime = Time.time - fingerStartTime;
                    float gestureDist = (touch.position - fingerStartPos).magnitude;

                    if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist)
                    {
                        Vector2 direction = touch.position - fingerStartPos;
                        Vector2 swipeType = Vector2.zero;

                        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                        {
                            // The swipe is horizontal:
                            swipeType = Vector2.right * Mathf.Sign(direction.x);

                            if (swipeType.x != 0.0f)
                            {
                                if (swipeType.x > 0.0f)
                                {
                                    // Go to the right
                                    return SwipeGestureDirection.Right;
                                }
                                else
                                {
                                    // Go to the left
                                    return SwipeGestureDirection.Left;
                                }
                            }
                        }
                        else
                        {
                            // the swipe is vertical:
                            swipeType = Vector2.up * Mathf.Sign(direction.y);

                            if (swipeType.y < 0.0f)
                            {
                                return SwipeGestureDirection.Down;
                            }
                        }

                    }

                    break;
            }
        }

        return SwipeGestureDirection.None;
    }
}
