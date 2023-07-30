using UnityEngine;
using UnityEngine.UI;

public class ListButton : MonoBehaviour
{
    private Button _button;
    private bool _isSelected = false;

    public Button Button
    {
        get => _button; set { _button = value; }
    }
    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void SelectButton()
    {
        _isSelected = true;
    }
    public void DeselectButton()
    {
        _isSelected = false;
    }
}