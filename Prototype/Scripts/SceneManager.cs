using Godot;
using System;
using System.Security.Cryptography;
using System.Collections.Generic;


public partial class SceneManager : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
    {
        int x = 20;

		GD.Print(x);
	
		int y = 15; 

        if (x < y)
        {
			
            AddTestScene();
	
        }
    }

	public void AddTestScene()
    {
        GetTree().CallDeferred("change_scene_to_file", "res://Scenes/test.tscn");
    }

    public void SwitchScene()
    {
        GetTree().ChangeSceneToFile("res://Scenes/test.tscn");
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

     public override void _UnhandledInput(InputEvent @event)
    {
        base._UnhandledInput(@event);

        if (@event is InputEventKey eventKey)
        {
            if (eventKey.Pressed && eventKey.Keycode == Key.Enter)
            {
                SwitchScene();
            }
        }
    }


}
