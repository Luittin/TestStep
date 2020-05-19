using EzySlice;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    GameObject prefubBlock = null, prefubDeliteBlock = null, prefabPlaneEffect = null;

    List<GameObject> towerBlocks = null;

    GameObject moveBlock = null;
    Transform deliteBlock = null;

    bool isAxis = true;

    Action<float> moveCamera;
    Action<int> moveVision;

    public Action EndGame;
    public Action AddResult;

    void Awake()
    {
        towerBlocks = new List<GameObject>();
        towerBlocks.Add(Instantiate(prefubBlock, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity, transform));
        CreateColor.RandomColor(towerBlocks[0].GetComponent<MeshRenderer>().material);
        moveCamera = Camera.main.GetComponent<MoveCamera>().AddTargetPosition;
        moveVision = Camera.main.GetComponent<MoveCamera>().VisionCamera;
        deliteBlock = Instantiate(prefubDeliteBlock, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity).transform;
    }

    public void CreateNewBlock()
    {
        Vector3 startPositionBlock = towerBlocks[towerBlocks.Count - 1].transform.position;
        if (isAxis)
            startPositionBlock.z = 1.7f;
        else
            startPositionBlock.x = -1.7f;

        startPositionBlock.y += 0.1f;

        isAxis = !isAxis;

        moveBlock = Instantiate(towerBlocks[towerBlocks.Count - 1], startPositionBlock, Quaternion.identity, transform);
        CreateColor.AddColorH(moveBlock.GetComponent<MeshRenderer>().material);
        if (moveBlock.GetComponent<MoveBlock>() == null)
            moveBlock.AddComponent<MoveBlock>();

        if (towerBlocks.Count >= 3)
        {
            moveCamera(0.1f);
        }
    }

    public void TapStopMoveBlock()
    {
        Vector3 moveBlockPosition = moveBlock.transform.position;
        Vector3 lastBlockPosition = towerBlocks[towerBlocks.Count - 1].transform.position;

        float positionX = moveBlockPosition.x - lastBlockPosition.x;
        float positionZ = moveBlockPosition.z - lastBlockPosition.z;

        

        GameObject[] sliceObject = null;

        if (moveBlock.GetComponent<MoveBlock>().StopBlock(towerBlocks[towerBlocks.Count - 1].transform))
        {
            Debug.Log(moveBlock.name);
            lastBlockPosition.y = moveBlockPosition.y;
            moveBlock.transform.position = lastBlockPosition;
            towerBlocks.Add(moveBlock);
            Vector3 position = moveBlock.transform.position;
            position.y -= 0.05f;
            Instantiate(prefabPlaneEffect, position, Quaternion.identity, moveBlock.transform); 
        }
        else
        {
            if (positionX > 0.0f)
            {
                lastBlockPosition.x += towerBlocks[towerBlocks.Count - 1].transform.localScale.x / 2;
                //sliceObject = Slice(lastBlockPosition, new Vector3(90, 0, 0));

                sliceObject = CubeCut.CutX(moveBlock.transform, lastBlockPosition);

            }
            else if (positionX < 0.0f)
            {
                lastBlockPosition.x -= towerBlocks[towerBlocks.Count - 1].transform.localScale.x / 2;
                //sliceObject = Slice(lastBlockPosition, new Vector3(90, 0, 0));
                sliceObject = CubeCut.CutX(moveBlock.transform, lastBlockPosition);

            }
            else if (positionZ > 0.0f)
            {
                lastBlockPosition.z += towerBlocks[towerBlocks.Count - 1].transform.localScale.z / 2;
                //sliceObject = Slice(lastBlockPosition, new Vector3(0, 0, 90));
                sliceObject = CubeCut.CutZ(moveBlock.transform, lastBlockPosition);

            }
            else if (positionZ < 0.0f)
            {
                lastBlockPosition.z -= towerBlocks[towerBlocks.Count - 1].transform.localScale.z / 2;
                //sliceObject = Slice(lastBlockPosition, new Vector3(0, 0, 90));
                sliceObject = CubeCut.CutZ(moveBlock.transform, lastBlockPosition);

            }

            if (sliceObject != null)
            {
                moveBlock.SetActive(false);
                SliceOBject(sliceObject);            
            }
            else
            {
                moveVision(towerBlocks.Count);
                Destroy(deliteBlock.gameObject);
                moveBlock.AddComponent<Rigidbody>();
                EndGame();
                return;
            }
            
        }
        AddResult();
        CreateNewBlock();
    }

    private void SliceOBject(GameObject[] _sliceObject)
    {
        for(int i = 0; i < 2; i++)
        {
            _sliceObject[i].AddComponent<BoxCollider>();
        }
        Vector3 posLastTower = towerBlocks[towerBlocks.Count - 1].transform.position;
        Vector3 slice0 = _sliceObject[0].transform.position + _sliceObject[0].GetComponent<BoxCollider>().center / 2;
        Vector3 slice1 = _sliceObject[1].transform.position + _sliceObject[1].GetComponent<BoxCollider>().center / 2;

        if(Vector3.Distance(posLastTower,slice0) > Vector3.Distance(posLastTower, slice1))
        {
            Rigidbody sliceRigidbody = _sliceObject[0].AddComponent<Rigidbody>();
            sliceRigidbody.useGravity = true;
            _sliceObject[1].transform.parent = transform;
            _sliceObject[0].transform.parent = deliteBlock;
            towerBlocks.Add(_sliceObject[1]);
        }
        else
        {
            Rigidbody sliceRigidbody = _sliceObject[1].AddComponent<Rigidbody>();
            sliceRigidbody.useGravity = true;
            _sliceObject[0].transform.parent = transform;
            _sliceObject[1].transform.parent = deliteBlock;
            towerBlocks.Add(_sliceObject[0]);
        }
    }
}
