using Godot;
using System;
using System.Data.Common;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

public partial class TestSpriteOptimus : Node2D
{

	private Sprite2D ArmRightUp;
	private Sprite2D ArmRightLow;
	private Sprite2D LeftArmUp;
	private Sprite2D  LeftArmLow;
	private Sprite2D  ExpressionNeutralPoseBase;
	private Sprite2D PoseBase;

	[Export]
	public DialogueManager spritetesting;
	
	public string id ;
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}


	public void OpSprites()
	{
		ArmRightUp = GetNode<Sprite2D>("OpTestSpriteArmRightUp");
		ArmRightLow = GetNode<Sprite2D>("OpTestSpriteArmRightLow");
		LeftArmUp = GetNode<Sprite2D>("OpTestSpriteArmLeftUp");
		LeftArmLow = GetNode<Sprite2D >("OpTestSpriteArmLeftLow");

		id = spritetesting.CurrentBlock["ID"];
		
		// GD.Print(id);
		
		switch(id) // Requires Testing, Ideally we can use switch cases to change sprites during Dialogue.
		{
			case null:
				GD.Print("Is Null");
			break;
			case "1.1":
				ArmRightUp.Visible = false;
				ArmRightLow.Visible = true;
				LeftArmUp.Visible = false;
				LeftArmLow.Visible = true;
			break;

			case "1.2":
				ArmRightUp.Visible = true;
				ArmRightLow.Visible = false;
				LeftArmUp.Visible = true;
				LeftArmLow.Visible = false;
			break;

			case "1.3":
				ArmRightUp.Visible = true;
				ArmRightLow.Visible = false;
				LeftArmUp.Visible = false;
				LeftArmLow.Visible = true;
			break;

			case "1.4":
				ArmRightUp.Visible = false;
				ArmRightLow.Visible = true;
				LeftArmUp.Visible = true;
				LeftArmLow.Visible = false;
			break;
			default:
				GD.Print("Broke");
			break;
		}
		

	

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
}
