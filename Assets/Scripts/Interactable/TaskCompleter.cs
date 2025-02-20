using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskCompleter : MonoBehaviour
{
    // Display
    [SerializeField] private TextMeshProUGUI _goalFlavorText;
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private TextMeshProUGUI _rewardFlavorText;
    [SerializeField] private Button _button;
    // Gameplay
    private AbstractTask _task;

    public void AssignTask(AbstractTask task)
    {
        _task = task;
        _goalFlavorText.text = task.goalFlavorText;
        _costText.text = task.goalResourceDict.GetStringWithSprites();
        _rewardFlavorText.text = task.rewardFlavorText;
        UpdateDisplay();
    }
    
    private void OnEnable()
    {
        ResourceManager.OnResourceAmountChanged += OnResourceAmountChanged;
    }
    
    private void OnResourceAmountChanged(ResourceTypeEnum resourceType)
    {
        if(_task != null && _task.goalResourceDict.CheckKey(resourceType))
            UpdateDisplay();
    }
    
    public void UpdateDisplay()
    {
        _button.interactable = GameManager.Instance.resourceManager.CheckCanSpendResource(_task.goalResourceDict);
    }

    public void CompleteTask()
    {
        if (GameManager.Instance.resourceManager.SpendResource(_task.goalResourceDict))
        {
            _task.ClaimReward();
            GameManager.Instance.taskManager.NextTask();   
        }
    }
}
