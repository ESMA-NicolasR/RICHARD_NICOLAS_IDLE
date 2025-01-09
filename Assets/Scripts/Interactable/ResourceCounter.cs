using TMPro;
using UnityEngine;

public class ResourceCounter : MonoBehaviour
{
    // Display
    [SerializeField] private TextMeshProUGUI _resourceText;
    [SerializeField] private Animator _textAnimator;
    // Gameplay
    [SerializeField] private ResourceTypeEnum _resourceType;

    private void OnEnable()
    {
        ResourceManager.OnResourceAmountChanged += OnResourceAmountChanged;
    }

    private void OnDisable()
    {
        ResourceManager.OnResourceAmountChanged -= OnResourceAmountChanged;
    }

    private void Start()
    {
        // Fail-safe display of the starting amount of resources
        UpdateDisplay();
    }

    private void OnResourceAmountChanged(ResourceTypeEnum resourceTypeEnumChanged)
    {
        if (resourceTypeEnumChanged == _resourceType)
        {
            UpdateDisplay();
        }
    }

    private void UpdateDisplay()
    {
        _resourceText.text = GameManager.Instance.resourceManager.GetResourceAmount(_resourceType).ToString();
        _textAnimator.SetTrigger("Wiggle");
    }
}
