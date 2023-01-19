using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHp;
    private UIManager _uIManager;

    void Start()
    {
        _uIManager = FindObjectOfType<UIManager>();
    }

    public void HpCount ()
    {        
        maxHp -= 1;
        _uIManager.UpdateHearts();
        if (maxHp == 0)
        {
            _uIManager.ShowResult(false);  
        }
    }
    
}
