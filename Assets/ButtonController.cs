using UnityEngine;
using LookingGlass;

public class ButtonController : MonoBehaviour {

    [SerializeField]
    GameObject camera;

    static RotationCamera rotationCamera;
    private float countTime;

    // Use this for initialization
    void Start () {
        rotationCamera = camera.GetComponent<RotationCamera>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        countTime += Time.deltaTime;
        if (0.5f < countTime)
        {
            if (ButtonManager.GetButton(ButtonType.CIRCLE))
            {
                rotationCamera.ToggleRotate();
            }
            if (ButtonManager.GetButton(ButtonType.SQUARE))
            {
                //rotationCamera.Theta = 135;
                int theta = (int)rotationCamera.Theta / 10;

                Debug.Log("A:" + theta);
                Debug.Log("B:" + (int)RotationCamera.Season.SPRING / 10);
                switch (theta)
                {
                    case (int)RotationCamera.Season.SPRING / 10:
                        rotationCamera.Theta = (float)RotationCamera.Season.SUMMER;
                        break;
                    case (int)RotationCamera.Season.SUMMER / 10:
                        rotationCamera.Theta = (float)RotationCamera.Season.AUTUMN;
                        break;
                    case (int)RotationCamera.Season.AUTUMN / 10:
                        rotationCamera.Theta = (float)RotationCamera.Season.WINTER;
                        break;
                    case (int)RotationCamera.Season.WINTER / 10:
                        rotationCamera.Theta = (float)RotationCamera.Season.SPRING;
                        break;
                    default:
                        rotationCamera.Theta = (float)RotationCamera.Season.SPRING;
                        break;
                }
            }

            countTime = 0f;
        }

        if (ButtonManager.GetButton(ButtonType.RIGHT))
        {
            rotationCamera.Theta += 0.5f;
        }
        if (ButtonManager.GetButton(ButtonType.LEFT))
        {
            rotationCamera.Theta += 0.5f;
        }
    }
}
