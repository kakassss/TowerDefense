using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractButtonListener : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void Awake()
    {
        _button.onClick.AddListener(OnclickListener);
    }

    protected virtual void OnclickListener()
    {
    }
}