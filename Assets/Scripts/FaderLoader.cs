using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderLoader : MonoBehaviour
{
    public void LoadLevelOnAnimEnd()
    {
        UIHandler.instance.LoadNextLevel();
    }
}
