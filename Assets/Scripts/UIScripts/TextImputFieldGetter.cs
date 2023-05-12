using TMPro;
using UnityEngine;
using UnityEngine.Events;

public sealed class TextImputFieldGetter : MonoBehaviour
{
    public UnityEvent<string> TextImputted;

    [SerializeField] private TMP_InputField _inputField;

    public void InputText() => TextImputted.Invoke(_inputField.text);
}
