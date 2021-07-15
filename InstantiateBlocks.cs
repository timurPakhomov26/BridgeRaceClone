
using UnityEngine;

public class InstantiateBlocks : MonoBehaviour
{
    [SerializeField]  private Transform[] blocks;
   [SerializeField] private Vector3 cameraDistance = new Vector3(15, 86, 22);
    private Transform player;
    private int _blockCountX=11;
    private int _blockCountZ=5;
    private const float InstPositionOnY = 1.51f;
    private float positionX = -92f;
    private  float positionZ = -43f;
    
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
        for (int i = 0; i < _blockCountX; i++)
        {
            InstRandom();
            for (int j = 0; j < _blockCountZ; j++)
            {
                    positionZ += 17;
                InstRandom();
            
            }
            positionX += 14;
            positionZ = -43;
        }
    }
    private void InstRandom()
    {
        int randomA = Random.Range(0, blocks.Length);
        Instantiate(blocks[randomA], new Vector3(positionX, InstPositionOnY, positionZ), Quaternion.identity); 
    }
}