using UnityEngine;

public class ButtonListManager : MonoBehaviour
{
    public ListButton SelectedButton = null;
    [SerializeField] private ListButton[] _buttons;

    private void Start()
    {
        foreach (ListButton button in _buttons)
        {
            button.Button.onClick.AddListener(delegate { OnAnyButtonClicked(button); });
        }
    }

    void OnAnyButtonClicked(ListButton listButton)
    {
        SelectedButton?.DeselectButton();
        SelectedButton = listButton;
        listButton.SelectButton();
    }
}