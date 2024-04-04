using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public GameObject laser;
    public Transform laserPos;
    public Transform arme;
    public List<GameObject> waypoints;
    public float speed = 2;
    int index = 0;
    private bool estEnTrainDeTirer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 destination = waypoints[index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;
        float distance = Vector3.Distance(transform.position, destination);
        if(distance <= 0.05)
        {
            index++;
        }
        Tirer();
    }

    public void Tirer()
    {
        if (estEnTrainDeTirer)
        {
            return;
        }

        RaycastHit hit;

        if (Physics.Raycast(laserPos.position, transform.TransformDirection(Vector3.forward), out hit, 20))
        {
            Debug.DrawRay(laserPos.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            if (hit.collider.gameObject.CompareTag("Player"))
            {
                GameObject temp = Instantiate(laser, laserPos.position, Quaternion.identity);
                temp.transform.rotation = Quaternion.LookRotation(arme.forward);
                temp.GetComponent<Laser>().direction = arme.forward;

                estEnTrainDeTirer = true;

                StartCoroutine(ReinitialiserTir());
            }
        }
    }
    private IEnumerator ReinitialiserTir()
    {
        yield return new WaitForSeconds(1f);

        estEnTrainDeTirer = false;
    }


}
