using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sat_Comp_Library : MonoBehaviour
{

    [System.Serializable]
    public struct Chasis
    {
        public string chasis_name;
        public ChasisBase chasisObj;
        public int price;
        [Range(0, 1)]
        public float chance_failure;
    }

    [System.Serializable]
    public struct Sat_Type
    {
        public string type_name;
        public GameObject type_obj;
        public int price;
    }

    public List<Chasis> available_chases;
    public List<Sat_Type> available_types;

    public static Sat_Comp_Library SatCompLib;

    // Start is called before the first frame update
    void Awake()
    {

        SatCompLib = this;

        if (available_chases.Count == 0) Debug.Log("WARNING: Chasis list contains no Chases, will lead to errors");
        if (available_types.Count == 0) Debug.Log("WARNING: Type list contains no types, will lead to errors");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Chasis GetChasis(int id, out int newID)
    {
        id += available_chases.Count;
        newID = id % available_chases.Count;
        return available_chases[id % available_chases.Count];
    }
}
