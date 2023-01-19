using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Transform heartPanel;
    [SerializeField] private Image heart;
    [SerializeField] private List<Image> hearts = new List<Image>();
    [SerializeField] private Sprite emptyHeart;
    [SerializeField] private GameObject windowResult;
    [SerializeField] private Text textLoss;
    [SerializeField] private Sprite[] winOrLoos;
     public Action GameOver;

    void Start()
    {

        for (int i = 0; i < FindObjectOfType<Player>().maxHp; i++)
        {
            hearts.Add (Instantiate(heart, heartPanel));
        }
        
    }

    public void UpdateHearts()
    {
        hearts[^1].sprite = emptyHeart;
        hearts.RemoveAt(hearts.Count - 1);
    }

    public void ShowResult (bool win)
    {
        GameOver.Invoke();
        textLoss.text = win?"WIN":"LOSE";
        windowResult.SetActive(true);
        textLoss.color = win ? new Color(0.1843137f,0.4039216f,0.3176471f) :  new Color(0.5490196f,0.1411765f,0.1882353f) ;
  
    }
}
  