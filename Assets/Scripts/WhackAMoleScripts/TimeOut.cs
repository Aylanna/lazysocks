using UnityEngine;
using System.Collections;

public class TimeOut : MonoBehaviour {

    public static bool wrongCharacter;
    private float timer;
    private float timeOut;

    // Use this for initialization
    void Start ()
    {
        wrongCharacter = true;
        timer = 0.000f;
        timeOut = Spawner.removeTimer;
    }

    // Update is called once per frame
    void Update ()
    {
        timer += Time.deltaTime;

        if (timer > timeOut)
        {
            if (wrongCharacter)
            {
                Spawner.spawnNum = 0;
                Destroy(this.gameObject);
            }

        }
    }

    protected IEnumerator PauseBeforeRemove()
    {
        yield return new WaitForSeconds(Spawner.timer);
        Spawner.spawnNum = 0;
        Destroy(this.gameObject);
    }
}
