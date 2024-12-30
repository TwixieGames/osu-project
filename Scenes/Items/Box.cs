using Godot;
using System;

public partial class Box : RigidBody2D
{
	Vector2 velocity;

	public override void _Process(double delta)
	{

	}
	public void MouseTouch()
	{
		GD.Print("Dont Touch!");
	}
}
