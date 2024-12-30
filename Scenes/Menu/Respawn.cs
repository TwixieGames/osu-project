using Godot;
using System;

public partial class Respawn : Node2D
{
	public void Press()
	{
		GetTree().ChangeSceneToFile("res://world.tscn");
	}
}
