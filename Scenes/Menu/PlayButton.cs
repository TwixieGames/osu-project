using Godot;
using System;

public partial class PlayButton : Button
{
	public void onPressed()
	{
		GD.Print("Clicked");
		GetTree().ChangeSceneToFile("res://world.tscn");
	}
}
