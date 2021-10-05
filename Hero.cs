
using System.Collections.Generic;
using UnityEngine;


public class Hero : MonoBehaviour
{

    
    [SerializeField] private GameObject _panel;
    [SerializeField] private List<GameObject> gameObjects = new List<GameObject>(); 
    [SerializeField]  private Transform stairs;
    [SerializeField] private Transform redBlockForStairs;
    [SerializeField] private GameObject basket;
    private CharacterController _characterController;
    private Vector3 _moveVector;
    private float _speed = 25f;
    private float _gravityForce; 
    private int _countBlock;
    private float _positionY = 7.1f;
    private float _positionZ = 52.9f;
    
    
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    private void FixedUpdate()
    {
        CharacterMove();
        GamingGravity();
    }
    private void CharacterMove()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = Input.GetAxis("Horizontal") * _speed;
        _moveVector.z = Input.GetAxis("Vertical") * _speed;
        _moveVector.y = _gravityForce;
        _characterController.Move(_moveVector * Time.fixedDeltaTime);
    }
    private void GamingGravity()
    {
        if (!_characterController.isGrounded)
        {
            _gravityForce -= 20 * Time.fixedDeltaTime;
        }
        else
        {
            _gravityForce = -4f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        float _positionZstairs = stairs.transform.position.z;
        int countBlocks = gameObjects.Count - 1;
        if (other.gameObject.CompareTag("RedBlock"))
        {  
            gameObjects.Add(other.gameObject);
            BlocksView(_countBlock,new Vector3(0,_positionY,-5f),basket.transform,4,false);
           _countBlock++;
            _positionY += redBlockForStairs.transform.localScale.z/4f;
        }
        if (other.gameObject.CompareTag("Stairs") && Input.GetKey(KeyCode.W) && gameObjects.Count>0)
            {
            _positionZstairs += redBlockForStairs.localScale.y;
                BlocksView(countBlocks, new Vector3(-23f, -3.2f, _positionZ), null, 1, true);   
                gameObjects[countBlocks].GetComponent<BoxCollider>().isTrigger = false;
                gameObjects[countBlocks].GetComponent<Rigidbody>().isKinematic = true;
                gameObjects.RemoveAt(countBlocks);
                stairs.position = new Vector3(stairs.transform.position.x, stairs.transform.position.y,
                    _positionZstairs);
                countBlocks--;
                _countBlock--;
            _positionZ += redBlockForStairs.transform.localScale.z;
                _positionY -= redBlockForStairs.transform.localScale.z / 4f;
        }

        if (other.gameObject.CompareTag("Plane2"))
        {
            _panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void BlocksView(int numberOfBlock,Vector3 position,Transform transform,int decrease,bool positionWorld)
    {
        gameObjects[numberOfBlock].transform.position = position;
        gameObjects[numberOfBlock].transform.SetParent(transform, positionWorld);
        gameObjects[numberOfBlock].transform.localScale = redBlockForStairs.localScale / decrease ;
    }
}



