using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseComponentChanger : MonoBehaviour
{

    public SatelliteHandler handler;

    public void Modify(string modify_vals)
    {
        string[] vals = modify_vals.Split(' ');

        if(int.TryParse(vals[1], out int dir))
            handler.ModifySatellite(vals[0], dir);
    }
}
