using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonTest : MonoBehaviour {
    public string onClickText = "I was clicked!";
    public Text uiText;


    public void ButtonClicked()
    {
        uiText.text = onClickText;
    }
}
