using UnityEngine;
using ProceduralDungeon.Infrastructure;
using ProceduralDungeon.UseCases;
using System.Collections.Generic;
using Zenject;

[ExecuteAlways]
public class DungeonDebugDrawer : MonoBehaviour
{
    [SerializeField] private int seed = 42;
    [SerializeField] private Color roomColor = new(0f, 1f, 0f, 0.3f);

    private GenerateDungeonUseCase _useCase;
    private List<DungeonGenerator.Room> _rooms;

    [Inject]
    public void Construct(GenerateDungeonUseCase useCase)
    {
        _useCase = useCase;
        _rooms   = _useCase.Execute(seed);
        Debug.Log(_rooms.Count);
    }
    
#if UNITY_EDITOR
    private void OnValidate()
    {
        if (!UnityEditor.EditorApplication.isPlaying && _useCase == null)
        {
            var gen = new DungeonGenerator();
            var tmpUseCase = new GenerateDungeonUseCase(gen);
            _rooms = tmpUseCase.Execute(seed);
        }
    }
#endif

    private void OnDrawGizmos()
    {
        if (_rooms == null) return;
        Gizmos.color = roomColor;
        foreach (var r in _rooms)
        {
            var center = new Vector3(r.rect.center.x, 0, r.rect.center.y);
            var size   = new Vector3(r.rect.size.x, 5, r.rect.size.y);
            Gizmos.DrawCube(center, size);
            Gizmos.color = Color.black;
            Gizmos.DrawWireCube(center, size);
            Gizmos.color = roomColor;
        }
    }
}
