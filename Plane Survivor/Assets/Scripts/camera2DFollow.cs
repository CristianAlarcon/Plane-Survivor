using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera2DFollow : MonoBehaviour {

public float offsetX = 4f;
public float offsetY = 0f;

public float orthoSize = 2f;
public int levelPixelWidth; // Width of level in pixels
public int levelPixelHeight; // Height of level in pixels
public int playerPixelWidth = 32; // The camera is centered by width/2 when possible
public int playerPixelHeight = 32; // The camera is centered by height/2 when possible

// DeadZones to let the gameObject move around in without moving the camera
public float deadZoneLeft = 100f; // deadZone to the left of the gameobject
public float deadZoneRight = 100f; // deadZone to the right of the gameobject
public float deadZoneBottom = 100f; // deadZone below the gameobject
public float deadZoneTop = 100f; // deadZone above the gameobject

public bool useSpeed = false; // enabled the camera moves at moveSpeed, disabled the camera instantly moves
public float moveSpeed = 0.75f; // how many world units to move per update

// SpeedZones define how far away the camera can get due to being too slow
public float speedZoneLeft = 200f; // speedZone to the left of the gameobject set high to effectively disable
public float speedZoneRight = 200f; // speedZone to the right of the gameobject set high to effectively disable
public float speedZoneBottom = 200f; // speedZone below the gameobject set high to effectively disable
public float speedZoneTop = 200f; // speedZone above the gameobject set high to effectively disable

float deadZoneX = 0f;
float deadZoneY = 0f;

void Start()
{
    if (levelPixelWidth == 0 || levelPixelHeight == 0)
    {
        Debug.LogError("[MainCameraFollowsMe]: Width or Height bounds not set (levelPixelWidth or levelPixelHeight)");
    }
}

void LateUpdate()
{
    if (levelPixelWidth > 0 && levelPixelHeight > 0)
    {
        Camera.main.orthographicSize = Screen.height / orthoSize;
        if (useSpeed)
        {
            if (gameObject.transform.position.x < deadZoneX - deadZoneLeft)
            {
                if (gameObject.transform.position.x < deadZoneX - deadZoneLeft - speedZoneLeft)
                {
                    deadZoneX = gameObject.transform.position.x + deadZoneLeft + speedZoneLeft;
                }
                else
                {
                    if (gameObject.transform.position.x > deadZoneX - moveSpeed - deadZoneLeft)
                    {
                        deadZoneX = gameObject.transform.position.x + deadZoneLeft;
                    }
                    else deadZoneX -= moveSpeed;
                }
            }
            else if (gameObject.transform.position.x > deadZoneX + deadZoneRight)
            {
                if (gameObject.transform.position.x > deadZoneX + deadZoneRight + speedZoneRight)
                {
                    deadZoneX = gameObject.transform.position.x - deadZoneRight - speedZoneRight;
                }
                else
                {
                    if (gameObject.transform.position.x < deadZoneX + moveSpeed + deadZoneRight)
                    {
                        deadZoneX = gameObject.transform.position.x - deadZoneRight;
                    }
                    else deadZoneX += moveSpeed;
                }
            }
            if (gameObject.transform.position.y < deadZoneY - deadZoneBottom)
            {
                if (gameObject.transform.position.y < deadZoneY - deadZoneBottom - speedZoneBottom)
                {
                    deadZoneY = gameObject.transform.position.y + deadZoneBottom + speedZoneBottom;
                }
                else
                {
                    if (gameObject.transform.position.y > deadZoneY - moveSpeed - deadZoneBottom)
                    {
                        deadZoneY = gameObject.transform.position.y + deadZoneBottom;
                    }
                    else deadZoneY -= moveSpeed;
                }
            }
            else if (gameObject.transform.position.y > deadZoneY + deadZoneTop)
            {
                if (gameObject.transform.position.y > deadZoneY + deadZoneTop + speedZoneTop)
                {
                    deadZoneY = gameObject.transform.position.y - deadZoneTop - speedZoneTop;
                }
                else
                {
                    if (gameObject.transform.position.y < deadZoneY + moveSpeed + deadZoneTop)
                    {
                        deadZoneY = gameObject.transform.position.y - deadZoneTop;
                    }
                    else deadZoneY += moveSpeed;
                }
            }
        }
        else
        {
            if (gameObject.transform.position.x < deadZoneX - deadZoneLeft)
                deadZoneX = gameObject.transform.position.x + deadZoneLeft;
            else if (gameObject.transform.position.x > deadZoneX + deadZoneRight)
                deadZoneX = gameObject.transform.position.x - deadZoneRight;
            if (gameObject.transform.position.y < deadZoneY - deadZoneBottom)
                deadZoneY = gameObject.transform.position.y + deadZoneBottom;
            else if (gameObject.transform.position.y > deadZoneY + deadZoneTop)
                deadZoneY = gameObject.transform.position.y - deadZoneTop;
        }

        float playerPixelX = deadZoneX + offsetX;
        float playerPixelY = deadZoneY + offsetY;

        // ( Screen wider than level ) ? Center Level X : Min( MaxCameraPixelX, Max( MinCameraPixelX, PlayerX+Width/2))
        float camX = ((levelPixelWidth / 2f) <= (Camera.main.pixelWidth / orthoSize)) ? (levelPixelWidth / 2f) : Mathf.Min(levelPixelWidth - (Camera.main.pixelWidth / orthoSize), Mathf.Max((Camera.main.pixelWidth / orthoSize), (playerPixelX + (playerPixelWidth / 2f))));

        // ( Screen taller than level ) ? Center Level Y : Min( MaxCameraPixelY, Max( MinCameraPixelY, PlayerY+Height/2))
        float camY = ((levelPixelHeight / 2f) <= (Camera.main.pixelHeight / orthoSize)) ? (levelPixelHeight / 2f) : Mathf.Min(levelPixelHeight - (Camera.main.pixelHeight / orthoSize), Mathf.Max((Camera.main.pixelHeight / orthoSize), (playerPixelY + (playerPixelHeight / 2f))));

        Camera.main.transform.position = new Vector3(camX, camY, -16f); //#TODO don't create extra vectors
    }
}
}