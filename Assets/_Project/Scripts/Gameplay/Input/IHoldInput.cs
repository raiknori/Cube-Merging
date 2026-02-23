using System;

public interface IHoldInput
{
    event Action InputHolded;
    event Action InputReleased;


}
