using UnityEngine;
using DG.Tweening;

public enum MainMenuPanels
{
    MainMenuPanel = 1,
    VehicleSelection,
    MapSelection,
    LevelSelection
}

public class MainMenuPanelsSliding : MonoBehaviour
{
    public float TransitionDuration = 0.25f;

    [SerializeField] RectTransform ParentPanelTransform;
    [SerializeField] GameObject BackButton;

    private bool _canTween = true;
    private int _totalPanels = 0;
    private int _currentRectScreen = 0;
    private bool _lastPanelReached = false;

    private void Start()
    {
        _totalPanels = ParentPanelTransform.transform.childCount;
        SetActiveBackButton(false);
        SelectNext();
    }
    //todo:Unsubscribe from the twneerCore

    public void SelectPrevious()
    {
        if (!_canTween) return;
        if (_currentRectScreen > 1)
        {
            _currentRectScreen--;
            var currentTransform = ParentPanelTransform.anchoredPosition;
            var tweenerCore = ParentPanelTransform.DOAnchorPos(currentTransform + new Vector2(2000, 0), TransitionDuration);
            tweenerCore.onComplete += OnTransitionCompleted;

            if (_currentRectScreen == 1)
                OnFirstPanelReached();
            _canTween = false;
        }
    }

    public void SelectNext()
    {
        if (!_canTween) return;
        if (_currentRectScreen < _totalPanels)
        {
            _currentRectScreen++;
            var currentTransform = ParentPanelTransform.anchoredPosition;
            var tweenerCore = ParentPanelTransform.DOAnchorPos(currentTransform + new Vector2(-2000, 0), TransitionDuration);
            tweenerCore.onComplete += OnTransitionCompleted;

            if (_currentRectScreen != 1 && !BackButton.activeSelf) SetActiveBackButton(true);
            if (_currentRectScreen == _totalPanels) OnLastPanelReached();
            _canTween = false;
        }
        else if (_lastPanelReached)
        {
            LevelManager.LevelManagerInstance.LoadLevelByIndex(1);
        }
    }

    void OnTransitionCompleted()
    {
        _canTween = true;
    }

    void OnLastPanelReached()
    {
        print("Last Panel Reached");
        _lastPanelReached = true;
    }

    void OnFirstPanelReached()
    {
        print("First Panel Reached");
        SetActiveBackButton(false);
    }

    void SetActiveBackButton(bool SetActive)
    {
        BackButton.SetActive(SetActive);
    }
}