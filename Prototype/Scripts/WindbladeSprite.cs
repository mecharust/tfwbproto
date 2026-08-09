using Godot;
using System;

public partial class WindbladeSprite : Node2D
{
	
	private Sprite2D _HappySprite;
	private Sprite2D _OhSprite;

    

    [Export] public int Please = 20;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        // GD.Print(Please);
		_HappySprite = GetNode<Sprite2D>("HappySprite");
		_OhSprite = GetNode<Sprite2D>("OhSprite");

	
		// GD.Print(_OhSprite.VisibilityLayer);

        
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
    {
        
        
    }

    //     if (@event is InputEventKey eventKey1)
    //     {
    //         if (eventKey1.Pressed && eventKey1.Keycode == Key.Space)
    //         {
    //             Position = Position with {X = -500.0f, Y= -200.0f};
                
    //         }
    //     }



    
}
