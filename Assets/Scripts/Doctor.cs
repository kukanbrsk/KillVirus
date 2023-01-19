using UnityEngine.EventSystems;

public class Doctor : Character
{

    public bool clickDoktor = true;
    private static Player _player;
    void Start()
    {
        transform.position = GetRandomPosition();
        if (_player == null)
        { 
            _player = FindObjectOfType<Player>();
        }
    }

   private void OnMouseDown()
     {
         if (EventSystem.current.IsPointerOverGameObject())
         {
             return;
         }

        if (clickDoktor)
        {
              transform.localScale *=2;
              clickDoktor = false; 
        }
        else
        {
           gameObject.SetActive(false);
        }
        _player.HpCount();
        FindObjectOfType<SoundManager>().PlayDoctorSound();

     }

}
