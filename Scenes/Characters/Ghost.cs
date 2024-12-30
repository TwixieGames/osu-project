using Godot;
using System;

public partial class Ghost : Enemy
{
	
	public override void _Ready()
	{
	}

	
	public override void _Process(double delta)
	{
		Movement();
		Velocity = velocity;
		MoveAndSlide();
	}
	
	
}
