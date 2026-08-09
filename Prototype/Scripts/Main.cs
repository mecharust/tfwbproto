using Godot;
using System;
using System.Xml.Resolvers;

public partial class Main : Node
{

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

        int SceneID = 2;

        if (SceneID == 1)
        {
            var scene = GD.Load<PackedScene>("res://Scenes/pilot.tscn");
            var instance = scene.Instantiate();
            AddChild(instance);
        }
        else
        {
            var scene = GD.Load<PackedScene>("res://Scenes/test.tscn");
            var instance = scene.Instantiate();
            AddChild(instance);
        }

    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
