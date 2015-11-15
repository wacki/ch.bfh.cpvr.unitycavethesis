﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Cave
{
    #region "enum"
    public enum CAVEMode
    {
        FourScreen, FourScreenStereo
    };

    public enum TrackedObject
    {
        Eyes, Wand, Nothing
    };

    #endregion


    public class CaveMain : MonoBehaviour
    {

        #region "settings"

        [Header("Main")]
        public int BeamerResolutionWidth = 1280;
        public int BeamerResolutionHeight = 960;
        public string Host = "192.168.0.201";
        public CAVEMode myCAVEMode = CAVEMode.FourScreen;
        public TrackedObject myTrackingMode = TrackedObject.Eyes;
        public bool rotateCave = true;
        //this is used to calc the frustum
        //public CAVEDimensions CaveDimensions;

        [Header("Wand")]
        public WandSettings WandSettings;

        [Header("Eyes")]
        public EyesSettings EyesSettings;

        [Header("Gamepad")]
        public GamepadSettings GamepadSettings;

        [Header("Weiteres")]
        public float EyeDistance = 0.07f;
                
        #endregion
        
        #region "public properties"

        public Transform CAVELeft { get { return _CAVELeft; } }
        public Transform CAVEFront { get { return _CAVEFront; } }
        public Transform CAVERight { get { return _CAVERight; } }
        public Transform CAVEBottom { get { return _CAVEBottom; } }

        public CameraManager CameraManager;
        public FrustumManager FrustumManager;
        public GameObject CameraContainer;

        //public Vector3 currentTrackedObject { get { return _TrackedObject; } }

        #endregion


        #region "private vars"

        private Transform _CAVELeft;
        private Transform _CAVEFront;
        private Transform _CAVERight;
        private Transform _CAVEBottom;

        private List<Camera> mySecondaryCameras = new List<Camera>();

        //private Vector3 _TrackedObject;

        #endregion
        
        void Awake()
        {
            Instantiate(CameraManager);
            Instantiate(FrustumManager);
            Instantiate(CameraContainer);
        }

        // Use this for initialization
        void Start()
        {
            foreach(Camera c in Camera.allCameras)
            {
                if (c != Camera.main) { mySecondaryCameras.Add(c); }
            };

            _CAVELeft = GameObject.FindWithTag("CaveLeft").GetComponent<Transform>();
            _CAVEFront = GameObject.FindWithTag("CaveFront").GetComponent<Transform>();
            _CAVERight = GameObject.FindWithTag("CaveRight").GetComponent<Transform>();
            _CAVEBottom = GameObject.FindWithTag("CaveBottom").GetComponent<Transform>();


            if (myCAVEMode == CAVEMode.FourScreen) EyeDistance = 0f;
            

            //GameObject cm = new GameObject();
            //cm.AddComponent<CameraManager>();
            ////cm.AddComponent(Type.GetType("CameraManager"));
            //cm.transform.parent = transform;

            //GameObject fm = new GameObject();
            ////fm.AddComponent(Type.GetType("FrustumManager"));
            //fm.AddComponent<FrustumManager>();
            //fm.transform.parent = transform;

            //_cm = new CameraManager();
            //_cm.Init(GetComponent<CaveMain>());

            //_fm = new FrustumManager();
            //_fm.Init(GetComponent<CaveMain>());

            //if(myTrackingMode == TrackedObject.Eyes)
            //{
            //    _TrackedObject = GameObject.FindWithTag("Wand").GetComponent<Transform>().position;
            //}
            //else if (myTrackingMode == Cave.TrackedObject.Eyes )
            //{
            //    _TrackedObject = GameObject.FindWithTag("Eyes").GetComponent<Transform>().position;

            //    //debug
            //    //_TrackedObject = new Vector3(1f, 1f, 0.5f);
            //}
            //else
            //{
            //    _TrackedObject = Vector3.zero ;
            //}
        }

        // Update is called once per frame
        void Update()
        {
            //performance ?
            API.Instance.Calculate();

            //_cm.Update();
            //_fm.Update();

           // Debug.Log(CalculatedValues.Instance.AngleWandEyes);
        }

        private void SetCameraTag()
        {

        }
    }
}