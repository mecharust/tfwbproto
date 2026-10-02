using Godot;
using System;
using System.Dynamic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;


public partial class Test : Node2D
{   
    
    private Node2D TestSprite;
    private Node2D TestSpriteArmtest;
    private Control DialogueUI;
    private RichTextLabel Text;
    public TestSpriteOptimus TestingSprites;
    [Export]
    public DialogueManager Testing;
    public string callID;

    

    // private const int Speed = 320;
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        TestSprite = GetNode<Node2D>("Character/TestSpriteOptimus");
        DialogueUI = GetNode<Control>("Character/DialogueManager/DialogueUI");
        Text = GetNode<RichTextLabel>("Character/DialogueManager/DialogueUI/DialogueBox/Label/Text");
        TestingSprites = GetNode<TestSpriteOptimus>("Character/TestSpriteOptimus");
        
        TimeTest();
        
        
        // TestingSprites.Call("OpSprites");
        
        
        TestSprite.Position = Position with { X = 100.0f, Y = 700.0f} ;
        TestSprite.Scale = Scale with {X = 0.5f, Y = 0.5f};

        // DialogueUI.Position = Position with {X = -1.0f, Y = 1.0f};
        // DialogueUI.Scale = Scale with {X = 1153.0f, Y = 653.0f};
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
    {
        callingID();
        SpriteControl();   
    }

    public void SpriteControl()
    {
        if(callID != null && TestSprite.Visible && callID.Contains("1."))
        {


            TestingSprites.Call("OpSprites");
            GD.Print("test");
            // GD.Print(callID);
        }
        else
        {
            GD.Print("OFF");
            TestingSprites.Call("OpSprites");
            GD.Print(callID);
            
        }
    }
    public void callingID()
    {
        callID = Testing.CurrentBlock["ID"];
    }

    IDCheckerHandler SpriteCall = (string callID) =>
    {
       
    };

    public delegate void IDCheckerHandler (string callID);
    public event IDCheckerHandler IDChecker;

    public async void TimeTest()
    {
    
        await ToSignal(GetTree().CreateTimer(1.5), "timeout");
        
        

        DialogueUI.Visible = true;
        
        Testing.Call("StartText");
        
        // callingID();

        

        if(callID.Contains("1."))
        {
            GD.Print("It worked");
        }
        else
        {
            GD.Print("Try again doodo");
        }
        

    }

 


     public override void _UnhandledInput(InputEvent @event)
    {
		

        base._UnhandledInput(@event);

        if (@event is InputEventKey eventKey)
        {
            if (eventKey.Pressed && eventKey.Keycode == Key.A)
            {
        
            }
        }
	}

}
