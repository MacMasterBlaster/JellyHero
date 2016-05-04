using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryManager : MonoBehaviour {

    public static InventoryManager instance;

    public Text bombCounterText;
    public Text coinCounterText;

    public int bombCount = 0;
    public int coinCount = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        SetBombCountText();
        SetCoinCountText();
    }

    void SetBombCountText()
    {
        bombCounterText.text = "X " + bombCount;
    }

    void SetCoinCountText()
    {
        coinCounterText.text = "X " + coinCount;
    }

    public static void AddToBombCount(int count)
    {
        instance.bombCount += count;
        instance.SetBombCountText();
    }

    public static void SubtractFromBombCount(int count)
    {
        instance.bombCount -= count;
        instance.SetBombCountText();
    }

    public static void AddToCoinCount(int count)
    {
        instance.coinCount += count;
        instance.SetCoinCountText();
    }

    public static void AddToCount(string name, int count)
    {
        if (name == "bomb")
        {
            AddToBombCount(count);
        }
        else if (name == "coin")
        {
            AddToCoinCount(count);
        }
        else
        {
            return;
        }
    }

    // TODO: add subtract from count for bomb
}
