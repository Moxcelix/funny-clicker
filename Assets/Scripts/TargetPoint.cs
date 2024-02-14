using UnityEngine;

public class TargetPoint : Point
{
    protected override void OnPress()
    {
        Debug.Log("На меня нажали!!!");
    }
}
