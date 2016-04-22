using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager instance;

    public Text modeText;
    public Text registerButtonText;
    public Text deleteButtonText;

    public TextInputPopUpController textInputPopUpController;

    public Button registerButton;
    public Button deleteButton;

    public enum State
    {
        Select,
        Delete,
        Register
    }

    public State state = State.Select;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        modeText.text = "- Select -";
        SetState(State.Select);
    }

    public void ToggleEliminationMode()
    {
        switch (state)
        {
            case State.Delete:
                SetState(State.Select);
                break;

            case State.Select:
                SetState(State.Delete);
                break;

            default:
                Debug.LogError("Delete button should be disabled.");
                break;
        }
    }
    public void ToggleRegisterMode()
    {
        switch (state)
        {
            case State.Register:
                SetState(State.Select);
                break;

            case State.Select:
                SetState(State.Register);
                break;

            default:
                Debug.LogError("Register button should be disabled.");
                break;
        }
    }

    public static void RegisterName(SaveFileSelectController controller)
    {
        instance.textInputPopUpController.gameObject.SetActive(true);
        instance.textInputPopUpController.saveFileSelectController = controller;
    }

    void SetState (State state)
    {
        this.state = state;
        switch (state)
        {
            case State.Delete:
                modeText.text = "- Delete -";
                deleteButtonText.text = "Done";
                registerButtonText.text = "Register Your Name";
                registerButton.interactable = false;
                deleteButton.interactable = true;
                break;

            case State.Register:
                modeText.text = "- Register -";
                deleteButtonText.text = "Delete";
                registerButtonText.text = "Done";
                registerButton.interactable = true;
                deleteButton.interactable = false;
                break;

            default:
                modeText.text = "- Select -";
                deleteButtonText.text = "Delete Files";
                registerButtonText.text = "Register Your Name";
                registerButton.interactable = SaveFileSelectController.CanRegisterAny();
                deleteButton.interactable = SaveFileSelectController.CanDeleteAny();
                break;
        }
    }
}
