using UnityEngine;
using UnityEngine.EventSystems;

public class Virus : Character
{
    private static GameManager _gameManager;
    public bool needDivision = true;
    public SpriteRenderer sR;

    private void Awake()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    { 
        if (_gameManager == null)
        {
                 _gameManager = FindObjectOfType<GameManager>();
        }
        _gameManager.ChangeCount(1);
    }

    void Start()
    {
        Target = GetRandomPosition();
        if (needDivision == true)
        {
            transform.position = GetRandomPosition();
            sR.sprite = _gameManager.ChangeSprite(out needDivision);
        }
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if(needDivision)
        {
            for (int i = 0; i < 2; i++)
            {
                Virus temp = _gameManager.GetVirus();
                temp.transform.position = transform.position;
                temp.sR.sprite = sR.sprite;
                temp.needDivision = false;
            }
        }
        _gameManager.ChangeCount(-1);
        _gameManager.ReleaseVirus(this);
        FindObjectOfType<SoundManager>().PlayVirusSound();
    }
}
