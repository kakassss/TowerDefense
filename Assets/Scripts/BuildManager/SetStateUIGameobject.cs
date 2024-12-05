using UnityEngine;
using UnityEngine.Serialization;

public class SetStateUIGameobject : MonoBehaviour
{
    [SerializeField] private GameObject _uiGoTarget; 
    [SerializeField] private GameObject _uiGoCurrent;
    
    //Generally using with button on click on ui gameobject
    public void SetStateSelectedGoAndReverseStateSelected(bool state)
    {
        _uiGoTarget.SetActive(state);
        _uiGoCurrent.SetActive(!state);
    }
    
    public void SetStateSelectedGoAndReverseStateThis(bool state)
    {
        _uiGoTarget.SetActive(state);
        this.gameObject.SetActive(!state);
    }

    public void SetStateSelectedGo(bool state)
    {
        _uiGoTarget.SetActive(state);
    }
}
