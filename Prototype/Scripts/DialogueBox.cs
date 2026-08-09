using Godot;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Nodes;
using System.Text.Json;

public partial class DialogueBox : PanelContainer
{
	private RichTextLabel Text;
	private int Speed = 12;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Text = GetNode<RichTextLabel>("Label/Text");
		
		
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Textwriter();
	
	}

	public async void Textwriter()
	{
		
		if(Text != null)
		{
				VisibilityLayer = 1;
				if(Text.VisibleCharacters != Text.GetTotalCharacterCount())
				{
					Text.VisibleCharacters += 1;
				}
					else
				{
					return;
				}

		}
		else
		{
			return;
		}
	}

}
