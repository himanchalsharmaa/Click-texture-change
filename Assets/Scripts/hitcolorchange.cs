using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using System;
using UnityEngine.Video;

public class hitcolorchange : MonoBehaviour
{
    //public Text ttext;
    private XRRayInteractor xrRayInteractor;
    private RaycastHit raycastHit;
    public List<Material> materials;
    private float t1;
    private VideoPlayer vp;
    System.Random rnd = new System.Random();
    void Awake(){
        xrRayInteractor=GetComponent<XRRayInteractor>();        
    }
    // Start is called before the first frame update
    void Start()
    {
        //
    }

    // Update is called once per frame
    void Update()
    {
        if(xrRayInteractor.TryGetCurrent3DRaycastHit(out raycastHit)){

                float t2=Time.time;  
                //ttext.text="t1:"+t1+" t2:"+t2;  
                if(t2-t1>1){
                OVRInput.Update();
                 
                float pressed=OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
                if(pressed==1.0){
                    if(raycastHit.transform.name=="PFB_TV"){
                        vp=raycastHit.transform.GetComponent<VideoPlayer>();
                        if(vp.isPlaying==false){
                        vp.Play();}
                        else{
                            vp.Stop();}
                        
                    }
                else{
                int num = rnd.Next(0,materials.Count);
                raycastHit.transform.GetComponent<MeshRenderer>().material=materials[num];
                t1=Time.time;}
                }}
            
        }
    }
}
