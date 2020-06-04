using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	Camera myCamera;
    Vector3 mousePos;
	Vector3 deltaMousePos;
    public float moveSpeed = 1.0f;
    public float rotateSpeed = 20.0f;
	public float orbitDistance = 5.0f;


	public enum MovementType
	{
		FreeCamera, OrbitSystem, SystemPerspective
	}
	MovementType movementType = MovementType.FreeCamera;

    // Start is called before the first frame update
    void Start()
    {
        myCamera = GetComponent<Camera>();
        mousePos = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
	{
		deltaMousePos = Input.mousePosition - mousePos;
		mousePos = Input.mousePosition;

		if (Input.GetKey(KeyCode.Escape))
		{
			SetCameraType(MovementType.FreeCamera);
		}

		switch (movementType)
		{
			case MovementType.FreeCamera:
				MoveFreeCamera();
				break;
			case MovementType.OrbitSystem:
				MoveOrbittingCamera();
				break;
			case MovementType.SystemPerspective:
				MoveSystemCamera();
				break;
		}
	}


	private void MoveFreeCamera()
	{
		if (Input.GetMouseButton(0))
		{
			transform.Rotate(Time.deltaTime * rotateSpeed * new Vector3(deltaMousePos.y, -deltaMousePos.x, 0.0f), Space.Self);
		}

		int upwardMovement = 0;
		if (Input.GetKey(KeyCode.W)) { upwardMovement++; }
		if (Input.GetKey(KeyCode.S)) { upwardMovement--; }

		int rightMovement = 0;
		if (Input.GetKey(KeyCode.D)) { rightMovement++; }
		if (Input.GetKey(KeyCode.A)) { rightMovement--; }

		int forwardMovement = 0;
		if (Input.GetKey(KeyCode.E)) { forwardMovement++; }
		if (Input.GetKey(KeyCode.Q)) { forwardMovement--; }

		transform.Translate(new Vector3(rightMovement, upwardMovement, forwardMovement) * moveSpeed * Time.deltaTime, Space.Self);
	}

	private void MoveOrbittingCamera()
	{
		if (Input.GetMouseButton(0))
		{
			//transform.RotateAround(SolarSystem.selectedSolarSystem.transform.position, new Vector3(deltaMousePos.y, -deltaMousePos.x), rotateSpeed * Time.deltaTime);

			//Debug.Log(transform.rotation);
			//Debug.Log(-transform.rotation.eulerAngles);
			//Debug.Log(SolarSystem.selectedSolarSystem.transform.position - transform.rotation.eulerAngles * orbitDistance);
			
			if (Input.GetMouseButton(0))
			{
				transform.Rotate(Time.deltaTime * rotateSpeed * new Vector3(deltaMousePos.y, -deltaMousePos.x, 0.0f), Space.Self);
				transform.position = SolarSystem.selectedSolarSystem.transform.position - transform.forward * orbitDistance;
			}
		}
	}

	private void MoveSystemCamera()
	{
		if (Input.GetMouseButton(0))
		{
			transform.Rotate(Time.deltaTime * rotateSpeed * new Vector3(deltaMousePos.y, -deltaMousePos.x, 0.0f), Space.Self);
		}
	}

	public void SetCameraType(MovementType type)
	{
		movementType = type;
		switch (type)
		{
			case MovementType.FreeCamera: 
				break;
			case MovementType.OrbitSystem:
				transform.position = SolarSystem.selectedSolarSystem.transform.position + orbitDistance * transform.forward;
				transform.LookAt(SolarSystem.selectedSolarSystem.transform, transform.up);
				break;
			case MovementType.SystemPerspective:
				transform.position = SolarSystem.selectedSolarSystem.transform.position;
				break;
		}
	}
}
