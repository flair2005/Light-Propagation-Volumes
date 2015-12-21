#version 130
precision lowp float;

in vec3 vertexPosition;
in vec3 vertexNormal;
in vec2 vertexTexCoord;
in vec4 vertexColor;

uniform mat4 mw;
uniform mat4 mvp;
uniform mat4 mvpdb;

out vec3 positionWorld;
out vec3 normal;
out vec2 texCoord;
out vec4 color;
out vec3 depthCoord;

void main()
{
  positionWorld = vec4(mw * vec4(vertexPosition, 1.0)).xyz;
  normal = vertexNormal;
  texCoord = vertexTexCoord;
  color = vertexColor;
  depthCoord = vec4(mvpdb * vec4(vertexPosition, 1.0)).xyz * 0.5 + 0.5;
  gl_Position = mvp * vec4(vertexPosition, 1.0);
}