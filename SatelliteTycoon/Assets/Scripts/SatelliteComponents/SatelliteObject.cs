using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteObject : MonoBehaviour
{

    protected Sat_Comp_Library.Chasis currChasis;
    protected Sat_Comp_Library.Sat_Type currType;

    protected int chasisID, typeID;

    private SatelliteHandler handler;

    // Start is called before the first frame update
    void Start()
    {
        handler = GameObject.FindObjectOfType<SatelliteHandler>();

        if (handler == null)
        {
            Debug.Log("WARNING: No satellite Handler found");
            Destroy(this.gameObject);
            return;
        }
        handler.RegisterSatellite(this);

        Modify("chasis", 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Modify(string componentToModify, int changeDir)
    {
        switch (componentToModify.ToLower())
        {
            case "chasis":
                chasisID += changeDir;
                currChasis = Sat_Comp_Library.SatCompLib.GetChasis(chasisID, out chasisID);
                break;
        }

        UpdateSatellite();
    }

    private void UpdateSatellite()
    {
        RemoveChildren();
        ChasisBase chasis_base = Instantiate(currChasis.chasisObj, this.transform.position, Quaternion.identity);
        chasis_base.transform.SetParent(this.transform);

    }

    public bool Launch()
    {
        return true;
    }

    private void RemoveChildren()
    {
        int i = 0;

        GameObject[] children = new GameObject[this.transform.childCount];

        foreach (Transform child in this.transform)
        {
            children[i] = child.gameObject;
            i += 1;
        }

        //Now destroy them
        foreach (GameObject child in children)
        {
            Destroy(child.gameObject);
        }
    }

}
