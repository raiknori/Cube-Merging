public class DeffaultDefineValue : IDefineValue
{
    public void DefineValue(IMergeable mergeable)
    {
        if (UnityEngine.Random.Range(0, 100) <= 25)
        {
            mergeable.SetValue(4);
        }
        else
        {
            mergeable.SetValue(2);
        }
    }

}