using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wall : MonoBehaviour
{
    public float speed;
    public float destroyDelayWithUser;
    private bool hit_by_user;
    private bool is_end;

    //for destroying the wall when it arrives at the end of the plane
    public float destroyDelayWithWallDestroyer;      //time to be destroyed
    private Collider myCollider;    //wall's collider

    //spawner
    private WallSpawner wallSpawner;

    // Start is called before the first frame update
    void Start()
    {
        hit_by_user = false;
        is_end = false;
        //find wall's collider
        myCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * Time.deltaTime * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("person") && !hit_by_user)
        {
            HitByUser();
        }
        else if (other.CompareTag("destroyWall") && !is_end)
        {
            is_end = true;
            arrivedAtTheEnd();
        }
    }

    //function called when the user touches the wall
    private void HitByUser()
    {
        GameStateManager.Instance.failedWall();

        //remove the wall from the list
        wallSpawner.RemoveWallFromList(gameObject);

        SoundManager.Instance.PlayHitSound();

        hit_by_user = true;
        speed = 0;

        //destroy the wall with a delay time
        Destroy(gameObject, destroyDelayWithUser);
    }

    //the wall arrived at the end of the plane so it must be destroyed
    private void arrivedAtTheEnd()
    {
        GameStateManager.Instance.passedWall();

        //remove the wall from the list
        wallSpawner.RemoveWallFromList(gameObject);

        SoundManager.Instance.PlayEndSound();

        myCollider.isTrigger = false;
        Destroy(gameObject, destroyDelayWithWallDestroyer);
    }

    public void SetSpawner(WallSpawner spawner)
    {
        wallSpawner = spawner;
    }

}
