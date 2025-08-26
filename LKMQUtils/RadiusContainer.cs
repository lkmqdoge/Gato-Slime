using System;
using Godot;

namespace LKMQUtils;

public enum RadiusContainerLayoutMode
{
	Centered,
	Flat,
}

[Tool]
[GlobalClass]
public partial class RadiusContainer : Container
{
	
	[Export(PropertyHint.Range, "-360.0f,360.0f,radians_as_degrees")] 
	public float Arc { 
		get
		{
			return _arc;
		}
		set
		{
			_arc = value;
			QueueSort();
		}
	}

	[Export] 
	public float Radius
	{
		get
		{
			return _radius;
		}
		set
		{
			_radius = value;
			QueueSort();
		}
	}

	[Export] 
	public bool AlignChildrenCenter
	{
		get
		{
			return _alignChildrenCenter;
		}
		set
		{
			_alignChildrenCenter = value;
			QueueSort();
		}
	}

	[Export] 
	public bool Fit
	{
		get
		{
			return _fit;
		}
		set
		{
			_fit = value;
			QueueSort();
		}
	}

	[Export] 
	public RadiusContainerLayoutMode RadiusContainerLayoutMode
	{
		get
		{
			return _radiusContainerLayoutMode;
		}
		set
		{
			_radiusContainerLayoutMode = value;
			QueueSort();
		}
	}

	private float _arc = (float)Math.PI*2;
	private float _radius = 0.0f;

	private RadiusContainerLayoutMode _radiusContainerLayoutMode = RadiusContainerLayoutMode.Flat;
	private bool _alignChildrenCenter = false;
	private bool _fit = false;

    public override void _Notification(int what)
    {
		if(what == NotificationSortChildren)
		{
			UpdateChildrenPosition();
		}
		base._Notification(what);
    }

	private void UpdateChildrenPosition()
	{
		Vector2 center = Size/2;

		foreach(var child in GetChildren())
		{
			if (child is Control)
			{
				Control controlChild = child as Control;
				switch(_radiusContainerLayoutMode)
				{
					case RadiusContainerLayoutMode.Centered:
						controlChild.Position = center + Vector2.Up.Rotated((child.GetIndex()+1) * (_arc/(GetChildCount()+1))) * _radius;
					break;
					case RadiusContainerLayoutMode.Flat:
						controlChild.Position = center + Vector2.Up.Rotated(child.GetIndex() * _arc/GetChildCount()) * _radius;
					break;
				}

				if (_alignChildrenCenter)
					controlChild.Position -= controlChild.Size/2;
				
				if (_fit)
					FitChildInContainer(controlChild);
			}
		}
	}

	private void FitChildInContainer(Control child)
	{
		if (child.Position.X<0)
		{
			child.Position = new Vector2(0, child.Position.Y);
		}
		else if (child.Position.X+child.Size.X>Size.X)
		{
			child.Position = new Vector2(Size.X - child.Size.X, child.Position.Y);
		}

		if (child.Position.Y<0)
		{
			child.Position = new Vector2(child.Position.X, 0);
		}
		else if (child.Position.Y+child.Size.Y>Size.Y)
		{
			child.Position = new Vector2(child.Position.X, Size.Y - child.Size.Y);
		}
	}
}
