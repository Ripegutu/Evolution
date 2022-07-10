using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionScript : MonoBehaviour
{

    private Transform target;

    // Start is called before the first frame update
    private void Start()
    {
        target = FindTarget();
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position = transform.position + new Vector3(direction.x, 0, direction.z) * 10f * Time.fixedDeltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Debug.Log("Coin hit!");
            collision.gameObject.tag = "Untagged";
            Destroy(collision.gameObject);
            target = FindTarget();
        }
    }

    public Transform FindTarget()
    {
        Debug.Log("Find target");
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        float minDistance = Mathf.Infinity;
        Transform closest;

        if (coins.Length == 0)
            return null;

        closest = null;
        for (int i = 0; i < coins.Length; ++i)
        {
            float distance = (coins[i].transform.position - transform.position).sqrMagnitude;

            if (distance < minDistance && (coins[i].transform.position.y - coins[i].transform.localScale.x/2f) < transform.localScale.y*2 - 0.01f)
            {
                closest = coins[i].transform;
                minDistance = distance;
            }
        }
        return closest;
    }
}
