using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour {

    public static InventoryManager instance;

    public Text bombCounterText;
    public Text coinCounterText;
    public Text keyCounterText;

    public GameObject menuPanel;
    public Button restartButon;

    public int bombCount = 0;
    public int coinCount = 0;
    public int keyCount = 0;

    private PlayerControllerComponentAnimation player;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (bombCounterText != null && keyCounterText != null && coinCounterText != null)
        {
            SetBombCountText();
            SetCoinCountText();
            SetKeyCountText();
        }

        player = Object.FindObjectOfType(typeof(PlayerControllerComponentAnimation)) as PlayerControllerComponentAnimation;
    }
    void Update(){
        if (!player.gameObject.activeSelf && !menuPanel.activeSelf){
            StartCoroutine("ShowMenuPanelCoroutine");
        }
    }

    IEnumerator ShowMenuPanelCoroutine (){ 
        menuPanel.SetActive(true);
        yield return new WaitForEndOfFrame();
        restartButon.Select();
    }

    void SetBombCountText()
    {
        if (bombCounterText != null)
        {
            bombCounterText.text = bombCount.ToString();
        }
        else
        {
            Debug.Log("No Bomb Counter Present");
        }
    }
	 void SetKeyCountText()
    {
        if (keyCounterText != null)
        {
            keyCounterText.text = keyCount.ToString();
        }
        else
        {
            Debug.Log("No Key Counter Present");
        }
    }
    void SetCoinCountText()
    {
        if (coinCounterText != null)
            {
                coinCounterText.text = coinCount.ToString();
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

    public static void AddToKeyCount(int count)
    {
        instance.keyCount += count;
        instance.SetKeyCountText();
    }

    public static void SubtractFromKeyCount(int count)
    {
        instance.keyCount -= count;
        instance.SetKeyCountText();
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
        else if (name == "key"){
        	AddToKeyCount(count);
        }
        else
        {
            return;
        }
    }

    public void PressedQuitGame() {
        Application.Quit();
    }

    public void PressedRestart() {
        SceneManager.LoadScene("LargeMap");     
    }
}
