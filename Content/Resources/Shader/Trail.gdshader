shader_type canvas_item;

void fragment()
{
	float t = sin(TIME);
	COLOR.rgb = vec3(t, 0.3, 0.0f);
}