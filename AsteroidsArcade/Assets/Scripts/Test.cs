using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private float lifeTime = 2f;

    private void OnEnable()
    {
        StartCoroutine(LifeRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(LifeRoutine());
    }

    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSeconds(lifeTime);
        this.Deactivate();
    }

    private void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}
