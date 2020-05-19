using UnityEngine;

public class CubeCut : MonoBehaviour {
	public static GameObject[] CutX(Transform victim,Vector3 _pos)
	{
		GameObject[] gameObjects = new GameObject[2];

		Vector3 pos = new Vector3(_pos.x, victim.position.y, victim.position.z);
		Vector3 victimScale = victim.localScale;
		float distance = Vector3.Distance(victim.position, pos);
		if (distance >= victimScale.x/2) return null;
		
		Vector3 leftPoint = victim.position - Vector3.right * victimScale.x/2;
		Vector3 rightPoint = victim.position + Vector3.right * victimScale.x/2;
		Material mat = victim.GetComponent<MeshRenderer>().material;
		Transform parent = victim.transform.parent;
		Destroy(victim.gameObject);
		
		GameObject rightSideObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
		rightSideObj.transform.position = (rightPoint + pos) /2;
		float rightWidth = Vector3.Distance(pos,rightPoint);
		rightSideObj.transform.localScale = new Vector3( rightWidth ,victimScale.y ,victimScale.z );
		//rightSideObj.AddComponent<Rigidbody>().mass = 100f;
        rightSideObj.GetComponent<MeshRenderer>().material = mat;
		rightSideObj.transform.parent = parent;
		gameObjects[0] = rightSideObj;

		GameObject leftSideObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
		leftSideObj.transform.position = (leftPoint + pos)/2;
		float leftWidth = Vector3.Distance(pos,leftPoint);
		leftSideObj.transform.localScale = new Vector3( leftWidth ,victimScale.y ,victimScale.z );
		//leftSideObj.AddComponent<Rigidbody>().mass = 100f;
		leftSideObj.GetComponent<MeshRenderer>().material = mat;
		leftSideObj.transform.parent = parent;
		gameObjects[1] = leftSideObj;

		return gameObjects;
	}

	public static GameObject[] CutZ(Transform victim, Vector3 _pos)
	{
		GameObject[] gameObjects = new GameObject[2];

		Vector3 pos = new Vector3(victim.position.x, victim.position.y, _pos.z);
		Vector3 victimScale = victim.localScale;
		float distance = Vector3.Distance(victim.position, pos);
		if (distance >= victimScale.z / 2) return null;

		Vector3 leftPoint = victim.position - Vector3.forward * victimScale.z / 2;
		Vector3 rightPoint = victim.position + Vector3.forward * victimScale.z / 2;
		Material mat = victim.GetComponent<MeshRenderer>().material;
		Transform parent = victim.transform.parent;
		Destroy(victim.gameObject);

		GameObject rightSideObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
		rightSideObj.transform.position = (rightPoint + pos) / 2;
		float rightWidth = Vector3.Distance(pos, rightPoint);
		rightSideObj.transform.localScale = new Vector3(victimScale.x, victimScale.y, rightWidth);
		//rightSideObj.AddComponent<Rigidbody>().mass = 100f;
		rightSideObj.GetComponent<MeshRenderer>().material = mat;
		rightSideObj.transform.parent = parent;
		gameObjects[0] = rightSideObj;

		GameObject leftSideObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
		leftSideObj.transform.position = (leftPoint + pos) / 2;
		float leftWidth = Vector3.Distance(pos, leftPoint);
		leftSideObj.transform.localScale = new Vector3(victimScale.x, victimScale.y, leftWidth);
		//leftSideObj.AddComponent<Rigidbody>().mass = 100f;
		leftSideObj.GetComponent<MeshRenderer>().material = mat;
		leftSideObj.transform.parent = parent;
		gameObjects[1] = leftSideObj;

		return gameObjects;
	}
}
