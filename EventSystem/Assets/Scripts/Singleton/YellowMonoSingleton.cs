using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class YellowMonoSingleton<T> : MonoBehaviour where T : YellowMonoSingleton<T>
{
    private static T m_Instance;

    public static T Instance
    {
        get
        {
            if (object.ReferenceEquals(YellowMonoSingleton<T>.m_Instance, null))
            {
                YellowMonoSingleton<T>.m_Instance = (UnityEngine.Object.FindObjectOfType(typeof(T)) as T);
                if (object.ReferenceEquals(YellowMonoSingleton<T>.m_Instance, null))
                {
                    Debug.LogWarning("cant find a gameobject of instance " + typeof(T) + "!");
                }
                else
                {
                    YellowMonoSingleton<T>.m_Instance.OnAwake();
                }
            }
            return YellowMonoSingleton<T>.m_Instance;
        }
    }



    private void Awake()
    {
       
        if (object.ReferenceEquals(YellowMonoSingleton<T>.m_Instance, null))
        {
            YellowMonoSingleton<T>.m_Instance = (this as T);
            YellowMonoSingleton<T>.m_Instance.OnAwake();
        }
    }
    protected virtual void OnAwake()
    {
    }

}
