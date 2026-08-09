using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Nodes;
using System.Data.Common;

//Functional Dialogue (DONE)
//Make it work with Sprite changes + Animarted Sprites & CGS

public partial class DialogueManager : Control
{
	[Export]
	public RichTextLabel NP {get; set;}
	[Export]
	public RichTextLabel Txt {get; set;}

	[Export(PropertyHint.File, "*.json")]
	public string txtfile {get; set;}


	public Control DialogueUI;

	public Dictionary<string, object> Scriptcontent {get; set;} //Dictionary of our Script


	// public Dictionary<string, object> CurrentBlock  {get; set;} //Dicitonary of the current block

	public dynamic CurrentBlock {get; set;}
	public dynamic NextBlock {get; set;}
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		DialogueUI = GetNode<Control>("DialogueUI");

	}

	public void StartText()
	{	
		CreateDictionary(txtfile);
		
		LoadBlock(CurrentBlock);


		// GD.Print(CurrentBlock);

		GD.Print(CurrentBlock["ID"]);

		// GD.Print("Hey");
	}


	public void CreateDictionary (string path)
	{

		var json = FileAccess.Open(path, FileAccess.ModeFlags.Read);
		var testing = json.GetAsText();
		// var o = JObject.Parse(testing); // <- parsing individually, not needed here
		

		Scriptcontent  = JsonConvert.DeserializeObject<Dictionary<string, object>>(testing); //parse into dictionary
		
		CurrentBlock = Scriptcontent["Start"]; //read the "start" block in the json File

		  
	}

	public void LoadBlock (dynamic block)
	{
		
		if (block.ContainsKey("Character")) //check if its Character Dialogue or Narrator Dialogue
		{
			NP.Text = block["Character"]?.ToString(); //Puts the Characters Name in the text box
				
			if(block.ContainsKey("Text"))
			{
				Txt.Text = block["Text"]?.ToString(); //puts the dialogue in the text box
			}
		}
		else
		{
			GD.Print("wrong Key"); //Narrator Dialogue check comes here.
		}

		if(block.ContainsKey("Next")) //checking if the dialogue continues.
		{
			Txt.VisibleCharacters = 0;
			string key = block["Next"];
			NextBlock = Scriptcontent[key];
		}
		else
		{
			Txt.VisibleCharacters = 0;
			if(block.ContainsKey("End"))
			{
				NextBlock = Scriptcontent["Start"]; //Placeholder endless loop
			}
		}
	}


	public void NextScene() //moves to next scene
	{
		CurrentBlock = NextBlock;
		LoadBlock(CurrentBlock);
	}
	
   public override void _UnhandledInput(InputEvent @event)
    {
		

        base._UnhandledInput(@event);

        if (@event is InputEventKey eventKey)
        {
            if (eventKey.Pressed && eventKey.Keycode == Key.Enter)
            {
            	NextScene();
            }
        }
	}
		
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
}
