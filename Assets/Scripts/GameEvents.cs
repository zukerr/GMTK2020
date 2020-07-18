using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{

    #region Singleton
    private static GameEvents _instance;
    public static GameEvents instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject obj = new GameObject("GameEvents");
                GameEvents e = obj.AddComponent<GameEvents>();
                _instance = e;
            }
            return _instance;
        }
    }
    #endregion
    // Start is called before the first frame update
    void Awake()
    {
        if(_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public event Action<int> OnKeyPickedUp;
    public void PickUpKey(int channel)
    {
        OnKeyPickedUp?.Invoke(channel);
    }
    public void ReloadScene()
    {
        LevelLoader.ReloadScene();
    }
}
