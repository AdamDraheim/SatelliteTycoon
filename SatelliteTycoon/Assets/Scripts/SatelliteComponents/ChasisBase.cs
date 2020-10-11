using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasisBase : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Pivots for additional components")]
    public Vector3 antennaPivot;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetPivot(string pivotName)
    {
        switch (pivotName.ToLower())
        {
            case "antenna":
                return antennaPivot;
        }
        return new Vector3(0, 0, 0);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position + antennaPivot, 0.5f);
    }
}
