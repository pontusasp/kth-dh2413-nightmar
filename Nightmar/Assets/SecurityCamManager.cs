using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamManager : MonoBehaviour
{
    public float yaw = 50.0f;
    public float pitch = 335.0f;

    public GameObject[] objects;
    public GameObject[] icons;

    private Camera[] cameras;

    public float maxHorizontal = 90;
    public float minHorizontal = 0;
    public float maxVertical = 359;
    public float minVertical = 285;

    public float cameraSpeed = 5;

    public float cameraSwitchDelay = 0.25f;
    private int currentCameraIndex;
    private float cameraSwitchTimestamp = 0;
    private bool switchingCamera = false;


    // Start is called before the first frame update
    void Start()
    {
        this.cameras = new Camera[objects.Length];

        // retrieve camera objects
        for (int i = 0; i < objects.Length; i++)
        {
            GameObject cameraObj = objects[i].transform.Find("Camera").gameObject;
            Camera cam = cameraObj.GetComponent<Camera>();
            cameras[i] = cam;
        }

        //Turn all cameras off, except the first default one
        for (int i = 1; i < cameras.Length; i++)
        {
            this.cameras[i].gameObject.SetActive(false);
        }

        //If any cameras were added to the controller, enable the first one
        if (this.cameras.Length > 0)
        {
            this.cameras[0].gameObject.SetActive(true);
            //Debug.Log("Camera with name: " + this.cameras[0].GetComponent<Camera>().name + ", is now enabled");
        }

    }

    void TemporaryCameraUpdate() {
        if (switchingCamera) {
            if (cameraSwitchTimestamp + cameraSwitchDelay < Time.realtimeSinceStartup) {
                cameras[cameras.Length - 1].gameObject.SetActive(false);
                cameras[currentCameraIndex].gameObject.SetActive(true);
                switchingCamera = false;
            }
        }
    }

    void CameraUpdate() {
        if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown("space")) {
            cameraSwitchTimestamp = Time.realtimeSinceStartup;

            //Byt till svartvit kamera, vänta n frames
            cameras[currentCameraIndex].gameObject.SetActive(false);
            icons[currentCameraIndex].gameObject.SetActive(false);

            currentCameraIndex = (currentCameraIndex + 1) % (cameras.Length - 1);
            switchingCamera = true;
            icons[currentCameraIndex].gameObject.SetActive(true);
            cameras[cameras.Length - 1].gameObject.SetActive(true);
        }
    }

    void RotationUpdate() {
        float yawInput = Input.GetAxis("Horizontal");
        float pitchInput = Input.GetAxis("Vertical");

        GameObject cameraGameObject = objects[currentCameraIndex];

        float dYaw = yawInput * cameraSpeed;
        float dPitch = pitchInput * cameraSpeed;

        Debug.Log(string.Format("dYaw: {0}\tdPitch: {1}", dYaw, dPitch));

        yaw -= dYaw;
        pitch += dPitch;
        yaw = Mathf.Clamp(yaw, minHorizontal, maxHorizontal);
        pitch = Mathf.Clamp(pitch, minVertical, maxVertical);

        cameraGameObject.transform.rotation = Quaternion.Euler(0, -yaw, 0) * Quaternion.Euler(-pitch, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        TemporaryCameraUpdate();
        CameraUpdate();
        RotationUpdate();
    }
}
