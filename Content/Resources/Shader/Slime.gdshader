shader_type canvas_item;

#define C(x) sin(x) * 0.5 + 0.5

group_uniforms Slime;
uniform vec2 resolution = vec2(512.0, 512.0);
uniform int octaves: hint_range(1, 10, 1) = 5;
uniform float speed: hint_range(0.1, 4.0, 0.1) = 1.0;
uniform float frequency:hint_range(0.1, 10.0, 0.1) = 1.0;
uniform float amplitude:hint_range(0.1, 10.0, 0.1) = 1.0;
uniform float time_shift:hint_range(0.1, 10.0, 0.1) = 1.0;
uniform float zoom:hint_range(0.1, 20.0, 0.1) = 5.0;

uniform sampler2D screen_texture : hint_screen_texture;

vec2 warp(vec2 uv, float time){
	float f = frequency;
	float a = amplitude;
	float t = time_shift;
	for (int s = 0; s < octaves; s++){
		uv += vec2(sin(uv.y * f + time * t), cos(uv.x * f + time*t)) / a;
		f*= 1.9;
		t*0.9;
		a*=2.0;
	}
	return uv;
}

void fragment() {
	float time = TIME * speed;
	vec2 uv = UV - 0.5;
	uv.x *= resolution.x / resolution.y;
	uv *= zoom;
	uv = warp(uv, time);

	float r = C(uv.x  + time);
	float g = C(uv.y - time);
	float b = C(uv.x * uv.y + C(time * 0.5));

	vec3 color = vec3(r, g, b);
	vec4 screen_color = texture(screen_texture, SCREEN_UV);
	color = mix(screen_color.rgb, color, 1.2);
	uv = UV - 0.5f;

    float a = 1.0f;

	COLOR = vec4(color, a);
}
