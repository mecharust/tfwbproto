using Godot;
using System;

public partial class Namebox : PanelContainer
{
	// Called when the node enters the scene tree for the first time.

	private RichTextLabel NamePlate;
	public override void _Ready()
	{
		NamePlate = GetNode<RichTextLabel>("Label2/NamePlate");
		BoxVisibility();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public async void BoxVisibility()
	{
		
		if(NamePlate != null)
		{
				VisibilityLayer = 1;

		}
		else
		{
			VisibilityLayer = 0;
		}
	}
}
