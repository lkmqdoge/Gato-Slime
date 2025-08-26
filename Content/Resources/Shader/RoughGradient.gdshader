shader_type canvas_item;

#define C(x) sin(x) * 0.5 + 0.5

uniform float speed : hint_range(0.01f, 256.0f, 0.01f) = 1.0f;
uniform int steps : hint_range(2, 256) = 8;
uniform vec4 color_a : source_color = vec4(1.0, 0.0, 0.0, 1.0);
uniform vec4 color_b : source_color = vec4(0.0, 0.0, 1.0, 1.0);

void fragment() {
	vec2 uv = UV;
	float time = TIME * speed;

	uv += sin(uv + time );

	float k = uv.x + uv.y;
	float t = floor(k * float(steps)) / float(steps);
	vec4 color = mix(color_a, color_b, t);

	COLOR = color;
}
