using UnityEngine;
using UnityEngine.Pool;

public class VirusPool : MonoBehaviour
{
    [SerializeField] private Virus vir;
    private ObjectPool<Virus> _pool;
    public ObjectPool<Virus> Pool => _pool;
    [SerializeField] private Difficulty difficulty;
    private void Awake()
    {
        _pool = new ObjectPool<Virus>(OnCreate, OnGet, OnRelease, OnDeath, false, 2, 15);
    }

    private Virus OnCreate()
    {
        var xxx = Instantiate(vir);
        xxx.speed = difficulty.baseSpeed;
        xxx.transform.localScale /= difficulty.baseScale;
        return xxx;
    }

    private void OnGet(Virus obj)
    {
        obj.gameObject.SetActive(true);
    }

    private void OnRelease(Virus obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void OnDeath(Virus obj)
    {
        Destroy(obj.gameObject);
    }

}
