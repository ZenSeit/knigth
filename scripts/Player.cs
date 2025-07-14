using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 130.0f;
	public const float JumpVelocity = -300.0f;
	private AnimatedSprite2D _animatedSprite;

	public override void _Ready()
	{
		// Obtén referencia al sprite animado
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;

		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
		UpdateAnimation(velocity);

	}

	private void UpdateAnimation(Vector2 velocity)
	{
		if (!IsOnFloor())
		{
			_animatedSprite.Play("jump");
		}
		else if (Mathf.Abs(velocity.X) > 10)
		{
			_animatedSprite.Play("run");

			// Flip sprite según dirección
			_animatedSprite.FlipH = velocity.X < 0;
		}
		else
		{
			_animatedSprite.Play("idle");
		}
	}
}
