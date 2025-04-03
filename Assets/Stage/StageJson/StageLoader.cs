using UnityEngine;
using System.IO;



public class StageLoader : MonoBehaviour
    {
    public GameObject wallPrefab; // 3Dの壁Prefab
    public GameObject floorPrefab; // 3Dの床Prefab
    public GameObject mirrorPrefabSmall; // 小さなミラー
    public GameObject mirrorPrefabLarge; // 大きなミラー
    public GameObject playerPrefab; // プレイヤーPrefab
    public GameObject enemyPrefab; // エネミーPrefab

    void Start()
        {
        LoadStage("TutorialStage.json");
        }

    void LoadStage(string fileName)
        {
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        if (File.Exists(filePath))
            {
            string json = File.ReadAllText(filePath);
            StageData stageData = JsonUtility.FromJson<StageData>(json);

            for (int y = 0; y < stageData.height; y++)
                {
                for (int x = 0; x < stageData.width; x++)
                    {
                    int tile = stageData.layout[y, x];
                    Vector3 position = new Vector3(x, 0, y); // x, y, z で位置を設定

                    switch (tile)
                        {
                        case 0: // Wall
                            Instantiate(wallPrefab, position, Quaternion.identity);
                            break;
                        case 1: // Floor
                            Instantiate(floorPrefab, position, Quaternion.identity);
                            break;
                        case 2: // Mirror (Small or Large)
                            // ランダムに小さなミラーか大きなミラーを選択
                            if (Random.Range(0, 2) == 0)
                                {
                                Instantiate(mirrorPrefabSmall, position, Quaternion.identity);
                                }
                            else
                                {
                                Instantiate(mirrorPrefabLarge, position, Quaternion.identity);
                                }
                            break;
                        case 3: // Player
                            Instantiate(playerPrefab, position, Quaternion.identity);
                            break;
                        case 4: // Enemy
                            Instantiate(enemyPrefab, position, Quaternion.identity);
                            break;
                        }
                    }
                }
            }
        else
            {
            Debug.LogError("Stage file not found: " + fileName);
            }
        }
    }
