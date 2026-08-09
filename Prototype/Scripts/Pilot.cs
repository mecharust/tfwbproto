using Godot;
using System;

public partial class Pilot : Node2D
{
	private Node2D TestSprite;
    private Node2D TestSpriteArmtest;
    private Control DialogueUI;
    private RichTextLabel Text;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		TestSprite = GetNode<Node2D>("Character/TestSpriteOptimus");
        DialogueUI = GetNode<Control>("Character/DialogueManager/DialogueUI");
        Text = GetNode<RichTextLabel>("Character/DialogueManager/DialogueUI/DialogueBox/Label/Text");

        var Testing = GetNode<DialogueManager>("Character/DialogueManager");
        Testing.Call("StartText");
        
        
        TestSprite.Position = Position with { X = 100.0f, Y = 700.0f} ;
        TestSprite.Scale = Scale with {X = 0.5f, Y = 0.5f};
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var TestingSprites = GetNode<TestSpriteOptimus>("Character/TestSpriteOptimus");
        TestingSprites.Call("OpSprites");
	}
}
