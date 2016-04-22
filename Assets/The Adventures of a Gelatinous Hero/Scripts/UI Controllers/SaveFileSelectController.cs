using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SaveFileSelectController : MonoBehaviour {

    public int numHearts = 3;
    public Text nameText;
    public Text deathsText;
    public Color heartColor;
    public Image[] heartImages;

    public SaveData saveData;

    void Start()
    {
        SetUp();
    }

    [ContextMenu("Setup")]
    void SetUp()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i >= saveData.maxLife)
            {
                heartImages[i].color = Color.clear;
            }
            else
            {
                heartImages[i].color = heartColor;
            }
            nameText.text = saveData.characterName;
            if (nameText.text == "")
            {
                deathsText.text = "";
            }
            else
            {
                deathsText.text = saveData.deathCount.ToString().PadLeft(3, '0');
            }
        }
    }

    void SetEmpty()
    {
        saveData.maxLife = 0;
        saveData.characterName = "";
        saveData.deathCount = 0;
        SetUp();
    }

    public void SetNew(string name)
    {
        saveData.maxLife = 3;
        saveData.characterName = name;
        saveData.deathCount = 0;
        SetUp();
    }

    public void FileSelected()
    {
        switch (MainMenuManager.instance.state)
        {
            case MainMenuManager.State.Delete:
                SetEmpty();
                break;

            case MainMenuManager.State.Select:
                SceneManager.LoadScene("DevScene");
                break;

            case MainMenuManager.State.Register:
                MainMenuManager.RegisterName(this);
                break;

            default:
                break;
        }
    }

    public bool CanRegister()
    {
        return (nameText.text == "");
    }

    public static bool CanRegisterAny()
    {
        bool canRegister = false;
        SaveFileSelectController[] controllers = Object.FindObjectsOfType(typeof(SaveFileSelectController)) as SaveFileSelectController[];
        foreach (SaveFileSelectController s in controllers)
        {
            if (s.nameText.text == "") canRegister = true;
        }
        return canRegister;
    }

    public static bool CanDeleteAny()
    {
        bool canDelete = false;
        SaveFileSelectController[] controllers = Object.FindObjectsOfType(typeof(SaveFileSelectController)) as SaveFileSelectController[];
        foreach (SaveFileSelectController s in controllers)
        {
            if (s.nameText.text != "") canDelete = true;
        }
        return canDelete;
    }

}
