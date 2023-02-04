using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMaterialManager : MonoBehaviour
{
    public string targetParticle;
    public Material dustCloud;
    public Material splinter;
    //public Dictionary<string, Material> materials;
    // Start is called before the first frame update
    void Start()
    {
        /*
        materials = new Dictionary<string, Material>();
        Material mat = Resources.Load("Materials/Dust-Cloud.mat") as Material;
        materials.Add("Dust-Cloud", Resources.Load("Materials/Dust-Cloud.mat", typeof(Material)) as Material);
        print(materials["Dust-Cloud"]);
        print(mat);
        */
    }

    // Update is called once per frame
    void Update()
    {
        if(targetParticle == "Dust Cloud")
        {
            GetComponent<ParticleSystemRenderer>().material = dustCloud;
        }
        if (targetParticle == "Splinter")
        {
            GetComponent<ParticleSystemRenderer>().material = splinter;
        }
    }
}
