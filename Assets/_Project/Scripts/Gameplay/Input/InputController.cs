using System;
using UnityEngine;

public class InputController : MonoBehaviour, IHoldInput
{
   
    public event Action InputHolded;
    public event Action InputReleased;

    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
            InputHolded?.Invoke();
        if (Input.GetMouseButtonUp(0)) 
            InputReleased?.Invoke();
    }
}
