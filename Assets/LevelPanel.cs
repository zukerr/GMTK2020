using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelPanel : MonoBehaviour
{
    public GameObject buttonPrefab;
    public int howManyLevels;
    public int firstLevelIndex = 0;
    public GameObject levelPanel;
    private void Start()
    {
        for (int i = 0; i < howManyLevels; i++)
        {
            GameObject o = Instantiate(buttonPrefab,transform);
            o.GetComponent<LevelButton>().levelIndex = firstLevelIndex++;
            o.GetComponentInChildren<TextMeshProUGUI>().text = (i+1).ToString();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            levelPanel.SetActive(false);
        }
    }
}
