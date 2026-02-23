using System;
using UnityEngine;

public class PhoneInputController : MonoBehaviour, IHoldInput
{
    public event Action InputHolded;
    public event Action InputReleased;

    private bool isHolding = false;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && !isHolding)
            {
                isHolding = true;
                InputHolded?.Invoke();
            }
            else if ((touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) && isHolding)
            {
                isHolding = false;
                InputReleased?.Invoke();
            }
        }
        else if (isHolding)
        {
            isHolding = false;
            InputReleased?.Invoke();
        }
    }
}
