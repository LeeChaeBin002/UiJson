using UnityEngine;

public class SpawnRandomShapes : MonoBehaviour
{
    public GameObject[] shapePrefabs;   // 미리 만든 shape 프리팹

    [Range(1, 20)] public int maxCount = 10; // 한 번에 최대 생성 갯수

    // 버튼에서 호출할 함수
    public void SpawnRandomCubes()
    {
        // 기존 Shape 삭제
        var oldShapes = GameObject.FindGameObjectsWithTag("Shape");
        foreach (var s in oldShapes) Destroy(s);

        int count = UnityEngine.Random.Range(3, 10);
        for (int i = 0; i < count; i++)
        {
            int prefabIndex = UnityEngine.Random.Range(0, shapePrefabs.Length);
            GameObject prefab = shapePrefabs[prefabIndex];

            Vector3 pos = new Vector3(
                UnityEngine.Random.Range(-5f, 5f),
                UnityEngine.Random.Range(0f, 3f),
                UnityEngine.Random.Range(-5f, 5f)
            );

            Quaternion rot = Quaternion.Euler(
                UnityEngine.Random.Range(0f, 360f),
                UnityEngine.Random.Range(0f, 360f),
                UnityEngine.Random.Range(0f, 360f)
            );

            GameObject shape = Instantiate(prefab, pos, rot);
            shape.tag = "Shape";

            shape.transform.localScale = Vector3.one * UnityEngine.Random.Range(0.5f, 2f);

            var rend = shape.GetComponent<Renderer>();
            if (rend != null)
                rend.material.color = new Color(UnityEngine.Random.value,
                                                UnityEngine.Random.value,
                                                UnityEngine.Random.value);
        }

        Debug.Log("Spawned shapes: " + count);
    }
}
