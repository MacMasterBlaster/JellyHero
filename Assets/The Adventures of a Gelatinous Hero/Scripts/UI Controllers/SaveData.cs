using UnityEngine;
using System.Collections;

public class SaveData : ScriptableObject {

    public string characterName = "Link";
    public int maxLife = 3;
    public float currentLife = 3;
    public int deathCount = 0;

    public bool[] defeatedLevels = new bool[8];

    public string lastSaveMap = "OverWorld";
    public Vector2 lastSavedPositon = Vector2.zero;

    public void Save()
    {

    }

    public void Load()
    {

    }
}
