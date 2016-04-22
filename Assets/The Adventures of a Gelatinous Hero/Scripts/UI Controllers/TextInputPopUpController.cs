using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextInputPopUpController : MonoBehaviour {

    public InputField inputField;
    public SaveFileSelectController saveFileSelectController;
    void Start()
    {
        gameObject.SetActive(false);
    }

	public void OnCancelClick()
    {
        gameObject.SetActive(false);
    }

    public void OnConfirmClicked()
    {
        saveFileSelectController.SetNew(inputField.text);
        gameObject.SetActive(false);
    }
}
