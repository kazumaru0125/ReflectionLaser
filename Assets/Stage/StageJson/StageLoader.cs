using UnityEngine;
using System.IO;



public class StageLoader : MonoBehaviour
    {
    public GameObject wallPrefab; // 3D�̕�Prefab
    public GameObject floorPrefab; // 3D�̏�Prefab
    public GameObject mirrorPrefabSmall; // �����ȃ~���[
    public GameObject mirrorPrefabLarge; // �傫�ȃ~���[
    public GameObject playerPrefab; // �v���C���[Prefab
    public GameObject enemyPrefab; // �G�l�~�[Prefab

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
                    Vector3 position = new Vector3(x, 0, y); // x, y, z �ňʒu��ݒ�

                    switch (tile)
                        {
                        case 0: // Wall
                            Instantiate(wallPrefab, position, Quaternion.identity);
                            break;
                        case 1: // Floor
                            Instantiate(floorPrefab, position, Quaternion.identity);
                            break;
                        case 2: // Mirror (Small or Large)
                            // �����_���ɏ����ȃ~���[���傫�ȃ~���[��I��
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
