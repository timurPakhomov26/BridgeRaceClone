
using UnityEngine;

public class InstantiateBlocks : MonoBehaviour
{  
    [SerializeField]  private Transform[] blocks;
    [SerializeField] private Vector3 cameraDistance;
    [SerializeField] private Transform _plane;
    [SerializeField] private Transform _objectsSpawnPosition;
    private Transform player;
    private float positionX;
    private float positionZ;
  
  

    
    private void Start()
    {
        player = FindObjectOfType<Hero>().transform;
        Instantiater();
    }
    private void Update()
    {
        Camera.main.transform.position = new Vector3(player.transform.position.x - cameraDistance.x,
            player.transform.position.y + cameraDistance.y, player.transform.position.z - cameraDistance.z);
    }
    private void Instantiater()
    {
        double number = 1.80d;
        for (int i = 0; i < (int)_plane.transform.localScale.x /number; i++)
        {
            InstRandom();
            for (int j = 0; j < (int)(_plane.transform.localScale.z-1) / number; j++)
            { 
                positionZ += blocks[0].transform.localScale.z * 6f;
                InstRandom();
            
            }
            positionX += blocks[0].transform.localScale.x * 6f;
            positionZ = 0;
        }
    }
    private void InstRandom()
    {
        int randomBlock = Random.Range(0, blocks.Length);
        Instantiate(blocks[randomBlock], new Vector3(_objectsSpawnPosition.position.x+positionX,
            _plane.transform.position.y+blocks[0].transform.localScale.y/2, _objectsSpawnPosition.position.z+positionZ), Quaternion.identity); 
    }
}