using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _virusCount;
    [SerializeField] private GameObject doc;
    [SerializeField] private VirusPool virusPool;
    [SerializeField] private Difficulty difficulty;
    [SerializeField] private SpriteRand spriteRand;
    private Coroutine _spawnVirus;
    private void Awake()
    {
        _spawnVirus = StartCoroutine(SpawnVirus());
        FindObjectOfType<UIManager>().GameOver = () => StopCoroutine(_spawnVirus);
        float x = difficulty.virusCount;
        var y = Mathf.CeilToInt(x / 2) - 1;
        FindObjectOfType<Player>().maxHp = y;
      
        for (int i = 0; i < x; i++)
        {
            virusPool.Pool.Get();
            if (i % 2 == 0)
            {
                Instantiate(doc);
            }
        }
    }

    public void ChangeCount(int delta)
    {
        _virusCount += delta;
        if (_virusCount == 0)
        {
            FindObjectOfType<UIManager>().ShowResult(true);
        }
    }
    
    public Sprite ChangeSprite (out bool green)
    {  
        int rand = Random.Range(0, spriteRand.spriteVirus.Length);
        green = rand == 1;
        return spriteRand.spriteVirus[rand]; 

    }

    public Virus GetVirus() => virusPool.Pool.Get();
    public void ReleaseVirus(Virus obj) => virusPool.Pool.Release(obj);

    IEnumerator SpawnVirus()
    {
        while (true)
        {
        yield return new WaitForSeconds(difficulty.spawnInterval);
        GetVirus();

        }
    }
}

