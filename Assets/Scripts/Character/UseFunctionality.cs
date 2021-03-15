using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
    public class UseFunctionality : MonoBehaviour
    {
        public PlayerController PlayerController;
        protected CrosshairScript Crosshair;
        protected Camera MainCamera;
        private Vector3 HitLocation;
        private void Awake()
        {
            MainCamera = Camera.main;
            PlayerController = GetComponent<PlayerController>();
        }
        // Start is called before the first frame update
        void Start()
        {
            Crosshair = PlayerController.CrosshairComponent;
        }

        public void OnUse(InputValue button)
        {
            Ray screenRay = MainCamera.ScreenPointToRay(new Vector3(Crosshair.CurrentMousePosition.x,
                        Crosshair.CurrentMousePosition.y, 0));

            if (!Physics.Raycast(screenRay, out RaycastHit hit,
                1000))
                return;

            HitLocation = hit.point;
            Vector3 hitDirection = hit.point - MainCamera.transform.position;

            //Debug.DrawRay(MainCamera.transform.position, hitDirection * WeaponStats.FireDistance, Color.red);
            Debug.DrawLine(MainCamera.transform.position, HitLocation, Color.red, 1);
            //Debug.Log("distance: " + (HitLocation - transform.position).magnitude);
            if(hit.collider.CompareTag("Door"))
            {
                hit.collider.gameObject.GetComponent<OpenDoorBehaviour>()?.Use();
            }
                
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}