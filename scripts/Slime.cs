using Godot;
using System;

public partial class Slime : Node2D
{
	[Export]
	public float Speed = 50f;
	private Vector2 _direction = Vector2.Right;

	private RayCast2D _leftRay;
	private RayCast2D _rightRay;

	public override void _Ready()
	{
		_leftRay = GetNode<RayCast2D>("LeftRay");
		_rightRay = GetNode<RayCast2D>("RightRay");
	}

	public override void _Process(double delta)
	{
		// Mover al slime
		Position += Speed * (float)delta * _direction;

		// Verificar colisión con paredes
		if (_direction == Vector2.Right && _rightRay.IsColliding())
		{
			_direction = Vector2.Left;
		}
		else if (_direction == Vector2.Left && _leftRay.IsColliding())
		{
			_direction = Vector2.Right;
		}
	}
	
}
