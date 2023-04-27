using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class InputFieldController : MonoBehaviour, ISelectHandler
{
    private TMP_InputField  inputField;

    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        inputField.inputType = TMP_InputField.InputType.Standard;
    }
}
