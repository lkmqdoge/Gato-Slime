using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

namespace GatoSlime.Game.World;

[GlobalClass]
public partial class WorldGenerator : Node2D
{
    [Export]
    public bool Enable = true;

    [Export]
    public int TotalHeight = 10;

    [Export]
    public int Seed { get; set; } = 0;

    private const int TileSize = 16;

    private const string RoomSourcePath = "res://Content/Resources/Room/";

    private List<RoomData> _roomDatas;

    public override void _Ready()
    {
        base._Ready();

        if (!Enable)
            return;

        _roomDatas = LoadRoomDatas();
        Generate();
    }

    public List<RoomData> LoadRoomDatas()
    {
        var datas = new List<RoomData>();

        var files = DirAccess.GetFilesAt(RoomSourcePath);
        foreach (var filename in files)
        {
            var combinedPath = RoomSourcePath + filename;
            var roomData = ResourceLoader.Load<RoomData>(combinedPath);
            datas.Add(roomData);
        }

        return datas;
    }

    public void Generate()
    {
        var generated = new RoomData[TotalHeight];
        var r = new Random(Seed == 0 ? Guid.NewGuid().GetHashCode() : Seed);
        var startRooms = _roomDatas.Where((data) => data.Tags.Contains("start"));

        generated[0] = startRooms.ElementAt(r.Next(0, startRooms.Count()));

        var normalRooms = _roomDatas.Where((data) => data.Tags.Contains("normal"));
        for (int i = 1; i < TotalHeight; i++)
        {
            generated[i] = normalRooms.ElementAt(r.Next(0, normalRooms.Count()));
        }
        for (int i = 0; i < TotalHeight; i++)
            AddRoom(i, generated[i]);
    }

    private void AddRoom(int id, RoomData roomData)
    {
        var targetPosition = Vector2.Up * id * roomData.Height * TileSize;
        var roomScenePacked = ResourceLoader.Load<PackedScene>(roomData.SourcePath);
        var roomSceneInstance = roomScenePacked.Instantiate<Node2D>();

        roomSceneInstance.GlobalPosition = targetPosition;

        AddChild(roomSceneInstance);
    }
}
