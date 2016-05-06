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
        if (bombCounterText != null && coinCounterText != null)
        {
            SetBombCountText();
            SetCoinCountText();
        }
    }

    void SetBombCountText()
    {
        if (bombCounterText != null)
        {
            bombCounterText.text = "X " + bombCount;
        }
        else
        {
            Debug.Log("No Bomb Counter Present");
        }
    }

    void SetCoinCountText()
    {
        if (coinCounterText != null)
            {
                coinCounterText.text = "X " + coinCount;
            }
        else
        {
            Debug.Log("No Coin Counter Present");
        }

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
}
