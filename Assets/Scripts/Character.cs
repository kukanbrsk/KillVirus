using UnityEngine;


public abstract class Character : MonoBehaviour
{
    protected Vector3 Target;
    public float speed = 3f;


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target, speed * Time.deltaTime);
        if (transform.position == Target)
        {
            Target = GetRandomPosition();

        }

    }

    protected Vector3 GetRandomPosition()
    {
        Vector3 randomPos = Vector3.zero;
        randomPos.x = Random.Range(-9f, 9f);
        randomPos.y = Random.Range(-5f, 5f);
        return randomPos;
    }


}
