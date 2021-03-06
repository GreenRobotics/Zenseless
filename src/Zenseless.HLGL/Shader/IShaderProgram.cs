﻿namespace Zenseless.HLGL
{
	using System;
	using System.Numerics;

	/// <summary>
	/// Enumeration of valid shader types
	/// </summary>
	public enum ShaderType
	{
		/// <summary>
		/// The fragment shader
		/// </summary>
		FragmentShader,
		/// <summary>
		/// The vertex shader
		/// </summary>
		VertexShader,
		/// <summary>
		/// The geometry shader
		/// </summary>
		GeometryShader,
		/// <summary>
		/// The tessellation evaluation shader
		/// </summary>
		TessEvaluationShader,
		/// <summary>
		/// The tessellation control shader
		/// </summary>
		TessControlShader,
		/// <summary>
		/// The compute shader
		/// </summary>
		ComputeShader
	}

	/// <summary>
	/// Enumeration of valid shader resource types
	/// </summary>
	public enum ShaderResourceType
	{
		/// <summary>
		/// The uniform
		/// </summary>
		Uniform,
		/// <summary>
		/// The attribute
		/// </summary>
		Attribute,
		/// <summary>
		/// The uniform buffer
		/// </summary>
		UniformBuffer,
		/// <summary>
		/// The rw buffer
		/// </summary>
		RWBuffer
	}

	/// <summary>
	/// Interface of a shader program
	/// </summary>
	/// <seealso cref="IDisposable" />
	public interface IShaderProgram : IDisposable
	{
		/// <summary>
		/// Gets the program identifier.
		/// </summary>
		/// <value>
		/// The program identifier.
		/// </value>
		int ProgramID { get; }

		/// <summary>
		/// Activates this instance.
		/// </summary>
		void Activate();
		
		/// <summary>
		/// Deactivates this instance.
		/// </summary>
		void Deactivate();
		
		/// <summary>
		/// Gets the resource location.
		/// </summary>
		/// <param name="resourceType">Type of the resource.</param>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		int GetResourceLocation(ShaderResourceType resourceType, string name);

		/// <summary>
		/// Set int Uniform on active shader.
		/// </summary>
		/// <param name="name">The uniform variable name.</param>
		/// <param name="value">The value to set.</param>
		void Uniform(string name, int value);

		/// <summary>
		/// Set float Uniform on active shader.
		/// </summary>
		/// <param name="name">The uniform variable name.</param>
		/// <param name="value">The value to set.</param>
		void Uniform(string name, float value);

		/// <summary>
		/// Set Vector2 Uniform on active shader.
		/// </summary>
		/// <param name="name">The uniform variable name.</param>
		/// <param name="vector">The vector.</param>
		void Uniform(string name, in Vector2 vector);

		/// <summary>
		/// Set Vector3 Uniform on active shader.
		/// </summary>
		/// <param name="name">The uniform variable name.</param>
		/// <param name="vector">The vector.</param>
		void Uniform(string name, in Vector3 vector);

		/// <summary>
		/// Set Vector4 Uniform on active shader.
		/// </summary>
		/// <param name="name">The uniform variable name.</param>
		/// <param name="vector">The vector.</param>
		void Uniform(string name, in Vector4 vector);

		/// <summary>
		/// Set matrix uniforms on active shader.
		/// </summary>
		/// <param name="name">The uniform variable name.</param>
		/// <param name="matrix">The input matrix.</param>
		/// <param name="transpose">if set to <c>true</c> the matrix is transposed.</param>
		void Uniform(string name, in Matrix4x4 matrix, bool transpose = false);
	}
}