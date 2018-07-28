using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLaser : MonoBehaviour
{
    [SerializeField] bool develop;
    [SerializeField] float distance = 1000.0f; //distance of laser beam
    [SerializeField] LineRenderer lr;
    [SerializeField] int limit = 100; //max reflection distance
    int verti = 1; //segment handler
    bool isActive;

    public Transform turretTip;

    private void Start()
    {
        lr.enabled = false;
        if (!develop)
            StartCoroutine(DrawLaser());
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && develop)
        {
            StopCoroutine(DrawLaserDevelop());
            StartCoroutine(DrawLaserDevelop());
        }
        else
            lr.enabled = false;
    }

    IEnumerator DrawLaser()
    {
        while (true)
        {
            lr.enabled = true;
            lr.SetPosition(0, transform.position);
            isActive = true;
            verti = 1;
            lr.positionCount = 2;

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            while (isActive)
            {
                if (Physics.Raycast(ray, out hit, distance))
                {
                    lr.SetPosition(verti, hit.point);
                    ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.transform.forward));
                    lr.positionCount++;
                    verti++;
                }
                else
                {
                    lr.SetPosition(verti, ray.GetPoint(limit));
                    isActive = false;
                }
            }
            yield return null;
        }
    }

    IEnumerator DrawLaserDevelop()
    {
        lr.enabled = true;
        lr.SetPosition(0, turretTip.position);
        isActive = true;
        verti = 1;
        lr.positionCount = 2;

        Ray ray = new Ray(turretTip.position, transform.forward);
        RaycastHit hit;
        while (isActive)
        {
            if (verti >= limit)
                isActive = false;
            if (Physics.Raycast(ray, out hit, distance))
            {
                lr.SetPosition(verti, hit.point);

                var endPoint = hit.collider.GetComponent<EndPoint>();
                if (endPoint)
                {
                    endPoint.Test();
                    isActive = false;
                    continue;
                }
                else
                {
                    ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.transform.forward));
                }
                lr.positionCount++;
                verti++;
            }
            else
            {
                lr.SetPosition(verti, ray.GetPoint(limit));
                isActive = false;
            }
        }


        yield return null;

    }
}
