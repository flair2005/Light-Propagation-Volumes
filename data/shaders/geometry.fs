#version 130
precision lowp float;

in vec3 positionWorld;
in vec3 normal;
in vec2 texCoord;
in vec4 color;
//in mat3 mtbnt;

uniform mat3 mwnit;
uniform vec3 cam;

uniform sampler2D difTex;
uniform sampler2D norTex;

uniform int type;

/*uniform vec3 lightPos;
uniform vec2 lightRange;
uniform vec3 lightColor;*/

out vec4 glFragColor;
out vec4 glFragColorPos;
out vec4 glFragColorNormal;
out float glFragColorDepth;

void main()
{
  vec4 fragDif = texture(difTex, texCoord);

  if(((type & 0x20000000) != 0) && (fragDif.a < 0.8))
    discard;

  //vec3 viewDir = normalize(cam - positionWorld);
  vec3 normalDir = normalize(mwnit * normalize(normal));
  /*vec3 lightDir = lightPos - positionWorld;

  float lightDist = clamp((length(lightDir) - lightRange.x) / (lightRange.y - lightRange.x) * -1.0 + 1.0, 0.0, 1.0);
  lightDir = normalize(lightDir);
  float lightDot = max(0.0, dot(normalDir, lightDir));

  vec3 colorDif = lightColor * lightDot * lightDist;*/

  glFragColor = vec4(fragDif.rgb * color.rgb/* * colorDif*/, 1.0);
  glFragColorPos = vec4(positionWorld, 1.0);
  glFragColorNormal = vec4(normalDir, 1.0); //vec4(mtbnt * normalize(texture(norTex, texCoord).rgb), 1.0);
  glFragColorDepth = gl_FragCoord.z;
}