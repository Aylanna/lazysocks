using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour {

    public int nrOfTap;

    // Use this for initialization
    void Start ()
    {
        nrOfTap = 1;
    }

    // Update is called once per frame
    void Update ()
    {
        if(nrOfTap == 1)
        {
            HitTarget();
        }
    }

    /**
     * This class makes sure the characters get destroyed when there is a touch on the screen or a mouse click
     */
    private void HitTarget()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;

            if (Physics.Raycast(ray, out Hit))
            {
                if (Hit.collider.gameObject == gameObject)
                {
                    Spawner.playName = gameObject.tag;
                    Spawner.isTapped = true;
                    Spawner.check = true;
                    nrOfTap = 2;

                    if (gameObject.tag == "Bad")
                    {
                        TimeOut.wrongCharacter = false;
                        Spawner.spawnNum = 1;
                    }
                    else
                    {
                        Spawner.spawnNum = 0;
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }
}
