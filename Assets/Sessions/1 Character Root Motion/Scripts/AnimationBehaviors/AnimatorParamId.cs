using System;
using UnityEngine;

[Serializable]
public struct AnimatorParamId<TParamType> where TParamType : struct
{
    public string paramName;

    public TParamType GetValue(Animator animator)
    {
        throw new NotImplementedException("Use derived Parameters!");
    }
}

[Serializable]
public struct IntAnimatorParamId<TParamType> where TParamType : struct
{
    public string paramName;

    public TParamType GetValue(Animator animator)
    {
        throw new NotImplementedException("Use derived Parameters!");
    }
}
