using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessTerrain : MonoBehaviour
{
    public const float MAXViewDst = 500;
    public Transform viewer;
    
    public static Vector2 ViewerPosition;
    int _chunkSize; 
    int _chunksVisibleInViewDst;
    
    Dictionary<Vector2, TerrainChunk> terrainChunkDictionary = new Dictionary<Vector2, TerrainChunk>();
    List<TerrainChunk> terrainChunksVisibleLastUpdate = new List<TerrainChunk>();

    private void Start()
    {
        _chunkSize = MapGenerator.mapChunkSize;
        _chunksVisibleInViewDst = Mathf.RoundToInt(MAXViewDst / _chunkSize);
    }

    private void Update()
    {
        var position = viewer.position;
        ViewerPosition = new Vector2(position.x, position.z);
        UpdateVisibleChunks();
    }

    void UpdateVisibleChunks()
    {
        for (int i = 0; i < terrainChunksVisibleLastUpdate.Count; i++)
        {
            terrainChunksVisibleLastUpdate[i].SetVisible(false);
        }
        terrainChunksVisibleLastUpdate.Clear();
            
        int currentChunkCoordX = Mathf.RoundToInt(ViewerPosition.x / _chunkSize);
        int currentChunkCoordY = Mathf.RoundToInt(ViewerPosition.y / _chunkSize);

        for (int yOffset = -_chunksVisibleInViewDst; yOffset <= _chunksVisibleInViewDst; yOffset++)
        {
            for (int xOffset = -_chunksVisibleInViewDst; xOffset <= _chunksVisibleInViewDst; xOffset++)
            {
                Vector2 viewedChunkCoord = new Vector2(currentChunkCoordX + xOffset, currentChunkCoordY + yOffset);

                if (terrainChunkDictionary.ContainsKey(viewedChunkCoord))
                {
                    terrainChunkDictionary[viewedChunkCoord].UpdateTerrainChunk();
                    if (terrainChunkDictionary[viewedChunkCoord].IsVisible())
                    {
                        terrainChunksVisibleLastUpdate.Add(terrainChunkDictionary[viewedChunkCoord]);
                    }
                }
                else
                {
                    terrainChunkDictionary.Add(viewedChunkCoord, new TerrainChunk(viewedChunkCoord, _chunkSize, transform));
                }
            }
        }
    }

    public class TerrainChunk
    {
        GameObject meshObject;
        Vector2 position;
        Bounds _bounds;
        public TerrainChunk(Vector2 coord, int size, Transform parent)
        {
            position = coord * size;
            _bounds = new Bounds(position, Vector2.one * size);
            Vector3 positionV3 = new Vector3(position.x, 0, position.y);

            meshObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
            meshObject.transform.position = positionV3;
            meshObject.transform.localScale = Vector3.one * size/ 10f;
            meshObject.transform.parent = parent;
            SetVisible(false);
        }

        public void UpdateTerrainChunk()
        {
            float viewerDstFromNearestEdge = Mathf.Sqrt(_bounds.SqrDistance(ViewerPosition));
            bool visible = viewerDstFromNearestEdge <= MAXViewDst;
            SetVisible(visible);
        }

        public void SetVisible(bool visisble)
        {
            meshObject.SetActive(visisble);
        }

        public bool IsVisible()
        {
            return meshObject.activeSelf;
        }
        
    }
}
