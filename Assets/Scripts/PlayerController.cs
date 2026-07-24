using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public float moveCooldown = 0.15f;

    private Vector2Int gridPos;
    private float timer;
    public Tilemap wallTilemap;
    public Tilemap treasureTilemap;
    public BagController bagController;
    public TreasureData testTreasure;

    
    void Start()
    {
        // Convert world position → grid position correctly
        gridPos = new Vector2Int(
            Mathf.FloorToInt(transform.position.x),
            Mathf.FloorToInt(transform.position.y)
        );
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer < moveCooldown)
            return;

        Vector2Int dir = Vector2Int.zero;

        if (Input.GetKeyDown(KeyCode.W)) dir = Vector2Int.up;
        if (Input.GetKeyDown(KeyCode.S)) dir = Vector2Int.down;
        if (Input.GetKeyDown(KeyCode.A)) dir = Vector2Int.left;
        if (Input.GetKeyDown(KeyCode.D)) dir = Vector2Int.right;

        if (dir != Vector2Int.zero)
        {
            Vector2Int target = gridPos + dir;

            Vector3Int targetCell = new Vector3Int(target.x, target.y, 0);

            // If there's a wall, cancel movement
            if (wallTilemap.GetTile(targetCell) != null)
            {
                return;
            }
            
            //move player
            gridPos = target;
            transform.position = new Vector3(gridPos.x + 0.5f, gridPos.y + 0.5f, 0f);
            
             // treasure check (after move)
            Vector3Int currentCell = new Vector3Int(gridPos.x, gridPos.y, 0);

            Debug.Log($"Checking {currentCell}, HasTile = {treasureTilemap.HasTile(currentCell)}");
            Debug.Log("Treasure Tilemap assigned? " + (treasureTilemap != null));
            
            if (treasureTilemap != null && treasureTilemap.HasTile(currentCell))
{
                bool added = bagController.AddItem(testTreasure);

                if (added)
                {
                    treasureTilemap.SetTile(currentCell, null);
                    Debug.Log("Added Ruby to the bag");
                }
}
            //cooldown reset
            timer = 0f;
        }
    }
}