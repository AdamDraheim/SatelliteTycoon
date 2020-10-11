using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteHandler : MonoBehaviour
{

    public GameObject SatelliteBase;

    private SatelliteObject currSatellite;

    protected int contractReward;
    protected int currFunds;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNewSatellite();
    }

    // Update is called once per frame
    void Update()
    {
        //temp test code
        if (Input.GetKeyDown(KeyCode.A))
        {
            ModifySatellite("chasis", -1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ModifySatellite("chasis", 1);
        }
    }

    public void RegisterSatellite(SatelliteObject obj)
    {
        this.currSatellite = obj;
    }

    public void SetContract()
    {
        //TODO make contract
    }

    public void ModifySatellite(string componentToChange, int changeDir)
    {
        if(this.currSatellite != null)
            this.currSatellite.Modify(componentToChange, changeDir);
    }

    private void SpawnNewSatellite()
    {
        Instantiate(SatelliteBase, this.transform.position, Quaternion.identity);
    }

    public void Launch()
    {
        if(this.currSatellite != null)
        {
            if (this.currSatellite.Launch())
            {
                currFunds += contractReward;
            }
            //TODO complete contract
            SpawnNewSatellite();
        }
    }
}
